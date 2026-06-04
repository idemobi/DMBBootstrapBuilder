#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapLiveConfigurator.Configuration;

/// <summary>
///     Represents options used by the Bootstrap live configurator module.
/// </summary>
public sealed class BootstrapLiveConfiguratorOptions
{
    #region Instance fields and properties

    /// <summary>
    ///     Gets or sets the route used to render the live configurator demo page.
    /// </summary>
    public string Route { get; set; } = "/bootstrap-live-configurator";

    #endregion
}