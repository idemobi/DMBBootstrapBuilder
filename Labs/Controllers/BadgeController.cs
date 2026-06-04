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
    ///     Provides live examples for the badge component.
    /// </summary>
    public class BadgeController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the badge example page.
        /// </summary>
        /// <returns>The badge example view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}