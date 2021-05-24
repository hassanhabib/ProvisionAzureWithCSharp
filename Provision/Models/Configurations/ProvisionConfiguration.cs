using System.Collections.Generic;

namespace Provision.Models.Configurations
{
    public class ProvisionConfiguration
    {
        public string ProjectName { get; set; }
        public List<string> Environments { get; set; }
    }
}
