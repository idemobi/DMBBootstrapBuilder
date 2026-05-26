#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj BoostrapButtonSize_EnumExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring boostrap button size enum in BootstrapBuilder components.
    /// </summary>
    public static class BoostrapButtonSize_EnumExtensions
    {
        #region Static methods

        /// <summary>
        /// Gets btn size css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetBtnSizeCss(this BoostrapButtonSize size)
        {
            return size switch
            {
                BoostrapButtonSize.Small => "btn-sm",
                BoostrapButtonSize.Large => "btn-lg",
                _ => string.Empty
            };
        }

        #endregion
    }
}