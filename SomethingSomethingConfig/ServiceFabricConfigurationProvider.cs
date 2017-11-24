using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;

namespace SomethingSomethingConfig
{
    internal class ServiceFabricConfigurationProvider : ConfigurationProvider
    {
        private readonly Func<ConfigurationPackage> _getConfig;

        public ServiceFabricConfigurationProvider(ICodePackageActivationContext ctx, string configPackageObjectName)
        {
            _getConfig = () => ctx.GetConfigurationPackageObject(configPackageObjectName);
            ctx.ConfigurationPackageModifiedEvent += (sender, e) =>
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
                .Select(param => new KeyValuePair<string, string>($"{section.Name}{ConfigurationPath.KeyDelimiter}{param.Name}", param.Value)));

            foreach (var config in configs) { Data[config.Key] = config.Value; }
        }
    }
}
