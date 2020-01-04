namespace FinanceAnalyzer.Data.DbContext.Realization
{
    using FinanceAnalyzer.Data.DbContext.Interfaces;
    using FinanceAnalyzer.Data.Helpers;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    internal class ProcedureExecutor : IExecutor
    {
        private SqlConnectionHelper _connectionHelper = new SqlConnectionHelper();

        public async Task<DataSet> ExecuteDataSet(string procedureName, IDictionary<string, object> values = null)
        {
            DataSet dataSet = null;
            using (var connection = new SqlConnection(_connectionHelper.GetConnectionString()))
            {
                var procedure = CreateProcedure(procedureName, values);
                procedure.Connection = connection;
                connection.Open();
                var adapter = new SqlDataAdapter(procedure);
                dataSet = new DataSet();
                await Task.FromResult(adapter.Fill(dataSet));
            }

            return dataSet;
        }

        public async Task<int> ExecuteNonQuery(string procedureName, IDictionary<string, object> values = null)
        {
            using (var connecton = new SqlConnection(_connectionHelper.GetConnectionString()))
            {
                var procedure = CreateProcedure(procedureName, values);
                procedure.Connection = connecton;
                connecton.Open();
                return await procedure.ExecuteNonQueryAsync();
            }
        }

        public async Task<object> ExecuteScalar(string procedureName, IDictionary<string, object> values = null)
        {
            using (var connecton = new SqlConnection(_connectionHelper.GetConnectionString()))
            {
                var procedure = CreateProcedure(procedureName, values);
                procedure.Connection = connecton;
                connecton.Open();
                return await procedure.ExecuteScalarAsync();
            }
        }

        private SqlCommand CreateProcedure(string procedureName, IDictionary<string, object> values = null)
        {
            var command = new SqlCommand
            {
                CommandText = procedureName,
                CommandType = CommandType.StoredProcedure,
            };
            if (values != null)
            {
                foreach (var param in values)
                {
                    var parameter = CreateParameter(param);
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }

        private SqlParameter CreateParameter(KeyValuePair<string, object> param)
        {
            return new SqlParameter
            {
                ParameterName = "@" + param.Key,
                Value = param.Value,
            };
        }
    }
}
