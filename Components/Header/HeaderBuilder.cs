#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj HeaderBuilder.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Builds and renders the BootstrapBuilder header component or page region.
    /// </summary>
    public sealed class HeaderBuilder : HtmlTagBuilder<HeaderBuilder>, IDisposable
    {
        #region Instance fields and properties

        private readonly HtmlRenderContext _context;
        private new bool _started;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderBuilder"/> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="context">The context value.</param>
        public HeaderBuilder(TextWriter writer, IHtmlHelper html, HtmlRenderContext context)
            : base(writer, html)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _tag = "div";

            switch (_context.Kind)
            {
                case HtmlRenderContextKind.Block:
                    _classesOfComponent.Add("block-header");
                    break;

                case HtmlRenderContextKind.Card:
                    _classesOfComponent.Add("card-header");
                    break;

                case HtmlRenderContextKind.Section:
                    _classesOfComponent.Add("section-header");
                    break;

                default:
                    _classesOfComponent.Add("header");
                    break;
            }
        }

        #endregion

        #region Instance methods

        /// <summary>
        /// Executes the BootstrapBuilder begin operation.
        /// </summary>
        /// <returns>The configured <see cref="HeaderBuilder"/> value or BootstrapBuilder result.</returns>
        public new HeaderBuilder Begin()
        {
            if (_started)
            {
                return this;
            }

            _context.RegisterRegionUse(HtmlRegionKind.Header);

            switch (_context.Kind)
            {
                case HtmlRenderContextKind.Block:
                case HtmlRenderContextKind.Card:
                case HtmlRenderContextKind.Section:
                    base.Begin();
                    break;

                default:
                    throw new InvalidOperationException($"Header is not supported in context '{_context.Kind}'.");
            }

            _started = true;
            return this;
        }

        /// <inheritdoc />
        protected override HeaderBuilder CreateInstance()
        {
            return new HeaderBuilder(_textWriter, _htmlHelper, _context);
        }

        /// <inheritdoc />
        protected override void InternalClone(HeaderBuilder source)
        {
            base.InternalClone(source);
            _started = false;
        }

        /// <inheritdoc />
        protected override void OnBeginRendering()
        {
        }

        /// <inheritdoc />
        protected override void OnEndRendering()
        {
        }

        #region From interface IDisposable

        /// <summary>
        /// Executes the BootstrapBuilder dispose operation.
        /// </summary>
        public new void Dispose()
        {
            if (!_started)
            {
                return;
            }

            base.Dispose();
            _started = false;
        }

        #endregion

        #endregion
    }
}