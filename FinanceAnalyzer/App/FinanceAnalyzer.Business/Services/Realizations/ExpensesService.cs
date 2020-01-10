namespace FinanceAnalyzer.Business.Services.Realizations
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FinanceAnalyzer.Business.Services.Interfaces;
    using FinanceAnalyzer.Data.DataContext.Interfaces;

    internal class ExpensesService : IExpensesService
    {
        private IExpensesContext<decimal> _expensesContext;

        public ExpensesService(IExpensesContext<decimal> expensesContext)
        {
            _expensesContext = expensesContext ?? throw new ArgumentNullException(nameof(expensesContext));
        }

        public async Task ClearAll()
        {
            await _expensesContext.ClearAll();
        }

        public async Task<IReadOnlyCollection<decimal>> GetAll()
        {
            return await _expensesContext.GetAll();
        }

        public async Task<IReadOnlyCollection<decimal>> GetAllByUserId(int id)
        {
            return await _expensesContext.GetAllByUserId(id);
        }

        public async Task Save(decimal obj)
        {
            await _expensesContext.Save(obj);
        }
    }
}
