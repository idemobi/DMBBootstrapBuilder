#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj BodyBuilder.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Builds and renders the BootstrapBuilder body component or page region.
    /// </summary>
    public sealed class BodyBuilder : HtmlConstrainedTagBuilder<BodyBuilder>, IDisposable
    {
        #region Instance fields and properties

        private HtmlRenderContext? _bodyContext;
        private readonly HtmlRenderContext _parentContext;
        private new bool _started;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BodyBuilder"/> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="parentContext">The parent context value.</param>
        public BodyBuilder(TextWriter writer, IHtmlHelper html, HtmlRenderContext parentContext)
            : base(writer, html)
        {
            _parentContext = parentContext ?? throw new ArgumentNullException(nameof(parentContext));
            _tag = "div";

            switch (_parentContext.Kind)
            {
                case HtmlRenderContextKind.Block:
                    _classesOfComponent.Add("block-body");
                    break;

                case HtmlRenderContextKind.Card:
                    _classesOfComponent.Add("card-body");
                    break;

                case HtmlRenderContextKind.Body:
                    _classesOfComponent.Add("body");
                    break;

                default:
                    _classesOfComponent.Add("body");
                    break;
            }
        }

        #endregion

        #region Instance methods

        /// <summary>
        /// Executes the BootstrapBuilder begin operation.
        /// </summary>
        /// <returns>The configured <see cref="BodyBuilder"/> value or BootstrapBuilder result.</returns>
        public new BodyBuilder Begin()
        {
            if (_started)
            {
                return this;
            }

            ReopenBodyIfFooterIsCurrentlyOpen();

            _parentContext.RegisterRegionUse(HtmlRegionKind.Body);

            _bodyContext = CreateBodyContext();

            _parentContext.Data[HtmlRegionStateKeys.BodyOpen] = true;
            _parentContext.Data[HtmlRegionStateKeys.FooterOpen] = false;

            HtmlRenderContextManager.Push(HtmlHelper, _bodyContext);

            _textWriter.Write($"<{_tag}{BuildAttributes()}>");

            _started = true;
            return this;
        }

        /// <inheritdoc />
        protected override BodyBuilder CreateInstance()
        {
            return new BodyBuilder(_textWriter, _htmlHelper, _parentContext);
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            HtmlRenderContext bodyContext = CreateBodyContext();

            _parentContext.RegisterRegionUse(HtmlRegionKind.Body);
            _parentContext.Data[HtmlRegionStateKeys.BodyOpen] = true;
            _parentContext.Data[HtmlRegionStateKeys.FooterOpen] = false;

            HtmlRenderContextManager.Push(HtmlHelper, bodyContext);

            try
            {
                writer.Write($"<{_tag}{BuildAttributes()}>");
                writer.Write($"</{_tag}>");
            }
            finally
            {
                _parentContext.Data[HtmlRegionStateKeys.BodyOpen] = false;

                HtmlRenderContext? current = HtmlRenderContextManager.Current(HtmlHelper);
                if (ReferenceEquals(current, bodyContext))
                {
                    HtmlRenderContextManager.Pop(HtmlHelper);
                }
            }
        }

        /// <inheritdoc />
        protected override void OnBeginRendering()
        {
        }

        /// <inheritdoc />
        protected override void OnEndRendering()
        {
        }

        private HtmlRenderContext CreateBodyContext()
        {
            HtmlRenderContext bodyContext = new HtmlRenderContext
            {
                Kind = HtmlRenderContextKind.Body,
                Owner = this
            };

            bodyContext.Data["ParentKind"] = _parentContext.Kind;
            bodyContext.Data["ParentContext"] = _parentContext;
            bodyContext.Data[HtmlRegionStateKeys.BodyClosedByFooter] = false;

            return bodyContext;
        }

        private void ReopenBodyIfFooterIsCurrentlyOpen()
        {
            bool footerOpen =
                _parentContext.Data.TryGetValue(HtmlRegionStateKeys.FooterOpen, out object? footerObj) &&
                footerObj is bool footerIsOpen &&
                footerIsOpen;

            if (!footerOpen)
            {
                return;
            }

            switch (_parentContext.Kind)
            {
                case HtmlRenderContextKind.Block:
                    _textWriter.Write("</div></div>");
                    break;

                case HtmlRenderContextKind.Card:
                    _textWriter.Write("</div></div>");
                    break;

                case HtmlRenderContextKind.Section:
                    _textWriter.Write("</div></footer>");
                    break;

                case HtmlRenderContextKind.Modal:
                case HtmlRenderContextKind.Body:
                    _textWriter.Write("</div></div>");
                    break;
            }

            _parentContext.Data[HtmlRegionStateKeys.FooterOpen] = false;
            _parentContext.Data[HtmlRegionStateKeys.BodyOpen] = false;
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

            bool bodyClosedByFooter =
                _bodyContext != null &&
                _bodyContext.Data.TryGetValue(HtmlRegionStateKeys.BodyClosedByFooter, out object? closedObj) &&
                closedObj is bool closed &&
                closed;

            if (!bodyClosedByFooter)
            {
                _textWriter.Write($"</{_tag}>");
            }

            _parentContext.Data[HtmlRegionStateKeys.BodyOpen] = false;

            HtmlRenderContext? current = HtmlRenderContextManager.Current(HtmlHelper);
            if (ReferenceEquals(current, _bodyContext))
            {
                HtmlRenderContextManager.Pop(HtmlHelper);
            }

            _bodyContext = null;
            _started = false;
        }

        #endregion

        #endregion
    }
}