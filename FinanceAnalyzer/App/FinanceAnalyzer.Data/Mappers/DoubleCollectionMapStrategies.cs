namespace FinanceAnalyzer.Data.Mappers
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    internal static class DoubleCollectionMapStrategies
    {
        internal static IReadOnlyCollection<double> MapDoubleCollection(string source)
        {
            return source != null
                ? source
                .Split('\n')
                .Where(element => double.TryParse(element, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                .Select(sortedElement => double.Parse(sortedElement))
                .ToArray()
                : null;
        }

        internal static IReadOnlyCollection<decimal> MapDecimalCollection(string source)
        {
            return source != null
                ? source
                .Split('\n')
                .Where(element => decimal.TryParse(element, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal number))
                .Select(sortedElement => decimal.Parse(sortedElement))
                .ToArray()
                : null;
        }
    }
}
