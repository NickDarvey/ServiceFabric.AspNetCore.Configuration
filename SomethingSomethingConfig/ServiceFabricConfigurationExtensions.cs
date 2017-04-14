using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingSomethingConfig
{
    public static class ServiceFabricConfigurationExtensions
    {
        public static IConfigurationBuilder AddServiceFabricConfiguration(this IConfigurationBuilder builder, ServiceContext ctx, string configPackageObjectName)
        {
            builder.Add(new ServiceFabricConfigurationSource(ctx, configPackageObjectName));
            return builder;
        }
    }
}
