#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

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
    ///     Builds and renders the BootstrapBuilder spinner component or page region.
    /// </summary>
    public sealed class SpinnerBuilder : HtmlTagBuilder<SpinnerBuilder>, ICanUseHeight, ICanUseWidth, ICanUseCustomClasses
    {
        #region Instance fields and properties

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

        private string _label
        {
            get => GetInternal("_label", "…loading…");
            set => SetInternal("_label", value);
        }

        private SpinnerSize _size
        {
            get => GetInternal("_size", SpinnerSize.Default);
            set => SetInternal("_size", value);
        }

        private string _sizeByUnit
        {
            get => GetInternal("_sizeByUnit", string.Empty);
            set => SetInternal("_sizeByUnit", value);
        }

        private VariantStyle _style
        {
            get => GetInternal("_style", VariantStyle.Primary);
            set => SetInternal("_style", value);
        }

        private SpinnerType _type
        {
            get => GetInternal("_type", SpinnerType.Border);
            set => SetInternal("_type", value);
        }

        private bool _wrapCentered
        {
            get => GetInternal("_wrapCentered", true);
            set => SetInternal("_wrapCentered", value);
        }

        private SpinnerWrapperBuilder _wrapperComponent;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SpinnerBuilder" /> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public SpinnerBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "div";
            _wrapperComponent = new SpinnerWrapperBuilder(_textWriter, _htmlHelper, "div");
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override SpinnerBuilder CreateInstance()
        {
            return new SpinnerBuilder(_textWriter, _htmlHelper);
        }

        /// <inheritdoc />
        protected override void InternalClone(SpinnerBuilder source)
        {
            base.InternalClone(source);

            _centerHorizontally = source._centerHorizontally;
            _centerVertically = source._centerVertically;
            _label = source._label;
            _size = source._size;
            _sizeByUnit = source._sizeByUnit;
            _style = source._style;
            _type = source._type;
            _wrapCentered = source._wrapCentered;
            _wrapperComponent = source._wrapperComponent.Clone();
        }

        /// <summary>
        ///     Executes the BootstrapBuilder in wrapper component operation.
        /// </summary>
        /// <param name="configure">The configure value.</param>
        /// <returns>The configured <see cref="SpinnerBuilder" /> value or BootstrapBuilder result.</returns>
        public SpinnerBuilder InWrapperComponent(Func<SpinnerWrapperBuilder, SpinnerWrapperBuilder> configure)
        {
            ArgumentNullException.ThrowIfNull(configure);
            _wrapperComponent = configure(_wrapperComponent);
            return this;
        }

        /// <summary>
        ///     Renders spinner html for the BootstrapBuilder output.
        /// </summary>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public string RenderSpinnerHtml()
        {
            using StringWriter writer = new();
            WriteSpinnerOnly(writer, HtmlEncoder.Default);
            return writer.ToString();
        }

        /// <summary>
        ///     Configures centered on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="horizontal">The horizontal value.</param>
        /// <param name="vertical">The vertical value.</param>
        /// <returns>The configured <see cref="SpinnerBuilder" /> value or BootstrapBuilder result.</returns>
        public SpinnerBuilder SetCentered(bool horizontal = true, bool vertical = false)
        {
            _wrapCentered = true;
            _centerHorizontally = horizontal;
            _centerVertically = vertical;
            return this;
        }

        /// <summary>
        ///     Configures label on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="label">The label value.</param>
        /// <returns>The configured <see cref="SpinnerBuilder" /> value or BootstrapBuilder result.</returns>
        public SpinnerBuilder SetLabel(string label)
        {
            _label = string.IsNullOrWhiteSpace(label) ? "Loading..." : label;
            return this;
        }

        /// <summary>
        ///     Configures size on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <returns>The configured <see cref="SpinnerBuilder" /> value or BootstrapBuilder result.</returns>
        public SpinnerBuilder SetSize(SpinnerSize size)
        {
            _size = size;
            _sizeByUnit = string.Empty;
            return this;
        }

        /// <summary>
        ///     Configures size on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <param name="unit">The unit value.</param>
        /// <returns>The configured <see cref="SpinnerBuilder" /> value or BootstrapBuilder result.</returns>
        public SpinnerBuilder SetSize(uint value, UnitSize unit)
        {
            _size = SpinnerSize.Free;
            _sizeByUnit = $"{value}{unit.GetCss()}";
            return this;
        }

        /// <summary>
        ///     Configures spinner type on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="type">The type value.</param>
        /// <returns>The configured <see cref="SpinnerBuilder" /> value or BootstrapBuilder result.</returns>
        public SpinnerBuilder SetSpinnerType(SpinnerType type)
        {
            _type = type;
            return this;
        }

        /// <summary>
        ///     Configures variant on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="style">The style value.</param>
        /// <returns>The configured <see cref="SpinnerBuilder" /> value or BootstrapBuilder result.</returns>
        public SpinnerBuilder SetVariant(VariantStyle style)
        {
            _style = style;
            return this;
        }

        /// <summary>
        ///     Configures wrapper min height on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <param name="unit">The unit value.</param>
        /// <returns>The configured <see cref="SpinnerBuilder" /> value or BootstrapBuilder result.</returns>
        public SpinnerBuilder SetWrapperMinHeight(uint value, UnitSize unit)
        {
            InWrapperComponent(wrapper => wrapper.SetStyle("min-height", $"{value}{unit.GetCss()}"));
            return this;
        }

        /// <summary>
        ///     Configures wrapper min width on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <param name="unit">The unit value.</param>
        /// <returns>The configured <see cref="SpinnerBuilder" /> value or BootstrapBuilder result.</returns>
        public SpinnerBuilder SetWrapperMinWidth(uint value, UnitSize unit)
        {
            InWrapperComponent(wrapper => wrapper.SetStyle("min-width", $"{value}{unit.GetCss()}"));
            return this;
        }

        private void WriteSpinnerOnly(TextWriter writer, HtmlEncoder encoder)
        {
            Dictionary<string, string> previousStyles = new(_styles, StringComparer.OrdinalIgnoreCase);

            using (PushInternalClasses(
                       _size == SpinnerSize.Free ? string.Empty : _size.GetCssClass(_type),
                       _type.GetCssClass(),
                       _style.GetOldTextCssClass()))
            {
                try
                {
                    if (_size == SpinnerSize.Free && !string.IsNullOrWhiteSpace(_sizeByUnit))
                    {
                        SetStyle("height", _sizeByUnit);
                        SetStyle("width", _sizeByUnit);
                    }

                    writer.Write($"<{_tag}{BuildAttributes()}><span class=\"visually-hidden\">{WebUtility.HtmlEncode(_label)}</span></{_tag}>");
                }
                finally
                {
                    _styles.Clear();

                    foreach (KeyValuePair<string, string> kvp in previousStyles)
                    {
                        _styles[kvp.Key] = kvp.Value;
                    }
                }
            }
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            string spinnerHtml = RenderSpinnerHtml();

            if (!_wrapCentered)
            {
                writer.Write(spinnerHtml);
                return;
            }

            SpinnerWrapperBuilder localWrapper = _wrapperComponent.Clone();
            localWrapper.SetInner(spinnerHtml);
            localWrapper.AddClass("d-flex");

            if (_centerHorizontally)
            {
                localWrapper.AddClass("justify-content-center");
            }

            if (_centerVertically)
            {
                localWrapper.AddClass("align-items-center");
            }

            localWrapper.WriteTo(writer, encoder);
        }

        #endregion
    }
}