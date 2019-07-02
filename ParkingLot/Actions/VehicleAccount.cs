using System;

namespace ParkingLot
{
    /// <summary>
    /// The class contains method for vehicle account manupulation.
    /// </summary>
    internal class VehicleAccount
    {
        /// <summary>
        /// Fund the vehicle account.
        /// </summary>
        /// <param name="v">Represents object of vehicle.</param>
        public static void FundAccount(Vehicle v)
        {
            Console.WriteLine("Enter the amount of money you want to fund:");

            input: if (double.TryParse(Console.ReadLine(), out double fund))
            {
                v.Balance += fund;
                Console.WriteLine($"{fund} was added to your account.");
            }
            else
            {
                Console.WriteLine("Incorrect input. Try again!");
                goto input;
            }
        }
    }
}
