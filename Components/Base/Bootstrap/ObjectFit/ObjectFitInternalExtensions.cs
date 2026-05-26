#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ObjectFitInternalExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring object fit internal in BootstrapBuilder components.
    /// </summary>
    public static class ObjectFitInternalExtensions
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="objectFit">The object fit value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this ObjectFit objectFit)
        {
            return objectFit switch
            {
                ObjectFit.Normal => string.Empty,
                ObjectFit.Contain => "contain",
                ObjectFit.Cover => "cover",
                ObjectFit.Fill => "fill",
                ObjectFit.Scale => "scale",
                ObjectFit.None => "none",
                _ => string.Empty
            };
        }

        #endregion
    }
}