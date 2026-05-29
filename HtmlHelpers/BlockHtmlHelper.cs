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
    ///     Represents the BootstrapBuilder block html helper component or support type.
    /// </summary>
    public static class BlockHtmlHelper
    {
        #region Static methods

        /// <summary>
        ///     Executes the BootstrapBuilder block builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="BlockBuilder" /> value or BootstrapBuilder result.</returns>
        public static BlockBuilder BlockBuilder(this IHtmlHelper html)
        {
            return new BlockBuilder(html.ViewContext.Writer, html);
        }

        #endregion
    }
}