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
    ///     Builds and renders the BootstrapBuilder block component or page region.
    /// </summary>
    public sealed class BlockBuilder : HtmlConstrainedTagBuilder<BlockBuilder>,
        ICanUseDebugOnly, ICanUseCustomClasses,
        ICanUseMargin, ICanUsePadding

    {
        #region Instance fields and properties

        #region Protected accessors

        /// <inheritdoc />
        protected override HtmlRenderContextKind ContextKind => HtmlRenderContextKind.Block;

        #endregion

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="BlockBuilder" /> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public BlockBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "div";
            _classesOfComponent.Add("block");
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override BlockBuilder CreateInstance()
        {
            return new BlockBuilder(_textWriter, _htmlHelper);
        }

        #endregion
    }
}