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
            services.AddScoped<IExpensesContext<Expense>, ExpensesContext>();
            services.AddScoped<IIncomeContext<Income>, IncomeContext>();
            services.AddScoped<IUserContext, UserContext>();
            services.AddScoped<ITaxContext<decimal>, TaxContext>();
            services.AddScoped<IExecutor, ProcedureExecutor>();
        }
    }
}
