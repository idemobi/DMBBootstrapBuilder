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
    ///     Builds and renders the BootstrapBuilder image render component or page region.
    /// </summary>
    [Documented]
    public sealed class ImageRenderBuilder : HtmlTagBuilder<ImageRenderBuilder>,
        ICanUseOrder,
        ICanUseFloat,
        ICanUseMargin,
        ICanUsePadding,
        ICanUseOpacity,
        ICanUseVisibility,
        ICanUseVerticalAlign,
        ICanUseTextAlign
    {
        #region Static methods

        private static void AppendStyle(List<string> styles, string property, string? value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                styles.Add($"{property}:{value}");
            }
        }

        private static string GetTimingCssValue(ImageRenderEffectTiming timing)
        {
            return timing switch
            {
                ImageRenderEffectTiming.Ease => "ease",
                ImageRenderEffectTiming.EaseIn => "ease-in",
                ImageRenderEffectTiming.EaseOut => "ease-out",
                ImageRenderEffectTiming.Linear => "linear",
                _ => "ease-in-out"
            };
        }

        #endregion

        #region Instance fields and properties

        private bool _allowDownload
        {
            get => GetInternal("_allowDownload", false);
            set => SetInternal("_allowDownload", value);
        }

        private bool _allowThemeDownload
        {
            get => GetInternal("_allowThemeDownload", false);
            set => SetInternal("_allowThemeDownload", value);
        }

        private bool _asEffect
        {
            get => GetInternal("_asEffect", false);
            set => SetInternal("_asEffect", value);
        }

        private double _effectAnimationDuration
        {
            get => GetInternal("_effectAnimationDuration", 10000d);
            set => SetInternal("_effectAnimationDuration", value);
        }

        private double _effectDelay
        {
            get => GetInternal("_effectDelay", 0d);
            set => SetInternal("_effectDelay", value);
        }

        private double _effectDuration
        {
            get => GetInternal("_effectDuration", 500d);
            set => SetInternal("_effectDuration", value);
        }

        private ImageRenderEffectTiming _effectTiming
        {
            get => GetInternal("_effectTiming", ImageRenderEffectTiming.EaseInOut);
            set => SetInternal("_effectTiming", value);
        }

        private ImageMediaBuilder _mediaComponent = null!;
        private ModalBuilder _modalComponent = null!;

        private bool _openInModal
        {
            get => GetInternal("_openInModal", false);
            set => SetInternal("_openInModal", value);
        }

        private bool _showDownloadButtonOnImage
        {
            get => GetInternal("_showDownloadButtonOnImage", false);
            set => SetInternal("_showDownloadButtonOnImage", value);
        }

        private bool _showSpinner
        {
            get => GetInternal("_showSpinner", true);
            set => SetInternal("_showSpinner", value);
        }

        private SpinnerBuilder _spinnerComponent = null!;

        private string _title
        {
            get => GetInternal("_title", string.Empty);
            set => SetInternal("_title", value);
        }

        private ImageWrapperBuilder _wrapperComponent = null!;

        internal bool AsEffect => _asEffect;
        internal new IHtmlHelper HtmlHelper => _htmlHelper;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImageRenderBuilder" /> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="src">The src value.</param>
        /// <param name="alt">The alt value.</param>
        public ImageRenderBuilder(TextWriter writer, IHtmlHelper html, string src, string alt = "")
            : base(writer, html)
        {
            ArgumentNullException.ThrowIfNull(src);

            _mediaComponent = new ImageMediaBuilder(writer, html, src, alt);
            _wrapperComponent = new ImageWrapperBuilder(writer, html);
            _spinnerComponent = new SpinnerBuilder(writer, html);
            _spinnerComponent.SetData("image-render-spinner", true);
            _modalComponent = new ModalBuilder(writer, html);
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override ImageRenderBuilder CreateInstance()
        {
            return new ImageRenderBuilder(_textWriter, _htmlHelper, _mediaComponent.GetSource(), _mediaComponent.GetAlternate());
        }

        /// <summary>
        ///     Executes the BootstrapBuilder in media component operation.
        /// </summary>
        /// <param name="configure">The configure value.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder InMediaComponent(Func<ImageMediaBuilder, ImageMediaBuilder> configure)
        {
            ArgumentNullException.ThrowIfNull(configure);
            _mediaComponent = configure(_mediaComponent);
            return this;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder in modal component operation.
        /// </summary>
        /// <param name="configure">The configure value.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder InModalComponent(Func<ModalBuilder, ModalBuilder> configure)
        {
            ArgumentNullException.ThrowIfNull(configure);
            _modalComponent = configure(_modalComponent);
            return this;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder in spinner component operation.
        /// </summary>
        /// <param name="configure">The configure value.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder InSpinnerComponent(Func<SpinnerBuilder, SpinnerBuilder> configure)
        {
            ArgumentNullException.ThrowIfNull(configure);
            _spinnerComponent = configure(_spinnerComponent);
            return this;
        }

        /// <inheritdoc />
        protected override void InternalClone(ImageRenderBuilder source)
        {
            base.InternalClone(source);

            _allowDownload = source._allowDownload;
            _allowThemeDownload = source._allowThemeDownload;
            _asEffect = source._asEffect;
            _effectAnimationDuration = source._effectAnimationDuration;
            _effectDelay = source._effectDelay;
            _effectDuration = source._effectDuration;
            _effectTiming = source._effectTiming;
            _openInModal = source._openInModal;
            _showDownloadButtonOnImage = source._showDownloadButtonOnImage;
            _showSpinner = source._showSpinner;
            _title = source._title;

            _mediaComponent = source._mediaComponent.Clone();
            _modalComponent = source._modalComponent.Clone();
            _spinnerComponent = source._spinnerComponent.Clone();
            _wrapperComponent = source._wrapperComponent.Clone();
        }

        /// <summary>
        ///     Executes the BootstrapBuilder in wrapper component operation.
        /// </summary>
        /// <param name="configure">The configure value.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder InWrapperComponent(Func<ImageWrapperBuilder, ImageWrapperBuilder> configure)
        {
            ArgumentNullException.ThrowIfNull(configure);
            _wrapperComponent = configure(_wrapperComponent);
            return this;
        }

        #region Effects

        /// <summary>
        ///     Executes the BootstrapBuilder mark as effect operation.
        /// </summary>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder MarkAsEffect()
        {
            _asEffect = true;
            return this;
        }

        #endregion

        /// <summary>
        ///     Removes border from the current BootstrapBuilder component or composer.
        /// </summary>
        /// <param name="side">The side value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder RemoveBorder(
            BorderSide side = BorderSide.All,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
        {
            _mediaComponent.RemoveBorder(side, breakpoint);
            return this;
        }

        #region Private methods

        private void RestoreAttribute(string name, string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                RemoveAttribute(name);
            }
            else
            {
                _attributes[name] = value;
            }
        }

        #endregion

        /// <summary>
        ///     Configures border on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="side">The side value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder SetBorder(
            BorderSide side = BorderSide.All,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
        {
            _mediaComponent.SetBorder(side, breakpoint);
            return this;
        }

        /// <summary>
        ///     Configures border color on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="color">The color value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder SetBorderColor(
            BorderColor color,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
        {
            _mediaComponent.SetBorderColor(color, breakpoint);
            return this;
        }

        /// <summary>
        ///     Configures border opacity on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="opacity">The opacity value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder SetBorderOpacity(
            BorderOpacity opacity,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
        {
            _mediaComponent.SetBorderOpacity(opacity, breakpoint);
            return this;
        }

        /// <summary>
        ///     Configures height on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <param name="unit">The unit value.</param>
        /// <param name="important">The important value.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder SetHeight(uint size, UnitSize unit = UnitSize.percent, bool important = false)
        {
            _mediaComponent.SetHeight(size, unit, important);
            _wrapperComponent.SetHeight(size, unit, important);
            return this;
        }

        /// <summary>
        ///     Configures max height on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <param name="unit">The unit value.</param>
        /// <param name="important">The important value.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder SetMaxHeight(uint size, UnitSize unit = UnitSize.percent, bool important = false)
        {
            _mediaComponent.SetMaxHeight(size, unit, important);
            _wrapperComponent.SetMaxHeight(size, unit, important);
            return this;
        }

        /// <summary>
        ///     Configures max width on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <param name="unit">The unit value.</param>
        /// <param name="important">The important value.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder SetMaxWidth(uint size, UnitSize unit = UnitSize.percent, bool important = false)
        {
            _mediaComponent.SetMaxWidth(size, unit, important);
            _wrapperComponent.SetMaxWidth(size, unit, important);
            return this;
        }

        /// <summary>
        ///     Configures min height on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <param name="unit">The unit value.</param>
        /// <param name="important">The important value.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder SetMinHeight(uint size, UnitSize unit = UnitSize.percent, bool important = false)
        {
            _mediaComponent.SetMinHeight(size, unit, important);
            _wrapperComponent.SetMinHeight(size, unit, important);
            return this;
        }

        /// <summary>
        ///     Configures min width on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <param name="unit">The unit value.</param>
        /// <param name="important">The important value.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder SetMinWidth(uint size, UnitSize unit = UnitSize.percent, bool important = false)
        {
            _mediaComponent.SetMinWidth(size, unit, important);
            _wrapperComponent.SetMinWidth(size, unit, important);
            return this;
        }

        /// <summary>
        ///     Configures rounded on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <param name="side">The side value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder SetRounded(
            BorderRadiusSize size = BorderRadiusSize.Normal,
            BorderRadiusSide side = BorderRadiusSide.All,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
        {
            _mediaComponent.SetRounded(size, side, breakpoint);
            return this;
        }

        /// <summary>
        ///     Configures shadow on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="shadow">The shadow value.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder SetShadow(Shadow shadow)
        {
            _mediaComponent.SetShadow(shadow);
            return this;
        }

        /// <summary>
        ///     Configures width on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <param name="unit">The unit value.</param>
        /// <param name="important">The important value.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder SetWidth(uint size, UnitSize unit = UnitSize.percent, bool important = false)
        {
            _mediaComponent.SetWidth(size, unit, important);
            _wrapperComponent.SetWidth(size, unit, important);
            return this;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder show spinner operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder ShowSpinner(bool value = true)
        {
            _showSpinner = value;
            return this;
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            PageInformation page = PageRegistry.GetOrCreatePageInformation(_htmlHelper.ViewContext.HttpContext);
            page.SetScriptFile("/js/ImageRender.js");
            page.SetStylesheet("/css/ImageRender.css");

            string id = _htmlHelper.GenerateUniqueId("img_");

            string? previousId = GetAttributeValue("id");
            string? previousImageRender = GetAttributeValue("data-image-render");
            string? previousSrc = GetAttributeValue("data-image-render-src");
            string? previousAlt = GetAttributeValue("data-image-render-alt");
            string? previousMode = GetAttributeValue("data-image-render-mode");
            string? previousOpenModal = GetAttributeValue("data-image-render-open-modal");
            string? previousAllowDownload = GetAttributeValue("data-image-render-allow-download");
            string? previousAllowThemeDownload = GetAttributeValue("data-image-render-allow-theme-download");

            try
            {
                SetId("render_" + id);

                _wrapperComponent.SetId("wrapper_" + id);
                _mediaComponent.SetId("media_" + id);
                _mediaComponent.SetData("image-render-img", true);

                _spinnerComponent.SetId("spinner_" + id);
                _spinnerComponent.SetCentered();
                _spinnerComponent.AddClass(string.Empty);

                SetData("image-render", true);
                SetData("image-render-src", _mediaComponent.GetSource());
                SetData("image-render-alt", _mediaComponent.GetAlternate());
                SetData("image-render-mode", _mediaComponent.ResolveMode().ToString());
                SetData("image-render-open-modal", _openInModal.ToString().ToLowerInvariant());
                SetData("image-render-allow-download", _allowDownload.ToString().ToLowerInvariant());
                SetData("image-render-allow-theme-download", _allowThemeDownload.ToString().ToLowerInvariant());

                if (_asEffect)
                {
                    SetStyle("--eb-image-effect-duration", $"{_effectDuration}ms");
                    SetStyle("--eb-image-effect-delay", $"{_effectDelay}ms");
                    SetStyle("--eb-image-effect-animation-duration", $"{_effectAnimationDuration}ms");
                    SetStyle("--eb-image-effect-timing", GetTimingCssValue(_effectTiming));
                }

                string overlayDownloadHtml = string.Empty;

                if (_allowDownload && _showDownloadButtonOnImage && !_openInModal)
                {
                    _wrapperComponent.AddClass("position-relative");
                    overlayDownloadHtml =
                        "<button type=\"button\" class=\"image-render-download btn btn-sm btn-light\" data-image-render-download-on-image=\"true\" aria-label=\"Download image\"><i class=\"bi-download\"></i></button>";
                }

                writer.Write($"<div{BuildAttributes()}>");
                writer.Write($"<div{_wrapperComponent.BuildAttributes()}>");

                if (_showSpinner)
                {
                    _spinnerComponent.WriteTo(writer, encoder);
                }

                _mediaComponent.WriteTo(writer, encoder);

                if (!string.IsNullOrWhiteSpace(overlayDownloadHtml))
                {
                    writer.Write(overlayDownloadHtml);
                }

                writer.Write("</div>");
                writer.Write("</div>");
            }
            finally
            {
                RestoreAttribute("id", previousId);
                RestoreAttribute("data-image-render", previousImageRender);
                RestoreAttribute("data-image-render-src", previousSrc);
                RestoreAttribute("data-image-render-alt", previousAlt);
                RestoreAttribute("data-image-render-mode", previousMode);
                RestoreAttribute("data-image-render-open-modal", previousOpenModal);
                RestoreAttribute("data-image-render-allow-download", previousAllowDownload);
                RestoreAttribute("data-image-render-allow-theme-download", previousAllowThemeDownload);
            }
        }

        #endregion

        #region Metadata

        /// <summary>
        ///     Executes the BootstrapBuilder alt operation.
        /// </summary>
        /// <param name="alt">The alt value.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder Alt(string alt)
        {
            _mediaComponent.SetAlt(alt ?? string.Empty);
            return this;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder title operation.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder Title(string title)
        {
            _title = title ?? string.Empty;
            return this;
        }

        #endregion

        #region Mode

        /// <summary>
        ///     Executes the BootstrapBuilder mode operation.
        /// </summary>
        /// <param name="mode">The mode value.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder Mode(ImageRenderMode mode)
        {
            _mediaComponent.SetMode(mode);
            return this;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder inline svg operation.
        /// </summary>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder InlineSvg()
        {
            _mediaComponent.SetMode(ImageRenderMode.InlineSvg);
            return this;
        }

        #endregion

        #region Appearance

        /// <summary>
        ///     Executes the BootstrapBuilder open in modal operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder OpenInModal(bool value = true)
        {
            _openInModal = value;
            return this;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder allow download operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder AllowDownload(bool value = true)
        {
            _allowDownload = value;
            return this;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder allow theme download operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder AllowThemeDownload(bool value = true)
        {
            _allowThemeDownload = value;
            return this;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder show download button on image operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder ShowDownloadButtonOnImage(bool value = true)
        {
            _showDownloadButtonOnImage = value;
            return this;
        }

        #endregion

        #region Effect timing

        /// <summary>
        ///     Executes the BootstrapBuilder effect duration ms operation.
        /// </summary>
        /// <param name="ms">The ms value.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder EffectDurationMs(int ms)
        {
            if (ms <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(ms));
            }

            _effectDuration = ms;
            return this;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder effect delay ms operation.
        /// </summary>
        /// <param name="ms">The ms value.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder EffectDelayMs(int ms)
        {
            if (ms < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(ms));
            }

            _effectDelay = ms;
            return this;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder effect animation duration ms operation.
        /// </summary>
        /// <param name="ms">The ms value.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder EffectAnimationDurationMs(int ms)
        {
            if (ms <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(ms));
            }

            _effectAnimationDuration = ms;
            return this;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder effect timing operation.
        /// </summary>
        /// <param name="timing">The timing value.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder" /> value or BootstrapBuilder result.</returns>
        public ImageRenderBuilder EffectTiming(ImageRenderEffectTiming timing)
        {
            _effectTiming = timing;
            return this;
        }

        #endregion
    }
}