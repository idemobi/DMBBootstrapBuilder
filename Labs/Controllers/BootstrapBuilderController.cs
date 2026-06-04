#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBBootstrapBuilder;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace DMBBootstrapBuilderLabs.Controllers
{
    /// <summary>
    ///     Provides documentation pages for <see cref="DMBBootstrapBuilder.BootstrapBuilderConfiguration" />.
    /// </summary>
    public class BootstrapBuilderController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the BootstrapBuilder architecture page.
        /// </summary>
        /// <returns>The architecture view.</returns>
        public IActionResult Architecture()
        {
            SetTitle("BootstrapBuilder - Architecture");
            SetDescription("BootstrapBuilder architecture");
            SetKeywords("BootstrapBuilder", "DMBBootstrapBuilder", "Architecture", "ASP.NET Core");
            return View();
        }

        /// <summary>
        ///     Renders the BootstrapBuilder getting started page.
        /// </summary>
        /// <returns>The getting started view.</returns>
        public IActionResult GettingStarted()
        {
            SetTitle("BootstrapBuilder - Getting Started");
            SetDescription("BootstrapBuilder getting started guide");
            SetKeywords("BootstrapBuilder", "DMBBootstrapBuilder", "Getting Started", "NuGet", "ASP.NET Core");
            return View();
        }

        /// <summary>
        ///     Renders the BootstrapBuilder introduction page.
        /// </summary>
        /// <returns>The introduction view.</returns>
        public IActionResult Introduction()
        {
            SetTitle("BootstrapBuilder - Introduction");
            SetDescription("BootstrapBuilder");
            SetKeywords("BootstrapBuilder", "DMBBootstrapBuilder", "NuGet", "ASP.NET Core");
            return View();
        }

        /// <summary>
        ///     Renders the BootstrapBuilder rendering pipeline page.
        /// </summary>
        /// <returns>The rendering pipeline view.</returns>
        public IActionResult RenderingPipeline()
        {
            SetTitle("BootstrapBuilder - Rendering Pipeline");
            SetDescription("BootstrapBuilder rendering pipeline");
            SetKeywords("BootstrapBuilder", "DMBBootstrapBuilder", "Rendering Pipeline", "ASP.NET Core");
            return View();
        }

        #endregion
    }
}
