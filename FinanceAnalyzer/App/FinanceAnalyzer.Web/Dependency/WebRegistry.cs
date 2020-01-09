using FinanceAnalyzer.Business.Dependency;
using FinanceAnalyzer.Data.Dependency;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceAnalyzer.Web.Dependency
{
    public static class WebRegistry
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddBusinessDependencies();
            services.AddDataDependencies();
        }
    }
}
