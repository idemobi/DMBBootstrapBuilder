#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBPageBuilder;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Composes Bootstrap CSS classes or page chrome for basic footer bar.
    /// </summary>
    public class BasicFooterBarComposer : IFooterBarComposer
    {
        #region Instance methods

        /// <summary>
        ///     Applies the default footer bar content before it is returned to the page layout.
        /// </summary>
        /// <param name="result">The footer bar builder to configure.</param>
        /// <param name="writer">The writer associated with the current Razor output.</param>
        /// <param name="html">The Razor HTML helper for the current view.</param>
        protected virtual void ConfigureFooterBar(FooterBarBuilder result, TextWriter writer, IHtmlHelper html)
        {
            //TODO rework mission
            //result.MissionTitle(WebLocalizer.GetInternal(nameof(DMBWebStandardInternalLocalization.COMMON_OurMission_TITLE))).Mission(WebLocalizer.GetInternal(nameof(DMBWebStandardInternalLocalization.COMMON_OurMission_DESCRIPTION)));
            result.BeforeFooter(new HtmlString(""));
            result.NoticeFooter(new HtmlString(""));
        }

        #region From interface IFooterBarComposer

        /// <summary>
        ///     Gets footer bar for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="FooterBarBuilder" /> value or BootstrapBuilder result.</returns>
        public FooterBarBuilder GetFooterBar(TextWriter writer, IHtmlHelper html)
        {
            PageInformation page = PageRegistry.GetOrCreatePageInformation(html.ViewContext.HttpContext);
            //page.SetScriptFile( "/js/TableSortable.js");
            page.SetStylesheet("/css/FooterBar.css");
            //page.AddScriptInline("ThemeMode", SCRIPT_INLINE);
            //PageAssetRegistry.AddLocalCssFile(html, "/css/FooterBar.css");
            if (html == null)
            {
                throw new ArgumentNullException(nameof(html));
            }

            FooterBarBuilder result = new FooterBarBuilder(writer, html);

            ConfigureFooterBar(result, writer, html);

            IEnumerable<IFooterBarSectionProvider> providers = html.ViewContext.HttpContext
                .RequestServices
                .GetServices<IFooterBarSectionProvider>();

            foreach (IFooterBarSectionProvider provider in providers.OrderBy(x => x.Order))
            {
                if (provider == null)
                {
                    continue;
                }

                if (!provider.IsEnabled(html))
                {
                    continue;
                }

                FooterBarModuleResult moduleResult = provider.Build(writer, html);
                if (moduleResult == null)
                {
                    continue;
                }

                foreach (FooterBarColumnDefinition column in moduleResult.Columns)
                {
                    if (column?.Groups == null || column.Groups.Count == 0)
                    {
                        continue;
                    }

                    result.AddColumn(column.Groups.ToArray());
                }
            }

            return result;
        }

        #endregion

        #endregion
    }
}