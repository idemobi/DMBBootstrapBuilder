#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.IO;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Builds and renders the BootstrapBuilder flex block component or page region.
    /// </summary>
    public sealed class FlexBlockBuilder : HtmlConstrainedTagBuilder<FlexBlockBuilder>,
        ICanUseMargin,
        ICanUsePadding,
        ICanUseAlignItems,
        ICanUseFlexDirection,
        ICanUseFlex,
        ICanUseTextAlign
    {
        #region Instance fields and properties

        #region Protected accessors

        /// <inheritdoc />
        protected override HtmlRenderContextKind ContextKind => HtmlRenderContextKind.Block;

        #endregion

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="FlexBlockBuilder" /> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public FlexBlockBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "div";
            _classesOfComponent.Add("flex-block");
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override FlexBlockBuilder CreateInstance()
        {
            return new FlexBlockBuilder(_textWriter, _htmlHelper);
        }

        #endregion
    }
}