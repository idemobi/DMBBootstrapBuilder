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
    ///     Builds and renders the BootstrapBuilder footer component or page region.
    /// </summary>
    public sealed class FooterBuilder : HtmlConstrainedTagBuilder<FooterBuilder>, IDisposable, ICanUseFlex
    {
        #region Instance fields and properties

        private readonly HtmlRenderContext _context;
        private string? _noticeText;
        private new bool _started;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="FooterBuilder" /> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="context">The context value.</param>
        public FooterBuilder(TextWriter writer, IHtmlHelper html, HtmlRenderContext context)
            : base(writer, html)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Executes the BootstrapBuilder begin operation.
        /// </summary>
        /// <returns>The configured <see cref="FooterBuilder" /> value or BootstrapBuilder result.</returns>
        public override FooterBuilder Begin()
        {
            if (_started)
            {
                return this;
            }

            _context.RegisterRegionUse(HtmlRegionKind.Footer);

            switch (_context.Kind)
            {
                case HtmlRenderContextKind.Body:
                    BeginBodyFooter();
                break;

                case HtmlRenderContextKind.Block:
                    BeginBlockFooter();
                break;

                case HtmlRenderContextKind.Card:
                    BeginCardFooter();
                break;

                case HtmlRenderContextKind.Section:
                    BeginSectionFooter();
                break;

                default:
                    Console.WriteLine($"Footer is not supported in context '{_context.Kind}'.");
                    //throw new InvalidOperationException($"Footer is not supported in context '{_context.Kind}'.");
                break;
            }

            _started = true;
            return this;
        }

        /// <inheritdoc />
        protected override FooterBuilder CreateInstance()
        {
            return new FooterBuilder(_textWriter, _htmlHelper, _context);
        }

        /// <inheritdoc />
        protected override void InternalClone(FooterBuilder source)
        {
            base.InternalClone(source);
            _noticeText = source._noticeText;
            _started = false;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder notice text operation.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <returns>The configured <see cref="FooterBuilder" /> value or BootstrapBuilder result.</returns>
        public FooterBuilder NoticeText(string text)
        {
            _noticeText = text;
            return this;
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            switch (_context.Kind)
            {
                case HtmlRenderContextKind.Body:
                    WriteBodyFooter(writer, encoder);
                break;

                case HtmlRenderContextKind.Block:
                    WriteBlockFooter(writer, encoder);
                break;

                case HtmlRenderContextKind.Card:
                    WriteCardFooter(writer, encoder);
                break;

                case HtmlRenderContextKind.Section:
                    WriteSectionFooter(writer, encoder);
                break;

                default:
                    Console.WriteLine($"Footer is not supported in context '{_context.Kind}'.");
                    //throw new InvalidOperationException($"Footer is not supported in context '{_context.Kind}'.");
                break;
            }
        }

        #region From interface IDisposable

        /// <summary>
        ///     Executes the BootstrapBuilder dispose operation.
        /// </summary>
        public new void Dispose()
        {
            if (!_started)
            {
                return;
            }

            switch (_context.Kind)
            {
                case HtmlRenderContextKind.Body:
                    EndBodyFooter();
                break;

                case HtmlRenderContextKind.Block:
                    EndBlockFooter();
                break;

                case HtmlRenderContextKind.Card:
                    EndCardFooter();
                break;

                case HtmlRenderContextKind.Section:
                    EndSectionFooter();
                break;
            }

            _started = false;
        }

        #endregion

        #endregion

        #region Private helpers

        private void CloseBodyIfOpenOnParentContext(HtmlRenderContext context)
        {
            bool bodyOpen =
                context.Data.TryGetValue(HtmlRegionStateKeys.BodyOpen, out object? bodyObj) &&
                bodyObj is bool open &&
                open;

            if (!bodyOpen)
            {
                return;
            }

            _textWriter.Write("</div>");
            context.Data[HtmlRegionStateKeys.BodyOpen] = false;
            context.Data[HtmlRegionStateKeys.BodyClosedByFooter] = true;
        }

        private string EncodeNoticeText()
        {
            return string.IsNullOrWhiteSpace(_noticeText)
                ? string.Empty
                : HtmlEncoder.Default.Encode(_noticeText);
        }

        #endregion

        #region Modal body footer

        private void BeginBodyFooter()
        {
            TextWriter writer = _textWriter;

            bool bodyStillOpen =
                _context.Data.TryGetValue(HtmlRegionStateKeys.BodyClosedByFooter, out object? closedObj) &&
                closedObj is bool alreadyClosed &&
                !alreadyClosed;

            if (_context.Data.TryGetValue("ParentKind", out object? parentKindObj) &&
                parentKindObj is HtmlRenderContextKind parentKind &&
                parentKind == HtmlRenderContextKind.Modal)
            {
                if (bodyStillOpen)
                {
                    writer.Write("</div>");
                    _context.Data[HtmlRegionStateKeys.BodyClosedByFooter] = true;
                }

                if (_context.Data.TryGetValue("ParentContext", out object? parentContextObj) &&
                    parentContextObj is HtmlRenderContext parentContext)
                {
                    parentContext.Data[HtmlRegionStateKeys.BodyOpen] = false;
                    parentContext.Data[HtmlRegionStateKeys.FooterOpen] = true;
                    parentContext.Data[HtmlRegionStateKeys.BodyClosedByFooter] = true;

                    parentContext.Data["HasCustomFooter"] = true;

                    if (parentContext.Data.TryGetValue("ModalRenderContext", out object? modalContextObj) &&
                        modalContextObj is ModalRenderContext modalContext)
                    {
                        modalContext.HasCustomFooter = true;
                    }
                }

                writer.Write($"""
                              <div class="modal-footer">
                                  <div class="w-100 {this.BuildFlexCssClasses()}">
                              """);
                return;
            }

            Console.WriteLine("Footer inside Body is only supported for Modal at the moment.");
            //throw new InvalidOperationException("Footer inside Body is only supported for Modal at the moment.");
        }

        private void EndBodyFooter()
        {
            TextWriter writer = _textWriter;

            writer.Write("</div>");

            if (!string.IsNullOrWhiteSpace(_noticeText))
            {
                writer.Write($"""
                              <div class="w-100 text-muted text-start modal-footer-text">{EncodeNoticeText()}</div>
                              """);
            }

            writer.Write("</div>");
        }

        private void WriteBodyFooter(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write($"""
                          <div class="modal-footer">
                              <div class="w-100 {this.BuildFlexCssClasses()}">
                              </div>
                          """);

            if (!string.IsNullOrWhiteSpace(_noticeText))
            {
                writer.Write($"""
                              <div class="w-100 text-muted text-start modal-footer-text">{EncodeNoticeText()}</div>
                              """);
            }

            writer.Write("</div>");
        }

        #endregion

        #region Block footer

        private void BeginBlockFooter()
        {
            CloseBodyIfOpenOnParentContext(_context);

            _context.Data[HtmlRegionStateKeys.FooterOpen] = true;

            _textWriter.Write($"""
                               <div class="block-footer">
                                   <div class="{this.BuildFlexCssClasses()}">
                               """);
        }

        private void EndBlockFooter()
        {
            TextWriter writer = _textWriter;

            writer.Write("</div>");

            if (!string.IsNullOrWhiteSpace(_noticeText))
            {
                writer.Write($"""
                              <div class="w-100 text-muted text-start block-footer-text">{EncodeNoticeText()}</div>
                              """);
            }

            writer.Write("</div>");
        }

        private void WriteBlockFooter(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write($"""
                          <div class="block-footer">
                              <div class="{this.BuildFlexCssClasses()}">
                              </div>
                          """);

            if (!string.IsNullOrWhiteSpace(_noticeText))
            {
                writer.Write($"""
                              <div class="w-100 text-muted text-start block-footer-text">{EncodeNoticeText()}</div>
                              """);
            }

            writer.Write("</div>");
        }

        #endregion

        #region Card footer

        private void BeginCardFooter()
        {
            CloseBodyIfOpenOnParentContext(_context);

            _context.Data[HtmlRegionStateKeys.FooterOpen] = true;

            _textWriter.Write($"""
                               <div class="card-footer">
                                   <div class="{this.BuildFlexCssClasses()}">
                               """);
        }

        private void EndCardFooter()
        {
            TextWriter writer = _textWriter;

            writer.Write("</div>");

            if (!string.IsNullOrWhiteSpace(_noticeText))
            {
                writer.Write($"""
                              <div class="w-100 text-muted text-start card-footer-text">{EncodeNoticeText()}</div>
                              """);
            }

            writer.Write("</div>");
        }

        private void WriteCardFooter(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write($"""
                          <div class="card-footer">
                              <div class="{this.BuildFlexCssClasses()}">
                              </div>
                          """);

            if (!string.IsNullOrWhiteSpace(_noticeText))
            {
                writer.Write($"""
                              <div class="w-100 text-muted text-start card-footer-text">{EncodeNoticeText()}</div>
                              """);
            }

            writer.Write("</div>");
        }

        #endregion

        #region Section footer

        private void BeginSectionFooter()
        {
            CloseBodyIfOpenOnParentContext(_context);

            _context.Data[HtmlRegionStateKeys.FooterOpen] = true;
            _textWriter.Write($"""<div class="{this.BuildFlexCssClasses()}">""");
        }

        private void EndSectionFooter()
        {
            TextWriter writer = _textWriter;

            writer.Write("</div>");

            if (!string.IsNullOrWhiteSpace(_noticeText))
            {
                writer.Write($"""<div class="w-100 text-muted text-start section-footer-text">{EncodeNoticeText()}</div>""");
            }
        }

        private void WriteSectionFooter(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write($"""<div class="{this.BuildFlexCssClasses()}"></div>""");

            if (!string.IsNullOrWhiteSpace(_noticeText))
            {
                writer.Write($"""<div class="w-100 text-muted text-start section-footer-text">{EncodeNoticeText()}</div>""");
            }
        }

        #endregion
    }
}