using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Bad.Core.Services
{
    public interface IFilesService
    {
        Task<string> Upload(IFormFile file);
    }
}
