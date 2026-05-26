#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj VariantStyleInternalExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring variant style internal in BootstrapBuilder components.
    /// </summary>
    public static class VariantStyleInternalExtensions
    {
        #region Static methods

        /// <summary>
        /// Gets background css class for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="variant">The variant value.</param>
        /// <param name="subtle">The subtle value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetBackgroundCssClass(this VariantStyle variant, bool subtle = false)
        {
            string value = variant.GetVariantCss();
            if (subtle)
            {
                return string.IsNullOrWhiteSpace(value) ? string.Empty : $"bg-{value}-subtle";
            }
            else
            {
                return string.IsNullOrWhiteSpace(value) ? string.Empty : $"bg-{value}";
            }
        }

        /// <summary>
        /// Gets button variant css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="style">The style value.</param>
        /// <param name="mode">The mode value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetButtonVariantCss(this VariantStyle style, ButtonVariantMode mode)
        {
            string value = style.GetVariantCss();

            return mode switch
            {
                ButtonVariantMode.Filled => $"btn-{value}",
                ButtonVariantMode.Outline => $"btn-outline-{value}",
                _ => $"btn-{value}"
            };
        }

        /// <summary>
        /// Gets recommended text variant for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="backgroundVariant">The background variant value.</param>
        /// <returns>The configured <see cref="VariantStyle"/> value or BootstrapBuilder result.</returns>
        public static VariantStyle? GetRecommendedTextVariant(this VariantStyle backgroundVariant)
        {
            return backgroundVariant switch
            {
                VariantStyle.Primary => VariantStyle.Light,
                VariantStyle.Secondary => VariantStyle.Light,
                // VariantStyle.Tertiary => VariantStyle.Light,
                VariantStyle.Success => VariantStyle.Light,
                VariantStyle.Warning => VariantStyle.Dark,
                VariantStyle.Danger => VariantStyle.Light,
                VariantStyle.Info => VariantStyle.Dark,
                VariantStyle.Light => VariantStyle.Dark,
                VariantStyle.Dark => VariantStyle.Light,
                _ => null
            };
        }

        /// <summary>
        /// Gets text css class for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="variant">The variant value.</param>
        /// <param name="emphasis">The emphasis value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetTextCssClass(this VariantStyle variant, bool emphasis)
        {
            string value = variant.GetVariantCss();
            if (emphasis)
            {
                return string.IsNullOrWhiteSpace(value) ? string.Empty : $"text-{value}-emphasis";
            }
            else
            {
                return string.IsNullOrWhiteSpace(value) ? string.Empty : $"text-{value}";
            }
        }

        /// <summary>
        /// Gets variant css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="variant">The variant value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetVariantCss(this VariantStyle variant)
        {
            return variant switch
            {
                VariantStyle.Primary => "primary",
                VariantStyle.Secondary => "secondary",
                // VariantStyle.Tertiary => "tertiary",
                VariantStyle.Success => "success",
                VariantStyle.Warning => "warning",
                VariantStyle.Danger => "danger",
                VariantStyle.Info => "info",
                VariantStyle.Light => "light",
                VariantStyle.Dark => "dark",
                _ => string.Empty
            };
        }

        #endregion
    }
}