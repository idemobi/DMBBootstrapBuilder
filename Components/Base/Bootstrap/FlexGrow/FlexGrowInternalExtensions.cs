#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj FlexGrowInternalExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring flex grow internal in BootstrapBuilder components.
    /// </summary>
    public static class FlexGrowInternalExtensions
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="flexGrow">The flex grow value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this FlexGrow flexGrow)
        {
            return flexGrow switch
            {
                FlexGrow.None => string.Empty,
                FlexGrow.Grow => "flex-grow-1",
                FlexGrow.NoGrow => "flex-grow-0",
                _ => string.Empty
            };
        }

        #endregion
    }
}