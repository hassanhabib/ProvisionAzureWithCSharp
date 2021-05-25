using System.Threading.Tasks;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.Sql.Fluent;
using Provision.Models.Storages;

namespace Provision.Services.Provisions
{
    public interface IProvisionService
    {
        ValueTask<IResourceGroup> CreateResourceGroupAsync(
            string projectName,
            string environment);

        ValueTask<IAppServicePlan> CreatePlanAsync(
            string projectName,
            string environment,
            IResourceGroup resourceGroup);

        ValueTask<IWebApp> CreateWebAppAsync(
            string projectName,
            string environment,
            string databaseConnectionString,
            IResourceGroup resourceGroup,
            IAppServicePlan appServicePlan);

        ValueTask<ISqlServer> CreateSqlServerAsync(
            string projectName,
            string environment,
            IResourceGroup resourceGroup);

        ValueTask<SqlDatabase> CreateSqlDatabaseAsync(
            string projectName,
            string environment,
            ISqlServer sqlServer);
    }
}
