#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj LoadingBlockBuilder.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using System.Net;
using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Builds and renders the BootstrapBuilder loading block component or page region.
    /// </summary>
    public sealed class LoadingBlockBuilder : HtmlTagBuilder<LoadingBlockBuilder>
    {
        #region Static methods

        private static string JoinClasses(params string[] values)
        {
            return string.Join(" ", values.Where(x => !string.IsNullOrWhiteSpace(x)));
        }

        private static bool TryParsePx(string? css, out uint value)
        {
            value = 0;

            if (string.IsNullOrWhiteSpace(css) || !css.EndsWith("px", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return uint.TryParse(css[..^2], out value);
        }

        #endregion

        #region Instance fields and properties

        private string _additionalClasses
        {
            get => GetInternal("_additionalClasses", string.Empty);
            set => SetInternal("_additionalClasses", value);
        }

        private bool _centerHorizontally
        {
            get => GetInternal("_centerHorizontally", true);
            set => SetInternal("_centerHorizontally", value);
        }

        private bool _centerVertically
        {
            get => GetInternal("_centerVertically", true);
            set => SetInternal("_centerVertically", value);
        }

        private bool _fullWidth
        {
            get => GetInternal("_fullWidth", true);
            set => SetInternal("_fullWidth", value);
        }

        private int _gap
        {
            get => GetInternal("_gap", 2);
            set => SetInternal("_gap", value);
        }

        private string? _minHeightCss
        {
            get => GetInternal<string?>("_minHeightCss", null);
            set => SetInternal("_minHeightCss", value);
        }

        private string _spinnerClasses
        {
            get => GetInternal("_spinnerClasses", string.Empty);
            set => SetInternal("_spinnerClasses", value);
        }

        private string? _spinnerHeightCss
        {
            get => GetInternal<string?>("_spinnerHeightCss", null);
            set => SetInternal("_spinnerHeightCss", value);
        }

        private string _spinnerLabel
        {
            get => GetInternal("_spinnerLabel", "Loading...");
            set => SetInternal("_spinnerLabel", value);
        }

        private SpinnerSize _spinnerSize
        {
            get => GetInternal("_spinnerSize", SpinnerSize.Default);
            set => SetInternal("_spinnerSize", value);
        }

        private SpinnerType _spinnerType
        {
            get => GetInternal("_spinnerType", SpinnerType.Border);
            set => SetInternal("_spinnerType", value);
        }

        private string? _spinnerWidthCss
        {
            get => GetInternal<string?>("_spinnerWidthCss", null);
            set => SetInternal("_spinnerWidthCss", value);
        }

        private VariantStyle _style
        {
            get => GetInternal("_style", VariantStyle.Primary);
            set => SetInternal("_style", value);
        }

        private string? _text
        {
            get => GetInternal<string?>("_text", null);
            set => SetInternal("_text", value);
        }

        private string _textClasses
        {
            get => GetInternal("_textClasses", string.Empty);
            set => SetInternal("_textClasses", value);
        }

        private bool _textMuted
        {
            get => GetInternal("_textMuted", true);
            set => SetInternal("_textMuted", value);
        }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadingBlockBuilder"/> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public LoadingBlockBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "div";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override LoadingBlockBuilder CreateInstance()
        {
            return new LoadingBlockBuilder(_textWriter, _htmlHelper);
        }

        /// <inheritdoc />
        protected override void InternalClone(LoadingBlockBuilder source)
        {
            base.InternalClone(source);

            _additionalClasses = source._additionalClasses;
            _centerHorizontally = source._centerHorizontally;
            _centerVertically = source._centerVertically;
            _fullWidth = source._fullWidth;
            _gap = source._gap;
            _minHeightCss = source._minHeightCss;
            _spinnerClasses = source._spinnerClasses;
            _spinnerHeightCss = source._spinnerHeightCss;
            _spinnerLabel = source._spinnerLabel;
            _spinnerSize = source._spinnerSize;
            _spinnerType = source._spinnerType;
            _spinnerWidthCss = source._spinnerWidthCss;
            _style = source._style;
            _text = source._text;
            _textClasses = source._textClasses;
            _textMuted = source._textMuted;
        }

        private string BuildSpinnerHtml()
        {
            SpinnerBuilder spinner = new SpinnerBuilder(_textWriter, _htmlHelper)
                .SetSpinnerType(_spinnerType)
                .SetSize(_spinnerSize)
                .SetVariant(_style)
                .SetLabel(_spinnerLabel)
                .AddClasses(_spinnerClasses);

            if (!string.IsNullOrWhiteSpace(_spinnerWidthCss) && !string.IsNullOrWhiteSpace(_spinnerHeightCss))
            {
                if (TryParsePx(_spinnerWidthCss, out uint pxw) &&
                    TryParsePx(_spinnerHeightCss, out uint pxh) &&
                    pxw == pxh)
                {
                    spinner.SetSize(pxw, UnitSize.px);
                }
                else
                {
                    if (TryParsePx(_spinnerWidthCss, out uint widthPx))
                    {
                        spinner.SetWidth(widthPx, UnitSize.px);
                    }

                    if (TryParsePx(_spinnerHeightCss, out uint heightPx))
                    {
                        spinner.SetHeight(heightPx, UnitSize.px);
                    }
                }
            }
            else
            {
                if (TryParsePx(_spinnerWidthCss, out uint widthPx))
                {
                    spinner.SetWidth(widthPx, UnitSize.px);
                }

                if (TryParsePx(_spinnerHeightCss, out uint heightPx))
                {
                    spinner.SetHeight(heightPx, UnitSize.px);
                }
            }

            return spinner.RenderSpinnerHtml() ?? string.Empty;
        }

        private string BuildTextHtml()
        {
            if (string.IsNullOrWhiteSpace(_text))
            {
                return string.Empty;
            }

            string css = JoinClasses(
                _textMuted ? "text-body-secondary" : string.Empty,
                _textClasses
            );

            return $"""
                    <div class="{WebUtility.HtmlEncode(css)}">{WebUtility.HtmlEncode(_text)}</div>
                    """;
        }

        private string BuildWrapperCss()
        {
            return JoinClasses(
                "d-flex",
                "flex-column",
                _centerHorizontally ? "justify-content-center align-items-center text-center" : string.Empty,
                _centerVertically && !_centerHorizontally ? "justify-content-center" : string.Empty,
                _fullWidth ? "w-100" : string.Empty,
                _gap > 0 ? $"gap-{_gap}" : string.Empty,
                _additionalClasses
            );
        }

        private string BuildWrapperStyleAttribute()
        {
            if (string.IsNullOrWhiteSpace(_minHeightCss))
            {
                return string.Empty;
            }

            return $""" style="min-height:{WebUtility.HtmlEncode(_minHeightCss)};" """;
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            string wrapperCss = BuildWrapperCss();
            string wrapperStyle = BuildWrapperStyleAttribute();
            string spinnerHtml = BuildSpinnerHtml();
            string textHtml = BuildTextHtml();

            writer.Write($"""
                          <div class="{WebUtility.HtmlEncode(wrapperCss)}"{wrapperStyle}>
                              {spinnerHtml}
                              {textHtml}
                          </div>
                          """);
        }

        #endregion

        #region Spinner API

        /// <summary>
        /// Configures spinner type on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="type">The type value.</param>
        /// <returns>The configured <see cref="LoadingBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public LoadingBlockBuilder WithSpinnerType(SpinnerType type)
        {
            _spinnerType = type;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder border operation.
        /// </summary>
        /// <returns>The configured <see cref="LoadingBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public LoadingBlockBuilder Border()
        {
            _spinnerType = SpinnerType.Border;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder grow operation.
        /// </summary>
        /// <returns>The configured <see cref="LoadingBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public LoadingBlockBuilder Grow()
        {
            _spinnerType = SpinnerType.Grow;
            return this;
        }

        /// <summary>
        /// Configures spinner size on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <returns>The configured <see cref="LoadingBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public LoadingBlockBuilder WithSpinnerSize(SpinnerSize size)
        {
            _spinnerSize = size;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder small spinner operation.
        /// </summary>
        /// <returns>The configured <see cref="LoadingBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public LoadingBlockBuilder SmallSpinner()
        {
            _spinnerSize = SpinnerSize.Small;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder style operation.
        /// </summary>
        /// <param name="style">The style value.</param>
        /// <returns>The configured <see cref="LoadingBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public LoadingBlockBuilder Style(VariantStyle style)
        {
            _style = style;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder spinner label operation.
        /// </summary>
        /// <param name="label">The label value.</param>
        /// <returns>The configured <see cref="LoadingBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public LoadingBlockBuilder SpinnerLabel(string label)
        {
            _spinnerLabel = string.IsNullOrWhiteSpace(label) ? "Loading..." : label;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder spinner size px operation.
        /// </summary>
        /// <param name="px">The px value.</param>
        /// <returns>The configured <see cref="LoadingBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public LoadingBlockBuilder SpinnerSizePx(int px)
        {
            if (px <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(px));
            }

            _spinnerWidthCss = $"{px}px";
            _spinnerHeightCss = $"{px}px";
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder spinner width px operation.
        /// </summary>
        /// <param name="px">The px value.</param>
        /// <returns>The configured <see cref="LoadingBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public LoadingBlockBuilder SpinnerWidthPx(int px)
        {
            if (px <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(px));
            }

            _spinnerWidthCss = $"{px}px";
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder spinner height px operation.
        /// </summary>
        /// <param name="px">The px value.</param>
        /// <returns>The configured <see cref="LoadingBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public LoadingBlockBuilder SpinnerHeightPx(int px)
        {
            if (px <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(px));
            }

            _spinnerHeightCss = $"{px}px";
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder spinner classes operation.
        /// </summary>
        /// <param name="classes">The classes value.</param>
        /// <returns>The configured <see cref="LoadingBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public LoadingBlockBuilder SpinnerClasses(string classes)
        {
            _spinnerClasses = classes ?? string.Empty;
            return this;
        }

        #endregion

        #region Text API

        /// <summary>
        /// Executes the BootstrapBuilder text operation.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <returns>The configured <see cref="LoadingBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public LoadingBlockBuilder Text(string? text)
        {
            _text = text;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder text muted operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="LoadingBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public LoadingBlockBuilder TextMuted(bool value = true)
        {
            _textMuted = value;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder text classes operation.
        /// </summary>
        /// <param name="classes">The classes value.</param>
        /// <returns>The configured <see cref="LoadingBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public LoadingBlockBuilder TextClasses(string classes)
        {
            _textClasses = classes ?? string.Empty;
            return this;
        }

        #endregion

        #region Layout API

        /// <summary>
        /// Executes the BootstrapBuilder centered operation.
        /// </summary>
        /// <param name="horizontal">The horizontal value.</param>
        /// <param name="vertical">The vertical value.</param>
        /// <returns>The configured <see cref="LoadingBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public LoadingBlockBuilder Centered(bool horizontal = true, bool vertical = true)
        {
            _centerHorizontally = horizontal;
            _centerVertically = vertical;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder center horizontally operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="LoadingBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public LoadingBlockBuilder CenterHorizontally(bool value = true)
        {
            _centerHorizontally = value;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder center vertically operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="LoadingBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public LoadingBlockBuilder CenterVertically(bool value = true)
        {
            _centerVertically = value;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder full width operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="LoadingBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public LoadingBlockBuilder FullWidth(bool value = true)
        {
            _fullWidth = value;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder gap operation.
        /// </summary>
        /// <param name="gap">The gap value.</param>
        /// <returns>The configured <see cref="LoadingBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public LoadingBlockBuilder Gap(int gap)
        {
            if (gap < 0 || gap > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(gap));
            }

            _gap = gap;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder min height px operation.
        /// </summary>
        /// <param name="px">The px value.</param>
        /// <returns>The configured <see cref="LoadingBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public LoadingBlockBuilder MinHeightPx(int px)
        {
            if (px <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(px));
            }

            _minHeightCss = $"{px}px";
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder min height vh operation.
        /// </summary>
        /// <param name="vh">The vh value.</param>
        /// <returns>The configured <see cref="LoadingBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public LoadingBlockBuilder MinHeightVh(int vh)
        {
            if (vh <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(vh));
            }

            _minHeightCss = $"{vh}vh";
            return this;
        }

        /// <summary>
        /// Configures classes on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="classes">The classes value.</param>
        /// <returns>The configured <see cref="LoadingBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public LoadingBlockBuilder WithClasses(string classes)
        {
            _additionalClasses = classes ?? string.Empty;
            return this;
        }

        #endregion
    }
}