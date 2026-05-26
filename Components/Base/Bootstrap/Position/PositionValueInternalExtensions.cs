#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj PositionValueInternalExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring position value internal in BootstrapBuilder components.
    /// </summary>
    public static class PositionValueInternalExtensions
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this PositionValue value)
        {
            return value switch
            {
                PositionValue.None => string.Empty,
                PositionValue.Zero => "0",
                PositionValue.Fifty => "50",
                PositionValue.Hundred => "100",
                _ => string.Empty
            };
        }

        #endregion
    }
}