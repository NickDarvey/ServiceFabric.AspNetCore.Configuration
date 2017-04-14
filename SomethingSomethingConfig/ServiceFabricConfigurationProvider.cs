using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomethingSomethingConfig
{
    internal class ServiceFabricConfigurationProvider : ConfigurationProvider
    {
        private readonly Func<ConfigurationPackage> _getConfig;

        public ServiceFabricConfigurationProvider(ServiceContext ctx, string configPackageObjectName)
        {
            _getConfig = () => ctx.CodePackageActivationContext.GetConfigurationPackageObject(configPackageObjectName);
            ctx.CodePackageActivationContext.ConfigurationPackageModifiedEvent += (sender, e) =>
            {
                Reload(e.NewPackage);
                OnReload();
            };
        }

        public override void Load() => Reload(_getConfig());

        private void Reload(ConfigurationPackage pkg)
        {
            Data.Clear();

            var configs = pkg
                .Settings.Sections
                .SelectMany(section => section.Parameters
                .Select(param => (Key: $"{section.Name}{ConfigurationPath.KeyDelimiter}{param.Name}", Value: param.Value)));

            foreach (var config in configs) { Data[config.Key] = config.Value; }
        }
    }
}
