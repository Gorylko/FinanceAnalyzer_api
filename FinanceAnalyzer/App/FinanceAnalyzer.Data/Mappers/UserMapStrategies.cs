namespace FinanceAnalyzer.Data.Mappers
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using FinanceAnalyzer.Data.Models;
    using FinanceAnalyzer.Shared.Entities;

    internal class UserMapStrategies
    {
        internal static UserDto MapUser(DataSet dataSet)
        {
            return dataSet == null || dataSet.Tables.Count == 0 || dataSet.Tables[0].Rows.Count == 0
                ? default
                : new UserDto
                {
                    Id = dataSet.Tables[0].Rows[0].Field<int>("Id"),
                    Login = dataSet.Tables[0].Rows[0].Field<string>("Login"),
                    Password = dataSet.Tables[0].Rows[0].Field<byte[]>("Password"),
                    PasswordSalt = dataSet.Tables[0].Rows[0].Field<byte[]>("PasswordSalt"),
                };
        }

        internal static IReadOnlyCollection<UserDto> MapUserCollection(DataSet dataSet)
        {
            return dataSet == null
                ? default
                : dataSet.Tables[0]
                .AsEnumerable()
                .Select(row =>
                    new UserDto
                    {
                        Id = row.Field<int>("Id"),
                        Login = row.Field<string>("Login"),
                        Password = row.Field<byte[]>("Password"),
                        PasswordSalt = row.Field<byte[]>("PasswordSalt"),
                    })
                .ToArray();
        }
    }
}
