using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RastreioBot.Api.Data;
using RastreioBot.Api.Interfaces;
using RastreioBot.Api.Models.Trackings;

namespace RastreioBot.Api.Repositories
{
    public class TrackingRepository : ITrackingRepository
    {
        private BotContext _context;

        public TrackingRepository(BotContext context)
        {
            _context = context;
        }

        public async Task<Tracking> AddTracking(Tracking tracking)
        {
            await _context.Trackings.AddAsync(tracking);
            return tracking;
        }

        public async Task<List<Tracking>> AddTrackingList(List<Tracking> trackings)
        {
            await _context.Trackings.AddRangeAsync(trackings);
            return trackings;
        }

        public async Task<Tracking> GetTrackingByNumber(string trackingNumber)
            => await _context.Trackings.FirstOrDefaultAsync(t => t.TrackingNumber.Equals(trackingNumber));

        public async Task<List<Tracking>> GetTrackingList()
            => await _context.Trackings.ToListAsync();
    }
}