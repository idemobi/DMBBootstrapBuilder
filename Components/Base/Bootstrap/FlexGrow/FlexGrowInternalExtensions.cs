#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring flex grow internal in BootstrapBuilder components.
    /// </summary>
    public static class FlexGrowInternalExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets css for BootstrapBuilder rendering or composition.
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