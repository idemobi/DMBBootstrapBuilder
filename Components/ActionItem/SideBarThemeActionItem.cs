#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj SideBarThemeActionItem.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder side bar theme action item component or support type.
    /// </summary>
    public sealed class SideBarThemeActionItem : JavaScriptActionItem
    {
        #region Constants

        private const string SCRIPT_INLINE =
            """
            (function () {
                var theme = localStorage.getItem('theme_sidebar') || 'default';

                switch ((theme || "").toLowerCase()) {
                    case "default":
                    case "light":
                    case "dark":
                    case "transparent":
                    case "primary":
                    case "inversed":
                        break;
                    case "colored":
                        theme = 'default';
                        break;
                    default:
                        theme = 'default';
                        break;
                }

                function apply() {
                    if (!document.body) {
                        return false;
                    }

                    document.body.setAttribute('sidebar', theme);
                    return true;
                }

                if (!apply()) {
                    document.addEventListener('DOMContentLoaded', apply, { once: true });
                }
            })();
            """;

        #endregion

        #region Static methods

        private static string BuildJavaScript(SideBarTheme sideBarTheme)
        {
            return $"DMBSideBarTheme.set('{GetThemeValue(sideBarTheme)}'); return false;";
        }

        private static string GetThemeValue(SideBarTheme sideBarTheme)
        {
            return sideBarTheme switch
            {
                SideBarTheme.Default => "default",
                SideBarTheme.Light => "light",
                SideBarTheme.Dark => "dark",
                SideBarTheme.Transparent => "transparent",
                SideBarTheme.Colored => "colored",
                SideBarTheme.Primary => "primary",
                SideBarTheme.Inversed => "inversed",
                _ => "default"
            };
        }

        #endregion

        #region Instance fields and properties

        /// <summary>
        /// Gets or sets the side bar theme value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public SideBarTheme SideBarTheme { set; get; }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SideBarThemeActionItem"/> class.
        /// </summary>
        public SideBarThemeActionItem()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SideBarThemeActionItem"/> class.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="sideBarTheme">The side bar theme value.</param>
        public SideBarThemeActionItem(IHtmlHelper html, SideBarTheme sideBarTheme)
            : base(BuildJavaScript(sideBarTheme))
        {
            InstallAsset(html);
            SideBarTheme = sideBarTheme;
            SetAttribut("data-dmb-setting", "sidebar-theme");
            SetAttribut("data-dmb-value", GetThemeValue(sideBarTheme));
            SetAttribut("data-dmb-role", "sidebar-theme-action");
        }

        #endregion

        #region Instance methods

        /// <summary>
        /// Executes the BootstrapBuilder install asset operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public void InstallAsset(IHtmlHelper html)
        {
            PageInformation page = PageRegistry.GetOrCreatePageInformation(html.ViewContext.HttpContext);
            page.SetScriptFile("/js/SideBarTheme.js");
            page.SetStylesheet("/css/SideBarTheme.css");
            page.AddScriptInline("SideBarTheme", SCRIPT_INLINE);
        }

        /// <summary>
        /// Configures mode on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="sideBarTheme">The side bar theme value.</param>
        /// <returns>The configured <see cref="SideBarThemeActionItem"/> value or BootstrapBuilder result.</returns>
        public SideBarThemeActionItem WithMode(SideBarTheme sideBarTheme)
        {
            SideBarTheme = sideBarTheme;
            return this;
        }

        #endregion
    }
}
