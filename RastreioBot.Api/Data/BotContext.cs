using Microsoft.EntityFrameworkCore;
using RastreioBot.Api.Models.Trackings;
using RastreioBot.Api.Models.Users;

namespace RastreioBot.Api.Data
{
    public class BotContext : DbContext
    {
        public BotContext(DbContextOptions<BotContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Tracking> Trackings { get; set; }
    }
}