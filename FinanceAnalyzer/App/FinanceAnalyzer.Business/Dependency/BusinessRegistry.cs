// <copyright file="BusinessRegistry.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FinanceAnalyzer.Business.Dependency
{
    using FinanceAnalyzer.Business.Services.Interfaces;
    using FinanceAnalyzer.Business.Services.Realizations;
    using Microsoft.Extensions.DependencyInjection;

    public static class BusinessRegistry
    {
        public static void AddBusinessDependencies(this IServiceCollection services)
        {
            services.AddTransient<IIncomeService, IncomeService>();
            services.AddTransient<IFinanceService<decimal>, FinanceService>();
            services.AddTransient<IExpensesService, ExpensesService>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<ITaxService, TaxService>();
        }
    }
}
