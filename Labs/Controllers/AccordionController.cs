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
    ///     Provides live examples for the accordion component.
    /// </summary>
    public class AccordionController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the accordion example page.
        /// </summary>
        /// <returns>The accordion example view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}