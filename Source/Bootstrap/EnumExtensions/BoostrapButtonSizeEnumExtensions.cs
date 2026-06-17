#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring boostrap button size enum in BootstrapBuilder components.
    /// </summary>
    public static class BoostrapButtonSizeEnumExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets btn size css for BootstrapBuilder rendering or composition.
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