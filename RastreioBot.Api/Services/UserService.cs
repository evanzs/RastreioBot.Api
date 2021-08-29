using System.Threading.Tasks;
using RastreioBot.Api.Interfaces;
using RastreioBot.Api.Models.Api.Users;
using RastreioBot.Api.Utils;

namespace RastreioBot.Api.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;
        private IUnitOfWork _uow;

        public UserService(IUserRepository repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        public async Task<UserApi> AddUserAsync(UserApi userApi)
        {
            var user = RastreioBotUtils.ConvertUserApiToUser(userApi);
            var userInserted = await _repository.InsertUser(user);

            if (userInserted is null)
                return null;

            await _uow.Commit();
            return RastreioBotUtils.ConvertUserToUserApi(userInserted);
        }

        public async Task<UserApi> GetUserAsync(int id)
        {
            var user = await _repository.GetUserById(id);

            if (user is null)
                return null;

            return RastreioBotUtils.ConvertUserToUserApi(user);
        }

        public async Task<UserApi> GetUserAsync(string token)
        {
            var user = await _repository.GetUserByToken(token);

            if (user is null)
                return null;

            return RastreioBotUtils.ConvertUserToUserApi(user);
        }
    }
}