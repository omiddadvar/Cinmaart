using Cinamaart.Application.Abstractions;
using Cinamaart.Application.DTO;
using Newtonsoft.Json;
using StackExchange.Redis;


namespace Cinamaart.Infrastructure.Services.Device
{
    public class UserDeviceService(IConnectionMultiplexer redis) : IUserDeviceService
    {
        public async Task SaveDeviceInfoAsync(long userId, DeviceInfoDTO deviceInfo)
        {
            var db = redis.GetDatabase();
            var key = $"{userId}:{deviceInfo.DeviceId}";

            // Convert DeviceInfo to JSON
            var jsonDeviceInfo = JsonConvert.SerializeObject(deviceInfo);

            // Save in Redis
            await db.StringSetAsync(key, jsonDeviceInfo);
        }
        public async Task<DeviceInfoDTO?> GetDeviceInfoAsync(long userId, string deviceId)
        {
            var db = redis.GetDatabase();
            var key = $"{userId}:{deviceId}";

            var jsonDeviceInfo = await db.StringGetAsync(key);
            if (jsonDeviceInfo.IsNullOrEmpty)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<DeviceInfoDTO>(jsonDeviceInfo);
        }
        public async Task<List<DeviceInfoDTO>> GetDeviceInfoForAllDevicesAsync(string userId)
        {
            var db = redis.GetDatabase();
            var server = redis.GetServer(redis.GetEndPoints().First());

            // Fetch all keys for the user
            var keys = server.Keys(pattern: $"{userId}:*").ToList();

            var deviceInfoList = new List<DeviceInfoDTO>();

            foreach (var key in keys)
            {
                var jsonDeviceInfo = await db.StringGetAsync(key);

                if (!jsonDeviceInfo.IsNullOrEmpty)
                {
                    var deviceInfo = JsonConvert.DeserializeObject<DeviceInfoDTO>(jsonDeviceInfo);
                    deviceInfoList.Add(deviceInfo);
                }
            }

            return deviceInfoList;
        }

        public async Task DeleteDeviceInfoAsync(long userId, string deviceId)
        {
            var db = redis.GetDatabase();
            var key = $"{userId}:{deviceId}";

            await db.KeyDeleteAsync(key);
        }
    }
}
