namespace FinanceAnalyzer.Business.Services.Interfaces
{
    using FinanceAnalyzer.Shared.Entities;
    using System.Collections.Generic;

    public interface IIncomeService : IService<Income, IReadOnlyCollection<Income>>
    {
    }
}
