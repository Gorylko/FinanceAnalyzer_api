namespace FinanceAnalyzer.UI.Displayers
{
    using System;
    using System.Collections.Generic;
    using FinanceAnalyzer.Shared.Entities;
    using FinanceAnalyzer.UI.Interfaces;

    public class ConsoleDisplayer : IDisplayer
    {
        public void DisplayStartMenu()
        {
            Console.Clear();
            Console.WriteLine(
@"1. Display income
2. Display expenses
3. Add New Income
4. Add new expense
5. Display full information
6. Clear history
7. Exit
8. Logout");
        }

        public void DisplayLoginMenu()
        {
            Console.Clear();
            Console.WriteLine(
@"1. Login
2. Register");
        }

        public void DisplayNotification(string message)
        {
            ClearAll();
            DisplayMessage(message);
            Console.ReadKey();
        }

        public void DisplayErrorMessage(string message)
        {
            Console.SetCursorPosition(0, 2);
            Console.Write(message);
        }

        public void ClearAll()
        {
            Console.Clear();
        }

        public void DisplayCollection<T>(IReadOnlyCollection<T> collection)
        {
            if (collection == null)
            {
                return;
            }

            foreach (var el in collection)
            {
                Console.WriteLine(el);
            }
        }

        public void DisplayMessage(string message, bool isClearAll = false, bool isOnFreePlace = false)
        {
            if (isClearAll)
            {
                ClearAll();
            }

            if (!isOnFreePlace)
            {
                Console.SetCursorPosition(0, 0);
            }

            Console.WriteLine(message);
        }

        public void DisplayIncome<T>(IReadOnlyCollection<T> collection)
        {
            ClearAll();
            DisplayMessage("Income : ");

            if (collection.Count == 0)
            {
                Console.WriteLine("The history is empty");
            }
            else
            {
                DisplayCollection(collection);
            }

            Console.WriteLine("Any key to return...");

            Console.ReadKey();
        }

        public void DisplayExpenses<T>(IReadOnlyCollection<T> collection)
        {
            ClearAll();
            DisplayMessage("Expenses : ");

            if (collection.Count == 0)
            {
                Console.WriteLine("The history is empty");
            }
            else
            {
                DisplayCollection(collection);
            }

            Console.WriteLine("Any key to return...");

            Console.ReadKey();
        }

        public void DisplayFullInformation(FinanceInfo financeInfo)
        {
            Console.Clear();
            Console.WriteLine(
 $@" Total income : {financeInfo.TotalIncome}
 Total Expenses : {financeInfo.TotalExpenses}
 Profit : {financeInfo.Profit}");

            Console.ReadKey();
        }
    }
}
