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
    using MapStrategy = FinanceAnalyzer.Data.Mappers.ExpenseMapStrategies;

    public class ExpensesContext : IExpensesContext<Expense>
    {
        private readonly IExecutor _executor;

        public ExpensesContext(IExecutor executor)
        {
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        }

        public async Task ClearAll()
        {
            await _executor.ExecuteNonQuery("sp_delete_all_expenses");
        }

        public async Task<IReadOnlyCollection<Expense>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<Expense>> GetAllByUserId(int userId)
        {
            var dataSet = await _executor.ExecuteDataSet(
                "sp_select_expenses_by_user_id",
                new Dictionary<string, object>
                {
                    { "userId", userId },
                });

            var mapper = new Mapper<DataSet, IReadOnlyCollection<Expense>> { Map = MapStrategy.MapExpenses };
            return mapper.Map(dataSet);
        }

        public Task<Expense> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Save(Expense obj)
        {
            await _executor.ExecuteNonQuery("sp_insert_expense", new Dictionary<string, object>
            {
                { "amount", obj.Value },
                { "userId", obj.UserId },
            });
        }
    }
}
