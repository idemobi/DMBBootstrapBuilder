using DMBPageBuilder;

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Composes Bootstrap CSS classes or page chrome for progress bar.
    /// </summary>
    public sealed class ProgressBarComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private bool _animated;
        private bool _striped;
        private VariantStyle _variant = VariantStyle.Primary;

        #endregion

        #region Instance methods

        /// <summary>
        /// Configures animated on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="ProgressBarComposer"/> value or BootstrapBuilder result.</returns>
        public ProgressBarComposer SetAnimated(bool value = true)
        {
            _animated = value;

            if (_animated)
            {
                _striped = true;
            }

            return this;
        }

        /// <summary>
        /// Configures striped on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="ProgressBarComposer"/> value or BootstrapBuilder result.</returns>
        public ProgressBarComposer SetStriped(bool value = true)
        {
            _striped = value;
            return this;
        }

        /// <summary>
        /// Configures variant on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="variant">The variant value.</param>
        /// <returns>The configured <see cref="ProgressBarComposer"/> value or BootstrapBuilder result.</returns>
        public ProgressBarComposer SetVariant(VariantStyle variant)
        {
            _variant = variant;
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
                "progress-bar"
            };

            string bgCss = _variant.GetBackgroundCssClass();
            if (!string.IsNullOrWhiteSpace(bgCss))
            {
                result.Add(bgCss);
            }

            if (_striped)
            {
                result.Add("progress-bar-striped");
            }

            if (_animated)
            {
                result.Add("progress-bar-animated");
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
            return new ProgressBarComposer()
                .SetVariant(_variant)
                .SetStriped(_striped)
                .SetAnimated(_animated);
        }

        #endregion

        #endregion
    }
}