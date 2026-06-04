#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBBootstrapBuilder;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace DMBBootstrapBuilderLabs.Controllers
{
    /// <summary>
    ///     Provides live examples for the alert component.
    /// </summary>
    public class AlertController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the alert component example page.
        /// </summary>
        /// <returns>The alert example view.</returns>
        public IActionResult Index()
        {
            SetTitle("AlertBuilder");
            SetDescription("AlertBuilder examples and showcase.");
            SetKeywords("AlertBuilder", "Alert", "DMBBootstrapBuilder", "examples");
            AddBreadcrumb(
                new AspRouteActionItem("home", IconStruct.Bootstrap("bi-house"), "Index", "Home"),
                new AspRouteActionItem("alerts", IconStruct.Bootstrap("bi-panel"), "Index", "Alert")
            );
            return View();
        }

        #endregion
    }
}