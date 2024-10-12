using Cinamaart.Application.Abstractions.Services;
using Cinamaart.Application.Extentions.Files;
using Cinamaart.Domain.Common.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Cinamaart.Infrastructure.Services.Files
{
    public class FileService : IFileService
    {
        private const string FILESTORAGE_CONFIG_KEY = "FileSettings:FileStoragePath";
        private readonly string _fileStoragePath;
        private readonly IConfiguration configuration;
        private readonly HttpContext _httpContext;

        public FileService(IConfiguration configuration, HttpContext httpContext)
        {
            _fileStoragePath = configuration[FILESTORAGE_CONFIG_KEY];
            _InitializeFolder();
            this.configuration = configuration;
            this._httpContext = httpContext;
        }
        private void _InitializeFolder()
        {
            if (string.IsNullOrEmpty(_fileStoragePath))
            {
                throw new FileNotFoundException("File storage path is not configured.");
            }
            if (!Directory.Exists(_fileStoragePath))
            {
                Directory.CreateDirectory(_fileStoragePath);
            }
            string tempFolderName;
            foreach (DocumentTypeEnum enumType in Enum.GetValues(typeof(DocumentTypeEnum)))
            {
                tempFolderName = Path.Combine(_fileStoragePath, enumType.ToString());
                if (!Directory.Exists(tempFolderName))
                {
                    Directory.CreateDirectory(tempFolderName);
                }
            }
        }
        public async Task<bool> UploadFileAsync(IFormFile file , string? filename = null)
        {
            bool result = false;
            var filePath = Path.Combine(_fileStoragePath, file.GetDocType().ToString(), filename ?? file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
                result = file.Length == stream.Length;
            }
            return result;
        }
        public async Task DeleteFileAsync(string fileName)
        {
            var filePath = Path.Combine(_fileStoragePath , fileName.GetExtensionToUpper(), fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        public async Task<FileStream> DownloadFileAsFileStreamAsync(string fileName)
        {
            var filePath = Path.Combine(_fileStoragePath, fileName.GetExtensionToUpper(), fileName);

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found.");
            }

            return new FileStream(filePath, FileMode.Open, FileAccess.Read);
        }
        public async Task<MemoryStream> DownloadFileAsMemoryStreamAsync(string fileName)
        {
            var fileStream = await DownloadFileAsFileStreamAsync(fileName);
            var memoryStream = new MemoryStream();
            fileStream.CopyTo(memoryStream);
            memoryStream.Position = 0;
            return memoryStream;
        }
        public async Task<byte[]> DownloadFileAsBytesAsync(string fileName)
        {
            var stream = await DownloadFileAsMemoryStreamAsync(fileName);
            return stream.ToArray();
        }
    }

}
