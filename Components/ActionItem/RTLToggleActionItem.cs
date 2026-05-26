#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj RTLToggleActionItem.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder rtl toggle action item component or support type.
    /// </summary>
    public sealed class RTLToggleActionItem : LayoutToggleActionItemBase
    {
        #region Constants

        private const string SCRIPT_INLINE =
            """
            (function () {
                var enabled = localStorage.getItem('layout_rtl') === 'true';

                function apply() {
                    var main = document.querySelector('#page-content');
                    if (!main) {
                        return false;
                    }

                    if (enabled) {
                        main.setAttribute('dir', 'rtl');
                    } else {
                        main.setAttribute('dir', 'ltr');
                    }

                    return true;
                }

                if (!apply()) {
                    document.addEventListener('DOMContentLoaded', apply, { once: true });
                }
            })();
            """;

        #endregion

        #region Instance fields and properties

        /// <summary>
        /// Gets or sets the setting key value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public override string SettingKey => "rtl";

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RTLToggleActionItem"/> class.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="value">The value to apply.</param>
        public RTLToggleActionItem(IHtmlHelper html, bool value)
            : base(value)
        {
            PageInformation page = PageRegistry.GetOrCreatePageInformation(html.ViewContext.HttpContext);
            page.SetScriptFile("/js/RTLMode.js");
            page.AddScriptInline("RTLToggle", SCRIPT_INLINE);

            SwitchJavaScript = $"RTLModeMethod.set(this.checked);";
            ConfigureStateAttributes();
        }

        #endregion
    }
}