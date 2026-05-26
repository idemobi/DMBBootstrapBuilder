#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ResponsiveBreakpointExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring responsive breakpoint in BootstrapBuilder components.
    /// </summary>
    public static class ResponsiveBreakpointExtensions
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
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
        /// Gets prefix css for BootstrapBuilder rendering or composition.
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