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
    ///     Provides live examples for the navigation bar component.
    /// </summary>
    public class NavBarController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the navigation bar example page.
        /// </summary>
        /// <returns>The navigation bar example view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}