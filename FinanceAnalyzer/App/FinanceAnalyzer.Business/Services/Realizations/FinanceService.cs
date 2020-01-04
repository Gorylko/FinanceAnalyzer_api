namespace FinanceAnalyzer.Business.Services.Realizations
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FinanceAnalyzer.Business.Services.Interfaces;
    using FinanceAnalyzer.Shared.Entities;

    public class FinanceService : IFinanceService<decimal>
    {
        private readonly IExpensesService _expensesService;
        private readonly IIncomeService _incomeService;
        private readonly ITaxService _taxService;

        public FinanceService(
            IExpensesService expensesService,
            IIncomeService incomeService,
            ITaxService taxService)
        {
            _expensesService = expensesService ?? throw new ArgumentNullException(nameof(expensesService));
            _incomeService = incomeService ?? throw new ArgumentNullException(nameof(incomeService));
            _taxService = taxService ?? throw new ArgumentNullException(nameof(taxService));
        }

        public async Task<FinanceInfo> GetFullInformation()
        {
            return new FinanceInfo
            {
                IncomeHistoryCollection = await _incomeService.GetAll(),
                ExpensesHistoryCollection = await _expensesService.GetAll(),
            };
        }

        public async Task<IReadOnlyCollection<decimal>> GetIncomeHistory()
        {
            return await _incomeService.GetAll();
        }

        public async Task<IReadOnlyCollection<decimal>> GetExpenseHistory()
        {
            return await _expensesService.GetAll();
        }

        public async Task AddNewIncome(decimal value)
        {
            await _incomeService.Save(await _taxService.TakeTax(value));
        }

        public async Task AddNewExpense(decimal value)
        {
            await _expensesService.Save(await _taxService.TakeTax(value));
        }

        public async Task ClearHistory()
        {
            await _expensesService.ClearAll();
            await _incomeService.ClearAll();
        }
    }
}
