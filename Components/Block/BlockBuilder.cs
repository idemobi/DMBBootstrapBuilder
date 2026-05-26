#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj BlockBuilder.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Builds and renders the BootstrapBuilder block component or page region.
    /// </summary>
    public sealed class BlockBuilder : HtmlConstrainedTagBuilder<BlockBuilder>,
        ICanUseDebugOnly, ICanUseCustomClasses,
        ICanUseMargin, ICanUsePadding
    
    {
        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockBuilder"/> class.
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

        #region Protected accessors

        protected override HtmlRenderContextKind ContextKind => HtmlRenderContextKind.Block;

        #endregion

        #region Instance methods

        protected override BlockBuilder CreateInstance()
        {
            return new BlockBuilder(_textWriter, _htmlHelper);
        }

        #endregion
    }
}
