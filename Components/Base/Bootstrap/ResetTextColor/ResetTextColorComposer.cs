#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ResetTextColorComposer.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Composes Bootstrap CSS classes or page chrome for reset text color.
    /// </summary>
    public sealed class ResetTextColorComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private ResetTextColor _resetTextColor = ResetTextColor.Normal;

        #endregion

        #region Instance methods

        /// <summary>
        /// Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="resetTextColor">The reset text color value.</param>
        /// <returns>The configured <see cref="ResetTextColorComposer"/> value or BootstrapBuilder result.</returns>
        public ResetTextColorComposer Set(ResetTextColor resetTextColor)
        {
            _resetTextColor = resetTextColor;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        /// Builds classes for BootstrapBuilder rendering.
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
        /// Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IIsCssClassComposer"/> value or BootstrapBuilder result.</returns>
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