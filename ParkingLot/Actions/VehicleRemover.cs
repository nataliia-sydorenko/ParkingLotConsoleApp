using System;

namespace ParkingLot
{
    /// <summary>
    /// The class contain method for taking vehicle from parking lot.
    /// </summary>
    public class VehicleRemover
    {
        /// <summary>
        /// Check whether the vehicle is parked.
        /// </summary>
        public static void TakeVehicle()
        {
                var id = VehicleViewer.ReadLicenseNumber();
                if (VehicleViewer.IsParked(id))
                {
                    var v = VehicleViewer.FindVehicle(id);
                    check: if (v.Balance < 0)
                    {
                    Console.WriteLine($"You have a debt for parking in amount of {v.Balance}. Please fund your account.");
                    VehicleAccount.FundAccount(v);
                    goto check;
                    }

                    v.IsParked = false;
                    Parking.GetInstance().vehicles.Remove(v);
                    Console.WriteLine("Taking vehicle is successful.");
                }
                else
                {
                    Console.WriteLine($"There is no vehicle with license number {id}");
                }
        }
    }
}
