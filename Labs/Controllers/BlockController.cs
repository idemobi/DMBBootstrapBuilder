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
    ///     Provides live examples for the block layout component.
    /// </summary>
    public class BlockController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the block layout example page.
        /// </summary>
        /// <returns>The block layout example view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}