#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Net;
using DMBPageBuilder;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the BootstrapBuilder nav brand logo component component or support type.
    /// </summary>
    public sealed class NavBrandLogoComponent : NavbarComponentBase
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the logo path value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string LogoPath { get; set; } = "/logo/logo.png";

        /// <summary>
        ///     Gets or sets the url value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string Url { get; set; } = "/";

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="NavBrandLogoComponent" /> class.
        /// </summary>
        /// <param name="url">The url value.</param>
        public NavBrandLogoComponent(string? url = "/")
        {
            Url = string.IsNullOrWhiteSpace(url) ? "/" : url;
        }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Renders value for the BootstrapBuilder output.
        /// </summary>
        /// <param name="htmlHelper">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The rendered HTML content for the BootstrapBuilder component.</returns>
        public override IHtmlContent Render(IHtmlHelper htmlHelper)
        {
            if (htmlHelper == null)
            {
                throw new ArgumentNullException(nameof(htmlHelper));
            }

            string css = BuildCommonCss("navbar-brand");
            return new HtmlString($"""<a class="{WebUtility.HtmlEncode(css)}" href="{WebUtility.HtmlEncode(Url)}"><img class="nav-brand-logo" src="{LogoPath}" alt="logo" height="40px" width="40px"></a>""");
        }

        #endregion
    }

    /// <summary>
    ///     Represents the BootstrapBuilder nav brand component component or support type.
    /// </summary>
    public sealed class NavBrandComponent : NavbarComponentBase
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the icon value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public IconStruct Icon { get; set; }

        /// <summary>
        ///     Gets or sets the text value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        ///     Gets or sets the url value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string Url { get; set; } = "/";

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="NavBrandComponent" /> class.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <param name="url">The url value.</param>
        /// <param name="icon">The icon value.</param>
        public NavBrandComponent(string? text = null, string? url = "/", IconStruct icon = default)
        {
            Text = text;
            Url = string.IsNullOrWhiteSpace(url) ? "/" : url;
            Icon = icon;
        }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Renders value for the BootstrapBuilder output.
        /// </summary>
        /// <param name="htmlHelper">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The rendered HTML content for the BootstrapBuilder component.</returns>
        public override IHtmlContent Render(IHtmlHelper htmlHelper)
        {
            if (htmlHelper == null)
            {
                throw new ArgumentNullException(nameof(htmlHelper));
            }

            string iconHtml = Icon.IsEmpty
                ? string.Empty
                : HtmlLayoutExtensions.IconBuilder(htmlHelper, Icon).ToString() ?? string.Empty;

            string textHtml = WebUtility.HtmlEncode(Text ?? string.Empty);
            string css = BuildCommonCss("navbar-brand");

            return new HtmlString($"""
                                   <a class="{WebUtility.HtmlEncode(css)} d-inline-flex gap-1" href="{WebUtility.HtmlEncode(Url)}">
                                       {iconHtml}{textHtml}
                                   </a>
                                   """);
        }

        #endregion
    }
}