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
    ///     Provides live examples for the pagination component.
    /// </summary>
    public class PaginationController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the pagination example page.
        /// </summary>
        /// <returns>The pagination example view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}
