using System.Threading.Tasks;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.Sql.Fluent;
using Provision.Brokers.Clouds;
using Provision.Brokers.Loggings;

namespace Provision.Services.Provisions
{
    public class ProvisionService : IProvisionService
    {
        private readonly ICloudBroker cloudBroker;
        private readonly ILoggingBroker loggingBroker;

        public ProvisionService()
        {
            this.cloudBroker = new CloudBroker();
            this.loggingBroker = new LoggingBroker();
        }

        public async ValueTask<ISqlDatabase> CreateSqlDatabaseAsync(
            string projectName,
            string environment,
            ISqlServer sqlServer)
        {
            string sqlDatabaseName = $"{projectName}-db-{environment}".ToLower();
            this.loggingBroker.LogActivity($"Creating {sqlDatabaseName} ...");

            ISqlDatabase sqlDatabase = await this.cloudBroker
                .CreateSqlDatabaseAsync(sqlDatabaseName, sqlServer);

            this.loggingBroker.LogActivity($"{sqlDatabaseName} Created");

            return sqlDatabase;
        }

        public async ValueTask<ISqlServer> CreateSqlServerAsync(
            string projectName,
            string environment,
            IResourceGroup resourceGroup)
        {
            string sqlServerName = $"{projectName}-dbserver-{environment}".ToLower();
            this.loggingBroker.LogActivity($"Creating {sqlServerName} ...");

            ISqlServer sqlServer = await this.cloudBroker
                .CreateSqlServerAsync(sqlServerName, resourceGroup);

            this.loggingBroker.LogActivity($"{sqlServerName} Created");

            return sqlServer;
        }

        public async ValueTask<IWebApp> CreateWebAppAsync(
            string projectName,
            string environment,
            IResourceGroup resourceGroup,
            IAppServicePlan appServicePlan)
        {
            string webAppName = $"{projectName}-{environment}".ToLower();
            this.loggingBroker.LogActivity($"Creating {webAppName} ...");

            IWebApp webApp = await this.cloudBroker
                .CreateWebAppAsync(webAppName, appServicePlan, resourceGroup);

            this.loggingBroker.LogActivity($"{webAppName} Created");

            return webApp;
        }

        public async ValueTask<IAppServicePlan> CreatePlanAsync(
            string projectName,
            string environment,
            IResourceGroup resourceGroup)
        {
            string planName = $"{projectName}-PLAN-{environment}".ToUpper();
            this.loggingBroker.LogActivity($"Creating {planName} ...");

            IAppServicePlan plan = await this.cloudBroker
                .CreatePlanAsync(planName, resourceGroup);

            this.loggingBroker.LogActivity($"{planName} Created");

            return plan;
        }

        public async ValueTask<IResourceGroup> CreateResourceGroupAsync(
            string projectName,
            string environment)
        {
            string resourceGroupName = $"{projectName}-RESOURCES-{environment}".ToUpper();
            this.loggingBroker.LogActivity($"Creating {resourceGroupName} ...");

            IResourceGroup resourceGroup = await this.cloudBroker
                .CreateResourceGroupAsync(resourceGroupName);

            this.loggingBroker.LogActivity($"{resourceGroupName} Created");

            return resourceGroup;
        }
    }
}
