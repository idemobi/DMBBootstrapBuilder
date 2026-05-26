using DMBPageBuilder;

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Composes Bootstrap CSS classes or page chrome for tab area.
    /// </summary>
    public sealed class TabAreaComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private bool _fill;
        private bool _justified;
        private TabAreaStyle _style = TabAreaStyle.Tabs;

        #endregion

        #region Instance methods

        /// <summary>
        /// Configures fill on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TabAreaComposer"/> value or BootstrapBuilder result.</returns>
        public TabAreaComposer SetFill(bool value = true)
        {
            _fill = value;
            return this;
        }

        /// <summary>
        /// Configures justified on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TabAreaComposer"/> value or BootstrapBuilder result.</returns>
        public TabAreaComposer SetJustified(bool value = true)
        {
            _justified = value;
            return this;
        }

        /// <summary>
        /// Configures style on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="style">The style value.</param>
        /// <returns>The configured <see cref="TabAreaComposer"/> value or BootstrapBuilder result.</returns>
        public TabAreaComposer SetStyle(TabAreaStyle style)
        {
            _style = style;
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
                "nav"
            };

            switch (_style)
            {
                case TabAreaStyle.Tabs:
                    result.Add("nav-tabs");
                break;

                case TabAreaStyle.Pills:
                    result.Add("nav-pills");
                break;

                case TabAreaStyle.Underline:
                    result.Add("nav-underline");
                break;
            }

            if (_fill)
            {
                result.Add("nav-fill");
            }

            if (_justified)
            {
                result.Add("nav-justified");
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
            return new TabAreaComposer()
                .SetStyle(_style)
                .SetFill(_fill)
                .SetJustified(_justified);
        }

        #endregion

        #endregion
    }
}