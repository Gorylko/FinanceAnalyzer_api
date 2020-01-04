namespace FinanceAnalyzer.Shared.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    public class FinanceInfo
    {
        public IReadOnlyCollection<decimal> IncomeHistoryCollection { get; set; }

        public IReadOnlyCollection<decimal> ExpensesHistoryCollection { get; set; }

        public decimal TotalIncome
        {
            get
            {
                return IncomeHistoryCollection == null
                    ? 0
                    : IncomeHistoryCollection.Sum();
            }
        }

        public decimal TotalExpenses
        {
            get
            {
                return ExpensesHistoryCollection == null
                    ? 0
                    : ExpensesHistoryCollection.Sum();
            }
        }

        public decimal Profit => TotalIncome - TotalExpenses;
    }
}
