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
    ///     Provides live examples for the tabs component.
    /// </summary>
    public class TabsController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the tabs example page.
        /// </summary>
        /// <returns>The tabs example view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}