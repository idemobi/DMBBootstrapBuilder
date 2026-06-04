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
    ///     Provides extension methods for configuring modal builder in BootstrapBuilder components.
    /// </summary>
    public static class ModalBuilderExtensions
    {
        #region Static methods

        /// <summary>
        ///     Executes the BootstrapBuilder modal builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="ModalBuilder" /> value or BootstrapBuilder result.</returns>
        public static ModalBuilder ModalBuilder(this IHtmlHelper html)
        {
            return new ModalBuilder(html.ViewContext.Writer, html);
        }

        #endregion
    }
}