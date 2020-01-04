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
        Task<FinanceInfo> GetFullInformation();

        Task AddNewExpense(T value);

        Task AddNewIncome(T value);

        Task ClearHistory();

        Task<IReadOnlyCollection<T>> GetIncomeHistory();

        Task<IReadOnlyCollection<T>> GetExpenseHistory();
    }
}
