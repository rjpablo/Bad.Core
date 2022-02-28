using Flurl;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Bad.Core.Services
{
    public class FilesService : IFilesService
    {
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHostingEnvironment _hostingEnvironment;

        public FilesService(IConfiguration config,
            IHttpContextAccessor httpContextAccessor,
            IHostingEnvironment hostingEnvironment)
        {
            _config = config;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<string> Upload(IFormFile file)
        {
            string uploadBasePath = _config["FileUpload:UploadBasePath"];
            string scheme = _httpContextAccessor.HttpContext.Request.Scheme + "://";
            string hostName = _httpContextAccessor.HttpContext.Request.Host.Value;
            string physicalFolderPath = Path.Combine(_hostingEnvironment.WebRootPath, uploadBasePath);

            string uploadedFilePath;

            try
            {
                if (!Directory.Exists(physicalFolderPath))
                {
                    Directory.CreateDirectory(physicalFolderPath);
                }

                string ext = Path.GetExtension(file.FileName);
                string uploadedFileName;

                do
                {
                    uploadedFileName = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + ext;
                    uploadedFilePath = Path.Combine(physicalFolderPath, uploadedFileName);
                } while (File.Exists(uploadedFilePath));

                using (var stream = System.IO.File.Create(uploadedFilePath))
                {
                    await file.CopyToAsync(stream);
                }

                return scheme + Url.Combine(hostName, uploadBasePath, uploadedFileName);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}