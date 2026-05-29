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
    ///     Represents the BootstrapBuilder flex block html helper component or support type.
    /// </summary>
    public static class FlexBlockHtmlHelper
    {
        #region Static methods

        /// <summary>
        ///     Executes the BootstrapBuilder flex block builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="FlexBlockBuilder" /> value or BootstrapBuilder result.</returns>
        public static FlexBlockBuilder FlexBlockBuilder(this IHtmlHelper html)
        {
            return new FlexBlockBuilder(html.ViewContext.Writer, html);
        }

        #endregion
    }
}