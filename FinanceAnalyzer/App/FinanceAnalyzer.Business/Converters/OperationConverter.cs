using FinanceAnalyzer.Shared.Entities;
using FinanceAnalyzer.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceAnalyzer.Shared.Helpers.Converters
{
    internal static class OperationConverter
    {
        public static Operation ToOperation(this Income income)
        {
            return new Operation
            {
                UserId = income.UserId,
                Type = OperationType.Income,
                Date = DateTime.Now,
                Value = income.Value,
            };
        }

        public static Operation ToOperation(this Expense expense)
        {
            return new Operation
            {
                UserId = expense.UserId,
                Type = OperationType.Expense,
                Date = DateTime.Now,
                Value = expense.Value,
            };
        }
    }
}
