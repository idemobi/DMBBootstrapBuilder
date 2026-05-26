#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj AlignSelfInternalExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring align self internal in BootstrapBuilder components.
    /// </summary>
    public static class AlignSelfInternalExtensions
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="alignSelf">The align self value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this AlignSelf alignSelf)
        {
            return alignSelf switch
            {
                AlignSelf.Auto => "auto",
                AlignSelf.Start => "start",
                AlignSelf.End => "end",
                AlignSelf.Center => "center",
                AlignSelf.Baseline => "baseline",
                AlignSelf.Stretch => "stretch",
                _ => "auto"
            };
        }

        #endregion
    }
}