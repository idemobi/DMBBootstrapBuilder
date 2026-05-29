#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring container builder in BootstrapBuilder components.
    /// </summary>
    public static class ContainerBuilderExtensions
    {
        #region Static methods

        /// <summary>
        ///     Executes the BootstrapBuilder container builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="ContainerBuilder" /> value or BootstrapBuilder result.</returns>
        public static ContainerBuilder ContainerBuilder(this IHtmlHelper html)
        {
            return new ContainerBuilder(html.ViewContext.Writer, html);
        }

        #endregion
    }
}