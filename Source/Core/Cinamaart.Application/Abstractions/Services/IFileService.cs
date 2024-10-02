using Cinamaart.Domain.Common.Enums;
using Microsoft.AspNetCore.Http;

namespace Cinamaart.Application.Abstractions.Services
{
    public interface IFileService
    {
        Task<bool> UploadFileAsync(IFormFile file, DocumentTypeEnum type);
        Task<FileStream> DownloadFileAsFileStreamAsync(string fileName, DocumentTypeEnum type);
        Task<MemoryStream> DownloadFileAsMemoryStreamAsync(string fileName, DocumentTypeEnum type);
        Task<byte[]> DownloadFileAsBytesAsync(string fileName, DocumentTypeEnum type);
        Task DeleteFileAsync(string fileName, DocumentTypeEnum type);
    }
}
