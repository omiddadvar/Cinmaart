using Cinamaart.Application.Abstractions.Services;
using Cinamaart.Domain.Common.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Infrastructure.Services.Files
{
    public class FileService : IFileService
    {
        private const string FILESTORAGE_CONFIG_KEY = "FileSettings:FileStoragePath";
        private readonly string _fileStoragePath;

        public FileService(IConfiguration configuration)
        {
            _fileStoragePath = configuration[FILESTORAGE_CONFIG_KEY];
            _InitializeFolder();
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
        public async Task<string> UploadFileAsync(
            IFormFile file , 
            DocumentTypeEnum type = DocumentTypeEnum.SRT)
        {
            var filePath = Path.Combine(_fileStoragePath, type.ToString(), file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }
        public async Task DeleteFileAsync(string fileName , DocumentTypeEnum type)
        {
            var filePath = Path.Combine(_fileStoragePath , type.ToString(), fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        public async Task<FileStream> DownloadFileAsFileStreamAsync(string fileName, DocumentTypeEnum type)
        {
            var filePath = Path.Combine(_fileStoragePath, type.ToString(), fileName);

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found.");
            }

            return new FileStream(filePath, FileMode.Open, FileAccess.Read);
        }
        public async Task<MemoryStream> DownloadFileAsMemoryStreamAsync(string fileName, DocumentTypeEnum type)
        {
            var fileStream = await DownloadFileAsFileStreamAsync(fileName, type);
            var memoryStream = new MemoryStream();
            fileStream.CopyTo(memoryStream);
            memoryStream.Position = 0;
            return memoryStream;
        }
        public async Task<byte[]> DownloadFileAsBytesAsync(string fileName, DocumentTypeEnum type)
        {
            var stream = await DownloadFileAsMemoryStreamAsync(fileName, type);
            return stream.ToArray();
        }
    }

}
