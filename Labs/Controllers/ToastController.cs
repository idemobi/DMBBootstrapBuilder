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
    ///     Provides live examples for the toast notification component.
    /// </summary>
    public class ToastController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the toast notification example page.
        /// </summary>
        /// <returns>The toast example view.</returns>
        public IActionResult Index()
        {
            SetTitle("ToastBuilder");
            SetDescription("ToastBuilder examples and documentation entry point for DMBBootstrapBuilder.");
            SetKeywords("ToastBuilder", "Toast", "Bootstrap toast", "DMBBootstrapBuilder", "examples");
            return View();
        }

        #endregion
    }
}