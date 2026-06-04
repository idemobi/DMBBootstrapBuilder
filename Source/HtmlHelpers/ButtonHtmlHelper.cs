#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the BootstrapBuilder button html helper component or support type.
    /// </summary>
    public static class ButtonHtmlHelper
    {
        #region Static methods

        /// <summary>
        ///     Executes the BootstrapBuilder button operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="action">The action value.</param>
        /// <returns>The configured <see cref="ButtonRender" /> value or BootstrapBuilder result.</returns>
        public static ButtonRender Button(this IHtmlHelper html, IActionItem action)
        {
            return new ButtonRender(html.ViewContext.Writer, html, action);
        }

        #endregion
    }
}