#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.IO;
using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Builds and renders the BootstrapBuilder image wrapper component or page region.
    /// </summary>
    public sealed class ImageWrapperBuilder : HtmlTagBuilder<ImageWrapperBuilder>,
        ICanUseMargin,
        ICanUsePadding,
        ICanUseOpacity,
        ICanUseHeight,
        ICanUseWidth, ICanUseCustomClasses
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImageWrapperBuilder" /> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public ImageWrapperBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "div";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override ImageWrapperBuilder CreateInstance()
        {
            return new ImageWrapperBuilder(_textWriter, _htmlHelper);
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write($"<{_tag}{BuildAttributes()}></{_tag}>");
        }

        #endregion
    }
}