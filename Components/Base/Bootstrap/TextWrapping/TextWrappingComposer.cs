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
    ///     Composes Bootstrap CSS classes or page chrome for text wrapping.
    /// </summary>
    public sealed class TextWrappingComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private TextWrapping _textWrapping = TextWrapping.Normal;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="textWrapping">The text wrapping value.</param>
        /// <returns>The configured <see cref="TextWrappingComposer" /> value or BootstrapBuilder result.</returns>
        public TextWrappingComposer Set(TextWrapping textWrapping)
        {
            _textWrapping = textWrapping;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        ///     Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            string css = _textWrapping.GetCss();

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
            var clone = new TextWrappingComposer();
            clone.Set(_textWrapping);
            return clone;
        }

        #endregion

        #endregion
    }
}