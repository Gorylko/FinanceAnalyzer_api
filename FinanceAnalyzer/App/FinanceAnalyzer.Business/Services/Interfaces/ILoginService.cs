namespace FinanceAnalyzer.Business.Services.Interfaces
{
    using System.Threading.Tasks;
    using FinanceAnalyzer.Shared.Entities;

    public interface ILoginService
    {
        Task<User> Login(string login, string password);

        Task<User> Register(string login, string password);

        Task<User> GetUserByLogin(string login);
    }
}
