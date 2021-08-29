using System.Threading.Tasks;
using RastreioBot.Api.Data;
using RastreioBot.Api.Interfaces;

namespace RastreioBot.Api.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private BotContext _context;

        public UnitOfWork(BotContext context)
        {
            _context = context;
        }

        public Task<int> Commit()
            => _context.SaveChangesAsync();
    }
}