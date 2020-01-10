namespace FinanceAnalyzer.Data.DataContext.Realizations.MsSql
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using FinanceAnalyzer.Data.Constants;
    using FinanceAnalyzer.Data.DataContext.Interfaces;
    using FinanceAnalyzer.Data.DbContext.Interfaces;
    using FinanceAnalyzer.Data.Mappers;
    using FinanceAnalyzer.Shared.Entities;
    using MapStrategy = FinanceAnalyzer.Data.Mappers.IncomeMapStrategies;

    public class IncomeContext : IIncomeContext<Income>
    {
        private readonly IExecutor _executor;

        public IncomeContext(IExecutor executor)
        {
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        }

        public async Task ClearAll()
        {
            await _executor.ExecuteNonQuery("sp_delete_all_incomes");
        }

        public async Task<IReadOnlyCollection<Income>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<Income>> GetAllByUserId(int userId)
        {
            var dataSet = await _executor.ExecuteDataSet(
                "sp_select_incomes_by_user_id",
                new Dictionary<string, object>
                {
                    { "userId", userId },
                });

            var mapper = new Mapper<DataSet, IReadOnlyCollection<Income>> { Map = MapStrategy.MapIncomes };
            return mapper.Map(dataSet);
        }

        public Task<Income> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Save(Income obj)
        {
            await _executor.ExecuteNonQuery("sp_insert_income", new Dictionary<string, object> 
            {
                { "amount", obj.Value },
                { "userId", obj.UserId },
            });
        }
    }
}
