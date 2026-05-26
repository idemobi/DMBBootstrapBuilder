#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj FlexShrinkInternalExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring flex shrink internal in BootstrapBuilder components.
    /// </summary>
    public static class FlexShrinkInternalExtensions
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this FlexShrink value)
        {
            return value switch
            {
                FlexShrink.None => string.Empty,
                FlexShrink.Shrink => "flex-shrink-1",
                FlexShrink.NoShrink => "flex-shrink-0",
                _ => string.Empty
            };
        }

        #endregion
    }
}