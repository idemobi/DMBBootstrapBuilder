#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj HtmlPanelBuilderBase.cs create at 2026/04/07 21:04:27
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
    /// Represents the BootstrapBuilder html panel builder base component or support type.
    /// </summary>
    /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
    public abstract class HtmlPanelBuilderBase<TBuilder> :
        HtmlBuilderBase<TBuilder>,
        IDisposable,
        IHasTitle,
        IHasSubtitle,
        IHasIcon
        where TBuilder : HtmlBuilderBase<TBuilder>
    {
        #region Instance fields and properties

        private string? _additionalClasses;
        private string? _bodyAdditionalClasses;
        private bool _bodyNoPadding;
        private bool _centered = true;
        protected bool _debugOnly;
        private CardDecorationStyle _decoration = CardDecorationStyle.Decoration_None;

        private IActionItem? _headerAction;
        private IconStruct _icon;
        private bool _iconOnlyCentered;
        private bool _iconOnlyHeader;
        private bool _noHeader;
        private bool _started;
        private string? _subtitle;
        private string? _title;
        private TitleLevel _titleLevel = TitleLevel.Four;
        protected VariantStyle _variant = VariantStyle.Normal;

        #endregion

        #region Instance constructors and destructors

        protected HtmlPanelBuilderBase(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
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

        #region Protected accessors

        protected IHtmlHelper HtmlHelper => _htmlHelper;

        protected TextWriter Writer => _textWriter;

        protected bool Started
        {
            get => _started;
            set => _started = value;
        }

        protected bool CenteredValue => _centered;
        protected bool NoHeaderValue => _noHeader;
        protected bool BodyNoPaddingValue => _bodyNoPadding;
        protected bool IconOnlyHeaderValue => _iconOnlyHeader;
        protected bool IconOnlyCenteredValue => _iconOnlyCentered;
        protected string? TitleValue => _title;
        protected string? SubtitleValue => _subtitle;
        protected IconStruct IconValue => _icon;
        protected string? AdditionalClassesValue => _additionalClasses;
        protected string? BodyAdditionalClassesValue => _bodyAdditionalClasses;
        protected IActionItem? HeaderActionValue => _headerAction;
        protected TitleLevel TitleLevelValue => _titleLevel;
        protected VariantStyle StyleValue => _variant;
        protected CardDecorationStyle DecorationValue => _decoration;

        #endregion

        #region Fluent API

        /// <summary>
        /// Configures title on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <param name="titleLevel">The title level value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public TBuilder SetTitle(string title, TitleLevel titleLevel = TitleLevel.Three)
        {
            _iconOnlyHeader = false;
            _iconOnlyCentered = false;
            _title = title;
            _titleLevel = titleLevel;

            return This();
        }

        /// <summary>
        /// Configures subtitle on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="subtitle">The subtitle value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public TBuilder SetSubtitle(string subtitle)
        {
            _subtitle = subtitle;
            return This();
        }

        /// <summary>
        /// Configures icon bootstrap on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="iconBootstrap">The icon bootstrap value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public TBuilder SetIconBootstrap(string iconBootstrap)
        {
            _icon = IconStruct.Bootstrap(iconBootstrap);
            return This();
        }

        /// <summary>
        /// Configures title on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <param name="titleLevel">The title level value.</param>
        /// <param name="icon">The icon value.</param>
        /// <param name="subtitle">The subtitle value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public TBuilder WithTitle(string title, TitleLevel titleLevel, IconStruct icon = default, string? subtitle = null)
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

            return This();
        }

        /// <summary>
        /// Configures icon only on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="titleLevel">The title level value.</param>
        /// <param name="icon">The icon value.</param>
        /// <param name="centered">The centered value.</param>
        /// <param name="subtitle">The subtitle value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public TBuilder WithIconOnly(TitleLevel titleLevel, IconStruct icon, bool centered = true, string? subtitle = null)
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

            return This();
        }

        /// <summary>
        /// Executes the BootstrapBuilder debug only operation.
        /// </summary>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public TBuilder DebugOnly()
        {
            _debugOnly = true;
            return This();
        }

        /// <summary>
        /// Executes the BootstrapBuilder centered operation.
        /// </summary>
        /// <param name="centered">The centered value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public TBuilder Centered(bool centered = true)
        {
            _centered = centered;
            return This();
        }

        /// <summary>
        /// Executes the BootstrapBuilder no header operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public TBuilder NoHeader(bool value = true)
        {
            _noHeader = value;
            return This();
        }

        /// <summary>
        /// Executes the BootstrapBuilder body no padding operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public TBuilder BodyNoPadding(bool value = true)
        {
            _bodyNoPadding = value;
            return This();
        }

        /// <summary>
        /// Configures variant on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="variant">The variant value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public TBuilder WithVariant(VariantStyle variant)
        {
            _variant = variant;
            return This();
        }

        /// <summary>
        /// Configures decoration on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="decoration">The decoration value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public TBuilder WithDecoration(CardDecorationStyle decoration)
        {
            _decoration = decoration;
            return This();
        }

        /// <summary>
        /// Configures additional classes on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="additionalClasses">The additional classes value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public TBuilder WithAdditionalClasses(string additionalClasses)
        {
            _additionalClasses = additionalClasses;
            return This();
        }

        /// <summary>
        /// Configures body class on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="cssClass">The css class value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public TBuilder WithBodyClass(string cssClass)
        {
            if (!string.IsNullOrWhiteSpace(cssClass))
            {
                _bodyAdditionalClasses = string.IsNullOrWhiteSpace(_bodyAdditionalClasses)
                    ? cssClass.Trim()
                    : $"{_bodyAdditionalClasses} {cssClass.Trim()}";
            }

            return This();
        }

        /// <summary>
        /// Configures header action on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="action">The action value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public TBuilder SetHeaderAction(IActionItem action)
        {
            _headerAction = action ?? throw new ArgumentNullException(nameof(action));
            return This();
        }

        /// <summary>
        /// Configures data attribut on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public TBuilder SetDataAttribut(string name, string value)
        {
            return SetAttribut($"data-{name}", value);
        }

        /// <summary>
        /// Configures data attribut on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public TBuilder SetDataAttribut(string name, bool value)
        {
            return SetAttribut($"data-{name}", value);
        }

        /// <summary>
        /// Configures aria attribut on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public TBuilder SetAriaAttribut(string name, string value)
        {
            return SetAttribut($"aria-{name}", value);
        }

        /// <summary>
        /// Configures aria attribut on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public TBuilder SetAriaAttribut(string name, bool value)
        {
            return SetAttribut($"aria-{name}", value);
        }

        /// <summary>
        /// Configures attribut on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public TBuilder SetAttribut(string name, string value)
        {
            return SetAttribute(name, value);
        }

        /// <summary>
        /// Configures attribut on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public TBuilder SetAttribut(string name, bool value)
        {
            return SetAttribute(name, value);
        }

        #endregion

        #region Public rendering lifecycle

        /// <summary>
        /// Executes the BootstrapBuilder begin operation.
        /// </summary>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public TBuilder Begin()
        {
            if (_started)
            {
                return This();
            }

            ValidateBeforeBegin();
            OnRenderDebug();
            OnBeginRendering();

            Writer.Write(RenderPanelStart());

            _started = true;
            return This();
        }

        /// <summary>
        /// Executes the BootstrapBuilder dispose operation.
        /// </summary>
        public virtual void Dispose()
        {
            if (!_started)
            {
                return;
            }

            Writer.Write(RenderPanelEnd());
            OnEndRendering();
            _started = false;
        }

        #endregion

        #region Overrides

        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            ValidateBeforeBegin();
            OnRenderDebug();
            OnBeginRendering();

            try
            {
                writer.Write(RenderPanelStart());
                writer.Write(RenderPanelEnd());
            }
            finally
            {
                OnEndRendering();
            }
        }

        protected override void InternalClone(TBuilder source)
        {
            base.InternalClone(source);

            if (source is not HtmlPanelBuilderBase<TBuilder> panel)
            {
                return;
            }

            _additionalClasses = panel._additionalClasses;
            _bodyAdditionalClasses = panel._bodyAdditionalClasses;
            _bodyNoPadding = panel._bodyNoPadding;
            _centered = panel._centered;
            _debugOnly = panel._debugOnly;
            _decoration = panel._decoration;
            _headerAction = panel._headerAction;
            _icon = panel._icon;
            _iconOnlyCentered = panel._iconOnlyCentered;
            _iconOnlyHeader = panel._iconOnlyHeader;
            _noHeader = panel._noHeader;
            _subtitle = panel._subtitle;
            _title = panel._title;
            _titleLevel = panel._titleLevel;
            _variant = panel._variant;
        }

        #endregion

        #region Overridables

        protected virtual void ValidateBeforeBegin()
        {
            if (_noHeader)
            {
                return;
            }

            if (!_iconOnlyHeader && string.IsNullOrWhiteSpace(_title))
            {
                throw new InvalidOperationException("Panel title must be defined before Begin().");
            }

            if (_iconOnlyHeader && _icon.IsEmpty)
            {
                throw new InvalidOperationException("Panel icon must be defined before Begin() when using IconOnly().");
            }
        }

        protected virtual void OnBeginRendering()
        {
        }

        protected virtual void OnEndRendering()
        {
        }

        protected abstract string RenderOuterStart(string contentHtml);
        protected abstract string RenderOuterEnd();

        protected virtual string GetRegionCssPrefix()
        {
            return "card";
        }

        protected virtual bool HasCloseButton()
        {
            return false;
        }

        protected virtual string RenderCloseButton()
        {
            return string.Empty;
        }

        protected virtual string GetToolsOverlayContainerCss()
        {
            return $"{GetRegionCssPrefix()}-tools-overlay position-absolute top-0 end-0 p-3 d-inline-flex align-items-center gap-2";
        }

        protected virtual string GetHeaderContentContainerCss()
        {
            List<string> classes = new();

            if (IconOnlyHeaderValue && IconOnlyCenteredValue)
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

        protected virtual string GetHeaderReservedBottomCss()
        {
            if (HeaderActionValue == null || NoHeaderValue)
            {
                return string.Empty;
            }

            int estimate = 0;

            estimate += TitleLevelValue switch
            {
                TitleLevel.One => 0,
                TitleLevel.Two => 0,
                TitleLevel.Three => 1,
                TitleLevel.Four => 1,
                TitleLevel.Five => 2,
                TitleLevel.Six => 2,
                _ => 1
            };

            if (string.IsNullOrWhiteSpace(SubtitleValue))
            {
                estimate += 1;
            }

            if (IconOnlyHeaderValue)
            {
                estimate += 1;
            }

            estimate += HeaderActionValue.Size switch
            {
                BoostrapButtonSize.Small => 0,
                BoostrapButtonSize.Medium => 1,
                BoostrapButtonSize.Large => 2,
                _ => 1
            };

            if (IconOnlyHeaderValue && IconOnlyCenteredValue)
            {
                estimate -= 1;
            }

            estimate = Math.Clamp(estimate, 0, 5);

            return estimate > 0 ? $"pb-{estimate}" : string.Empty;
        }

        protected virtual bool ShouldRenderBodyEndHtml()
        {
            return true;
        }

        #endregion

        #region Protected render helpers

        protected virtual string RenderPanelStart()
        {
            string contentHtml = $"{RenderToolsOverlayHtml()}{RenderHeaderHtml()}{RenderBodyStartHtml()}";
            return RenderOuterStart(contentHtml);
        }

        protected virtual string RenderPanelEnd()
        {
            string bodyEnd = ShouldRenderBodyEndHtml()
                ? RenderBodyEndHtml()
                : string.Empty;

            return $"{bodyEnd}{RenderOuterEnd()}";
        }

        protected virtual string RenderHeaderHtml()
        {
            if (_noHeader)
            {
                return string.Empty;
            }

            string prefix = GetRegionCssPrefix();
            string styleCss = _variant.ToString().ToLowerInvariant();
            string titleLevel = _titleLevel.Tag();
            string titleGap = _titleLevel.Gap();
            string headerContentCss = GetHeaderContentContainerCss();
            string additionalAttributes = BuildAdditionalAttributes();

            if (_iconOnlyHeader)
            {
                string iconHtmlOnly = _icon.IsEmpty
                    ? string.Empty
                    : $"<span>{RenderIconHtml(_icon)}</span>";

                string subtitleHtml = string.IsNullOrWhiteSpace(_subtitle)
                    ? string.Empty
                    : _iconOnlyCentered
                        ? $"""<div class="{prefix}-subtitle small opacity-75 text-center ">{HtmlEncoder.Default.Encode(_subtitle)}</div>"""
                        : $"""<div class="{prefix}-subtitle small opacity-75 ">{HtmlEncoder.Default.Encode(_subtitle)}</div>""";

                if (_iconOnlyCentered)
                {
                    return $"""
 <div class="{prefix}-header bg-{styleCss}text-bg-{styleCss}border-bottom"{additionalAttributes}>
    <div class="d-flex flex-column align-items-center text-center {headerContentCss}">
        <{titleLevel}class="{prefix}-title d-inline-flex align-items-center">{iconHtmlOnly}</{titleLevel}>
        {subtitleHtml}
    </div>
 </div>
 """;
                }

                return $"""
 <div class="{prefix}-header bg-{styleCss}text-bg-{styleCss}border-bottom"{additionalAttributes}>
    <div class="{headerContentCss}">
        <{titleLevel}class="{prefix}-title d-inline-flex align-items-center">{iconHtmlOnly}</{titleLevel}>
        {subtitleHtml}
    </div>
 </div>
 """;
            }

            string iconHtml = _icon.IsEmpty
                ? string.Empty
                : $"<span>{RenderIconHtml(_icon)}</span>";

            string standardSubtitleHtml = string.IsNullOrWhiteSpace(_subtitle)
                ? string.Empty
                : $"""<div class="{prefix}-subtitle small opacity-75">{HtmlEncoder.Default.Encode(_subtitle)}</div>""";

            return $"""
<div class="{prefix}-header bg-{styleCss} text-bg-{styleCss} border-bottom"{additionalAttributes}>
    <div class="{headerContentCss}">
        <{titleLevel} class="{prefix}-title d-inline-flex align-items-center {titleGap}">{iconHtml}<span>{HtmlEncoder.Default.Encode(_title ?? string.Empty)}</span></{titleLevel}>
        {standardSubtitleHtml}
    </div>
</div>
""";
        }

        protected virtual string RenderToolsOverlayHtml()
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

        protected virtual string RenderToolsOverlayContentHtml()
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

        protected virtual string RenderBodyStartHtml()
        {
            string prefix = GetRegionCssPrefix();

            List<string> classes = new()
            {
                $"{prefix}-body",
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

        protected virtual string RenderBodyEndHtml()
        {
            return """
                   </div>
                   """;
        }

        protected string BuildPanelSurfaceCssClasses()
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

        protected virtual string GetDecorationCssClass()
        {
            string decoration = _decoration.ToString().ToLowerInvariant().Replace("_", "-");
            return string.IsNullOrWhiteSpace(decoration)
                ? string.Empty
                : $"{GetRegionCssPrefix()}-{decoration}";
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