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
    ///     Provides live examples for the breadcrumb component.
    /// </summary>
    public class BreadcrumbController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the breadcrumb example page.
        /// </summary>
        /// <returns>The breadcrumb example view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}