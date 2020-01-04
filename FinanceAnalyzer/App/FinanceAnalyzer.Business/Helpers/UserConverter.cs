namespace FinanceAnalyzer.Business.Helpers
{
    using FinanceAnalyzer.Data.Models;
    using FinanceAnalyzer.Shared.Entities;

    internal static class UserConverter
    {
        public static User ConvertToUser(this UserDto userDto, string uncryptedUserPassword = null)
        {
            return userDto == null
                ? null
                : new User
                {
                    Id = userDto.Id,
                    Login = userDto.Login,
                    Password = uncryptedUserPassword,
                };
        }
    }
}
