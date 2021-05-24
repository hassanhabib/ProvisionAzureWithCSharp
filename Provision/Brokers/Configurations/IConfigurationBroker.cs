using Provision.Models.Configurations;

namespace Provision.Brokers.Configurations
{
    public interface IConfigurationBroker
    {
        ProvisionConfiguration GetConfigurations();
    }
}
