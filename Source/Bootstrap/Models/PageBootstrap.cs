#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Collections.Generic;
using DMBPageBuilder;
using Microsoft.AspNetCore.Http;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the BootstrapBuilder page bootstrap information component or support type.
    /// </summary>
    public class PageBootstrapInformation
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the alerts value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public List<AlertModel> Alerts { set; get; } = new List<AlertModel>();

        /// <summary>
        ///     Gets or sets the breadcrumb actions value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public List<IActionItem> BreadcrumbActions { set; get; } = new List<IActionItem>();

        /// <summary>
        ///     Gets or sets the page container style value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public ContainerStyle PageContainerStyle { set; get; } = ContainerStyle.Lg;

        /// <summary>
        ///     Gets or sets the page container swichable value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool PageContainerSwichable { set; get; } = true;

        /// <summary>
        ///     Gets or sets the page style value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public PageContainer PageStyle { set; get; } = PageContainer.ContainerPage;

        /// <summary>
        ///     Gets or sets the side bar value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public SideBarComponent? SideBar { set; get; }

        #endregion
    }

    /// <summary>
    ///     Represents the BootstrapBuilder page bootstrap registry component or support type.
    /// </summary>
    public class PageBootstrapRegistry
    {
        #region Constants

        const string PageInformationKey = $"__{nameof(PageBootstrapRegistry)}_PageBootstrapInformation__";
        const string SideBarKey = $"__{nameof(PageBootstrapRegistry)}_SideBarComponent__";

        #endregion

        #region Static methods

        /// <summary>
        ///     Gets page information for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="httpContext">The http context value.</param>
        /// <returns>The configured <see cref="PageBootstrapInformation" /> value or BootstrapBuilder result.</returns>
        public static PageBootstrapInformation GetPageInformation(HttpContext? httpContext)
        {
            if (httpContext == null)
            {
                return new PageBootstrapInformation();
            }

            if (httpContext.Items.TryGetValue(PageInformationKey, out object? value) && value is PageBootstrapInformation existing)
            {
                return existing;
            }

            return new PageBootstrapInformation();
        }

        /// <summary>
        ///     Gets side bar component for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="httpContext">The http context value.</param>
        /// <returns>The configured <see cref="SideBarComponent" /> value or BootstrapBuilder result.</returns>
        public static SideBarComponent? GetSideBarComponent(HttpContext? httpContext)
        {
            if (httpContext == null)
            {
                return null;
            }

            if (httpContext.Items.TryGetValue(SideBarKey, out object? value) && value is SideBarComponent existing)
            {
                return existing;
            }

            return null;
        }

        /// <summary>
        ///     Configures page bootstrap information on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="httpContext">The http context value.</param>
        /// <param name="page">The page information used during BootstrapBuilder rendering.</param>
        public static void SetPageBootstrapInformation(HttpContext httpContext, PageBootstrapInformation page)
        {
            httpContext.Items[PageInformationKey] = page;
        }

        /// <summary>
        ///     Configures side bar component on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="httpContext">The http context value.</param>
        /// <param name="sideBarComponent">The side bar component value.</param>
        public static void SetSideBarComponent(HttpContext httpContext, SideBarComponent sideBarComponent)
        {
            httpContext.Items[SideBarKey] = sideBarComponent;
        }

        #endregion
    }
}