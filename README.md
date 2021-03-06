# ServiceFabric.AspNetCore.Configuration
A library that unites Service Fabric's config packages and ASP.NET Core's configuration.

## Usage
Install it from [NuGet](https://www.nuget.org/packages/NickDarvey.ServiceFabric.AspNetCore.Configuration/), `Install-Package NickDarvey.ServiceFabric.AspNetCore.Configuration`,
and add the the providers to your startup class
```
public class Startup
{
    public Startup(IHostingEnvironment env)
    {
        var builder = new ConfigurationBuilder()
            .AddServiceFabricConfiguration(
                ctx: FabricRuntime.GetActivationContext(), configPackageObjectName: "Config");
        Configuration = builder.Build();
    }
}
```

then if you add a section to your service's `Settings.xml`

```
<Section Name="Authorization">
    <Parameter Name="Audience" Value="https://api.coolthingimade.io/myservice"/>
    <Parameter Name="Authority" MustOverride="true" Value=""/>
</Section>
```

you can access it like

```
var options = new JwtBearerOptions
{
    Audience = Configuration["Authorization:Audience"],
    Authority = Configuration["Authorization:Authority"]
};
app.UseJwtBearerAuthentication(options);
```
