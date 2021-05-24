using System.IO;
using Microsoft.Extensions.Configuration;
using Provision.Models.Configurations;

namespace Provision.Brokers.Configurations
{
    public class ConfigurationBroker : IConfigurationBroker
    {
        public ProvisionConfiguration GetConfigurations()
        {
            IConfigurationRoot configurations = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();

            return configurations.Get<ProvisionConfiguration>();
        }
    }
}
