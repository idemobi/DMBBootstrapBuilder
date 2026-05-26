#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ThemeModeActionItem.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder theme mode action item component or support type.
    /// </summary>
    public sealed class ThemeModeActionItem : JavaScriptActionItem
    {
        #region Static methods

        private static string BuildJavaScript(ThemeMode themeMode)
        {
            string value = GetThemeModeValue(themeMode);
            return $"ThemeMode.set('{value}'); return false;";
        }

        private static string GetThemeModeValue(ThemeMode themeMode)
        {
            return themeMode switch
            {
                ThemeMode.Light => "light",
                ThemeMode.Dark => "dark",
                _ => "auto"
            };
        }

        #endregion

        #region Instance fields and properties

        /// <summary>
        /// Gets or sets the theme mode value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public ThemeMode ThemeMode { get; }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ThemeModeActionItem"/> class.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="themeMode">The theme mode value.</param>
        public ThemeModeActionItem(IHtmlHelper html, ThemeMode themeMode)
            : base(BuildJavaScript(themeMode))
        {
            PageInformation page = PageRegistry.GetOrCreatePageInformation(html.ViewContext.HttpContext);
            page.SetScriptFile("/js/ThemeMode.js");
            // page.SetStylesheet( "/css/ThemeMode.css");

            ThemeMode = themeMode;
            SetAttribut("data-dmb-setting", "theme-mode");
            SetAttribut("data-dmb-value", GetThemeModeValue(themeMode));
            SetAttribut("data-dmb-role", "theme-mode-action");
        }

        #endregion
    }
}
