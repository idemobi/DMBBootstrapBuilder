#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj VariantStyleExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring variant style in BootstrapBuilder components.
    /// </summary>
    public static class VariantStyleExtensions
    {
        #region Static methods

        /// <summary>
        /// Gets old background css class for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="variant">The variant value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetOldBackgroundCssClass(this VariantStyle variant)
        {
            return variant switch
            {
                VariantStyle.Primary => "bg-primary",
                VariantStyle.Secondary => "bg-secondary",
                // VariantStyle.Tertiary => "bg-tertiary",
                VariantStyle.Success => "bg-success",
                VariantStyle.Warning => "bg-warning",
                VariantStyle.Danger => "bg-danger",
                VariantStyle.Info => "bg-info",
                // VariantStyle.Light => "bg-light text-dark",
                // VariantStyle.Dark => "bg-dark text-light",
                _ => "bg-primary"
            };
        }

        /// <summary>
        /// Gets old suffix css class for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="variant">The variant value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetOldSuffixCssClass(this VariantStyle variant)
        {
            return variant switch
            {
                VariantStyle.Primary => "-primary",
                VariantStyle.Secondary => "-secondary",
                // VariantStyle.Tertiary => "-tertiary",
                VariantStyle.Success => "-success",
                VariantStyle.Warning => "-warning",
                VariantStyle.Danger => "-danger",
                VariantStyle.Info => "-info",
                VariantStyle.Light => "-light",
                VariantStyle.Dark => "-dark",
                _ => string.Empty
            };
        }

        /// <summary>
        /// Gets old text css class for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="variant">The variant value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetOldTextCssClass(this VariantStyle variant)
        {
            return variant switch
            {
                VariantStyle.Primary => "text-primary",
                VariantStyle.Secondary => "text-secondary",
                // VariantStyle.Tertiary => "text-tertiary",
                VariantStyle.Success => "text-success",
                VariantStyle.Warning => "text-warning",
                VariantStyle.Danger => "text-danger",
                VariantStyle.Info => "text-info",
                VariantStyle.Light => "text-light",
                VariantStyle.Dark => "text-dark",
                _ => string.Empty
            };
        }

        #endregion
    }
}