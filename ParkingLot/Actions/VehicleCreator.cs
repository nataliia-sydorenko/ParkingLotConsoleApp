using System;
using System.Linq;
using System.Threading;

namespace ParkingLot
{
    /// <summary>
    /// The class contains methods for parking vehicle.
    /// </summary>
    internal class VehicleCreator
    {
        private TimerCallback tm;
        private Timer timer;

        /// <summary>
        /// Create new object of vehicle.
        /// </summary>
        /// <returns>Returns created object of vehicle.</returns>
        /// <param name="type">Represents number value of vehicle type.</param>
        /// <param name="balance">Represents double value of vehicle balance.</param>
        /// <param name="licenseNumber">Represents string value of vehicle license number.</param>
        public Vehicle CreateVehicle(int type, double balance, string licenseNumber)
        {
            Vehicle vehicle = null;
            switch (type)
            {
                case 1:
                    vehicle = new Motorbike() { Balance = balance, Id = licenseNumber };
                    break;

                case 2:
                    vehicle = new Car() { Balance = balance, Id = licenseNumber };
                    break;

                case 3:
                    vehicle = new Bus() { Balance = balance, Id = licenseNumber };
                    break;

                case 4:
                    vehicle = new Truck() { Balance = balance, Id = licenseNumber };
                    break;
            }

            return vehicle;
        }

        /// <summary>
        /// Read vehicle info from console.
        /// </summary>
        /// /// <param name="type">Represents number value of vehicle type.</param>
        /// <param name="balance">Represents double value of vehicle balance.</param>
        /// <param name="licenseNumber">Represents string value of vehicle license number.</param>
        public void ReadInfo(out int type, out double balance, out string licenseNumber)
        {
            var incorrectInput = "Incorrect input, try again!";
            input1: Console.WriteLine("Choose the type of your vehicle (press a number):\n" +
                "1 - Motorbike\n" +
                "2 - Car\n" +
                "3 - Bus\n" +
                "4 - Truck");
            string num = Console.ReadLine();
            if (!int.TryParse(num, out type) & !Enumerable.Range(1, 4).Contains(type))
            {
                Console.WriteLine(incorrectInput);
                goto input1;
            }

            Console.WriteLine("Enter your license number:");
            licenseNumber = Console.ReadLine();
            input2: Console.WriteLine("Enter the account balance of your vehicle:");
            string bal = Console.ReadLine();
            if (!double.TryParse(bal, out balance))
            {
                Console.WriteLine(incorrectInput);
                goto input2;
            }
        }

        /// <summary>
        /// Park vehicle and turn on meter.
        /// </summary>
        public void AddVehicle()
        {
            if (Settings.capacity > Parking.GetInstance().vehicles.Count)
            {
                this.ReadInfo(out int type, out double balance, out string licenseNumber);
                Vehicle v = this.CreateVehicle(type, balance, licenseNumber);
                v.IsParked = true;

                if (!VehicleViewer.IsParked(v.Id))
                {
                    Parking.GetInstance().vehicles.Add(v);
                    this.tm = new TimerCallback(this.GetPaid);
                    this.timer = new Timer(this.tm, v, 0, Settings.period);
                    Console.WriteLine("Your vehicle is parked.");
                }
                else
                {
                    Console.WriteLine("Your vehicle has already parked.");
                }
            }
            else
            {
                Console.WriteLine("Sorry, the ParkingLot is full.");
            }
        }

        /// <summary>
        /// Withdraw money from vehicle account.
        /// </summary>
        /// /// <param name="vehicle">Represents object of vehicle.</param>
        public void GetPaid(object vehicle)
        {
            Vehicle v = (Vehicle)vehicle;
            double sum = 0;
            if (v.IsParked)
            {
                if (v.Balance >= v.Rate)
                {
                    sum = v.Rate;
                    v.Balance -= sum;
                    Parking.GetInstance().Balance += sum;
                    Parking.GetInstance().transactions.Add(new Transaction() { Amount = sum, TimeOfTransaction = DateTime.Now, VehicleId = v.Id });
                }
                else
                {
                    sum = v.Rate * Settings.penalty;
                    v.Balance -= sum;
                    Parking.GetInstance().Balance += sum;
                    Parking.GetInstance().transactions.Add(new Transaction() { Amount = sum, TimeOfTransaction = DateTime.Now, VehicleId = v.Id });
                }
            }
            else
            {
                this.timer.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }
    }
}
