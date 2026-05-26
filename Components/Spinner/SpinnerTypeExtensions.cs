#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj SpinnerTypeExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring spinner type in BootstrapBuilder components.
    /// </summary>
    public static class SpinnerTypeExtensions
    {
        #region Static methods

        /// <summary>
        /// Gets css class for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="style">The style value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCssClass(this SpinnerType style)
        {
            return style switch
            {
                SpinnerType.Grow => "spinner-grow",
                _ => "spinner-border"
            };
        }

        #endregion
    }
}