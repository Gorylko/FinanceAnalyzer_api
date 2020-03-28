using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceAnalyzer.Data.DataContext.Interfaces
{
    public interface IFinanceContext<T> : IDataContext<T>
    {
        Task<IReadOnlyCollection<T>> GetAllByUserId(int userId);
    }
}
