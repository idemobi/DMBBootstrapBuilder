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
    ///     Provides live examples for the fluid layout toggle.
    /// </summary>
    public class FluidController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the fluid layout toggle example page.
        /// </summary>
        /// <returns>The fluid toggle example view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}