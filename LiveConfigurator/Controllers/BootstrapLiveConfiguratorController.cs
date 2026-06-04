#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBBootstrapBuilder;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace DMBBootstrapLiveConfigurator.Controllers;

/// <summary>
///     Provides a manual preview page for Bootstrap live configuration scenarios.
/// </summary>
public sealed class BootstrapLiveConfiguratorController : RawBootstrapController
{
    #region Instance methods

    /// <summary>
    ///     Renders a standalone Bootstrap visual validation page.
    /// </summary>
    /// <returns>A view showing normal, empty, error, and realistic sample states.</returns>
    public IActionResult Examples()
    {
        SetTitle("Bootstrap Live Examples");
        SetDescription("Standalone Bootstrap examples to validate rendering outside configurator.");
        SetKeywords("Bootstrap", "Examples", "Preview", "Theme", "DMB");
        return View();
    }

    /// <summary>
    ///     Renders the Bootstrap live configurator preview page.
    /// </summary>
    /// <returns>A view containing live configuration states and realistic sample data.</returns>
    public IActionResult Index()
    {
        SetTitle("Bootstrap Live Configurator");
        SetDescription("Interactive Bootstrap live configurator for theme parameters.");
        SetKeywords("Bootstrap", "Configurator", "Theme", "Live", "DMB");
        return View();
    }

    /// <summary>
    ///     Renders the Bootstrap live configurator preview page using a short URL.
    /// </summary>
    /// <returns>A view containing live configuration states and realistic sample data.</returns>
    [HttpGet("/bootstrap-live-configurator")]
    public IActionResult Shortcut()
    {
        return View("Index");
    }

    #endregion
}