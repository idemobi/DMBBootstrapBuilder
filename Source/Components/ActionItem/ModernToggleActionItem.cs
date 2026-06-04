#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the BootstrapBuilder modern toggle action item component or support type.
    /// </summary>
    public sealed class ModernToggleActionItem : LayoutToggleActionItemBase
    {
        #region Constants

        private const string SCRIPT_INLINE =
            """
            (function () {
                var enabled = localStorage.getItem('layout_modern') === 'true';
                function apply() {
                    if (!document.body) {return false;}
                    document.body.setAttribute('data-layout-modern', enabled ? 'true' : 'false');
                    return true;
                }
                if (!apply()) {document.addEventListener('DOMContentLoaded', apply, { once: true });}
            })();
            """;

        #endregion

        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the setting key value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public override string SettingKey => "modern";

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ModernToggleActionItem" /> class.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="value">The value to apply.</param>
        public ModernToggleActionItem(IHtmlHelper html, bool value)
            : base(value)
        {
            PageInformation page = PageRegistry.GetOrCreatePageInformation(html.ViewContext.HttpContext);
            page.SetScriptFile("/js/ModernMode.js");
            page.SetStylesheet("/css/ModernMode.css");
            page.AddScriptInline("ModernToggle", SCRIPT_INLINE);
            SwitchJavaScript = $"ModernModeMethod.set(this.checked);";
            ConfigureStateAttributes();
        }

        #endregion
    }
}