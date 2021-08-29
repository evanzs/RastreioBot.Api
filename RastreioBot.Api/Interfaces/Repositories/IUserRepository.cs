using System.Threading.Tasks;
using RastreioBot.Api.Models.Users;

namespace RastreioBot.Api.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        Task<User> GetUserByToken(string token);
        Task<User> InsertUser(User user);
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUserById(int id);
        Task<bool> DeleteUserByToken(string token);
        Task<bool> ExistsUserById(int id);
        Task<bool> ExistsUserByToken(string token);
    }
}