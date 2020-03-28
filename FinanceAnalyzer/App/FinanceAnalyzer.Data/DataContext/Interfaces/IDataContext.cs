namespace FinanceAnalyzer.Data.DataContext.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDataContext<T>
    {
        Task<T> GetById(int id);

        Task<IReadOnlyCollection<T>> GetAll();

        Task Save(T obj);

        Task ClearAll();
    }
}
