#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Filters;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides MVC controller behavior for BootstrapBuilder raw bootstrap pages.
    /// </summary>
    public abstract class RawBootstrapController : RawPageController
    {
        #region Constants

        private const string THEME_MODE_HEAD_SCRIPT =
            """
            (function () {
                var mode = localStorage.getItem("theme") || "auto";
                var resolved = mode;

                if (mode !== "light" && mode !== "dark") {
                    resolved = window.matchMedia("(prefers-color-scheme: dark)").matches ? "dark" : "light";
                }

                document.documentElement.setAttribute("data-bs-theme", resolved);
            })();
            """;

        #endregion

        #region Instance fields and properties

        /// <summary>
        ///     Gets the breadcrumb actions rendered by the Bootstrap page chrome.
        /// </summary>
        protected List<IActionItem> BreadcrumbActions => PageBootstrap.BreadcrumbActions;

        private PageBootstrapInformation PageBootstrap = new PageBootstrapInformation();

        #endregion

        #region Instance methods

        /// <summary>
        ///     Adds alerts to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="alerts">The alerts value.</param>
        public void AddAlerts(params AlertModel[] alerts)
        {
            PageBootstrap.Alerts.AddRange(alerts);
        }

        /// <summary>
        ///     Adds breadcrumb to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="items">The items value.</param>
        public void AddBreadcrumb(params IActionItem[] items)
        {
            PageBootstrap.BreadcrumbActions.AddRange(items);
        }

        private void CheckContainerAndSwitchable()
        {
            if (PageBootstrap.PageContainerStyle == ContainerStyle.Fluid)
            {
                PageBootstrap.PageContainerSwichable = false;
            }
        }

        /// <summary>
        ///     Executes the BootstrapBuilder on action executing operation.
        /// </summary>
        /// <param name="context">The context value.</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            Page.BodyBuilder = new BasicBootstrapBodyBuilder();
            Page.AlertManager = new BootstrapPageAlertManager();
            Page.CookieConsentComposer = BootstrapBuilderConfiguration.Config.CookieConsentComposer;

            Page.SetStylesheet(BootstrapConstants.Css, -999, PageCrossOrigin.Anonymous, BootstrapConstants.CssIntegrity);
            Page.SetScriptFile(BootstrapConstants.Javascript, PageScriptLocation.Head, PageScriptLoadingMode.Defer, -999, PageCrossOrigin.Anonymous, BootstrapConstants.JavascriptIntegrity);
            Page.SetStylesheet(BootstrapIconConstants.Css, -988, PageCrossOrigin.Anonymous);
            Page.SetScriptFile(PopperJsConstants.Css, PageScriptLocation.Head, PageScriptLoadingMode.Defer, -988, PageCrossOrigin.Anonymous, PopperJsConstants.CssIntegrity);

            Page.SetStylesheet("/css/Bootstrap_Adds.css", -977);
            Page.AddScriptInline("BootstrapThemeModeHead", THEME_MODE_HEAD_SCRIPT, PageScriptLocation.Head);

            PageBootstrapRegistry.SetPageBootstrapInformation(HttpContext, PageBootstrap);
        }

        /// <summary>
        ///     Configures page container on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="pageStyle">The page style value.</param>
        public void SetPageContainer(PageContainer pageStyle)
        {
            PageBootstrap.PageStyle = pageStyle;
            CheckContainerAndSwitchable();
        }

        /// <summary>
        ///     Configures page container style on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="style">The style value.</param>
        public void SetPageContainerStyle(ContainerStyle style)
        {
            PageBootstrap.PageContainerStyle = style;
            CheckContainerAndSwitchable();
        }

        /// <summary>
        ///     Configures page container swichable on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="swichable">The swichable value.</param>
        public void SetPageContainerSwichable(bool swichable)
        {
            PageBootstrap.PageContainerSwichable = swichable;
            CheckContainerAndSwitchable();
        }

        /// <summary>
        ///     Configures sidebar on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="sideBarComponent">The side bar component value.</param>
        public void SetSidebar(SideBarComponent sideBarComponent)
        {
            PageBootstrap.SideBar = sideBarComponent;
        }

        #endregion
    }
}