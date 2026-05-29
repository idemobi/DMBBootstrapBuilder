#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring responsive breakpoint in BootstrapBuilder components.
    /// </summary>
    public static class ResponsiveBreakpointExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this ResponsiveBreakpoint breakpoint)
        {
            return breakpoint switch
            {
                ResponsiveBreakpoint.Xs => string.Empty,
                ResponsiveBreakpoint.Sm => "sm",
                ResponsiveBreakpoint.Md => "md",
                ResponsiveBreakpoint.Lg => "lg",
                ResponsiveBreakpoint.Xl => "xl",
                ResponsiveBreakpoint.Xxl => "xxl",
                _ => string.Empty
            };
        }

        /// <summary>
        ///     Gets prefix css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="style">The style value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetPrefixCss(this ResponsiveBreakpoint style)
        {
            return style switch
            {
                ResponsiveBreakpoint.Xs => "",
                ResponsiveBreakpoint.Sm => "-sm",
                ResponsiveBreakpoint.Md => "-md",
                ResponsiveBreakpoint.Lg => "-lg",
                ResponsiveBreakpoint.Xl => "-xl",
                ResponsiveBreakpoint.Xxl => "-xxl",
                _ => string.Empty
            };
        }

        #endregion
    }
}