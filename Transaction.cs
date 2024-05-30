using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzz6
{
    public interface ITransaction
    {
        Guid TransactionId { get; }
        double Amount { get; }
        DateTime Date { get; }
    }
    internal class Transaction : ITransaction
    {
        public Guid TransactionId { get; set; }
        public double Amount { get; set; }

        public DateTime Date { get; set; }
    }

    public static class TransactionAnalyzer
    {
        public static double CalculateAverageAmount<T>(IEnumerable<T> transactions, DateTime startDate, DateTime andTime)where T : ITransaction
        {
            var filteredTransactions = transactions.Where(t => t.Date >= startDate && t.Date <= andTime);

            if (!filteredTransactions.Any())
            {
                return 0.0;
            }

            return filteredTransactions.Average(t => t.Amount);
        }
    }


}
