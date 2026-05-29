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
    ///     Represents the BootstrapBuilder bootstrap style helper component or support type.
    /// </summary>
    public static class BootstrapStyleHelper
    {
        #region Static methods

        /// <summary>
        ///     Gets btn variant css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="style">The style value.</param>
        /// <param name="outline">The outline value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetBtnVariantCss(this VariantStyle style, bool outline = false)
        {
            string value = style.GetOldVariantCss();
            return outline ? $"btn-outline-{value}" : $"btn-{value}";
        }

        /// <summary>
        ///     Gets gap css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="oldGap">The old gap value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetGapCss(this Old_Gap oldGap)
        {
            return oldGap switch
            {
                Old_Gap.Gap0 => "gap-0",
                Old_Gap.Gap1 => "gap-1",
                Old_Gap.Gap2 => "gap-2",
                Old_Gap.Gap3 => "gap-3",
                Old_Gap.Gap4 => "gap-4",
                Old_Gap.Gap5 => "gap-5",
                _ => string.Empty
            };
        }

        /// <summary>
        ///     Gets justify css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="justify">The justify value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetJustifyCss(this JustifyContent justify)
        {
            return justify switch
            {
                JustifyContent.Start => "justify-content-start",
                JustifyContent.Center => "justify-content-center",
                JustifyContent.End => "justify-content-end",
                JustifyContent.Between => "justify-content-between",
                JustifyContent.Around => "justify-content-around",
                JustifyContent.Evenly => "justify-content-evenly",
                _ => string.Empty
            };
        }

        /// <summary>
        ///     Gets old variant css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="style">The style value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetOldVariantCss(this VariantStyle style)
        {
            return style switch
            {
                VariantStyle.Primary => "primary",
                VariantStyle.Secondary => "secondary",
                VariantStyle.Success => "success",
                VariantStyle.Warning => "warning",
                VariantStyle.Danger => "danger",
                VariantStyle.Info => "info",
                VariantStyle.Light => "light",
                VariantStyle.Dark => "dark",
                _ => ""
            };
        }

        /// <summary>
        ///     Gets switch style css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="style">The style value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetSwitchStyleCss(VariantStyle style)
        {
            return style switch
            {
                VariantStyle.Primary => "dmb-switch-primary",
                VariantStyle.Secondary => "dmb-switch-secondary",
                VariantStyle.Success => "dmb-switch-success",
                VariantStyle.Warning => "dmb-switch-warning",
                VariantStyle.Danger => "dmb-switch-danger",
                VariantStyle.Info => "dmb-switch-info",
                VariantStyle.Light => "dmb-switch-light",
                VariantStyle.Dark => "dmb-switch-dark",
                _ => "dmb-switch-primary"
            };
        }

        #endregion
    }
}