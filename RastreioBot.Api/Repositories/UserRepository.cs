using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RastreioBot.Api.Data;
using RastreioBot.Api.Interfaces;
using RastreioBot.Api.Models.Users;

namespace RastreioBot.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private BotContext _context;

        public UserRepository(BotContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserById(int id)
            => await _context.Users.FirstOrDefaultAsync(u => u.Id.Equals(id));

        public async Task<User> GetUserByToken(string token)
            => await _context.Users.FirstOrDefaultAsync(u => u.UserToken.Equals(token));

        public async Task<User> InsertUser(User user)
        {
            await _context.Users.AddAsync(user);
            return user;
        }

        public Task<User> UpdateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteUserById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteUserByToken(string token)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> ExistsUserById(int id)
            => await _context.Users.AnyAsync(u => u.Id.Equals(id));

        public async Task<bool> ExistsUserByToken(string token)
            => await _context.Users.AnyAsync(u => u.UserToken.Equals(token));
    }
}