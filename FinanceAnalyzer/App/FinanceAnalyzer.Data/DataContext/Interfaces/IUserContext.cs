namespace FinanceAnalyzer.Data.DataContext.Interfaces
{
    using System.Threading.Tasks;
    using FinanceAnalyzer.Data.Models;
    using FinanceAnalyzer.Shared.Entities;

    public interface IUserContext : IDataContext<UserDto>
    {
        Task<UserDto> GetByLoginAndPassword(string login, byte[] password);

        Task<byte[]> GetUserSaltByLogin(string login);
    }
}
