#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBPageBuilder;
using DMBServerWebHelper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

#endregion

namespace DMBBootstrapLiveConfigurator;

/// <summary>
///     Provides configuration bootstrap for the DMBBootstrapLiveConfigurator package.
/// </summary>
[Serializable]
public sealed class BootstrapLiveConfiguratorConfiguration : WebGenericConfiguration<BootstrapLiveConfiguratorConfiguration>, IServerWebConfig
{
    #region Instance methods

    #region From interface IServerWebConfig

    /// <summary>
    ///     Applies service configuration after host configuration is loaded.
    /// </summary>
    /// <param name="appBuilder">The host application builder.</param>
    /// <param name="configBuilder">The configuration builder.</param>
    /// <param name="configRoot">The configuration root.</param>
    public override void AfterConfiguration(IHostApplicationBuilder appBuilder, IConfigurationBuilder configBuilder, IConfigurationRoot configRoot)
    {
        appBuilder.Services.ConfigureOptions<BootstrapLiveConfiguratorConfigureOptions>();
        appBuilder.Services.RegisterGlobalScriptAsset(
            key: "DMBBootstrapLiveConfigurator.GlobalTheme",
            url: "/js/BootstrapLiveConfigurator.GlobalTheme.js",
            location: PageScriptLocation.Head,
            loadingMode: PageScriptLoadingMode.Defer,
            order: 998
        );
    }

    /// <summary>
    ///     Indicates whether API description generation is required.
    /// </summary>
    /// <returns><see langword="false" /> because this package does not expose API endpoints.</returns>
    public override bool ApiDescription()
    {
        return false;
    }

    /// <summary>
    ///     Executes tasks before configuration is loaded.
    /// </summary>
    /// <param name="appBuilder">The host application builder.</param>
    /// <param name="configBuilder">The configuration builder.</param>
    /// <param name="configRoot">The configuration root.</param>
    public override void BeforeConfiguration(IHostApplicationBuilder appBuilder, IConfigurationBuilder configBuilder, IConfigurationRoot configRoot)
    {
    }

    /// <summary>
    ///     Indicates whether this package requires app settings.
    /// </summary>
    /// <returns><see langword="false" /> because the default configuration is self-contained.</returns>
    public override bool NeedsConfigFileOrAppSettings()
    {
        return false;
    }

    /// <summary>
    ///     Executes test randomization hooks.
    /// </summary>
    public override void RandomFake()
    {
    }

    #endregion

    #endregion
}