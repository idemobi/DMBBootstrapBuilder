#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj Html_FooterBar_Extensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring html footer bar in BootstrapBuilder components.
    /// </summary>
    public static class Html_FooterBar_Extensions
    {
        #region Static methods

        /// <summary>
        /// Executes the BootstrapBuilder footer bar builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="FooterBarBuilder"/> value or BootstrapBuilder result.</returns>
        public static FooterBarBuilder FooterBarBuilder(this IHtmlHelper html)
        {
            if (html == null)
            {
                throw new ArgumentNullException(nameof(html));
            }

            return new FooterBarBuilder(html.ViewContext.Writer, html);
        }

        #endregion
    }
}