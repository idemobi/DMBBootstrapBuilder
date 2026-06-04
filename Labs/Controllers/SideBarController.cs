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
    ///     Provides live examples for the sidebar component.
    /// </summary>
    public class SideBarController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the sidebar example page.
        /// </summary>
        /// <returns>The sidebar example view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}