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
    ///     Composes Bootstrap CSS classes or page chrome for font size.
    /// </summary>
    public sealed class FontSizeComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private FontSize _fontSize = FontSize.Normal;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="fontSize">The font size value.</param>
        /// <returns>The configured <see cref="FontSizeComposer" /> value or BootstrapBuilder result.</returns>
        public FontSizeComposer Set(FontSize fontSize)
        {
            _fontSize = fontSize;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        ///     Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            string css = _fontSize.GetCss();

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
            var clone = new FontSizeComposer();
            clone.Set(_fontSize);
            return clone;
        }

        #endregion

        #endregion
    }
}