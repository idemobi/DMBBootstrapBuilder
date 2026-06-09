#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Globalization;
using System.Net;
using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Builds and renders the BootstrapBuilder progress bar component or page region.
    /// </summary>
    public sealed class ProgressBarBuilder :
        HtmlTagBuilder<ProgressBarBuilder>,
        ICanUseProgressBar
    {
        #region Instance fields and properties

        private string? _label
        {
            get => GetInternal<string?>("_label", null);
            set => SetInternal("_label", value);
        }

        private double _max
        {
            get => GetInternal("_max", 100d);
            set => SetInternal("_max", value);
        }

        private double _min
        {
            get => GetInternal("_min", 0d);
            set => SetInternal("_min", value);
        }

        private bool _renderWrapper
        {
            get => GetInternal("_renderWrapper", true);
            set => SetInternal("_renderWrapper", value);
        }

        private bool _showLabel
        {
            get => GetInternal("_showLabel", false);
            set => SetInternal("_showLabel", value);
        }

        private double _value
        {
            get => GetInternal("_value", 50d);
            set => SetInternal("_value", value);
        }

        private HtmlBuilderWrapper _wrapperComponent;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProgressBarBuilder" /> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public ProgressBarBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "div";
            _wrapperComponent = new HtmlBuilderWrapper(writer, html, HtmlTag.Div, "progress");
        }

        #endregion

        #region Instance methods

        private double ComputePercentage()
        {
            NormalizeBounds();

            if (_max <= _min)
            {
                return 0d;
            }

            double clamped = Math.Max(_min, Math.Min(_value, _max));
            return ((clamped - _min) / (_max - _min)) * 100d;
        }

        /// <inheritdoc />
        protected override ProgressBarBuilder CreateInstance()
        {
            return new ProgressBarBuilder(_textWriter, _htmlHelper);
        }

        /// <inheritdoc />
        protected override void InternalClone(ProgressBarBuilder source)
        {
            base.InternalClone(source);

            _label = source._label;
            _max = source._max;
            _min = source._min;
            _renderWrapper = source._renderWrapper;
            _showLabel = source._showLabel;
            _value = source._value;
            _wrapperComponent = source._wrapperComponent.Clone();
        }

        /// <summary>
        ///     Executes the BootstrapBuilder in wrapper component operation.
        /// </summary>
        /// <param name="configure">The configure value.</param>
        /// <returns>The configured <see cref="ProgressBarBuilder" /> value or BootstrapBuilder result.</returns>
        public ProgressBarBuilder InWrapperComponent(Func<HtmlBuilderWrapper, HtmlBuilderWrapper> configure)
        {
            ArgumentNullException.ThrowIfNull(configure);
            _wrapperComponent = configure(_wrapperComponent);
            return this;
        }

        private void NormalizeBounds()
        {
            if (_max < _min)
            {
                (_min, _max) = (_max, _min);
            }
        }

        internal string RenderBarHtmlOnly()
        {
            using StringWriter writer = new();
            WriteBarOnly(writer, HtmlEncoder.Default);
            return writer.ToString();
        }

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

        /// <summary>
        ///     Configures height on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <param name="unit">The unit value.</param>
        /// <returns>The configured <see cref="ProgressBarBuilder" /> value or BootstrapBuilder result.</returns>
        public ProgressBarBuilder SetHeight(uint size, UnitSize unit)
        {
            _wrapperComponent.SetStyle("height", $"{size}{unit.GetCss()}");
            return this;
        }

        /// <summary>
        ///     Configures label on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="label">The label value.</param>
        /// <returns>The configured <see cref="ProgressBarBuilder" /> value or BootstrapBuilder result.</returns>
        public ProgressBarBuilder SetLabel(string? label)
        {
            _label = label;
            return this;
        }

        /// <summary>
        ///     Configures max on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="ProgressBarBuilder" /> value or BootstrapBuilder result.</returns>
        public ProgressBarBuilder SetMax(double value)
        {
            _max = value;
            NormalizeBounds();
            return this;
        }

        /// <summary>
        ///     Configures min on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="ProgressBarBuilder" /> value or BootstrapBuilder result.</returns>
        public ProgressBarBuilder SetMin(double value)
        {
            _min = value;
            NormalizeBounds();
            return this;
        }

        /// <summary>
        ///     Configures percentage on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="ProgressBarBuilder" /> value or BootstrapBuilder result.</returns>
        public ProgressBarBuilder SetPercentage(double value)
        {
            _min = 0d;
            _max = 100d;
            _value = value;
            return this;
        }

        /// <summary>
        ///     Configures show label on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="ProgressBarBuilder" /> value or BootstrapBuilder result.</returns>
        public ProgressBarBuilder SetShowLabel(bool value = true)
        {
            _showLabel = value;
            return this;
        }

        /// <summary>
        ///     Configures size on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <returns>The configured <see cref="ProgressBarBuilder" /> value or BootstrapBuilder result.</returns>
        public ProgressBarBuilder SetSize(ProgressBarSize size)
        {
            _wrapperComponent.SetStyle("height", size.GetSizeAndUnitStyle());
            return this;
        }

        /// <summary>
        ///     Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="ProgressBarBuilder" /> value or BootstrapBuilder result.</returns>
        public ProgressBarBuilder SetValue(double value)
        {
            _value = value;
            return this;
        }

        internal ProgressBarBuilder WithoutWrapper(bool value = true)
        {
            _renderWrapper = !value;
            return this;
        }

        private void WriteBarOnly(TextWriter writer, HtmlEncoder encoder)
        {
            double percentage = ComputePercentage();

            string? previousRole = GetAttributeValue("role");
            string? previousAriaValueMin = GetAttributeValue("aria-valuemin");
            string? previousAriaValueMax = GetAttributeValue("aria-valuemax");
            string? previousAriaValueNow = GetAttributeValue("aria-valuenow");
            Dictionary<string, string> previousStyles = new(_styles, StringComparer.OrdinalIgnoreCase);

            try
            {
                SetAttribute("role", "progressbar");
                SetAria("valuemin", _min.ToString(CultureInfo.InvariantCulture));
                SetAria("valuemax", _max.ToString(CultureInfo.InvariantCulture));
                SetAria("valuenow", _value.ToString(CultureInfo.InvariantCulture));
                SetStyle("width", $"{percentage.ToString("0.####", CultureInfo.InvariantCulture)}%");

                string content = string.Empty;

                if (_showLabel)
                {
                    string label = _label ?? $"{percentage:0.#}%";
                    content = WebUtility.HtmlEncode(label);
                }

                writer.Write($"<{GetTag()}{BuildAttributes()}>{content}</{GetTag()}>");
            }
            finally
            {
                RestoreAttribute("role", previousRole);
                RestoreAttribute("aria-valuemin", previousAriaValueMin);
                RestoreAttribute("aria-valuemax", previousAriaValueMax);
                RestoreAttribute("aria-valuenow", previousAriaValueNow);

                _styles.Clear();

                foreach (KeyValuePair<string, string> kvp in previousStyles)
                {
                    _styles[kvp.Key] = kvp.Value;
                }
            }
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            if (_renderWrapper)
            {
                _wrapperComponent.SetInner(RenderBarHtmlOnly());
                _wrapperComponent.WriteTo(writer, encoder);
                return;
            }

            WriteBarOnly(writer, encoder);
        }

        #endregion
    }
}