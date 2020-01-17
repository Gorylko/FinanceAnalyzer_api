namespace FinanceAnalyzer.Data.DataContext.Realizations.MsSql
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using FinanceAnalyzer.Data.DataContext.Interfaces;
    using FinanceAnalyzer.Data.DbContext.Interfaces;
    using FinanceAnalyzer.Data.Mappers;
    using FinanceAnalyzer.Shared.Entities;
    using MapStrategy = FinanceAnalyzer.Data.Mappers.IncomeMapStrategies;

    public class OperationHistoryContext : IFinanceHistoryContext<Operation>
    {
        private readonly IExecutor _executor;

        public OperationHistoryContext(IExecutor executor)
        {
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        }

        public async Task ClearAll()
        {
            await _executor.ExecuteNonQuery("sp_delete_#####");
        }

        public async Task<IReadOnlyCollection<Operation>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<Operation>> GetAllByUserId(int userId)
        {
            var dataSet = await _executor.ExecuteDataSet(
                "sp_select_operation_history_by_user_id",
                new Dictionary<string, object>
                {
                    { "userId", userId },
                });

            var mapper = new Mapper<DataSet, IReadOnlyCollection<Operation>> { Map = MapStrategy.MapIncomes };
            return mapper.Map(dataSet);
        }

        public Task<Operation> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Save(Operation obj)
        {
            await _executor.ExecuteNonQuery("sp_insert_income", new Dictionary<string, object>
            {
                { "amount", obj.Value },
                { "userId", obj. },
            });
        }
    }
}
