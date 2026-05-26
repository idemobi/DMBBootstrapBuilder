#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj FlexDirectionInternalExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring flex direction internal in BootstrapBuilder components.
    /// </summary>
    public static class FlexDirectionInternalExtensions
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="flexDirection">The flex direction value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this FlexDirection flexDirection)
        {
            return flexDirection switch
            {
                FlexDirection.Row => "row",
                FlexDirection.RowReverse => "row-reverse",
                FlexDirection.Column => "column",
                FlexDirection.ColumnReverse => "column-reverse",
                _ => "row"
            };
        }

        #endregion
    }
}