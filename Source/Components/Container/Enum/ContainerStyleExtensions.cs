#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring container style in BootstrapBuilder components.
    /// </summary>
    public static class ContainerStyleExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets css for BootstrapBuilder rendering or composition.
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
                //ContainerStyle.LandingPage => "landing-page",
                _ => "container"
            };
        }

        #endregion
    }
}