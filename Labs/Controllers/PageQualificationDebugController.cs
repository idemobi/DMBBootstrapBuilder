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
    ///     Provides a debug page for page qualification diagnostics.
    /// </summary>
    public class PageQualificationDebugController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the page qualification debug page.
        /// </summary>
        /// <returns>The debug view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}