#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj OpacityInternalExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring opacity internal in BootstrapBuilder components.
    /// </summary>
    public static class OpacityInternalExtensions
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="opacity">The opacity value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this Opacity opacity)
        {
            return opacity switch
            {
                Opacity.Normal => string.Empty,
                Opacity.O0 => "opacity-0",
                Opacity.O25 => "opacity-25",
                Opacity.O50 => "opacity-50",
                Opacity.O75 => "opacity-75",
                Opacity.O100 => "opacity-100",
                _ => string.Empty
            };
        }

        /// <summary>
        /// Gets value for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="opacity">The opacity value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetValue(this Opacity opacity)
        {
            return opacity switch
            {
                Opacity.Normal => string.Empty,
                Opacity.O0 => "0",
                Opacity.O25 => "0.25",
                Opacity.O50 => "0.50",
                Opacity.O75 => "0.75",
                Opacity.O100 => "1",
                _ => string.Empty
            };
        }

        #endregion
    }
}