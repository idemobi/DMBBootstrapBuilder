#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj Title_HtmlHelpers.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder title html helpers component or support type.
    /// </summary>
    public static class Title_HtmlHelpers
    {
        #region Static methods

        /// <summary>
        /// Executes the BootstrapBuilder title builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="TitleBuilder"/> value or BootstrapBuilder result.</returns>
        [Documented]
        public static TitleBuilder TitleBuilder(this IHtmlHelper html)
        {
            return new TitleBuilder(html.ViewContext.Writer, html);
        }

        #endregion
    }
}