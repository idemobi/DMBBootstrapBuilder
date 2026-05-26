#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ZIndexInternalExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring z index internal in BootstrapBuilder components.
    /// </summary>
    public static class ZIndexInternalExtensions
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="zIndex">The z index value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this ZIndex zIndex)
        {
            return zIndex switch
            {
                ZIndex.Normal => string.Empty,
                ZIndex.N1 => "z-n1",
                ZIndex.Z0 => "z-0",
                ZIndex.Z1 => "z-1",
                ZIndex.Z2 => "z-2",
                ZIndex.Z3 => "z-3",
                _ => string.Empty
            };
        }

        #endregion
    }
}