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
    ///     Composes Bootstrap CSS classes or page chrome for reset text color.
    /// </summary>
    public sealed class ResetTextColorComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private ResetTextColor _resetTextColor = ResetTextColor.Normal;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="resetTextColor">The reset text color value.</param>
        /// <returns>The configured <see cref="ResetTextColorComposer" /> value or BootstrapBuilder result.</returns>
        public ResetTextColorComposer Set(ResetTextColor resetTextColor)
        {
            _resetTextColor = resetTextColor;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        ///     Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            string css = _resetTextColor.GetCss();

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
            var clone = new ResetTextColorComposer();
            clone.Set(_resetTextColor);
            return clone;
        }

        #endregion

        #endregion
    }
}