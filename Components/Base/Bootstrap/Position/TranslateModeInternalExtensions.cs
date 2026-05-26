#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj TranslateModeInternalExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring translate mode internal in BootstrapBuilder components.
    /// </summary>
    public static class TranslateModeInternalExtensions
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="mode">The mode value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this TranslateMode mode)
        {
            return mode switch
            {
                TranslateMode.None => string.Empty,
                TranslateMode.Middle => "translate-middle",
                TranslateMode.MiddleX => "translate-middle-x",
                TranslateMode.MiddleY => "translate-middle-y",
                _ => string.Empty
            };
        }

        #endregion
    }
}