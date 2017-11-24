using Microsoft.Extensions.Configuration;
using System.Fabric;

namespace SomethingSomethingConfig
{
    internal class ServiceFabricConfigurationSource : IConfigurationSource
    {
        private readonly ICodePackageActivationContext _ctx;
        private readonly string _configPackageObjectName;

        public ServiceFabricConfigurationSource(ICodePackageActivationContext ctx, string configPackageObjectName)
        {
            _ctx = ctx;
            _configPackageObjectName = configPackageObjectName;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder) =>
            new ServiceFabricConfigurationProvider(_ctx, _configPackageObjectName);
    }
}
