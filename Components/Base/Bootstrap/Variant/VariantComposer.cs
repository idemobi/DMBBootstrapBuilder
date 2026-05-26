#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj VariantComposer.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Composes Bootstrap CSS classes or page chrome for variant.
    /// </summary>
    public sealed class VariantComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private bool _autoTextVariantFromBackground;
        private Opacity _backgroundOpacity;
        private bool _backgroundSubtle;

        private VariantStyle? _backgroundVariant;
        private bool _textEmphasize;
        private VariantStyle? _textVariant;

        #endregion

        #region Instance methods

        /// <summary>
        /// Configures background complex on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="variant">The variant value.</param>
        /// <param name="autoTextVariant">The auto text variant value.</param>
        /// <param name="opacity">The opacity value.</param>
        /// <param name="subtle">The subtle value.</param>
        /// <returns>The configured <see cref="VariantComposer"/> value or BootstrapBuilder result.</returns>
        public VariantComposer SetBackgroundComplex(VariantStyle variant, bool autoTextVariant, Opacity opacity = Opacity.Normal, bool subtle = false)
        {
            _backgroundVariant = variant;
            _autoTextVariantFromBackground = autoTextVariant;
            _backgroundSubtle = subtle;
            _backgroundOpacity = opacity;
            return this;
        }

        /// <summary>
        /// Configures background opacity on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="opacity">The opacity value.</param>
        /// <returns>The configured <see cref="VariantComposer"/> value or BootstrapBuilder result.</returns>
        public VariantComposer SetBackgroundOpacity(Opacity opacity)
        {
            _backgroundOpacity = opacity;
            return this;
        }

        /// <summary>
        /// Configures background subtle on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="subtle">The subtle value.</param>
        /// <returns>The configured <see cref="VariantComposer"/> value or BootstrapBuilder result.</returns>
        public VariantComposer SetBackgroundSubtle(bool subtle)
        {
            _backgroundSubtle = subtle;
            return this;
        }

        /// <summary>
        /// Configures background variant on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="variant">The variant value.</param>
        /// <returns>The configured <see cref="VariantComposer"/> value or BootstrapBuilder result.</returns>
        public VariantComposer SetBackgroundVariant(VariantStyle variant)
        {
            _backgroundVariant = variant;
            return this;
        }

        /// <summary>
        /// Configures text on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="variant">The variant value.</param>
        /// <returns>The configured <see cref="VariantComposer"/> value or BootstrapBuilder result.</returns>
        public VariantComposer SetText(VariantStyle variant)
        {
            _textVariant = variant;
            return this;
        }

        /// <summary>
        /// Configures text emphasize on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="emphasize">The emphasize value.</param>
        /// <returns>The configured <see cref="VariantComposer"/> value or BootstrapBuilder result.</returns>
        public VariantComposer SetTextEmphasize(bool emphasize = false)
        {
            _textEmphasize = emphasize;
            return this;
        }

        /// <summary>
        /// Configures text variant from background on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="autoTextVariant">The auto text variant value.</param>
        /// <returns>The configured <see cref="VariantComposer"/> value or BootstrapBuilder result.</returns>
        public VariantComposer SetTextVariantFromBackground(bool autoTextVariant)
        {
            _autoTextVariantFromBackground = autoTextVariant;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        /// Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            List<string> result = new();

            if (_backgroundVariant.HasValue)
            {
                string bgCss = _backgroundVariant.Value.GetBackgroundCssClass(_backgroundSubtle);
                if (!string.IsNullOrWhiteSpace(bgCss))
                {
                    result.Add(bgCss);
                }

                if (_autoTextVariantFromBackground)
                {
                    VariantStyle? autoTextVariant = _backgroundVariant.Value.GetRecommendedTextVariant();
                    if (autoTextVariant.HasValue)
                    {
                        string autoTextCss = autoTextVariant.Value.GetTextCssClass(_textEmphasize);
                        if (!string.IsNullOrWhiteSpace(autoTextCss))
                        {
                            result.Add(autoTextCss);
                        }
                    }
                }
            }

            if (_backgroundOpacity != Opacity.Normal)
            {
                result.Add($"bg-{_backgroundOpacity.GetCss()}");
            }

            if (_autoTextVariantFromBackground == false)
            {
                if (_textVariant.HasValue)
                {
                    string textCss = _textVariant.Value.GetTextCssClass(_textEmphasize);
                    if (!string.IsNullOrWhiteSpace(textCss))
                    {
                        result.Add(textCss);
                    }
                }
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
            var clone = new VariantComposer();

            clone._textVariant = _textVariant;
            clone._backgroundVariant = _backgroundVariant;
            clone._autoTextVariantFromBackground = _autoTextVariantFromBackground;
            clone._backgroundSubtle = _backgroundSubtle;
            clone._backgroundOpacity = _backgroundOpacity;
            clone._textEmphasize = _textEmphasize;

            return clone;
        }

        #endregion

        #endregion
    }
}