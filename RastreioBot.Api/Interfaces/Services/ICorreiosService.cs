using System.Collections.Generic;
using System.Threading.Tasks;

namespace RastreioBot.Api.Interfaces.Services
{
    public interface ICorreiosService
    {
        Task<object> GetTrackings(List<string> trackings);
    }
}