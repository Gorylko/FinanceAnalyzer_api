namespace FinanceAnalyzer.UI.Data
{
    using System.IO;
    using System.Text.Json;
    using System.Threading.Tasks;
    using FinanceAnalyzer.Shared.Entities;
    using FinanceAnalyzer.UI.Interfaces;

    internal class CookieManager : ICookieManager
    {
        private const string UserCookiePath = "user.json";

        public async Task<User> GetUserFromCookie()
        {
            try
            {
                using (FileStream fileStream = new FileStream(UserCookiePath, FileMode.OpenOrCreate))
                {
                    return await JsonSerializer.DeserializeAsync<User>(fileStream);
                }
            }
            catch (JsonException)
            {
                return default;
            }
        }

        public async Task SaveUserCookie(User user)
        {
            using (FileStream fileStream = new FileStream(UserCookiePath, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<User>(fileStream, user);
            }
        }

        public Task DeleteCookies()
        {
            return Task.Run(() => File.Delete(UserCookiePath));
        }
    }
}
