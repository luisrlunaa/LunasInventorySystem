// Ignore Spelling: Accessor

using Luna.Core.Domain.Common.Services;
using Microsoft.AspNetCore.Http;

namespace Luna.Infrastructure.Services
{
    public class UserInternetProtocolAddressService : IUserInternetProtocolAddressService
    {
        public IHttpContextAccessor HttpContextAccessor { get; }

        private string _IpAddress = string.Empty;

        public string IdAddress
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_IpAddress))
                {
                    return _IpAddress;
                }

                if (HttpContextAccessor.HttpContext != null)
                {
                    var tempIp = string.Empty;
                    if (HttpContextAccessor.HttpContext!.Request.Headers.ContainsKey("X-Forwarded-For"))
                    {
                        tempIp = HttpContextAccessor.HttpContext.Request.Headers["X-Forwarded-For"].ToString();
                    }
                    else
                    {
                        tempIp = HttpContextAccessor.HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
                    }
                    var str = tempIp ?? "N/A";
                    _IpAddress = str;
                }

                return _IpAddress;
            }
        }

        public UserInternetProtocolAddressService(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }
    }
}
