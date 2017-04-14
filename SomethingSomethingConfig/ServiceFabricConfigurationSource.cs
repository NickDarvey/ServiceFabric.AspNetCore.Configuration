using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingSomethingConfig
{
    internal class ServiceFabricConfigurationSource : IConfigurationSource
    {
        private readonly ServiceContext _ctx;
        private readonly string _configPackageObjectName;

        public ServiceFabricConfigurationSource(ServiceContext ctx, string configPackageObjectName)
        {
            _ctx = ctx;
            _configPackageObjectName = configPackageObjectName;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder) =>
            new ServiceFabricConfigurationProvider(_ctx, _configPackageObjectName);
    }
}
