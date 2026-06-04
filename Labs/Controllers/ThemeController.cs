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
    ///     Provides live examples for the theme mode switcher.
    /// </summary>
    public class ThemeController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the theme mode switcher example page.
        /// </summary>
        /// <returns>The theme mode example view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}