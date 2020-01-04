namespace FinanceAnalyzer.Data.Mappers
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    internal static class IncomeMapStrategies
    {
        internal static IReadOnlyCollection<decimal> MapIncomes(DataSet dataSet)
        {
            return dataSet == null
                ? null
                : dataSet.Tables[0]
                .AsEnumerable()
                .Select(row => row.Field<decimal>("Amount"))
                .ToList();
        }
    }
}
