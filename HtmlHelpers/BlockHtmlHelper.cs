#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj BlockHtmlHelper.cs create at 2026/04/08 09:04:40
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder block html helper component or support type.
    /// </summary>
    public static class BlockHtmlHelper
    {
        #region Static methods

        /// <summary>
        /// Executes the BootstrapBuilder block builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="BlockBuilder"/> value or BootstrapBuilder result.</returns>
        public static BlockBuilder BlockBuilder(this IHtmlHelper html)
        {
            return new BlockBuilder(html.ViewContext.Writer, html);
        }

        #endregion
    }
}