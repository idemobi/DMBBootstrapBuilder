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
    ///     Provides live examples for the progress bar component.
    /// </summary>
    public class ProgressController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the progress bar example page.
        /// </summary>
        /// <returns>The progress bar example view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}