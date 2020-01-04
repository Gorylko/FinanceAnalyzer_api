// <copyright file="BusinessRegistry.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FinanceAnalyzer.Business.Dependency
{
    using FinanceAnalyzer.Business.Services.Interfaces;
    using FinanceAnalyzer.Business.Services.Realizations;
    using StructureMap;

    public class BusinessRegistry : Registry
    {
        public BusinessRegistry()
        {
            For<IIncomeService>().Use<IncomeService>();
            For<IFinanceService<decimal>>().Use<FinanceService>();
            For<IExpensesService>().Use<ExpensesService>();
            For<ILoginService>().Use<LoginService>();
            For<ITaxService>().Use<TaxService>();
        }
    }
}
