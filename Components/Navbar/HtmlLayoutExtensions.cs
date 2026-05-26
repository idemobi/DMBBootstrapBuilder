#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj HtmlLayoutExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring html layout in BootstrapBuilder components.
    /// </summary>
    public static partial class HtmlLayoutExtensions
    {
        #region Static methods

        /// <summary>
        /// Executes the BootstrapBuilder navbar builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="NavbarBuilder"/> value or BootstrapBuilder result.</returns>
        public static NavbarBuilder NavbarBuilder(this IHtmlHelper html)
        {
            return new NavbarBuilder(html.ViewContext.Writer, html);
        }

        #endregion
    }
}