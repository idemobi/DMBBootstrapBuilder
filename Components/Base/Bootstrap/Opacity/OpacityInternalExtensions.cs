#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring opacity internal in BootstrapBuilder components.
    /// </summary>
    public static class OpacityInternalExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="opacity">The opacity value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this Opacity opacity)
        {
            return opacity switch
            {
                Opacity.Normal => string.Empty,
                Opacity.O0 => "opacity-0",
                Opacity.O25 => "opacity-25",
                Opacity.O50 => "opacity-50",
                Opacity.O75 => "opacity-75",
                Opacity.O100 => "opacity-100",
                _ => string.Empty
            };
        }

        /// <summary>
        ///     Gets value for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="opacity">The opacity value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetValue(this Opacity opacity)
        {
            return opacity switch
            {
                Opacity.Normal => string.Empty,
                Opacity.O0 => "0",
                Opacity.O25 => "0.25",
                Opacity.O50 => "0.50",
                Opacity.O75 => "0.75",
                Opacity.O100 => "1",
                _ => string.Empty
            };
        }

        #endregion
    }
}