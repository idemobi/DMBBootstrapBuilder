#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj UnitSizeExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring unit size in BootstrapBuilder components.
    /// </summary>
    public static class UnitSizeExtensions
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this UnitSize size)
        {
            return size switch
            {
                UnitSize.auto => "auto",
                UnitSize.px => "px",
                UnitSize.percent => "%",
                UnitSize.em => "em",
                UnitSize.ex => "ex",
                UnitSize.rem => "rem",
                UnitSize.vh => "vh",
                UnitSize.vw => "vw",
                UnitSize.vmin => "vmin",
                UnitSize.vmax => "vmax",
                UnitSize.point => "pt",
                UnitSize.pica => "pc",
                UnitSize.millimeter => "mm",
                UnitSize.centimeter => "cm",
                UnitSize.inch => "in",
                _ => string.Empty
            };
        }

        #endregion
    }
}