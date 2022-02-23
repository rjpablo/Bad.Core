using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;

namespace Bad.Core.Services
{
    public interface IService
    {
        IDbContextTransaction BeginTransaction();
    }
}
