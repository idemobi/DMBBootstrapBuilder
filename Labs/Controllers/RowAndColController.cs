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
    ///     Provides live examples for the Bootstrap row and column grid system.
    /// </summary>
    public class RowAndColController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the row and column grid example page.
        /// </summary>
        /// <returns>The row and column example view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}