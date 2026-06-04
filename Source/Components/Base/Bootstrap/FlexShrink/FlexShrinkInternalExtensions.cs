#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring flex shrink internal in BootstrapBuilder components.
    /// </summary>
    public static class FlexShrinkInternalExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets css for BootstrapBuilder rendering or composition.
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