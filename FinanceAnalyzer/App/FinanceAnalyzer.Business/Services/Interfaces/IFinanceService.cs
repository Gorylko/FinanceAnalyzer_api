// <copyright file="IFinanceService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FinanceAnalyzer.Business.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FinanceAnalyzer.Shared.Entities;

    public interface IFinanceService
    {
        Task<FinanceInfo> GetFullInformation(int userId);

        Task AddNewExpense(Expense expense);

        Task AddNewIncome(Income income);

        Task ClearHistory(int userId);

        Task<IReadOnlyCollection<Income>> GetIncomeHistory(int userId);

        Task<IReadOnlyCollection<Expense>> GetExpenseHistory(int userId);
    }
}
