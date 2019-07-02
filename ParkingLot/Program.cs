using System;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace ParkingLot
{
    /// <summary>
    /// The main class contains the entry point of ParkingLot console application.
    /// </summary>
    internal class Program
    {
        public static string Menu { get; } = "\nChoose an action (press a number):\n" +
                        "1 - Show the balance of ParkingLot\n" +
                        "2 - Show the amount of money earned for last minute\n" +
                        "3 - Show a number of spare place\n" +
                        "4 - Show all transactions of ParkingLot for last minute\n" +
                        "5 - Show all history of transactions\n" +
                        "6 - Show all parked vehicles\n" +
                        "7 - Park a vehicle\n" +
                        "8 - Take a vehicle\n" +
                        "9 - Fund the account of the vehicle\n" +
                        "For exit press ESC\n";

        static readonly HttpClient client = new HttpClient();

        private const string APP_PATH = "http://localhost:55122";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(Menu);
                string choise = ReadInput();
                if (int.TryParse(choise, out int num) && Enumerable.Range(1, 9).Contains(num))
                {
                    switch (num)
                    {
                        case 1:
                            Console.WriteLine($"The balance of ParkingLot is {Parking.GetInstance().Balance}");
                            break;
                        case 2:
                            Console.WriteLine($"The amount of money earned for last minute is { TransactionsViewer.ShowLastMinuteIncome()}");
                            break;
                        case 3:
                            Console.WriteLine($"There are {Settings.capacity - Parking.GetInstance().vehicles.Count} spare places at the parking.");
                            break;
                        case 4:
                            TransactionsViewer.ViewLastMinuteTransactions();
                            break;
                        case 5:
                            TransactionsLogger.ShowAllTranactions();
                            break;
                        case 6:
                            VehicleViewer.ShowParkedVehicle();
                            break;
                        case 7:
                            new VehicleCreator().AddVehicle();
                            TransactionsLogger.LogTransactions();
                            break;
                        case 8:
                            VehicleRemover.TakeVehicle();
                            break;
                        case 9:
                            VehicleAccount.FundAccount(VehicleViewer.FindVehicle(VehicleViewer.ReadLicenseNumber()));
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input. Try again!");
                }
            }
        }

        /// <summary>
        /// Read data from console.
        /// </summary>
        private static string ReadInput()
        {
            string input = null;

            StringBuilder builder = new StringBuilder();

            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter && info.Key != ConsoleKey.Escape)
            {
                builder.Append(info.KeyChar);
                info = Console.ReadKey(true);
            }

            if (info.Key == ConsoleKey.Escape)
            {
                System.Environment.Exit(0);
            }
            else if (info.Key == ConsoleKey.Enter)
            {
                input = builder.ToString();
            }

            return input;
        }
    }
}
