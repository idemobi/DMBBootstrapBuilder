#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ResponsiveDisplayHelper.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder responsive display helper component or support type.
    /// </summary>
    public static class ResponsiveDisplayHelper
    {
        #region Static methods

        /// <summary>
        /// Builds responsive css for BootstrapBuilder rendering.
        /// </summary>
        /// <param name="visibleFrom">The visible from value.</param>
        /// <param name="visibleUntil">The visible until value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string BuildResponsiveCss(
            ResponsiveBreakpoint visibleFrom = ResponsiveBreakpoint.Xs,
            ResponsiveBreakpoint visibleUntil = ResponsiveBreakpoint.Xs
        )
        {
            var classes = new List<string>();

            string fromCss = BuildVisibleFromCss(visibleFrom);
            if (!string.IsNullOrWhiteSpace(fromCss))
            {
                classes.Add(fromCss);
            }

            string untilCss = BuildVisibleUntilCss(visibleUntil);
            if (!string.IsNullOrWhiteSpace(untilCss))
            {
                classes.Add(untilCss);
            }

            return string.Join(" ", classes.Where(x => !string.IsNullOrWhiteSpace(x)));
        }

        /// <summary>
        /// Builds visible from css for BootstrapBuilder rendering.
        /// </summary>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string BuildVisibleFromCss(ResponsiveBreakpoint breakpoint)
        {
            return breakpoint switch
            {
                ResponsiveBreakpoint.Sm => "d-none d-sm-block",
                ResponsiveBreakpoint.Md => "d-none d-md-block",
                ResponsiveBreakpoint.Lg => "d-none d-lg-block",
                ResponsiveBreakpoint.Xl => "d-none d-xl-block",
                ResponsiveBreakpoint.Xxl => "d-none d-xxl-block",
                _ => string.Empty
            };
        }

        /// <summary>
        /// Builds visible until css for BootstrapBuilder rendering.
        /// </summary>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string BuildVisibleUntilCss(ResponsiveBreakpoint breakpoint)
        {
            return breakpoint switch
            {
                ResponsiveBreakpoint.Sm => "d-block d-sm-none",
                ResponsiveBreakpoint.Md => "d-block d-md-none",
                ResponsiveBreakpoint.Lg => "d-block d-lg-none",
                ResponsiveBreakpoint.Xl => "d-block d-xl-none",
                ResponsiveBreakpoint.Xxl => "d-block d-xxl-none",
                _ => string.Empty
            };
        }

        #endregion
    }
}