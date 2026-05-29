#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Builds and renders the BootstrapBuilder basic bootstrap body component or page region.
    /// </summary>
    public class BasicBootstrapBodyBuilder : IBodyBuilder
    {
        #region Instance fields and properties

        /// <summary>
        ///     Stores the body attributes value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public readonly Dictionary<string, string> BodyAttributes = new(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Stores the body classes value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public readonly List<string> BodyClasses = new();

        private ContainerBuilder Container = null!;

        /// <summary>
        ///     Stores the footer attributes value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public readonly Dictionary<string, string> FooterAttributes = new(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Stores the footer classes value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public readonly List<string> FooterClasses = new();

        /// <summary>
        ///     Stores the header attributes value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public readonly Dictionary<string, string> HeaderAttributes = new(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Stores the header classes value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public readonly List<string> HeaderClasses = new();

        /// <summary>
        ///     Stores the main attributes value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public readonly Dictionary<string, string> MainAttributes = new(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///     Stores the main classes value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public readonly List<string> MainClasses = new();

        #endregion

        #region Instance methods

        /// <summary>
        ///     Renders body attributes for the BootstrapBuilder output.
        /// </summary>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public string RenderBodyAttributes()
        {
            List<string> attrs = new();

            if (BodyClasses.Count > 0)
            {
                attrs.Add($@"class=""{string.Join(" ", BodyClasses.Distinct())}""");
            }

            foreach ((string key, string value) in BodyAttributes)
            {
                attrs.Add($@"{key}=""{HtmlEncoder.Default.Encode(value)}""");
            }

            return attrs.Count > 0 ? " " + string.Join(" ", attrs) : string.Empty;
        }

        /// <summary>
        ///     Renders footer attributes for the BootstrapBuilder output.
        /// </summary>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public string RenderFooterAttributes()
        {
            List<string> attrs = new();

            if (FooterClasses.Count > 0)
            {
                attrs.Add($@"class=""{string.Join(" ", FooterClasses.Distinct())}""");
            }

            foreach ((string key, string value) in FooterAttributes)
            {
                attrs.Add($@"{key}=""{HtmlEncoder.Default.Encode(value)}""");
            }

            return attrs.Count > 0 ? " " + string.Join(" ", attrs) : string.Empty;
        }

        /// <summary>
        ///     Renders header attributes for the BootstrapBuilder output.
        /// </summary>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public string RenderHeaderAttributes()
        {
            List<string> attrs = new();

            if (HeaderClasses.Count > 0)
            {
                attrs.Add($@"class=""{string.Join(" ", HeaderClasses.Distinct())}""");
            }

            foreach ((string key, string value) in HeaderAttributes)
            {
                attrs.Add($@"{key}=""{HtmlEncoder.Default.Encode(value)}""");
            }

            return attrs.Count > 0 ? " " + string.Join(" ", attrs) : string.Empty;
        }

        /// <summary>
        ///     Renders main attributes for the BootstrapBuilder output.
        /// </summary>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public string RenderMainAttributes()
        {
            List<string> attrs = new();

            if (MainClasses.Count > 0)
            {
                attrs.Add($@"class=""{string.Join(" ", MainClasses.Distinct())}""");
            }

            foreach ((string key, string value) in MainAttributes)
            {
                attrs.Add($@"{key}=""{HtmlEncoder.Default.Encode(value)}""");
            }

            return attrs.Count > 0 ? " " + string.Join(" ", attrs) : string.Empty;
        }

        #region From interface IBodyBuilder

        /// <summary>
        ///     Renders body end for the BootstrapBuilder output.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="page">The page information used during BootstrapBuilder rendering.</param>
        public void RenderBodyEnd(TextWriter writer, IHtmlHelper html, PageInformation page)
        {
            writer.Write($@"</body>");
        }

        /// <summary>
        ///     Renders body start for the BootstrapBuilder output.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="page">The page information used during BootstrapBuilder rendering.</param>
        public void RenderBodyStart(TextWriter writer, IHtmlHelper html, PageInformation page)
        {
            // string language = LanguageTools.ResolveLanguage(html.ViewContext.HttpContext);
            // BodyClasses.Add($"{language}");
            BodyClasses.Add("d-flex flex-column min-vh-100");
            writer.Write($@"<body{RenderBodyAttributes()}>");
        }

        /// <summary>
        ///     Renders footer end for the BootstrapBuilder output.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="page">The page information used during BootstrapBuilder rendering.</param>
        public void RenderFooterEnd(TextWriter writer, IHtmlHelper html, PageInformation page)
        {
            writer.Write($@"</footer>");
        }

        /// <summary>
        ///     Renders footer start for the BootstrapBuilder output.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="page">The page information used during BootstrapBuilder rendering.</param>
        public void RenderFooterStart(TextWriter writer, IHtmlHelper html, PageInformation page)
        {
            FooterClasses.Add("footer-bar mt-auto");
            writer.Write($@"<!-- Bootstrap footer -->");
            writer.Write($@"<footer{RenderFooterAttributes()}>");
            FooterBarBuilder footerBar = BootstrapBuilderConfiguration.Config.FooterBarComposer.GetFooterBar(writer, html);
            footerBar.WriteTo(writer, HtmlEncoder.Default);
        }

        /// <summary>
        ///     Renders header end for the BootstrapBuilder output.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="page">The page information used during BootstrapBuilder rendering.</param>
        public void RenderHeaderEnd(TextWriter writer, IHtmlHelper html, PageInformation page)
        {
            writer.Write($@"</header>");
        }

        /// <summary>
        ///     Renders header start for the BootstrapBuilder output.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="page">The page information used during BootstrapBuilder rendering.</param>
        public void RenderHeaderStart(TextWriter writer, IHtmlHelper html, PageInformation page)
        {
            writer.Write($@"<!-- Bootstrap header -->");
            writer.Write($@"<header{RenderHeaderAttributes()}>");
        }

        /// <summary>
        ///     Renders main end for the BootstrapBuilder output.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="page">The page information used during BootstrapBuilder rendering.</param>
        public void RenderMainEnd(TextWriter writer, IHtmlHelper html, PageInformation page)
        {
            writer.Write($@"</div>");
            writer.Write($@"</div>");
            Container.End();
            writer.Write($@"</main>");
        }

        /// <summary>
        ///     Renders main start for the BootstrapBuilder output.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="page">The page information used during BootstrapBuilder rendering.</param>
        public void RenderMainStart(TextWriter writer, IHtmlHelper html, PageInformation page)
        {
            PageBootstrapInformation bootstrapInformation = PageBootstrapRegistry.GetPageInformation(html.ViewContext.HttpContext);

            MainClasses.Add("flex-grow-1");
            writer.Write($@"<!-- Bootstrap main -->");
            writer.Write($@"<main{RenderMainAttributes()}>");

            writer.Write($@"<!-- navigation bar start -->");
            NavbarBuilder desktopNavBar = BootstrapBuilderConfiguration.Config.NavigationBarComposer.GetDesktopNavbar(writer, html);
            NavbarBuilder mobileNavBar = BootstrapBuilderConfiguration.Config.NavigationBarComposer.GetMobileNavbar(writer, html, bootstrapInformation.SideBar);
            desktopNavBar.WriteTo(writer, HtmlEncoder.Default);
            mobileNavBar.WriteTo(writer, HtmlEncoder.Default);
            writer.Write($@"<!-- navigation bar end -->");

            Container = new ContainerBuilder(writer, html);
            Container.SwitchableToFluid(bootstrapInformation.PageContainerSwichable).Style(bootstrapInformation.PageContainerStyle).SetSidebar(bootstrapInformation.SideBar);
            Container.Begin();
            writer.Write($@"<div class=""container-content w-100"" id=""page-content"">");
            BreadcrumbBuilder? breadcrumb = BootstrapBuilderConfiguration.Config.BreadcrumbComposer.GetBreadcrumb(writer, html, bootstrapInformation.BreadcrumbActions);
            if (breadcrumb != null)
            {
                breadcrumb.WriteTo(writer, HtmlEncoder.Default);
            }

            foreach (AlertModel alert in bootstrapInformation.Alerts)
            {
                if (alert != null)
                {
                    AlertBuilder alertBuilt = alert.AlertBuilt(writer, html);
                    alertBuilt.WriteTo(writer, HtmlEncoder.Default);
                }
            }

            if (page.AlertManager is IBootstrapPageAlertManager alertManager)
            {
                foreach (AlertModel alert in alertManager.ToAlertModels())
                {
                    AlertBuilder alertBuilt = alert.AlertBuilt(writer, html);
                    alertBuilt.WriteTo(writer, HtmlEncoder.Default);
                }
            }

            writer.Write($@"<div class=""content"">");
        }

        #endregion

        #endregion
    }
}