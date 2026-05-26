#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj NavbarDividerComponent.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using System.Net;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder navbar divider component component or support type.
    /// </summary>
    public sealed class NavbarDividerComponent : NavbarComponentBase
    {
        #region Instance fields and properties

        /// <summary>
        /// Gets or sets the margin value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public Old_Gap Margin { get; set; } = Old_Gap.Gap2;

        #endregion

        #region Instance methods

        /// <summary>
        /// Renders value for the BootstrapBuilder output.
        /// </summary>
        /// <param name="htmlHelper">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The rendered HTML content for the BootstrapBuilder component.</returns>
        public override IHtmlContent Render(IHtmlHelper htmlHelper)
        {
            string css = BuildCommonCss(
                "vr",
                Margin.GetGapCss());

            return new HtmlString($"""
                                   <div class="{WebUtility.HtmlEncode(css)}"></div>
                                   """);
        }

        /// <summary>
        /// Configures margin on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="oldGap">The old gap value.</param>
        /// <returns>The configured <see cref="NavbarDividerComponent"/> value or BootstrapBuilder result.</returns>
        public NavbarDividerComponent WithMargin(Old_Gap oldGap)
        {
            Margin = oldGap;
            return this;
        }

        #endregion
    }
}