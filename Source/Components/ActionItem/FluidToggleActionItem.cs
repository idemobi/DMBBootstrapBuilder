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
    ///     Represents the BootstrapBuilder fluid toggle action item component or support type.
    /// </summary>
    public sealed class FluidToggleActionItem : LayoutToggleActionItemBase
    {
        #region Constants

        private const string SCRIPT_INLINE =
            """
            (function () {
                var enabled = localStorage.getItem('layout_fluid') === 'true';

                function apply() {
                    if (!document.body) {
                        return false;
                    }

                    //document.body.setAttribute('data-layout-fluid', enabled ? 'true' : 'false');

                    document.querySelectorAll('[data-switchable-fluid="true"]').forEach(function (element) {
                        var reverse = (element.getAttribute('data-switchable-reverse') || '').trim();
                        var reverseClasses = reverse ? reverse.split(/\s+/).filter(Boolean) : [];

                        if (enabled) {
                            reverseClasses.forEach(function (cssClass) {
                                element.classList.remove(cssClass);
                            });

                            element.classList.add('container-fluid');
                        } else {
                            element.classList.remove('container-fluid');

                            reverseClasses.forEach(function (cssClass) {
                                element.classList.add(cssClass);
                            });
                        }
                    });

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
        ///     Gets or sets the setting key value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public override string SettingKey => "fluid";

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="FluidToggleActionItem" /> class.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="value">The value to apply.</param>
        public FluidToggleActionItem(IHtmlHelper html, bool value)
            : base(value)
        {
            PageInformation page = PageRegistry.GetOrCreatePageInformation(html.ViewContext.HttpContext);
            page.SetScriptFile("/js/FluidMode.js");
            page.AddScriptInline("FluidToggle", SCRIPT_INLINE);
            SwitchJavaScript = $"FluidModeMethod.set(this.checked);";
            ConfigureStateAttributes();
        }

        #endregion
    }
}