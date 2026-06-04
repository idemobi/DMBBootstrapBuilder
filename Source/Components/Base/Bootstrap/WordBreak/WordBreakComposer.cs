#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Collections.Generic;
using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Composes Bootstrap CSS classes or page chrome for word break.
    /// </summary>
    public sealed class WordBreakComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private WordBreak _wordBreak = WordBreak.None;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="wordBreak">The word break value.</param>
        /// <returns>The configured <see cref="WordBreakComposer" /> value or BootstrapBuilder result.</returns>
        public WordBreakComposer Set(WordBreak wordBreak)
        {
            _wordBreak = wordBreak;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        ///     Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            string css = _wordBreak.GetCss();

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
            var clone = new WordBreakComposer();
            clone.Set(_wordBreak);
            return clone;
        }

        #endregion

        #endregion
    }
}