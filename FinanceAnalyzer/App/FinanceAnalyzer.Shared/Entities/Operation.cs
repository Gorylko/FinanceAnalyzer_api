namespace FinanceAnalyzer.Shared.Entities
{
    using System;
    using FinanceAnalyzer.Shared.Enums;

    public class Operation
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public OperationType Type { get; set; }

        public decimal Value { get; set; }

        public DateTime Date { get; set; }
    }
}
