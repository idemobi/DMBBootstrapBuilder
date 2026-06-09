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
    ///     Provides live examples for the title component.
    /// </summary>
    public class TitleController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Renders the title component example page.
        /// </summary>
        /// <returns>The title example view.</returns>
        public IActionResult Index()
        {
            SetPageContainer(PageContainer.ContainerPage);
            SetPageContainerStyle(ContainerStyle.Default);
            SetDescription("Title");
            SetKeywords("title", "component", "bootstrap");
            return View();
        }

        #endregion
    }
}