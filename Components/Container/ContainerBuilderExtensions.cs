#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ContainerBuilderExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring container builder in BootstrapBuilder components.
    /// </summary>
    public static class ContainerBuilderExtensions
    {
        #region Static methods

        /// <summary>
        /// Executes the BootstrapBuilder container builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="ContainerBuilder"/> value or BootstrapBuilder result.</returns>
        public static ContainerBuilder ContainerBuilder(this IHtmlHelper html)
        {
            return new ContainerBuilder(html.ViewContext.Writer, html);
        }

        #endregion
    }
}