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
    ///     Provides live examples for the card component.
    /// </summary>
    public class CardController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the card example page.
        /// </summary>
        /// <returns>The card example view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}