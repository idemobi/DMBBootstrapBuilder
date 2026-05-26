#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj CssGridGapComposer.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using System.Globalization;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Composes Bootstrap CSS classes or page chrome for css grid gap.
    /// </summary>
    public sealed class CssGridGapComposer : IIsInlineStyleComposer
    {
        #region Instance fields and properties

        private string? _gap;

        #endregion

        #region Instance methods

        /// <summary>
        /// Configures css on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="cssValue">The css value value.</param>
        /// <returns>The configured <see cref="CssGridGapComposer"/> value or BootstrapBuilder result.</returns>
        public CssGridGapComposer SetCss(string cssValue)
        {
            _gap = cssValue;
            return this;
        }

        /// <summary>
        /// Configures rem on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="rem">The rem value.</param>
        /// <returns>The configured <see cref="CssGridGapComposer"/> value or BootstrapBuilder result.</returns>
        public CssGridGapComposer SetRem(double rem)
        {
            _gap = $"{rem.ToString(CultureInfo.InvariantCulture)}rem";
            return this;
        }

        #region From interface IIsInlineStyleComposer

        /// <summary>
        /// Builds styles for BootstrapBuilder rendering.
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