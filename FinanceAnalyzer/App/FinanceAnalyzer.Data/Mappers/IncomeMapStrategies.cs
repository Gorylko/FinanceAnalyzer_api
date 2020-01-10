namespace FinanceAnalyzer.Data.Mappers
{
    using FinanceAnalyzer.Shared.Entities;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    internal static class IncomeMapStrategies
    {
        internal static IReadOnlyCollection<Income> MapIncomes(DataSet dataSet)
        {
            return dataSet == null
                ? null
                : dataSet.Tables[0]
                .AsEnumerable()
                .Select(row => new Income {
                    Id = row.Field<int>("Id"),
                    UserId = row.Field<int>("UserId"),
                    Value = row.Field<decimal>("Amount"),
                    })
                .ToList();
        }
    }
}
