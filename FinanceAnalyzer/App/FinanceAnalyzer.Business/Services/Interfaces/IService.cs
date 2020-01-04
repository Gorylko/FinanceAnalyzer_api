// <copyright file="IService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FinanceAnalyzer.Business.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface IService<TValue, TResult>
    {
        Task<TResult> GetAll();

        Task Save(TValue obj);

        Task ClearAll();
    }
}
