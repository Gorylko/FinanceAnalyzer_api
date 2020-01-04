namespace FinanceAnalyzer.Data.Mappers
{
    using System;

    public class Mapper<TInput, TOutput>
    {
        public Func<TInput, TOutput> Map { get; set; }

        public Func<TInput, TOutput> MapCollection { get; set; }
    }
}
