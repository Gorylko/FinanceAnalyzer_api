namespace FinanceAnalyzer.Data.DbContext.Interfaces
{
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    public interface IExecutor
    {
        Task<DataSet> ExecuteDataSet(string procedureName, IDictionary<string, object> values = null);

        Task<object> ExecuteScalar(string procedureName, IDictionary<string, object> values = null);

        Task<int> ExecuteNonQuery(string procedureName, IDictionary<string, object> values = null);
    }
}
