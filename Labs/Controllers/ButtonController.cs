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
    ///     Provides live examples for the button component.
    /// </summary>
    public class ButtonController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the button example page.
        /// </summary>
        /// <returns>The button example view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}