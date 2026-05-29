#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring translate mode internal in BootstrapBuilder components.
    /// </summary>
    public static class TranslateModeInternalExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="mode">The mode value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this TranslateMode mode)
        {
            return mode switch
            {
                TranslateMode.None => string.Empty,
                TranslateMode.Middle => "translate-middle",
                TranslateMode.MiddleX => "translate-middle-x",
                TranslateMode.MiddleY => "translate-middle-y",
                _ => string.Empty
            };
        }

        #endregion
    }
}