#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ModalBuilderExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring modal builder in BootstrapBuilder components.
    /// </summary>
    public static class ModalBuilderExtensions
    {
        #region Static methods

        /// <summary>
        /// Executes the BootstrapBuilder modal builder operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="ModalBuilder"/> value or BootstrapBuilder result.</returns>
        public static ModalBuilder ModalBuilder(this IHtmlHelper html)
        {
            return new ModalBuilder(html.ViewContext.Writer, html);
        }

        #endregion
    }
}