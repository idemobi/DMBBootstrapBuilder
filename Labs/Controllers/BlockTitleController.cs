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
    ///     Provides live examples for the block title component.
    /// </summary>
    public class BlockTitleController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the block title example page.
        /// </summary>
        /// <returns>The block title example view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}