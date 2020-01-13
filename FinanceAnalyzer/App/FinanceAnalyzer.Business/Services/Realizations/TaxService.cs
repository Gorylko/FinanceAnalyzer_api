namespace FinanceAnalyzer.Business.Services.Realizations
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FinanceAnalyzer.Business.Services.Interfaces;
    using FinanceAnalyzer.Data.DataContext.Interfaces;

    internal class TaxService : ITaxService
    {
        private const decimal TaxPercentage = 13;
        private ITaxContext<decimal> _taxContext;

        public TaxService(ITaxContext<decimal> taxContext)
        {
            _taxContext = taxContext ?? throw new ArgumentNullException(nameof(taxContext));
        }

        public async Task ClearAll()
        {
            await _taxContext.ClearAll();
        }

        public async Task<IReadOnlyCollection<decimal>> GetAll()
        {
            return await _taxContext.GetAll();
        }

        public Task<IReadOnlyCollection<decimal>> GetAllByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Save(decimal obj)
        {
            await _taxContext.Save(obj);
        }

        public async Task<decimal> TakeTax(decimal income)
        {
            var newIncome = income - (income * TaxPercentage / 100);

            await _taxContext.Save(income - newIncome);

            return newIncome;
        }
    }
}
