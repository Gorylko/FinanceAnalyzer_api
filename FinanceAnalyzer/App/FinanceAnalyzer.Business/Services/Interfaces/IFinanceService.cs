// <copyright file="IFinanceService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FinanceAnalyzer.Business.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FinanceAnalyzer.Shared.Entities;

    public interface IFinanceService<T>
    {
        Task<FinanceInfo> GetFullInformation(int userId);

        Task AddNewExpense(T value, int userId);

        Task AddNewIncome(T value, int userId);

        Task ClearHistory(int userId);

        Task<IReadOnlyCollection<T>> GetIncomeHistory(int userId);

        Task<IReadOnlyCollection<T>> GetExpenseHistory(int userId);
    }
}
