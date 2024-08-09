using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.DTO
{
    public record DeviceInfoDTO
    {
        public string DeviceId { get; set; }
        public string DeviceName { get; set; } // e.g., "iPhone 12"
        public string OSVersion { get; set; } // e.g., "iOS 14.5"
        public string RefreshToken { get; set; } // The refresh token for this device
        public DateTime LastLoginTime { get; set; } // Last time this device logged in
    }
}
