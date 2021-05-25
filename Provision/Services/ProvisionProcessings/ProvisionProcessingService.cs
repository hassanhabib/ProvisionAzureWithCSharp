using System.Threading.Tasks;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.Sql.Fluent;
using Provision.Brokers.Configurations;
using Provision.Models.Configurations;
using Provision.Models.Storages;
using Provision.Services.Provisions;

namespace Provision.Services.ProvisionProcessings
{
    public class ProvisionProcessingService : IProvisionProcessingService
    {
        private readonly IProvisionService provisionService;
        private readonly IConfigurationBroker configurationBroker;

        public ProvisionProcessingService()
        {
            this.provisionService = new ProvisionService();
            this.configurationBroker = new ConfigurationBroker();
        }

        public async ValueTask ProvisionAsync()
        {
            ProvisionConfiguration provisionConfiguration =
                this.configurationBroker.GetConfigurations();

            string projectName = provisionConfiguration.ProjectName;

            foreach (string environment in provisionConfiguration.Environments)
            {
                IResourceGroup resourceGroup = await this.provisionService
                    .CreateResourceGroupAsync(projectName, environment);

                IAppServicePlan appServicePlan = await this.provisionService
                    .CreatePlanAsync(projectName, environment, resourceGroup);

                ISqlServer sqlServer = await this.provisionService
                    .CreateSqlServerAsync(projectName, environment, resourceGroup);

                SqlDatabase sqlDatabase = await this.provisionService
                    .CreateSqlDatabaseAsync(projectName, environment, sqlServer);

                IWebApp webApp = await this.provisionService
                    .CreateWebAppAsync(
                        projectName, 
                        environment,
                        sqlDatabase.ConnectionString,
                        resourceGroup, 
                        appServicePlan);
            }
        }
    }
}
