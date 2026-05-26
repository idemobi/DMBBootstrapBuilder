#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ContainerStyleExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring container style in BootstrapBuilder components.
    /// </summary>
    public static class ContainerStyleExtensions
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="style">The style value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this ContainerStyle style)
        {
            return style switch
            {
                ContainerStyle.None => string.Empty,
                ContainerStyle.Default => "container",
                ContainerStyle.Fluid => "container-fluid",
                ContainerStyle.Sm => "container-sm",
                ContainerStyle.Md => "container-md",
                ContainerStyle.Lg => "container-lg",
                ContainerStyle.Xl => "container-xl",
                ContainerStyle.Xxl => "container-xxl",
                ContainerStyle.LandingPage => "landing-page",
                _ => "container"
            };
        }

        #endregion
    }
}