#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Composes Bootstrap CSS classes or page chrome for vertical align.
    /// </summary>
    public sealed class VerticalAlignComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private VerticalAlign _verticalAlign = VerticalAlign.Baseline;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="verticalAlign">The vertical align value.</param>
        /// <returns>The configured <see cref="VerticalAlignComposer" /> value or BootstrapBuilder result.</returns>
        public VerticalAlignComposer Set(VerticalAlign verticalAlign)
        {
            _verticalAlign = verticalAlign;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        ///     Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            string css = _verticalAlign.GetCss();

            if (string.IsNullOrWhiteSpace(css))
            {
                return Array.Empty<string>();
            }

            return new[] { css };
        }

        /// <summary>
        ///     Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IIsCssClassComposer" /> value or BootstrapBuilder result.</returns>
        public IIsCssClassComposer Clone()
        {
            var clone = new VerticalAlignComposer();
            clone.Set(_verticalAlign);
            return clone;
        }

        #endregion

        #endregion
    }
}