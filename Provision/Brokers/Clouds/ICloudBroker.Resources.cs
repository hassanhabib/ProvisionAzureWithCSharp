using System.Threading.Tasks;
using Microsoft.Azure.Management.ResourceManager.Fluent;

namespace Provision.Brokers.Clouds
{
    public partial interface ICloudBroker
    {
        ValueTask<IResourceGroup> CreateResourceGroupAsync(string resourceGroupName);
    }
}
