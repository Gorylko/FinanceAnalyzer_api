// <copyright file="IExpensesService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FinanceAnalyzer.Business.Services.Interfaces
{
    using FinanceAnalyzer.Shared.Entities;
    using System.Collections.Generic;

    public interface IExpensesService : IService<Expense, IReadOnlyCollection<Expense>>
    {
    }
}
