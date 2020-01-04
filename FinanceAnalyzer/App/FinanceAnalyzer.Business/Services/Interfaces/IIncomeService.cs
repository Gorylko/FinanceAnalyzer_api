namespace FinanceAnalyzer.Business.Services.Interfaces
{
    using System.Collections.Generic;

    public interface IIncomeService : IService<decimal, IReadOnlyCollection<decimal>>
    {
    }
}
