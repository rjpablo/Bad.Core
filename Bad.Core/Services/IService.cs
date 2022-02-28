using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;
using System.Threading.Tasks;

namespace Bad.Core.Services
{
    public interface IService
    {
        IDbContextTransaction BeginTransaction();
        Task SaveAsync();
    }
}
