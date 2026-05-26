#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj BreadcrumbToggleActionItem.cs create at 2026/05/18 13:56:18
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder breadcrumb visibility toggle action item component.
    /// </summary>
    public sealed class BreadcrumbToggleActionItem : LayoutToggleActionItemBase
    {
        #region Constants

        private const string SCRIPT_INLINE =
            """
            (function () {
                var enabled = localStorage.getItem('layout_breadcrumb') !== 'false';
                document.documentElement.setAttribute('data-layout-breadcrumb', enabled ? 'true' : 'false');
            })();
            """;

        #endregion

        #region Instance fields and properties

        /// <summary>
        /// Gets or sets the setting key value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public override string SettingKey => "breadcrumb";

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BreadcrumbToggleActionItem"/> class.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="value">The value to apply.</param>
        public BreadcrumbToggleActionItem(IHtmlHelper html, bool value)
            : base(value)
        {
            PageInformation page = PageRegistry.GetOrCreatePageInformation(html.ViewContext.HttpContext);
            page.SetScriptFile("/js/BreadcrumbMode.js");
            page.SetStylesheet("/css/BreadcrumbMode.css");
            page.AddScriptInline("BreadcrumbToggle", SCRIPT_INLINE);
            SwitchJavaScript = "BreadcrumbModeMethod.set(this.checked);";
            ConfigureStateAttributes();
        }

        #endregion
    }
}
