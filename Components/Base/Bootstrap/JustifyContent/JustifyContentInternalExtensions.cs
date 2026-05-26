#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj JustifyContentInternalExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring justify content internal in BootstrapBuilder components.
    /// </summary>
    public static class JustifyContentInternalExtensions
    {
        #region Static methods

        /// <summary>
        /// Gets new css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="justifyContent">The justify content value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetNewCss(this JustifyContent justifyContent)
        {
            return justifyContent switch
            {
                JustifyContent.Start => "start",
                JustifyContent.End => "end",
                JustifyContent.Center => "center",
                JustifyContent.Between => "between",
                JustifyContent.Around => "around",
                JustifyContent.Evenly => "evenly",
                _ => "start"
            };
        }

        #endregion
    }
}