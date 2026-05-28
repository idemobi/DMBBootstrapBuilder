#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj RowBuilder.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Builds and renders the BootstrapBuilder row component or page region.
    /// </summary>
    public sealed class RowBuilder : HtmlConstrainedTagBuilder<RowBuilder>,
        ICanUseRowCols,
        ICanUseGridGap,
        ICanUseGridGapX,
        ICanUseGridGapY,
        ICanUsePadding,
        ICanUseMargin,
        ICanUseJustifyContent,
        ICanUseVerticalAlign,
        ICanUseAlignItems,
        ICanUseHeight,
        ICanUseWidth,
        ICanUseCustomClasses
    {
        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RowBuilder"/> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public RowBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "div";
            _classesOfComponent.Add("row");
            this.SetGap(Gap.G3);
        }

        #endregion

        #region Protected accessors

        /// <inheritdoc />
        protected override HtmlRenderContextKind ContextKind => HtmlRenderContextKind.Row;

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override RowBuilder CreateInstance()
        {
            return new RowBuilder(_textWriter, _htmlHelper);
        }

        #endregion
    }
}
