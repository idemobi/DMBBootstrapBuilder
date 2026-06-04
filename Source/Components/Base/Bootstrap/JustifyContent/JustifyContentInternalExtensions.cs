#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring justify content internal in BootstrapBuilder components.
    /// </summary>
    public static class JustifyContentInternalExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets new css for BootstrapBuilder rendering or composition.
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