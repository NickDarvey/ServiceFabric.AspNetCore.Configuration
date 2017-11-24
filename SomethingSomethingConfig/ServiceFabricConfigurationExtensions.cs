using Microsoft.Extensions.Configuration;
using System.Fabric;

namespace SomethingSomethingConfig
{
    public static class ServiceFabricConfigurationExtensions
    {
        public static IConfigurationBuilder AddServiceFabricConfiguration(this IConfigurationBuilder builder, ICodePackageActivationContext ctx, string configPackageObjectName)
        {
            builder.Add(new ServiceFabricConfigurationSource(ctx, configPackageObjectName));
            return builder;
        }
    }
}
