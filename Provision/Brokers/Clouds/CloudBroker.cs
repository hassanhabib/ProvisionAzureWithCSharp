using System;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Provision.Brokers.Clouds
{
    public partial class CloudBroker : ICloudBroker
    {
        private readonly string clientId;
        private readonly string clientSecret;
        private readonly string clientTenantId;
        private readonly string adminName;
        private readonly string adminAccess;
        private readonly IAzure azure;

        public CloudBroker()
        {
            this.clientId = Environment.GetEnvironmentVariable("AzureClientId");
            this.clientSecret = Environment.GetEnvironmentVariable("AzureClientSecret");
            this.clientTenantId = Environment.GetEnvironmentVariable("AzureTenantId");
            this.adminName = Environment.GetEnvironmentVariable("AzureAdminName");
            this.adminAccess = Environment.GetEnvironmentVariable("AzureAdminAccess");
            this.azure = AuthenticateAzure();
        }

        private IAzure AuthenticateAzure()
        {
            var creds = SdkContext.AzureCredentialsFactory.FromServicePrincipal(
                clientId: this.clientId,
                clientSecret: this.clientSecret,
                tenantId: this.clientTenantId,
                environment: AzureEnvironment.AzureGlobalCloud);

            return Azure.Configure()
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                .Authenticate(creds)
                .WithDefaultSubscription();
        }
    }
}
