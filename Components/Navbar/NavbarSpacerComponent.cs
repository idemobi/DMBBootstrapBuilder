#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj NavbarSpacerComponent.cs create at 2026/04/07 21:04:27
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
    /// Represents the BootstrapBuilder navbar spacer component component or support type.
    /// </summary>
    public sealed class NavbarSpacerComponent : NavbarComponentBase
    {
        #region Instance fields and properties

        /// <summary>
        /// Gets or sets the grow value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool Grow { get; set; } = true;
        /// <summary>
        /// Gets or sets the shrink value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool Shrink { get; set; } = false;

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
                Grow ? "flex-grow-1" : string.Empty,
                Shrink ? "flex-shrink-1" : "flex-shrink-0");

            return new HtmlString($"""
                                   <div class="{WebUtility.HtmlEncode(css)}"></div>
                                   """);
        }

        /// <summary>
        /// Configures grow on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="NavbarSpacerComponent"/> value or BootstrapBuilder result.</returns>
        public NavbarSpacerComponent WithGrow(bool value = true)
        {
            Grow = value;
            return this;
        }

        /// <summary>
        /// Configures shrink on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="NavbarSpacerComponent"/> value or BootstrapBuilder result.</returns>
        public NavbarSpacerComponent WithShrink(bool value = true)
        {
            Shrink = value;
            return this;
        }

        #endregion
    }
}