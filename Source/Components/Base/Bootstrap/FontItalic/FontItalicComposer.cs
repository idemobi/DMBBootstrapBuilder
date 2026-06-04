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
    ///     Composes Bootstrap CSS classes or page chrome for font italic.
    /// </summary>
    public sealed class FontItalicComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private FontItalic _fontItalic = FontItalic.Normal;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="fontItalic">The font italic value.</param>
        /// <returns>The configured <see cref="FontItalicComposer" /> value or BootstrapBuilder result.</returns>
        public FontItalicComposer Set(FontItalic fontItalic)
        {
            _fontItalic = fontItalic;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        ///     Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            string css = _fontItalic.GetCss();

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
            var clone = new FontItalicComposer();
            clone.Set(_fontItalic);
            return clone;
        }

        #endregion

        #endregion
    }
}