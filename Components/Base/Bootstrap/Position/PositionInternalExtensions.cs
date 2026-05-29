#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring position internal in BootstrapBuilder components.
    /// </summary>
    public static class PositionInternalExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="position">The position value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this Position position)
        {
            return position switch
            {
                Position.Normal => string.Empty,
                Position.Static => "position-static",
                Position.Relative => "position-relative",
                Position.Absolute => "position-absolute",
                Position.Fixed => "position-fixed",
                Position.Sticky => "position-sticky",
                _ => string.Empty
            };
        }

        #endregion
    }
}