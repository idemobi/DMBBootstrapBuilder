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
    ///     Composes Bootstrap CSS classes or page chrome for text shadow.
    /// </summary>
    public sealed class TextShadowComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private Shadow _shadow = Shadow.Normal;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="shadow">The shadow value.</param>
        /// <returns>The configured <see cref="TextShadowComposer" /> value or BootstrapBuilder result.</returns>
        public TextShadowComposer Set(Shadow shadow)
        {
            _shadow = shadow;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        ///     Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            string css = _shadow.GetTextCss();

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
            var clone = new TextShadowComposer();
            clone.Set(_shadow);
            return clone;
        }

        #endregion

        #endregion
    }
}