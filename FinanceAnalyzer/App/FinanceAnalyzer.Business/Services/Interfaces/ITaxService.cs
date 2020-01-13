namespace FinanceAnalyzer.Business.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITaxService : IService<decimal, IReadOnlyCollection<decimal>>
    {
        Task<decimal> TakeTax(decimal income);
    }
}
