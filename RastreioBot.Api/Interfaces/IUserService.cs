using System.Threading.Tasks;
using RastreioBot.Api.Models.Api.Users;

namespace RastreioBot.Api.Interfaces
{
    public interface IUserService
    {
        Task<UserApi> GetUserAsync(int id);
        Task<UserApi> GetUserAsync(string token);
        Task<UserApi> AddUserAsync(UserApi user);
    }
}