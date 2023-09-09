using Luna.Core.Domain.Common.Interfaces;

namespace Luna.Core.Domain.Common.Services
{
    public interface IUserInternetProtocolAddressService : IScopedService
    {
        string IdAddress { get; }
    }
}
