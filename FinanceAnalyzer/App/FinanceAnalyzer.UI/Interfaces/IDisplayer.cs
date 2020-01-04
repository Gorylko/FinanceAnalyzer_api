namespace FinanceAnalyzer.UI.Interfaces
{
    using System.Collections.Generic;
    using FinanceAnalyzer.Shared.Entities;

    internal interface IDisplayer
    {
        void DisplayCollection<T>(IReadOnlyCollection<T> collection);

        void DisplayStartMenu();

        void DisplayLoginMenu();

        void ClearAll();

        void DisplayErrorMessage(string message);

        void DisplayNotification(string message);

        void DisplayMessage(string message, bool isClearAll = false, bool isOnFreePlace = false);

        void DisplayIncome<T>(IReadOnlyCollection<T> collection);

        void DisplayExpenses<T>(IReadOnlyCollection<T> collection);

        void DisplayFullInformation(FinanceInfo financeInfo);
    }
}
