using System;
using System.Collections.Generic;

namespace ParkingLot
{
    /// <summary>
    /// The class contains methods for vehicle manupulation.
    /// </summary>
    internal class VehicleViewer
    {
        /// <summary>
        /// The list of parked vehicles.
        /// </summary>
        private static readonly List<Vehicle> Vehs = Parking.GetInstance().vehicles;

        /// <summary>
        /// Print information about all parked vehicle.
        /// </summary>
        public static void ShowParkedVehicle()
        {
            foreach (var v in Vehs)
            {
                Console.WriteLine(v);
            }
        }

        /// <summary>
        /// Check whether the vehicle is parked.
        /// </summary>
        /// <returns>Returns true value if the vehicle is parked.</returns>
        /// <param name="id">Represents string value of vehicle license number.</param>
        public static bool IsParked(string id) => Vehs.Exists(x => x.Id.Contains(id));

        /// <summary>
        /// Find the vehicle by license number at parking lot.
        /// </summary>
        /// <returns>Returns parked Vehicle object.</returns>
        /// <param name="id">Represents string value of vehicle license number.</param>
        public static Vehicle FindVehicle(string id) => Vehs.Find(x => x.Id.Contains(id));

        /// <summary>
        /// Read vehicle license number from console.
        /// </summary>
        /// <returns>Returns string value of vehicle license number.</returns>
        public static string ReadLicenseNumber()
        {
            Console.WriteLine("Enter your vehicle license number");
            return Console.ReadLine();
        }
    }
}
