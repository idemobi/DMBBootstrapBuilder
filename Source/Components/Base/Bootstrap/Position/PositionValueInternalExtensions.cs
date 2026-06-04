#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring position value internal in BootstrapBuilder components.
    /// </summary>
    public static class PositionValueInternalExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this PositionValue value)
        {
            return value switch
            {
                PositionValue.None => string.Empty,
                PositionValue.Zero => "0",
                PositionValue.Fifty => "50",
                PositionValue.Hundred => "100",
                _ => string.Empty
            };
        }

        #endregion
    }
}