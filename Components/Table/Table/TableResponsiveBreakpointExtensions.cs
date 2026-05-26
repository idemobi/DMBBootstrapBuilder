#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj TableResponsiveBreakpointExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring table responsive breakpoint in BootstrapBuilder components.
    /// </summary>
    public static class TableResponsiveBreakpointExtensions
    {
        #region Static methods

        /// <summary>
        /// Gets css class for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCssClass(this TableResponsiveBreakpoint breakpoint)
        {
            return breakpoint switch
            {
                TableResponsiveBreakpoint.None => string.Empty,
                TableResponsiveBreakpoint.Always => "table-responsive",
                TableResponsiveBreakpoint.Sm => "table-responsive-sm",
                TableResponsiveBreakpoint.Md => "table-responsive-md",
                TableResponsiveBreakpoint.Lg => "table-responsive-lg",
                TableResponsiveBreakpoint.Xl => "table-responsive-xl",
                TableResponsiveBreakpoint.Xxl => "table-responsive-xxl",
                _ => string.Empty
            };
        }

        #endregion
    }
}