using System.Threading.Tasks;

namespace Provision.Services.ProvisionProcessings
{
    public interface IProvisionProcessingService
    {
        ValueTask ProvisionAsync();
    }
}
