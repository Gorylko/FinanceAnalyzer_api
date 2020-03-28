namespace FinanceAnalyzer.Data.Helpers
{
    using System.Data.SqlClient;

    internal class SqlConnectionHelper
    {
        internal string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "kiryl.database.windows.net";
            builder.UserID = "gorylko";
            builder.Password = "Rbhbkk78901234";
            builder.InitialCatalog = "FinanceAnalyzer";

            return builder.ToString();
        }
    }
}
