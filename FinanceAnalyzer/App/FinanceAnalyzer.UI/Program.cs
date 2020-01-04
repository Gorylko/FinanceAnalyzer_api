namespace FinanceAnalyzer.UI
{
    using System;
    using System.Threading.Tasks;
    using FinanceAnalyzer.IoC;
    using FinanceAnalyzer.UI.Dependency;
    using FinanceAnalyzer.UI.Interfaces;
    using StructureMap;

    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var launcher = GetContainer().GetInstance<ILauncher>();

            try
            {
                await launcher.Launch();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex);
            }
        }

        private static IContainer GetContainer()
        {
            CustomContainer.Initialize();

            var container = CustomContainer.Container;
            container.Configure(c => c.AddRegistry<UIRegistry>());

            return container;
        }
    }
}
