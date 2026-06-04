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
    ///     Provides live examples for the spinner component.
    /// </summary>
    public class SpinnerController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the spinner example page.
        /// </summary>
        /// <returns>The spinner example view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}