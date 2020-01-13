namespace FinanceAnalyzer.Business.Services.Realizations
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FinanceAnalyzer.Business.Services.Interfaces;
    using FinanceAnalyzer.Data.DataContext.Interfaces;
    using FinanceAnalyzer.Shared.Entities;

    internal class ExpensesService : IExpensesService
    {
        private IExpensesContext<Expense> _expensesContext;

        public ExpensesService(IExpensesContext<Expense> expensesContext)
        {
            _expensesContext = expensesContext ?? throw new ArgumentNullException(nameof(expensesContext));
        }

        public async Task ClearAll()
        {
            await _expensesContext.ClearAll();
        }

        public async Task<IReadOnlyCollection<Expense>> GetAll()
        {
            return await _expensesContext.GetAll();
        }

        public async Task<IReadOnlyCollection<Expense>> GetAllByUserId(int id)
        {
            return await _expensesContext.GetAllByUserId(id);
        }

        public async Task Save(Expense obj)
        {
            await _expensesContext.Save(obj);
        }
    }
}
