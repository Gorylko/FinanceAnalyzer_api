namespace FinanceAnalyzer.Business.Services.Realizations
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FinanceAnalyzer.Business.Services.Interfaces;
    using FinanceAnalyzer.Data.DataContext.Interfaces;
    using FinanceAnalyzer.Shared.Entities;

    internal class IncomeService : IIncomeService
    {
        private readonly IIncomeContext<Income> _incomeContext;

        public IncomeService(IIncomeContext<Income> incomeContext)
        {
            _incomeContext = incomeContext ?? throw new ArgumentNullException(nameof(incomeContext));
        }

        public async Task ClearAll()
        {
            await _incomeContext.ClearAll();
        }

        public async Task<IReadOnlyCollection<Income>> GetAll()
        {
            return await _incomeContext.GetAll();
        }

        public async Task<IReadOnlyCollection<Income>> GetAllByUserId(int id)
        {
            return await _incomeContext.GetAllByUserId(id);
        }

        public async Task Save(Income obj)
        {
            await _incomeContext.Save(obj);
        }
    }
}
