#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj AlertComposer.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Composes Bootstrap CSS classes or page chrome for alert.
    /// </summary>
    public sealed class AlertComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private bool _dismissible;
        private bool _fade;
        private bool _show = true;
        private VariantStyle _variant = VariantStyle.Primary;
        private bool _withIconLayout;

        /// <summary>
        /// Gets or sets a value indicating whether dismissible is enabled for BootstrapBuilder rendering.
        /// </summary>
        public bool IsDismissible => _dismissible;
        /// <summary>
        /// Gets or sets a value indicating whether fade is enabled for BootstrapBuilder rendering.
        /// </summary>
        public bool IsFade => _fade;
        /// <summary>
        /// Gets or sets a value indicating whether show is enabled for BootstrapBuilder rendering.
        /// </summary>
        public bool IsShow => _show;
        /// <summary>
        /// Gets or sets a value indicating whether with icon layout is enabled for BootstrapBuilder rendering.
        /// </summary>
        public bool IsWithIconLayout => _withIconLayout;
        /// <summary>
        /// Gets or sets the variant value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public VariantStyle Variant => _variant;

        #endregion

        #region Instance methods

        /// <summary>
        /// Configures dismissible on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="AlertComposer"/> value or BootstrapBuilder result.</returns>
        public AlertComposer SetDismissible(bool value = true)
        {
            _dismissible = value;
            return this;
        }

        /// <summary>
        /// Configures fade on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="AlertComposer"/> value or BootstrapBuilder result.</returns>
        public AlertComposer SetFade(bool value = true)
        {
            _fade = value;
            return this;
        }

        /// <summary>
        /// Configures show on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="AlertComposer"/> value or BootstrapBuilder result.</returns>
        public AlertComposer SetShow(bool value = true)
        {
            _show = value;
            return this;
        }

        /// <summary>
        /// Configures variant on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="variant">The variant value.</param>
        /// <returns>The configured <see cref="AlertComposer"/> value or BootstrapBuilder result.</returns>
        public AlertComposer SetVariant(VariantStyle variant)
        {
            _variant = variant;
            return this;
        }

        /// <summary>
        /// Configures with icon layout on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="AlertComposer"/> value or BootstrapBuilder result.</returns>
        public AlertComposer SetWithIconLayout(bool value = true)
        {
            _withIconLayout = value;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        /// Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            List<string> result = new()
            {
                "alert"
            };

            string variantCss = _variant.GetVariantCss();
            if (!string.IsNullOrWhiteSpace(variantCss))
            {
                result.Add($"alert-{variantCss}");
            }

            if (_dismissible)
            {
                result.Add("alert-dismissible");
            }

            if (_fade)
            {
                result.Add("fade");
            }

            if (_show)
            {
                result.Add("show");
            }

            if (_withIconLayout)
            {
                result.Add("d-flex");
                result.Add("align-items-start");
            }

            return result
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct(StringComparer.Ordinal)
                .ToList();
        }

        /// <summary>
        /// Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IIsCssClassComposer"/> value or BootstrapBuilder result.</returns>
        public IIsCssClassComposer Clone()
        {
            return new AlertComposer()
                .SetVariant(_variant)
                .SetDismissible(_dismissible)
                .SetFade(_fade)
                .SetShow(_show)
                .SetWithIconLayout(_withIconLayout);
        }

        #endregion

        #endregion
    }
}