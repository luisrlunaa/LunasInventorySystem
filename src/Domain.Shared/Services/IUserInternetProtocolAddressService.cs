using Luna.Core.Domain.Common.Common.Contracts;

namespace Luna.Core.Domain.Common.Services
{
    public interface IUserInternetProtocolAddressService : IScopedService
    {
        string IdAddress { get; }
    }
}
