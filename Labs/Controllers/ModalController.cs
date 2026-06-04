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
    ///     Provides live examples for the modal component.
    /// </summary>
    public class ModalController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the modal example page.
        /// </summary>
        /// <returns>The modal example view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}