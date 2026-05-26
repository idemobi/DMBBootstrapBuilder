#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj Image_HtmlHelper.cs create at 2026/04/08 15:04:23
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder image html helper component or support type.
    /// </summary>
    public static class Image_HtmlHelper
    {
        #region Static methods

        /// <summary>
        /// Executes the BootstrapBuilder image render operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="src">The src value.</param>
        /// <returns>The configured <see cref="ImageRenderBuilder"/> value or BootstrapBuilder result.</returns>
        [Documented]
        public static ImageRenderBuilder ImageRender(this IHtmlHelper html, [PathReference] string src)
        {
            if (html == null)
            {
                throw new ArgumentNullException(nameof(html));
            }

            return new ImageRenderBuilder(html.ViewContext.Writer, html, src);
        }

        #endregion
    }
}