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
    ///     Provides live examples for the section layout component.
    /// </summary>
    public class SectionController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the section layout example page.
        /// </summary>
        /// <returns>The section layout example view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}