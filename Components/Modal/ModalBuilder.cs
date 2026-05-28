#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ModalBuilder.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using System.Text;
using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Builds and renders the BootstrapBuilder modal component or page region.
    /// </summary>
    public sealed class ModalBuilder :
        HtmlConstrainedTagBuilder<ModalBuilder>,
        IDisposable,
        ICanUseCustomClasses,
        IHasTitle,
        IHasSubtitle,
        IHasIcon
    {
        #region Static fields and properties

        /// <summary>
        /// Gets or sets the close button add class value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public static string CloseButtonAddClass => "btn-sm";
        /// <summary>
        /// Gets or sets the close icon bootstrap value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public static string CloseIconBootstrap => "bi bi-x-lg";

        #endregion

        #region Instance fields and properties

        private string? _additionalClasses
        {
            get => GetInternal<string?>("_additionalClasses", null);
            set => SetInternal("_additionalClasses", value);
        }

        private string? _bodyAdditionalClasses
        {
            get => GetInternal<string?>("_bodyAdditionalClasses", null);
            set => SetInternal("_bodyAdditionalClasses", value);
        }

        private bool _bodyNoPadding
        {
            get => GetInternal("_bodyNoPadding", false);
            set => SetInternal("_bodyNoPadding", value);
        }

        private bool _centered
        {
            get => GetInternal("_centered", true);
            set => SetInternal("_centered", value);
        }

        private bool _debugOnly
        {
            get => GetInternal("_debugOnly", false);
            set => SetInternal("_debugOnly", value);
        }

        private IActionItem? _headerAction
        {
            get => GetInternal<IActionItem?>("_headerAction", null);
            set => SetInternal("_headerAction", value);
        }

        private bool _hasPdfPreview
        {
            get => GetInternal("_hasPdfPreview", false);
            set => SetInternal("_hasPdfPreview", value);
        }

        private HtmlRenderContext? _htmlRenderContext;

        private IconStruct _icon
        {
            get => GetInternal("_icon", IconStruct.Empty);
            set => SetInternal("_icon", value);
        }

        private bool _iconOnlyCentered
        {
            get => GetInternal("_iconOnlyCentered", false);
            set => SetInternal("_iconOnlyCentered", value);
        }

        private bool _iconOnlyHeader
        {
            get => GetInternal("_iconOnlyHeader", false);
            set => SetInternal("_iconOnlyHeader", value);
        }

        private string _modalId
        {
            get => GetInternal("_modalId", string.Empty);
            set => SetInternal("_modalId", value);
        }

        private ModalRenderContext? _modalRenderContext;

        private bool _noHeader
        {
            get => GetInternal("_noHeader", false);
            set => SetInternal("_noHeader", value);
        }

        private int _pdfIframeHeight
        {
            get => GetInternal("_pdfIframeHeight", 600);
            set => SetInternal("_pdfIframeHeight", value);
        }

        private string? _pdfIframeId
        {
            get => GetInternal<string?>("_pdfIframeId", null);
            set => SetInternal("_pdfIframeId", value);
        }

        private string? _pdfPreviewUrl
        {
            get => GetInternal<string?>("_pdfPreviewUrl", null);
            set => SetInternal("_pdfPreviewUrl", value);
        }

        private bool _renderTriggerInsideBegin
        {
            get => GetInternal("_renderTriggerInsideBegin", false);
            set => SetInternal("_renderTriggerInsideBegin", value);
        }

        private ModalSize _size
        {
            get => GetInternal("_size", ModalSize.Lg);
            set => SetInternal("_size", value);
        }

        private new bool _started
        {
            get => GetInternal("_started", false);
            set => SetInternal("_started", value);
        }

        private string? _subtitle
        {
            get => GetInternal<string?>("_subtitle", null);
            set => SetInternal("_subtitle", value);
        }

        private string? _title
        {
            get => GetInternal<string?>("_title", null);
            set => SetInternal("_title", value);
        }

        private TitleLevel _titleLevel
        {
            get => GetInternal("_titleLevel", TitleLevel.Four);
            set => SetInternal("_titleLevel", value);
        }

        private ModalActionItem? _triggerAction;

        private bool _triggerRequested
        {
            get => GetInternal("_triggerRequested", false);
            set => SetInternal("_triggerRequested", value);
        }

        private VariantStyle _variant
        {
            get => GetInternal("_variant", VariantStyle.Normal);
            set => SetInternal("_variant", value);
        }

        #endregion

        #region Interface properties

        string? IHasTitle.Title
        {
            get => _title;
            set => _title = value;
        }

        string? IHasSubtitle.Subtitle
        {
            get => _subtitle;
            set => SetInternal("_subtitle", value);
        }

        IconStruct IHasIcon.Icon
        {
            get => _icon;
            set => _icon = value;
        }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ModalBuilder"/> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public ModalBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "div";
            _modalId = html.GenerateUniqueId("modal");
        }

        #endregion

        #region Protected accessors

        /// <inheritdoc />
        protected override HtmlRenderContextKind ContextKind => HtmlRenderContextKind.Body;

        #endregion

        #region Fluent API

        /// <summary>
        /// Configures title on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <param name="titleLevel">The title level value.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder SetTitle(string title, TitleLevel titleLevel = TitleLevel.Three)
        {
            _iconOnlyHeader = false;
            _iconOnlyCentered = false;
            _title = title;
            _titleLevel = titleLevel;
            return this;
        }

        /// <summary>
        /// Configures subtitle on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="subtitle">The subtitle value.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder SetSubtitle(string subtitle)
        {
            _subtitle = subtitle;
            return this;
        }

        /// <summary>
        /// Configures icon bootstrap on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="iconBootstrap">The icon bootstrap value.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder SetIconBootstrap(string iconBootstrap)
        {
            _icon = IconStruct.Bootstrap(iconBootstrap);
            return this;
        }

        /// <summary>
        /// Configures title on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <param name="titleLevel">The title level value.</param>
        /// <param name="icon">The icon value.</param>
        /// <param name="subtitle">The subtitle value.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder WithTitle(string title, TitleLevel titleLevel, IconStruct icon = default, string? subtitle = null)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Modal title cannot be null or empty.", nameof(title));
            }

            _iconOnlyHeader = false;
            _iconOnlyCentered = false;
            _title = title;
            _titleLevel = titleLevel;
            _icon = icon;
            _subtitle = subtitle;

            return this;
        }

        /// <summary>
        /// Configures icon only on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="titleLevel">The title level value.</param>
        /// <param name="icon">The icon value.</param>
        /// <param name="centered">The centered value.</param>
        /// <param name="subtitle">The subtitle value.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder WithIconOnly(TitleLevel titleLevel, IconStruct icon, bool centered = true, string? subtitle = null)
        {
            if (icon.IsEmpty)
            {
                throw new ArgumentException("Icon cannot be null or empty.", nameof(icon));
            }

            _iconOnlyHeader = true;
            _iconOnlyCentered = centered;
            _titleLevel = titleLevel;
            _icon = icon;
            _subtitle = subtitle;
            _title ??= "_ICON_ONLY_";

            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder debug only operation.
        /// </summary>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder DebugOnly()
        {
            _debugOnly = true;
            return this;
        }

        /// <summary>
        /// Configures debug only on the current BootstrapBuilder instance.
        /// </summary>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder SetDebugOnly()
        {
            _debugOnly = true;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder centered operation.
        /// </summary>
        /// <param name="centered">The centered value.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder Centered(bool centered = true)
        {
            _centered = centered;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder no header operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder NoHeader(bool value = true)
        {
            _noHeader = value;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder body no padding operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder BodyNoPadding(bool value = true)
        {
            _bodyNoPadding = value;
            return this;
        }

        /// <summary>
        /// Configures variant on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="variant">The variant value.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder WithVariant(VariantStyle variant)
        {
            _variant = variant;
            return this;
        }

        /// <summary>
        /// Configures additional classes on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="additionalClasses">The additional classes value.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder WithAdditionalClasses(string additionalClasses)
        {
            _additionalClasses = additionalClasses;
            return this;
        }

        /// <summary>
        /// Configures body class on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="cssClass">The css class value.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder WithBodyClass(string cssClass)
        {
            if (!string.IsNullOrWhiteSpace(cssClass))
            {
                _bodyAdditionalClasses = string.IsNullOrWhiteSpace(_bodyAdditionalClasses)
                    ? cssClass.Trim()
                    : $"{_bodyAdditionalClasses} {cssClass.Trim()}";
            }

            return this;
        }

        /// <summary>
        /// Configures header action on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="action">The action value.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder SetHeaderAction(IActionItem action)
        {
            _headerAction = action ?? throw new ArgumentNullException(nameof(action));
            return this;
        }

        /// <summary>
        /// Configures data attribut on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder SetDataAttribut(string name, string value)
        {
            return SetAttribut($"data-{name}", value);
        }

        /// <summary>
        /// Configures data attribut on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder SetDataAttribut(string name, bool value)
        {
            return SetAttribut($"data-{name}", value);
        }

        /// <summary>
        /// Configures aria attribut on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder SetAriaAttribut(string name, string value)
        {
            return SetAttribut($"aria-{name}", value);
        }

        /// <summary>
        /// Configures aria attribut on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder SetAriaAttribut(string name, bool value)
        {
            return SetAttribut($"aria-{name}", value);
        }

        /// <summary>
        /// Configures attribut on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder SetAttribut(string name, string value)
        {
            return SetAttribute(name, value);
        }

        /// <summary>
        /// Configures attribut on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder SetAttribut(string name, bool value)
        {
            return SetAttribute(name, value);
        }

        /// <summary>
        /// Executes the BootstrapBuilder id operation.
        /// </summary>
        /// <param name="modalId">The modal id value.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder Id(string modalId)
        {
            if (string.IsNullOrWhiteSpace(modalId))
            {
                throw new ArgumentException("Modal id cannot be null or empty.", nameof(modalId));
            }

            _modalId = modalId.Trim();
            SyncTriggerTarget();
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder size operation.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder Size(ModalSize size)
        {
            _size = size;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder trigger operation.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <param name="icon">The icon value.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder Trigger(string? title = null, IconStruct icon = default)
        {
            _triggerRequested = true;

            _triggerAction ??= ActionItemFactory.Modal(
                title ?? _title ?? string.Empty,
                _modalId,
                icon.IsEmpty ? _icon : icon);

            _triggerAction.ModalTargetId = _modalId;

            if (!string.IsNullOrWhiteSpace(title))
            {
                _triggerAction.Title = title;
            }

            if (!icon.IsEmpty)
            {
                _triggerAction.Icon = icon;
            }

            if (_triggerAction.Variant == VariantStyle.Normal)
            {
                _triggerAction.Variant = _variant;
            }

            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder trigger operation.
        /// </summary>
        /// <param name="action">The action value.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder Trigger(IActionItem action)
        {
            ArgumentNullException.ThrowIfNull(action);

            _triggerRequested = true;
            _triggerAction = ConvertToModalTrigger(action);

            if (string.IsNullOrWhiteSpace(_triggerAction.Title))
            {
                _triggerAction.Title = _title;
            }

            if (_triggerAction.Icon.IsEmpty)
            {
                _triggerAction.Icon = _icon;
            }

            _triggerAction.ModalTargetId = _modalId;

            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder trigger style operation.
        /// </summary>
        /// <param name="style">The style value.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder TriggerStyle(VariantStyle style)
        {
            _triggerAction ??= ActionItemFactory.Modal(_title ?? string.Empty, _modalId, _icon);
            _triggerAction.Variant = style;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder trigger outlined operation.
        /// </summary>
        /// <param name="outlined">The outlined value.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder TriggerOutlined(bool outlined = true)
        {
            _triggerAction ??= ActionItemFactory.Modal(_title ?? string.Empty, _modalId, _icon);
            _triggerAction.Outline = outlined;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder trigger size operation.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder TriggerSize(BoostrapButtonSize size)
        {
            _triggerAction ??= ActionItemFactory.Modal(_title ?? string.Empty, _modalId, _icon);
            _triggerAction.Size = size;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder trigger classes operation.
        /// </summary>
        /// <param name="additionalClasses">The additional classes value.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder TriggerClasses(string additionalClasses)
        {
            _triggerAction ??= ActionItemFactory.Modal(_title ?? string.Empty, _modalId, _icon);
            _triggerAction.AdditionalClasses = additionalClasses ?? string.Empty;
            return this;
        }

        /// <summary>
        /// Gets trigger for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="action">The action value.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder GetTrigger(out ModalActionItem action)
        {
            action = BuildTriggerAction();
            return this;
        }

        /// <summary>
        /// Renders trigger inside begin for the BootstrapBuilder output.
        /// </summary>
        /// <param name="renderInsideBegin">The render inside begin value.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder RenderTriggerInsideBegin(bool renderInsideBegin = true)
        {
            _triggerRequested = true;
            _renderTriggerInsideBegin = renderInsideBegin;
            return this;
        }

        /// <summary>
        /// Adds pdf preview url to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="urlOfPdf">The url of pdf value.</param>
        /// <param name="iframeHeight">The iframe height value.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public ModalBuilder AddPDFPreviewURL(string urlOfPdf, int iframeHeight = 600)
        {
            if (string.IsNullOrWhiteSpace(urlOfPdf))
            {
                throw new ArgumentException("PDF URL cannot be null or empty.", nameof(urlOfPdf));
            }

            if (iframeHeight <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(iframeHeight));
            }

            _hasPdfPreview = true;
            _pdfPreviewUrl = urlOfPdf;
            _pdfIframeId = HtmlHelper.GenerateUniqueId("frame");
            _pdfIframeHeight = iframeHeight;

            return this;
        }

        #endregion

        #region Lifecycle

        /// <summary>
        /// Executes the BootstrapBuilder begin operation.
        /// </summary>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public new ModalBuilder Begin()
        {
            if (_started)
            {
                return this;
            }

            ValidateBeforeBegin();
            OnRenderDebug();
            OnBeginRendering();

            if (_triggerRequested && _renderTriggerInsideBegin)
            {
                WriteHtmlContent(HtmlHelper.Button(BuildTriggerAction()));
            }

            _textWriter.Write(RenderModalStart());

            if (_hasPdfPreview)
            {
                _textWriter.Write($"""<iframe id="{_pdfIframeId}" width="100%" height="{_pdfIframeHeight}px" style="border: none;"></iframe>""");
            }

            _started = true;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder dispose operation.
        /// </summary>
        public new void Dispose()
        {
            if (!_started)
            {
                return;
            }

            _textWriter.Write(RenderModalEnd());

            if (_hasPdfPreview)
            {
                _textWriter.Write(RenderPdfPreviewScript());
            }

            OnEndRendering();
            _started = false;
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            ValidateBeforeBegin();
            OnRenderDebug();
            OnBeginRendering();

            try
            {
                writer.Write(RenderModalStart());

                if (_hasPdfPreview)
                {
                    writer.Write($"""<iframe id="{_pdfIframeId}" width="100%" height="{_pdfIframeHeight}px" style="border: none;"></iframe>""");
                }

                writer.Write(RenderModalEnd());

                if (_hasPdfPreview)
                {
                    writer.Write(RenderPdfPreviewScript());
                }
            }
            finally
            {
                OnEndRendering();
            }
        }

        #endregion

        #region Overrides

        /// <inheritdoc />
        protected override ModalBuilder CreateInstance()
        {
            return new ModalBuilder(_textWriter, _htmlHelper);
        }

        /// <inheritdoc />
        protected override void InternalClone(ModalBuilder source)
        {
            base.InternalClone(source);

            _additionalClasses = source._additionalClasses;
            _bodyAdditionalClasses = source._bodyAdditionalClasses;
            _bodyNoPadding = source._bodyNoPadding;
            _centered = source._centered;
            _debugOnly = source._debugOnly;
            _headerAction = source._headerAction;
            _icon = source._icon;
            _iconOnlyCentered = source._iconOnlyCentered;
            _iconOnlyHeader = source._iconOnlyHeader;
            _noHeader = source._noHeader;
            _title = source._title;
            _subtitle = source._subtitle;
            _titleLevel = source._titleLevel;
            _variant = source._variant;

            _hasPdfPreview = source._hasPdfPreview;
            _modalId = source._modalId;
            _pdfIframeHeight = source._pdfIframeHeight;
            _pdfIframeId = source._pdfIframeId;
            _pdfPreviewUrl = source._pdfPreviewUrl;
            _renderTriggerInsideBegin = source._renderTriggerInsideBegin;
            _size = source._size;
            _triggerRequested = source._triggerRequested;

            _triggerAction = source._triggerAction == null
                ? null
                : (ModalActionItem)source._triggerAction.Clone();

            _started = false;
            _htmlRenderContext = null;
            _modalRenderContext = null;
        }

        /// <inheritdoc />
        protected override void OnBeginRendering()
        {
            _modalRenderContext = new ModalRenderContext
            {
                ModalId = _modalId,
                HasCustomFooter = false
            };

            _htmlRenderContext = new HtmlRenderContext
            {
                Kind = HtmlRenderContextKind.Body,
                Owner = this
            };

            _htmlRenderContext.Data["ParentKind"] = HtmlRenderContextKind.Modal;
            _htmlRenderContext.Data["ParentContext"] = _htmlRenderContext;
            _htmlRenderContext.Data["ModalRenderContext"] = _modalRenderContext;
            _htmlRenderContext.Data["HasCustomFooter"] = false;
            _htmlRenderContext.Data[HtmlRegionStateKeys.BodyOpen] = true;
            _htmlRenderContext.Data[HtmlRegionStateKeys.FooterOpen] = false;
            _htmlRenderContext.Data[HtmlRegionStateKeys.BodyClosedByFooter] = false;

            HtmlRenderContextManager.Push(HtmlHelper, _htmlRenderContext);
        }

        /// <inheritdoc />
        protected override void OnEndRendering()
        {
            HtmlRenderContext? current = HtmlRenderContextManager.Current(HtmlHelper);

            if (ReferenceEquals(current, _htmlRenderContext))
            {
                HtmlRenderContextManager.Pop(HtmlHelper);
            }

            _htmlRenderContext = null;
            _modalRenderContext = null;
        }

        #endregion

        #region Validation

        private void ValidateBeforeBegin()
        {
            if (_noHeader)
            {
                return;
            }

            if (!_iconOnlyHeader && string.IsNullOrWhiteSpace(_title))
            {
                throw new InvalidOperationException("Modal title must be defined before Begin().");
            }

            if (_iconOnlyHeader && _icon.IsEmpty)
            {
                throw new InvalidOperationException("Modal icon must be defined before Begin() when using IconOnly().");
            }
        }

        #endregion

        #region Render helpers

        private string RenderModalStart()
        {
            string bodyStartHtml = RenderBodyStartHtml();
            string headerHtml = RenderHeaderHtml();
            string toolsOverlayHtml = RenderToolsOverlayHtml();

            string centeredCss = _centered ? "modal-dialog-centered" : string.Empty;
            string sizeCss = _size == ModalSize.Auto ? string.Empty : $"modal-{_size.ToString().ToLowerInvariant()}";
            string contentClasses = BuildModalContentCss();

            return $"""
<!-- Modal start -->
<div class="modal fade" id="{HtmlEncoder.Default.Encode(_modalId)}" tabindex="-1" aria-labelledby="" aria-hidden="true">
    <div class="modal-dialog modal-dialog-scrollable {sizeCss} {centeredCss}">
        <div class="{contentClasses}">
            {toolsOverlayHtml}
            {headerHtml}
            {bodyStartHtml}
""";
        }

        private string RenderModalEnd()
        {
            string bodyEnd = ShouldRenderBodyEndHtml()
                ? RenderBodyEndHtml()
                : string.Empty;

            return $"""
            {bodyEnd}
        </div>
    </div>
</div>
<!-- Modal end -->
""";
        }

        private string RenderHeaderHtml()
        {
            if (_noHeader)
            {
                return string.Empty;
            }

            string titleLevel = _titleLevel.Tag();
            string titleGap = _titleLevel.Gap();
            string styleCss = _variant.ToString().ToLowerInvariant();
            string headerContentCss = GetHeaderContentContainerCss();

            if (_iconOnlyHeader)
            {
                string iconHtmlOnly = _icon.IsEmpty
                    ? string.Empty
                    : $"<span>{RenderIconHtml(_icon)}</span>";

                string subtitleHtml = string.IsNullOrWhiteSpace(_subtitle)
                    ? string.Empty
                    : _iconOnlyCentered
                        ? $"""<div class="modal-subtitle small opacity-75 text-center">{HtmlEncoder.Default.Encode(_subtitle)}</div>"""
                        : $"""<div class="modal-subtitle small opacity-75">{HtmlEncoder.Default.Encode(_subtitle)}</div>""";

                if (_iconOnlyCentered)
                {
                    return $"""
<div class="modal-header bg-{styleCss} text-bg-{styleCss} border-bottom">
    <div class="d-flex flex-column align-items-center text-center w-100 {headerContentCss}">
        <{titleLevel} class="modal-title d-inline-flex align-items-center">{iconHtmlOnly}</{titleLevel}>
        {subtitleHtml}
    </div>
</div>
""";
                }

                return $"""
<div class="modal-header bg-{styleCss} text-bg-{styleCss} border-bottom">
    <div class="{headerContentCss}">
        <{titleLevel} class="modal-title d-inline-flex align-items-center">{iconHtmlOnly}</{titleLevel}>
        {subtitleHtml}
    </div>
</div>
""";
            }

            string iconHtml = _icon.IsEmpty
                ? string.Empty
                : $"<span>{RenderIconHtml(_icon)}</span>";

            string subtitleStandardHtml = string.IsNullOrWhiteSpace(_subtitle)
                ? string.Empty
                : $"""<div class="modal-subtitle small opacity-75">{HtmlEncoder.Default.Encode(_subtitle)}</div>""";

            return $"""
<div class="modal-header bg-{styleCss} text-bg-{styleCss} border-bottom">
    <div class="{headerContentCss}">
        <{titleLevel} class="modal-title d-inline-flex align-items-center {titleGap}">{iconHtml}<span>{HtmlEncoder.Default.Encode(_title ?? string.Empty)}</span></{titleLevel}>
        {subtitleStandardHtml}
    </div>
</div>
""";
        }

        private string RenderToolsOverlayHtml()
        {
            string toolsContentHtml = RenderToolsOverlayContentHtml();

            if (string.IsNullOrWhiteSpace(toolsContentHtml))
            {
                return string.Empty;
            }

            return $"""
<div class="{GetToolsOverlayContainerCss()}">
    {toolsContentHtml}
</div>
""";
        }

        private string RenderToolsOverlayContentHtml()
        {
            List<string> parts = new();

            if (_headerAction != null)
            {
                IHtmlContent buttonContent = HtmlHelper.Button(_headerAction);

                using StringWriter writer = new();
                buttonContent.WriteTo(writer, HtmlEncoder.Default);
                parts.Add(writer.ToString());
            }

            if (HasCloseButton())
            {
                string closeHtml = RenderCloseButton();
                if (!string.IsNullOrWhiteSpace(closeHtml))
                {
                    parts.Add(closeHtml);
                }
            }

            return string.Join(Environment.NewLine, parts);
        }

        private string RenderBodyStartHtml()
        {
            List<string> classes = new()
            {
                "modal-body",
                "text-start"
            };

            if (_bodyNoPadding)
            {
                classes.Add("p-0");
            }

            if (!string.IsNullOrWhiteSpace(_bodyAdditionalClasses))
            {
                classes.Add(_bodyAdditionalClasses);
            }

            return $"""
<div class="{string.Join(" ", classes.Where(x => !string.IsNullOrWhiteSpace(x)))}">
""";
        }

        private string RenderBodyEndHtml()
        {
            return """
</div>
""";
        }

        private bool ShouldRenderBodyEndHtml()
        {
            if (_htmlRenderContext == null)
            {
                return true;
            }

            if (_htmlRenderContext.Data.TryGetValue(HtmlRegionStateKeys.BodyOpen, out object? bodyOpenObj) &&
                bodyOpenObj is bool bodyOpen)
            {
                return bodyOpen;
            }

            return true;
        }

        private string BuildModalContentCss()
        {
            List<string> classes = new()
            {
                "modal-content",
                "overflow-hidden"
            };

            if (!string.IsNullOrWhiteSpace(_additionalClasses))
            {
                classes.Add(_additionalClasses);
            }

            if (_debugOnly)
            {
                classes.Add("theme-debug-only");
            }

            return string.Join(" ", classes.Where(x => !string.IsNullOrWhiteSpace(x)));
        }

        private bool HasCloseButton()
        {
            return !_noHeader;
        }

        private string RenderCloseButton()
        {
            string styleCss = _variant.ToString().ToLowerInvariant();

            return $"""
<button type="button" class="btn {CloseButtonAddClass} text-bg-{styleCss}" data-bs-dismiss="modal" aria-label="Close">
    <span class="{CloseIconBootstrap}"></span>
</button>
""";
        }

        private string GetToolsOverlayContainerCss()
        {
            return "modal-tools-overlay position-absolute top-0 end-0 p-3 d-inline-flex align-items-center gap-2";
        }

        private string GetHeaderContentContainerCss()
        {
            List<string> classes = new();

            if (_iconOnlyHeader && _iconOnlyCentered)
            {
                classes.Add("w-100");
            }

            string reservedBottomCss = GetHeaderReservedBottomCss();
            if (!string.IsNullOrWhiteSpace(reservedBottomCss))
            {
                classes.Add(reservedBottomCss);
            }

            return string.Join(" ", classes.Where(x => !string.IsNullOrWhiteSpace(x)));
        }

        private string GetHeaderReservedBottomCss()
        {
            if (_headerAction == null || _noHeader)
            {
                return string.Empty;
            }

            int estimate = 0;

            estimate += _titleLevel switch
            {
                TitleLevel.One => 0,
                TitleLevel.Two => 0,
                TitleLevel.Three => 1,
                TitleLevel.Four => 1,
                TitleLevel.Five => 2,
                TitleLevel.Six => 2,
                _ => 1
            };

            if (string.IsNullOrWhiteSpace(_subtitle))
            {
                estimate += 1;
            }

            if (_iconOnlyHeader)
            {
                estimate += 1;
            }

            estimate += _headerAction.Size switch
            {
                BoostrapButtonSize.Small => 0,
                BoostrapButtonSize.Medium => 1,
                BoostrapButtonSize.Large => 2,
                _ => 1
            };

            if (_iconOnlyHeader && _iconOnlyCentered)
            {
                estimate -= 1;
            }

            estimate = Math.Clamp(estimate, 0, 5);

            return estimate > 0 ? $"pb-{estimate}" : string.Empty;
        }

        #endregion

        #region Private helpers

        private void SyncTriggerTarget()
        {
            if (_triggerAction != null)
            {
                _triggerAction.ModalTargetId = _modalId;

                if (_debugOnly)
                {
                    _triggerAction.DebugOnly = true;
                }
            }
        }

        private ModalActionItem BuildTriggerAction()
        {
            _triggerAction ??= ActionItemFactory.Modal(
                _title ?? string.Empty,
                _modalId,
                _icon);

            _triggerAction.ModalTargetId = _modalId;

            if (_debugOnly)
            {
                _triggerAction.DebugOnly = true;
            }

            if (string.IsNullOrWhiteSpace(_triggerAction.Title))
            {
                _triggerAction.Title = _iconOnlyHeader ? string.Empty : _title;
            }

            if (_triggerAction.Icon.IsEmpty)
            {
                _triggerAction.Icon = _icon;
            }

            return _triggerAction;
        }

        private ModalActionItem ConvertToModalTrigger(IActionItem action)
        {
            if (action is ModalActionItem modalAction)
            {
                ModalActionItem clone = (ModalActionItem)modalAction.Clone();
                clone.ModalTargetId = _modalId;

                if (_debugOnly)
                {
                    clone.DebugOnly = true;
                }

                return clone;
            }

            return new ModalActionItem
            {
                Id = action.Id,
                Title = action.Title,
                Subtitle = action.Subtitle,
                Icon = action.Icon,
                DebugOnly = _debugOnly || action.DebugOnly,
                Outline = action.Outline,
                Variant = action.Variant,
                Size = action.Size,
                AdditionalClasses = action.AdditionalClasses,
                Disabled = action.Disabled,
                Active = action.Active,
                BadgeText = action.BadgeText,
                BadgeStyle = action.BadgeStyle,
                ModalTargetId = _modalId
            };
        }

        private string RenderPdfPreviewScript()
        {
            return $$$"""
<script>
document.addEventListener('DOMContentLoaded', function () {
    var modalEl = document.getElementById('{{_modalId}}');
    var iframe = document.getElementById('{{_pdfIframeId}}');
    var pdfUrl = '{{_pdfPreviewUrl}}';

    if (!modalEl || !iframe) {
        return;
    }

    modalEl.addEventListener('show.bs.modal', function () {
        iframe.src = pdfUrl;
    });

    modalEl.addEventListener('hidden.bs.modal', function () {
        iframe.src = '';
    });
});
</script>
""";
        }

        private void WriteHtmlContent(IHtmlContent content)
        {
            content.WriteTo(_textWriter, HtmlEncoder.Default);
        }

        private string RenderIconHtml(IconStruct icon)
        {
            using StringWriter writer = new();
            HtmlLayoutExtensions.IconBuilder(_htmlHelper, icon).WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        }

        #endregion
    }
}
