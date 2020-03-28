namespace FinanceAnalyzer.Shared.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    public class FinanceInfo
    {
        public IReadOnlyCollection<Income> IncomeHistoryCollection { get; set; }

        public IReadOnlyCollection<Expense> ExpensesHistoryCollection { get; set; }

        public decimal TotalIncome
        {
            get
            {
                return IncomeHistoryCollection == null
                    ? 0
                    : IncomeHistoryCollection.Select(el => el.Value).Sum();
            }
        }

        public decimal TotalExpenses
        {
            get
            {
                return ExpensesHistoryCollection == null
                    ? 0
                    : ExpensesHistoryCollection.Select(el => el.Value).Sum();
            }
        }

        public decimal Profit => TotalIncome - TotalExpenses;
    }
}
