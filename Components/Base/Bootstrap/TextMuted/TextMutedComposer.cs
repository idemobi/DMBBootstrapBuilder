#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj TextMutedComposer.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Composes Bootstrap CSS classes or page chrome for text muted.
    /// </summary>
    public sealed class TextMutedComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private TextMuted _textMuted = TextMuted.None;

        #endregion

        #region Instance methods

        /// <summary>
        /// Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="textMuted">The text muted value.</param>
        /// <returns>The configured <see cref="TextMutedComposer"/> value or BootstrapBuilder result.</returns>
        public TextMutedComposer Set(TextMuted textMuted)
        {
            _textMuted = textMuted;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        /// Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            string css = _textMuted.GetCss();

            if (string.IsNullOrWhiteSpace(css))
            {
                return Array.Empty<string>();
            }

            return new[] { css };
        }

        /// <summary>
        /// Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IIsCssClassComposer"/> value or BootstrapBuilder result.</returns>
        public IIsCssClassComposer Clone()
        {
            var clone = new TextMutedComposer();
            clone.Set(_textMuted);
            return clone;
        }

        #endregion

        #endregion
    }
}