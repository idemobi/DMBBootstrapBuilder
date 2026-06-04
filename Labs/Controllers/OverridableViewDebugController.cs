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
    ///     Provides a debug page for overridable view resolution.
    /// </summary>
    public class OverridableViewDebugController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the overridable view debug page.
        /// </summary>
        /// <returns>The debug view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}