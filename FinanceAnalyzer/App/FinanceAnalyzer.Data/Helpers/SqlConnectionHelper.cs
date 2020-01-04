namespace FinanceAnalyzer.Data.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Text;

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
