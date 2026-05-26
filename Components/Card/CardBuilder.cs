#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj CardBuilder.cs create at 2026/04/07 21:04:27
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
    /// Builds and renders the BootstrapBuilder card component or page region.
    /// </summary>
    public sealed class CardBuilder :
        HtmlConstrainedTagBuilder<CardBuilder>,
        IDisposable,
        ICanUseCustomClasses,
        IHasTitle,
        IHasSubtitle,
        IHasIcon
    {
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

        private CardDecorationStyle _decoration
        {
            get => GetInternal("_decoration", CardDecorationStyle.Decoration_success);
            set => SetInternal("_decoration", value);
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

        private bool _noHeader
        {
            get => GetInternal("_noHeader", false);
            set => SetInternal("_noHeader", value);
        }

        private HtmlRenderContext? _renderContext;

        private bool _started
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
            set => _subtitle = value;
        }

        IconStruct IHasIcon.Icon
        {
            get => _icon;
            set => _icon = value;
        }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CardBuilder"/> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public CardBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "div";
            _classesOfComponent.Add("card");
            _decoration = CardDecorationStyle.Decoration_success;
        }

        #endregion

        #region Protected accessors

        protected override HtmlRenderContextKind ContextKind => HtmlRenderContextKind.Card;

        protected IHtmlHelper HtmlHelper => _htmlHelper;

        #endregion

        #region Fluent API

        /// <summary>
        /// Configures title on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <param name="titleLevel">The title level value.</param>
        /// <returns>The configured <see cref="CardBuilder"/> value or BootstrapBuilder result.</returns>
        public CardBuilder SetTitle(string title, TitleLevel titleLevel = TitleLevel.Three)
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
        /// <returns>The configured <see cref="CardBuilder"/> value or BootstrapBuilder result.</returns>
        public CardBuilder SetSubtitle(string subtitle)
        {
            _subtitle = subtitle;
            return this;
        }

        /// <summary>
        /// Configures icon bootstrap on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="iconBootstrap">The icon bootstrap value.</param>
        /// <returns>The configured <see cref="CardBuilder"/> value or BootstrapBuilder result.</returns>
        public CardBuilder SetIconBootstrap(string iconBootstrap)
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
        /// <returns>The configured <see cref="CardBuilder"/> value or BootstrapBuilder result.</returns>
        public CardBuilder WithTitle(string title, TitleLevel titleLevel, IconStruct icon = default, string? subtitle = null)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Panel title cannot be null or empty.", nameof(title));
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
        /// <returns>The configured <see cref="CardBuilder"/> value or BootstrapBuilder result.</returns>
        public CardBuilder WithIconOnly(TitleLevel titleLevel, IconStruct icon, bool centered = true, string? subtitle = null)
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
        /// <returns>The configured <see cref="CardBuilder"/> value or BootstrapBuilder result.</returns>
        public CardBuilder DebugOnly()
        {
            _debugOnly = true;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder centered operation.
        /// </summary>
        /// <param name="centered">The centered value.</param>
        /// <returns>The configured <see cref="CardBuilder"/> value or BootstrapBuilder result.</returns>
        public CardBuilder Centered(bool centered = true)
        {
            _centered = centered;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder no header operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="CardBuilder"/> value or BootstrapBuilder result.</returns>
        public CardBuilder NoHeader(bool value = true)
        {
            _noHeader = value;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder body no padding operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="CardBuilder"/> value or BootstrapBuilder result.</returns>
        public CardBuilder BodyNoPadding(bool value = true)
        {
            _bodyNoPadding = value;
            return this;
        }

        /// <summary>
        /// Configures variant on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="variant">The variant value.</param>
        /// <returns>The configured <see cref="CardBuilder"/> value or BootstrapBuilder result.</returns>
        public CardBuilder WithVariant(VariantStyle variant)
        {
            _variant = variant;
            return this;
        }

        /// <summary>
        /// Configures decoration on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="decoration">The decoration value.</param>
        /// <returns>The configured <see cref="CardBuilder"/> value or BootstrapBuilder result.</returns>
        public CardBuilder WithDecoration(CardDecorationStyle decoration)
        {
            _decoration = decoration;
            return this;
        }

        /// <summary>
        /// Configures additional classes on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="additionalClasses">The additional classes value.</param>
        /// <returns>The configured <see cref="CardBuilder"/> value or BootstrapBuilder result.</returns>
        public CardBuilder WithAdditionalClasses(string additionalClasses)
        {
            _additionalClasses = additionalClasses;
            return this;
        }

        /// <summary>
        /// Configures body class on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="cssClass">The css class value.</param>
        /// <returns>The configured <see cref="CardBuilder"/> value or BootstrapBuilder result.</returns>
        public CardBuilder WithBodyClass(string cssClass)
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
        /// <returns>The configured <see cref="CardBuilder"/> value or BootstrapBuilder result.</returns>
        public CardBuilder SetHeaderAction(IActionItem action)
        {
            _headerAction = action ?? throw new ArgumentNullException(nameof(action));
            return this;
        }

        /// <summary>
        /// Configures data attribut on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="CardBuilder"/> value or BootstrapBuilder result.</returns>
        public CardBuilder SetDataAttribut(string name, string value)
        {
            return SetAttribut($"data-{name}", value);
        }

        /// <summary>
        /// Configures data attribut on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="CardBuilder"/> value or BootstrapBuilder result.</returns>
        public CardBuilder SetDataAttribut(string name, bool value)
        {
            return SetAttribut($"data-{name}", value);
        }

        /// <summary>
        /// Configures aria attribut on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="CardBuilder"/> value or BootstrapBuilder result.</returns>
        public CardBuilder SetAriaAttribut(string name, string value)
        {
            return SetAttribut($"aria-{name}", value);
        }

        /// <summary>
        /// Configures aria attribut on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="CardBuilder"/> value or BootstrapBuilder result.</returns>
        public CardBuilder SetAriaAttribut(string name, bool value)
        {
            return SetAttribut($"aria-{name}", value);
        }

        /// <summary>
        /// Configures attribut on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="CardBuilder"/> value or BootstrapBuilder result.</returns>
        public CardBuilder SetAttribut(string name, string value)
        {
            return SetAttribute(name, value);
        }

        /// <summary>
        /// Configures attribut on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="CardBuilder"/> value or BootstrapBuilder result.</returns>
        public CardBuilder SetAttribut(string name, bool value)
        {
            return SetAttribute(name, value);
        }

        #endregion

        #region Lifecycle

        /// <summary>
        /// Executes the BootstrapBuilder begin operation.
        /// </summary>
        /// <returns>The configured <see cref="CardBuilder"/> value or BootstrapBuilder result.</returns>
        public new CardBuilder Begin()
        {
            if (_started)
            {
                return this;
            }

            ValidateBeforeBegin();
            OnRenderDebug();
            OnBeginRendering();

            _textWriter.Write(RenderCardStart());
            _started = true;

            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder dispose operation.
        /// </summary>
        public void Dispose()
        {
            if (!_started)
            {
                return;
            }

            _textWriter.Write(RenderCardEnd());
            OnEndRendering();
            _started = false;
        }

        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            ValidateBeforeBegin();
            OnRenderDebug();
            OnBeginRendering();

            try
            {
                writer.Write(RenderCardStart());
                writer.Write(RenderCardEnd());
            }
            finally
            {
                OnEndRendering();
            }
        }

        #endregion

        #region Overrides

        protected override CardBuilder CreateInstance()
        {
            return new CardBuilder(_textWriter, _htmlHelper);
        }

        protected override void InternalClone(CardBuilder source)
        {
            base.InternalClone(source);

            _additionalClasses = source._additionalClasses;
            _bodyAdditionalClasses = source._bodyAdditionalClasses;
            _bodyNoPadding = source._bodyNoPadding;
            _centered = source._centered;
            _debugOnly = source._debugOnly;
            _decoration = source._decoration;
            _headerAction = source._headerAction;
            _icon = source._icon;
            _iconOnlyCentered = source._iconOnlyCentered;
            _iconOnlyHeader = source._iconOnlyHeader;
            _noHeader = source._noHeader;
            _subtitle = source._subtitle;
            _title = source._title;
            _titleLevel = source._titleLevel;
            _variant = source._variant;

            _started = false;
            _renderContext = null;
        }

        protected override void OnBeginRendering()
        {
            _renderContext = new HtmlRenderContext
            {
                Kind = HtmlRenderContextKind.Card,
                Owner = this
            };

            _renderContext.Data[HtmlRegionStateKeys.BodyOpen] = true;
            _renderContext.Data[HtmlRegionStateKeys.FooterOpen] = false;
            _renderContext.Data[HtmlRegionStateKeys.BodyClosedByFooter] = false;

            HtmlRenderContextManager.Push(HtmlHelper, _renderContext);
        }

        protected override void OnEndRendering()
        {
            HtmlRenderContext? current = HtmlRenderContextManager.Current(HtmlHelper);

            if (ReferenceEquals(current, _renderContext))
            {
                HtmlRenderContextManager.Pop(HtmlHelper);
            }

            _renderContext = null;
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
                throw new InvalidOperationException("Card title must be defined before Begin().");
            }

            if (_iconOnlyHeader && _icon.IsEmpty)
            {
                throw new InvalidOperationException("Card icon must be defined before Begin() when using IconOnly().");
            }
        }

        #endregion

        #region Render helpers

        private string RenderCardStart()
        {
            string contentHtml = $"{RenderToolsOverlayHtml()}{RenderHeaderHtml()}{RenderBodyStartHtml()}";
            return RenderOuterStart(contentHtml);
        }

        private string RenderCardEnd()
        {
            string bodyEnd = ShouldRenderBodyEndHtml()
                ? RenderBodyEndHtml()
                : string.Empty;

            return $"{bodyEnd}{RenderOuterEnd()}";
        }

        private string RenderOuterStart(string contentHtml)
        {
            string surfaceClasses = BuildPanelSurfaceCssClasses();

            string classes = string.IsNullOrWhiteSpace(surfaceClasses)
                ? "card"
                : $"card {surfaceClasses}";

            if (_debugOnly)
            {
                classes += " theme-debug-only";
            }

            #if DEBUG
            classes += " cardbuilder";
            #endif

            string additionalAttributes = BuildAdditionalAttributes();

            return $"""
<div class="{classes}"{additionalAttributes}>
    {contentHtml}
""";
        }

        private string RenderOuterEnd()
        {
            return """
</div>
""";
        }

        private string RenderHeaderHtml()
        {
            if (_noHeader)
            {
                return string.Empty;
            }

            string prefix = "card";
            string styleCss = _variant.ToString().ToLowerInvariant();
            string titleLevel = _titleLevel.Tag();
            string titleGap = _titleLevel.Gap();
            string headerContentCss = GetHeaderContentContainerCss();

            if (_iconOnlyHeader)
            {
                string iconHtmlOnly = _icon.IsEmpty
                    ? string.Empty
                    : $"<span>{RenderIconHtml(_icon)}</span>";

                string subtitleHtml = string.IsNullOrWhiteSpace(_subtitle)
                    ? string.Empty
                    : _iconOnlyCentered
                        ? $"""<div class="{prefix}-subtitle small opacity-75 text-center">{HtmlEncoder.Default.Encode(_subtitle)}</div>"""
                        : $"""<div class="{prefix}-subtitle small opacity-75">{HtmlEncoder.Default.Encode(_subtitle)}</div>""";

                if (_iconOnlyCentered)
                {
                    return $"""
<div class="{prefix}-header bg-{styleCss} text-bg-{styleCss} border-bottom">
    <div class="d-flex flex-column align-items-center text-center {headerContentCss}">
        <{titleLevel} class="{prefix}-title d-inline-flex align-items-center">{iconHtmlOnly}</{titleLevel}>
        {subtitleHtml}
    </div>
</div>
""";
                }

                return $"""
<div class="{prefix}-header bg-{styleCss} text-bg-{styleCss} border-bottom">
    <div class="{headerContentCss}">
        <{titleLevel} class="{prefix}-title d-inline-flex align-items-center">{iconHtmlOnly}</{titleLevel}>
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
                : $"""<div class="{prefix}-subtitle small opacity-75">{HtmlEncoder.Default.Encode(_subtitle)}</div>""";

            return $"""
<div class="{prefix}-header bg-{styleCss} text-bg-{styleCss} border-bottom">
    <div class="{headerContentCss}">
        <{titleLevel} class="{prefix}-title d-inline-flex align-items-center {titleGap}">{iconHtml}<span>{HtmlEncoder.Default.Encode(_title ?? string.Empty)}</span></{titleLevel}>
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

            return string.Join(Environment.NewLine, parts);
        }

        private string RenderBodyStartHtml()
        {
            List<string> classes = new()
            {
                "card-body",
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
            if (_renderContext == null)
            {
                return true;
            }

            if (_renderContext.Data.TryGetValue(HtmlRegionStateKeys.BodyOpen, out object? bodyOpenObj) &&
                bodyOpenObj is bool bodyOpen)
            {
                return bodyOpen;
            }

            return true;
        }

        private string BuildPanelSurfaceCssClasses()
        {
            List<string> classes = new()
            {
                "overflow-hidden"
            };

            if (!string.IsNullOrWhiteSpace(_additionalClasses))
            {
                classes.Add(_additionalClasses);
            }

            string decorationCss = GetDecorationCssClass();
            if (!string.IsNullOrWhiteSpace(decorationCss))
            {
                classes.Add(decorationCss);
            }

            return string.Join(" ", classes.Where(x => !string.IsNullOrWhiteSpace(x)));
        }

        private string GetDecorationCssClass()
        {
            string decoration = _decoration.ToString().ToLowerInvariant().Replace("_", "-");
            return string.IsNullOrWhiteSpace(decoration)
                ? string.Empty
                : $"card-{decoration}";
        }

        private string GetToolsOverlayContainerCss()
        {
            return "card-tools-overlay position-absolute top-0 end-0 p-3 d-inline-flex align-items-center gap-2";
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

        private string BuildAdditionalAttributes()
        {
            if (_attributes.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new();

            foreach (KeyValuePair<string, string> kvp in _attributes)
            {
                if (string.IsNullOrWhiteSpace(kvp.Key) || string.IsNullOrWhiteSpace(kvp.Value))
                {
                    continue;
                }

                if (string.Equals(kvp.Key, "class", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(kvp.Key, "style", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                sb.Append(' ');
                sb.Append(HtmlEncoder.Default.Encode(kvp.Key));
                sb.Append("=\"");
                sb.Append(HtmlEncoder.Default.Encode(kvp.Value));
                sb.Append('"');
            }

            return sb.ToString();
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