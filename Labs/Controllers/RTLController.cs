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
    ///     Provides live examples for the RTL direction toggle.
    /// </summary>
    public class RTLController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the RTL toggle example page.
        /// </summary>
        /// <returns>The RTL toggle example view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}