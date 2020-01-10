namespace FinanceAnalyzer.Data.Dependency
{
    using FinanceAnalyzer.Data.DataContext.Interfaces;
    using FinanceAnalyzer.Data.DataContext.Realizations;
    using FinanceAnalyzer.Data.DataContext.Realizations.MsSql;
    using FinanceAnalyzer.Data.DbContext.Interfaces;
    using FinanceAnalyzer.Data.DbContext.Realization;
    using FinanceAnalyzer.Shared.Entities;
    using Microsoft.Extensions.DependencyInjection;

    public static class DataRegistry
    {
        public static void AddDataDependencies(this IServiceCollection services)
        {
            services.AddTransient<IExpensesContext<Expense>, ExpensesContext>();
            services.AddTransient<IIncomeContext<Income>, IncomeContext>();
            services.AddTransient<IUserContext, UserContext>();
            services.AddTransient<ITaxContext<decimal>, TaxContext>();
            services.AddTransient<IExecutor, ProcedureExecutor>();
        }
    }
}
