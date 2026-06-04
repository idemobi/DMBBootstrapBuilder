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
    ///     Provides live examples for the table component.
    /// </summary>
    public class TableController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the table example page.
        /// </summary>
        /// <returns>The table example view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}