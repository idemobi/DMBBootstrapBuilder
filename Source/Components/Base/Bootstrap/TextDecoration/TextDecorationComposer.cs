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
    ///     Composes Bootstrap CSS classes or page chrome for text decoration.
    /// </summary>
    public sealed class TextDecorationComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private TextDecoration _textDecoration = TextDecoration.None;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="textDecoration">The text decoration value.</param>
        /// <returns>The configured <see cref="TextDecorationComposer" /> value or BootstrapBuilder result.</returns>
        public TextDecorationComposer Set(TextDecoration textDecoration)
        {
            _textDecoration = textDecoration;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        ///     Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            string css = _textDecoration.GetCss();

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
            var clone = new TextDecorationComposer();
            clone.Set(_textDecoration);
            return clone;
        }

        #endregion

        #endregion
    }
}