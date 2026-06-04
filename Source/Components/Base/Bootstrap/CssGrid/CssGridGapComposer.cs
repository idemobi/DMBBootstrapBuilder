#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Collections.Generic;
using System.Globalization;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Composes Bootstrap CSS classes or page chrome for css grid gap.
    /// </summary>
    public sealed class CssGridGapComposer : IIsInlineStyleComposer
    {
        #region Instance fields and properties

        private string? _gap;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures css on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="cssValue">The css value value.</param>
        /// <returns>The configured <see cref="CssGridGapComposer" /> value or BootstrapBuilder result.</returns>
        public CssGridGapComposer SetCss(string cssValue)
        {
            _gap = cssValue;
            return this;
        }

        /// <summary>
        ///     Configures rem on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="rem">The rem value.</param>
        /// <returns>The configured <see cref="CssGridGapComposer" /> value or BootstrapBuilder result.</returns>
        public CssGridGapComposer SetRem(double rem)
        {
            _gap = $"{rem.ToString(CultureInfo.InvariantCulture)}rem";
            return this;
        }

        #region From interface IIsInlineStyleComposer

        /// <summary>
        ///     Builds styles for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildStyles()
        {
            if (string.IsNullOrWhiteSpace(_gap))
            {
                return System.Array.Empty<string>();
            }

            return new[] { $"--bs-gap:{_gap};" };
        }

        #endregion

        #endregion
    }
}