#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring clearfix internal in BootstrapBuilder components.
    /// </summary>
    public static class ClearfixInternalExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="clearfix">The clearfix value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this Clearfix clearfix)
        {
            return clearfix switch
            {
                Clearfix.Normal => string.Empty,
                Clearfix.Clearfix => "clearfix",
                _ => string.Empty
            };
        }

        #endregion
    }
}