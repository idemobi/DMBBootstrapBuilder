#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring float internal in BootstrapBuilder components.
    /// </summary>
    public static class FloatInternalExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this Float value)
        {
            return value switch
            {
                Float.Normal => string.Empty,
                Float.Start => "start",
                Float.End => "end",
                Float.None => "none",
                _ => string.Empty
            };
        }

        #endregion
    }
}