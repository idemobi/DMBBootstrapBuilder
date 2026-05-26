#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ButtonHtmlHelper.cs create at 2026/04/08 09:04:40
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder button html helper component or support type.
    /// </summary>
    public static class ButtonHtmlHelper
    {
        #region Static methods

        /// <summary>
        /// Executes the BootstrapBuilder button operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="action">The action value.</param>
        /// <returns>The configured <see cref="ButtonRender"/> value or BootstrapBuilder result.</returns>
        public static ButtonRender Button(this IHtmlHelper html, IActionItem action)
        {
            return new ButtonRender(html.ViewContext.Writer, html, action);
        }

        #endregion
    }
}