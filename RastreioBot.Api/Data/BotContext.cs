using Microsoft.EntityFrameworkCore;
using RastreioBot.Api.Models.Trackings;

namespace RastreioBot.Api.Data
{
    public class BotContext : DbContext
    {
        public BotContext(DbContextOptions<BotContext> options) : base(options) { }

        public DbSet<Tracking> Trackings { get; set; }
    }
}