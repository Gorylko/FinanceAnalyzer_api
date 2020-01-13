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
            services.AddScoped<IIncomeService, IncomeService>();
            services.AddScoped<IFinanceService, FinanceService>();
            services.AddScoped<IExpensesService, ExpensesService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ITaxService, TaxService>();
        }
    }
}
