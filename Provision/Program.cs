using System.Threading.Tasks;
using Provision.Services.ProvisionProcessings;

namespace Provision
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            IProvisionProcessingService provisionProcessingService =
                new ProvisionProcessingService();

            await provisionProcessingService.ProvisionAsync();
        }
    }
}
