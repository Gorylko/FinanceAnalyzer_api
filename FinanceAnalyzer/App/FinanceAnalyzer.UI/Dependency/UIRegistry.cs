namespace FinanceAnalyzer.UI.Dependency
{
    using FinanceAnalyzer.UI.Data;
    using FinanceAnalyzer.UI.DataReceivers;
    using FinanceAnalyzer.UI.Displayers;
    using FinanceAnalyzer.UI.Interfaces;
    using StructureMap;

    public class UIRegistry : Registry
    {
        public UIRegistry()
        {
            For<ILauncher>().Use<AppLauncher>();
            For<ICookieManager>().Use<CookieManager>();
            For<IDisplayer>().Use<ConsoleDisplayer>();
            For<IDataReceiver>().Use<ConsoleDataReceiver>();
        }
    }
}
