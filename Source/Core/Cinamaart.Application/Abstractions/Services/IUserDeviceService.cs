using Cinamaart.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Abstractions.Services
{
    public interface IUserDeviceService
    {
        Task SaveDeviceInfoAsync(long userId, DeviceInfoDTO deviceInfo);
        Task<DeviceInfoDTO?> GetDeviceInfoAsync(long userId, string deviceId);
        Task<List<DeviceInfoDTO>> GetDeviceInfoForAllDevicesAsync(string userId);
        Task DeleteDeviceInfoAsync(long userId, string deviceId);
    }
}
