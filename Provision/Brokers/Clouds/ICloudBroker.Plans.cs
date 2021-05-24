﻿using System.Threading.Tasks;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;

namespace Provision.Brokers.Clouds
{
    public partial interface ICloudBroker
    {
        ValueTask<IAppServicePlan> CreatePlanAsync(string planName, IResourceGroup resourceGroup);
    }
}
