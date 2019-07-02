using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace ParkingLot
{
    /// <summary>
    /// The class contains methods for logging tranactions.
    /// </summary>
    internal static class TransactionsLogger
    {
        private static readonly string FilePath = Path.Combine(Environment.CurrentDirectory, "Transaction.txt");

        /// <summary>
        /// Print all hisrory of tranactions.
        /// </summary>
        public static void ShowAllTranactions()
        {
            try
            {
                using (StreamReader sr = new StreamReader(FilePath, Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            List<Transaction> trs = new List<Transaction>(Parking.GetInstance().transactions);
            foreach (Transaction t in trs.ToArray())
            {
                Console.WriteLine(t);
            }
        }

        /// <summary>
        /// Set timers for automatic writing logs.
        /// </summary>
        public static void LogTransactions()
        {
            File.Create(FilePath).Close();
            TimerCallback tmc1 = new TimerCallback(WriteTransactions);
            TimerCallback tmc2 = new TimerCallback(CheckTransactions);
            Timer timer1 = new Timer(tmc1, Parking.GetInstance().transactions, 60000, 60000);
            Timer timer2 = new Timer(tmc2, Parking.GetInstance().transactions, 0, 1000);
        }

        /// <summary>
        /// Write transactions once a minute to log file.
        /// </summary>
        /// <param name="obj">Represents object of transactions list.</param>
        public static void WriteTransactions(object obj)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(new FileStream(FilePath, FileMode.OpenOrCreate)))
                {
                    List<Transaction> tr = new List<Transaction>((List<Transaction>)obj);
                    foreach (Transaction t in tr.ToArray())
                    {
                        sw.WriteLine(t);
                    }
                }
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Delete transactions older than last minute from list of transactions.
        /// </summary>
        /// <param name="obj">Represents object of transactions list.</param>
        public static void CheckTransactions(object obj)
        {
            try
            {
                List<Transaction> trs = (List<Transaction>)obj;
                List<Transaction> tr = new List<Transaction>(trs);
                foreach (Transaction t in tr.ToArray())
                {
                    if (t.TimeOfTransaction < DateTime.Now.AddMinutes(-1))
                    {
                        trs.Remove(t);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
