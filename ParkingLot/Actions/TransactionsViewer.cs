using System;
using System.Collections.Generic;

namespace ParkingLot
{
    /// <summary>
    /// The class contains methods for tranaction manupulation.
    /// </summary>
    internal static class TransactionsViewer
    {
        /// <summary>
        /// Return the value of paking lot income for last minute.
        /// </summary>
        /// <returns>Return the income of paking lot for last minute.</returns>
        public static double ShowLastMinuteIncome()
        {
            double income = 0;
            List<Transaction> tr = new List<Transaction>(Parking.GetInstance().transactions);
            foreach (Transaction t in tr.ToArray())
            {
                income += t.Amount;
            }

            return income;
        }

        /// <summary>
        /// Print all transactions for last minute.
        /// </summary>
        public static void ViewLastMinuteTransactions()
        {
            List<Transaction> tr = new List<Transaction>(Parking.GetInstance().transactions);
            foreach (Transaction t in tr)
            {
                Console.WriteLine(t);
            }
        }

    }
}
