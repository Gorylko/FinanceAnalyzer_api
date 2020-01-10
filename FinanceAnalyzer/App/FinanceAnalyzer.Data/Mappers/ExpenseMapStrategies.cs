using FinanceAnalyzer.Shared.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FinanceAnalyzer.Data.Mappers
{
    public static class ExpenseMapStrategies
    {
        public static IReadOnlyCollection<Expense> MapExpenses(DataSet dataSet)
        {
            return dataSet == null
                ? null
                : dataSet.Tables[0]
                .AsEnumerable()
                .Select(row => new Expense
                {
                    Id = row.Field<int>("Id"),
                    UserId = row.Field<int>("UserId"),
                    Value = row.Field<decimal>("Amount"),
                })
                .ToList();
        }
    }
}
