#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Globalization;
using DMBBootstrapBuilder.Resources;
using DMBPageBuilder;
using DMBServerWebHelper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides language bar section content for BootstrapBuilder page chrome.
    /// </summary>
    public class LanguageBarSectionProvider : IProfileBarSectionProvider
    {
        #region Instance fields and properties

        private readonly IOptions<RequestLocalizationOptions> _locOptions;

        #region From interface IProfileBarSectionProvider

        /// <summary>
        ///     Gets or sets the order value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public int Order => 900;

        #endregion

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="LanguageBarSectionProvider" /> class.
        /// </summary>
        /// <param name="locOptions">The loc options value.</param>
        public LanguageBarSectionProvider(IOptions<RequestLocalizationOptions> locOptions)
        {
            _locOptions = locOptions ?? throw new ArgumentNullException(nameof(locOptions));
        }

        #endregion

        #region Instance methods

        #region From interface IProfileBarSectionProvider

        /// <summary>
        ///     Builds value for BootstrapBuilder rendering.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="ProfilBarModuleResult" /> value or BootstrapBuilder result.</returns>
        public ProfilBarModuleResult Build(TextWriter writer, IHtmlHelper html)
        {
            HttpContext context = html.ViewContext.HttpContext;
            CultureInfo? requestCulture = context.Features.Get<IRequestCultureFeature>()?.RequestCulture.UICulture;

            ProfilBarModuleResult result = new ProfilBarModuleResult();

            GroupActionItem group = new GroupActionItem()
                .SetLocalizedTitle(nameof(DMBBootstrapBuilderInternalLocalization.ACTIONITEM_NAVBAR_GROUP_Language_TITLE))
                .SetLocalizedIconBootstrap(nameof(DMBBootstrapBuilderInternalLocalization.ACTIONITEM_NAVBAR_GROUP_Language_ICON));

            result.ActionList.Add(group);

            if (_locOptions.Value.SupportedUICultures != null)
            {
                foreach (CultureInfo culture in _locOptions.Value.SupportedUICultures)
                {
                    bool isCurrent = string.Equals(requestCulture?.Name, culture.Name, StringComparison.OrdinalIgnoreCase);

                    if (isCurrent)
                    {
                        PageInformation page = PageRegistry.GetOrCreatePageInformation(html.ViewContext.HttpContext);
                        //page.SetScriptFile( "/js/TableSortable.js");
                        page.SetStylesheet($"/css/language/{culture.TwoLetterISOLanguageName}.css");
                        //page.AddScriptInline("ThemeMode", SCRIPT_INLINE);
                        //PageAssetRegistry.AddLocalCssFile(html, $"/css/language/{culture.TwoLetterISOLanguageName}.css");

                        JavaScriptActionItem currentItem = new JavaScriptActionItem("return false;")
                            .SetLocalizedTitle(culture.DisplayName)
                            .SetActive()
                            .SetDisabled();
                        group.AddItem(currentItem);
                    }
                    else
                    {
                        string cookieValue = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture, culture));
                        string onClick = (ServerWebHelperConfiguration.CookieLanguage?.GenerateOnClick(cookieValue) ?? "return false;") + " location.reload();";
                        JavaScriptActionItem item = new JavaScriptActionItem(onClick)
                            .SetLocalizedTitle(culture.DisplayName);
                        group.AddItem(item);
                    }
                }
            }

            return result;
        }

        /// <summary>
        ///     Determines whether enabled is active for BootstrapBuilder rendering.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>True when the requested BootstrapBuilder condition is active; otherwise, false.</returns>
        public bool IsEnabled(IHtmlHelper html)
        {
            return _locOptions.Value.SupportedUICultures is { Count: > 1 };
        }

        #endregion

        #endregion
    }
}