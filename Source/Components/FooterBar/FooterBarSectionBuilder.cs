#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Builds and renders the BootstrapBuilder footer bar section component or page region.
    /// </summary>
    public sealed class FooterBarSectionBuilder
    {
        #region Static methods

        private static string ConvertToString(IHtmlContent content)
        {
            using StringWriter writer = new StringWriter();
            content.WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        }

        #endregion

        #region Instance fields and properties

        private string _additionalClasses = string.Empty;

        private ContainerStyle _containerStyle = ContainerStyle.Default;
        private IHtmlContent? _content;
        private readonly IHtmlHelper _html;
        private readonly string _sectionCssClass;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="FooterBarSectionBuilder" /> class.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="sectionCssClass">The section css class value.</param>
        public FooterBarSectionBuilder(IHtmlHelper html, string sectionCssClass)
        {
            _html = html ?? throw new ArgumentNullException(nameof(html));
            _sectionCssClass = sectionCssClass ?? throw new ArgumentNullException(nameof(sectionCssClass));
        }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Executes the BootstrapBuilder container operation.
        /// </summary>
        /// <param name="style">The style value.</param>
        /// <returns>The configured <see cref="FooterBarSectionBuilder" /> value or BootstrapBuilder result.</returns>
        public FooterBarSectionBuilder Container(ContainerStyle style)
        {
            _containerStyle = style;
            return this;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder content operation.
        /// </summary>
        /// <param name="content">The content value.</param>
        /// <returns>The configured <see cref="FooterBarSectionBuilder" /> value or BootstrapBuilder result.</returns>
        public FooterBarSectionBuilder Content(IHtmlContent? content)
        {
            _content = content;
            return this;
        }

        /// <summary>
        ///     Renders value for the BootstrapBuilder output.
        /// </summary>
        /// <returns>The rendered HTML content for the BootstrapBuilder component.</returns>
        public IHtmlContent Render()
        {
            if (_content == null)
            {
                return HtmlString.Empty;
            }

            string rawContent = ConvertToString(_content);

            if (string.IsNullOrWhiteSpace(rawContent))
            {
                return HtmlString.Empty;
            }

            TagBuilder section = new TagBuilder("section");
            section.AddCssClass(_sectionCssClass);

            if (!string.IsNullOrWhiteSpace(_additionalClasses))
            {
                section.AddCssClass(_additionalClasses);
            }

            if (_containerStyle == ContainerStyle.None)
            {
                section.InnerHtml.AppendHtml(rawContent);
            }
            else
            {
                string wrapped = WrapInContainer(rawContent);
                section.InnerHtml.AppendHtml(wrapped);
            }

            return section;
        }

        /// <summary>
        ///     Configures classes on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="classes">The classes value.</param>
        /// <returns>The configured <see cref="FooterBarSectionBuilder" /> value or BootstrapBuilder result.</returns>
        public FooterBarSectionBuilder WithClasses(string classes)
        {
            _additionalClasses = classes ?? string.Empty;
            return this;
        }

        private string WrapInContainer(string rawContent)
        {
            using StringWriter writer = new StringWriter();

            TextWriter originalWriter = _html.ViewContext.Writer;
            _html.ViewContext.Writer = writer;

            try
            {
                using (_html.ContainerBuilder().Style(_containerStyle).Begin())
                {
                    _html.ViewContext.Writer.Write(rawContent);
                }
            }
            finally
            {
                _html.ViewContext.Writer = originalWriter;
            }

            return writer.ToString();
        }

        #endregion
    }
}