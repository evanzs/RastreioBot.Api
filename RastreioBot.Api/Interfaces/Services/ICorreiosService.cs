using System.Collections.Generic;
using System.Threading.Tasks;

namespace RastreioBot.Api.Interfaces.Services
{
    public interface ICorreiosService
    {
        Task<string> GetTrackings(List<string> trackings);
    }
}