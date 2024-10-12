using Cinamaart.Domain.Common.Enums;
using Microsoft.AspNetCore.Http;

namespace Cinamaart.Application.Abstractions.Services
{
    public interface IFileService
    {
        Task<bool> UploadFileAsync(IFormFile file, string? filename = null);
        Task<FileStream> DownloadFileAsFileStreamAsync(string fileName);
        Task<MemoryStream> DownloadFileAsMemoryStreamAsync(string fileName);
        Task<byte[]> DownloadFileAsBytesAsync(string fileName);
        Task DeleteFileAsync(string fileName);
    }
}
