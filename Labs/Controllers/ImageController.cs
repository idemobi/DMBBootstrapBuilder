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
    ///     Provides live examples for the image component.
    /// </summary>
    public class ImageController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the image component example page.
        /// </summary>
        /// <returns>The image example view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}