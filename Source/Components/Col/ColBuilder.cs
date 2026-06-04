#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Collections.Generic;
using System.IO;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Builds and renders the BootstrapBuilder col component or page region.
    /// </summary>
    public sealed class ColBuilder : HtmlConstrainedTagBuilder<ColBuilder>,
        ICanUseColSize,
        ICanUseOffset,
        ICanUseOrder,
        ICanUseDebugOnly,
        ICanUsePadding,
        ICanUseMargin,
        ICanUseVerticalAlign,
        ICanUseJustifyContent,
        ICanUseBackgroundVariant,
        ICanUseTextVariant,
        ICanUseCustomClasses
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ColBuilder" /> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public ColBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "div";
            _classesOfComponent.Add("col");
            this.SetCol(ColSize.Col12);
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override ColBuilder CreateInstance()
        {
            return new ColBuilder(_textWriter, _htmlHelper);
        }

        #endregion

        #region Protected accessors

        /// <inheritdoc />
        protected override HtmlRenderContextKind ContextKind => HtmlRenderContextKind.Col;

        /// <inheritdoc />
        protected override bool RequiresParentContext => true;

        /// <inheritdoc />
        protected override IReadOnlyCollection<HtmlRenderContextKind> AllowedParentContextKinds =>
            new[]
            {
                HtmlRenderContextKind.Row
            };

        #endregion
    }
}