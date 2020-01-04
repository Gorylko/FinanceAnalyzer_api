namespace FinanceAnalyzer.Business.Services.Realizations
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FinanceAnalyzer.Business.Services.Interfaces;
    using FinanceAnalyzer.Data.DataContext.Interfaces;

    internal class IncomeService : IIncomeService
    {
        private readonly IIncomeContext<decimal> _incomeContext;

        public IncomeService(IIncomeContext<decimal> incomeContext)
        {
            _incomeContext = incomeContext ?? throw new ArgumentNullException(nameof(incomeContext));
        }

        public async Task ClearAll()
        {
            await _incomeContext.ClearAll();
        }

        public async Task<IReadOnlyCollection<decimal>> GetAll()
        {
            return await _incomeContext.GetAll();
        }

        public async Task Save(decimal obj)
        {
            await _incomeContext.Save(obj);
        }
    }
}
