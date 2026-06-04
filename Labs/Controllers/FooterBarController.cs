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
    ///     Provides live examples for the footer bar component.
    /// </summary>
    public class FooterBarController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the footer bar example page.
        /// </summary>
        /// <returns>The footer bar example view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}