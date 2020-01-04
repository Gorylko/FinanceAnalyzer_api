namespace FinanceAnalyzer.Data.DataContext.Realizations.MsSql
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using FinanceAnalyzer.Data.DataContext.Interfaces;
    using FinanceAnalyzer.Data.DbContext.Interfaces;
    using FinanceAnalyzer.Data.Mappers;
    using FinanceAnalyzer.Data.Models;
    using FinanceAnalyzer.Shared.Entities;

    internal class UserContext : IUserContext
    {
        private readonly IExecutor _executor;

        public UserContext(IExecutor executor)
        {
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        }

        public async Task ClearAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<UserDto>> GetAll()
        {
            var dataSet = await _executor.ExecuteDataSet("sp_select_all_users");

            var mapper = new Mapper<DataSet, IReadOnlyCollection<UserDto>> { MapCollection = UserMapStrategies.MapUserCollection };
            return mapper.MapCollection(dataSet);
        }

        public async Task<UserDto> GetById(int id)
        {
            var dataSet = await _executor.ExecuteDataSet(
                "sp_select_user_by_id",
                new Dictionary<string, object>
                {
                    { "id", id },
                });

            var mapper = new Mapper<DataSet, UserDto> { Map = UserMapStrategies.MapUser };
            return mapper.Map(dataSet);
        }

        public async Task<UserDto> GetByLoginAndPassword(string login, byte[] password)
        {
            var dataSet = await _executor.ExecuteDataSet(
                "sp_select_user_by_login_and_password",
                new Dictionary<string, object>
                {
                    { "login", login },
                    { "password", password },
                });

            var mapper = new Mapper<DataSet, UserDto> { Map = UserMapStrategies.MapUser };
            return mapper.Map(dataSet);
        }

        public async Task<byte[]> GetUserSaltByLogin(string login)
        {
            var value = await _executor.ExecuteScalar(
                "sp_select_salt_by_user_login",
                new Dictionary<string, object>
                {
                    { "login", login },
                });
            return value as byte[];
        }

        public async Task Save(UserDto obj)
        {
            await _executor.ExecuteNonQuery("sp_insert_user", new Dictionary<string, object>
            {
                { "login", obj.Login },
                { "password", obj.Password },
                { "passwordSalt", obj.PasswordSalt },
            });
        }
    }
}
