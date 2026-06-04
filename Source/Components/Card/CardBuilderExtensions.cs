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
    ///     Provides extension methods for configuring card builder in BootstrapBuilder components.
    /// </summary>
    public static class CardBuilderExtensions
    {
        #region Static methods

        /// <summary>
        ///     Executes the BootstrapBuilder card builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="CardBuilder" /> value or BootstrapBuilder result.</returns>
        public static CardBuilder CardBuilder(this IHtmlHelper html)
        {
            return new CardBuilder(html.ViewContext.Writer, html);
        }

        #endregion
    }
}