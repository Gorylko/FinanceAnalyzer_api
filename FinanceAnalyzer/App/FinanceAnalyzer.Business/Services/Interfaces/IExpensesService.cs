// <copyright file="IExpensesService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FinanceAnalyzer.Business.Services.Interfaces
{
    using System.Collections.Generic;

    public interface IExpensesService : IService<decimal, IReadOnlyCollection<decimal>>
    {
    }
}
