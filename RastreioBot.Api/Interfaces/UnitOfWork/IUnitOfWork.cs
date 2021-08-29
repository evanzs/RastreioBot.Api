using System.Threading.Tasks;

namespace RastreioBot.Api.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> Commit();
    }
}