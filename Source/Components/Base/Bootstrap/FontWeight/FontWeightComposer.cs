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
    ///     Composes Bootstrap CSS classes or page chrome for font weight.
    /// </summary>
    public sealed class FontWeightComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private FontWeight _fontWeight = FontWeight.Normal;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="fontWeight">The font weight value.</param>
        /// <returns>The configured <see cref="FontWeightComposer" /> value or BootstrapBuilder result.</returns>
        public FontWeightComposer Set(FontWeight fontWeight)
        {
            _fontWeight = fontWeight;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        ///     Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            string css = _fontWeight.GetCss();

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
            var clone = new FontWeightComposer();
            clone.Set(_fontWeight);
            return clone;
        }

        #endregion

        #endregion
    }
}