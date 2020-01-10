namespace FinanceAnalyzer.Shared.Entities
{
    public class Expense
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public decimal Value { get; set; }
    }
}
