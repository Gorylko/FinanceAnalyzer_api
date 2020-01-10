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

        public async Task<FinanceInfo> GetFullInformation(int userId)
        {
            return new FinanceInfo
            {
                IncomeHistoryCollection = await _incomeService.GetAllByUserId(userId),
                ExpensesHistoryCollection = await _expensesService.GetAllByUserId(userId),
            };
        }

        public async Task<IReadOnlyCollection<decimal>> GetIncomeHistory(int userId)
        {
            return await _incomeService.GetAllByUserId(userId);
        }

        public async Task<IReadOnlyCollection<decimal>> GetExpenseHistory(int userId)
        {
            return await _expensesService.GetAllByUserId(userId);
        }

        public async Task AddNewIncome(decimal value, int userId)
        {
            await _incomeService.Save(await _taxService.TakeTax(value));
        }

        public async Task AddNewExpense(decimal value, int userId)
        {
            await _expensesService.Save(await _taxService.TakeTax(value));
        }

        public async Task ClearHistory(int userId)
        {
            await _expensesService.ClearAll();
            await _incomeService.ClearAll();
        }
    }
}
