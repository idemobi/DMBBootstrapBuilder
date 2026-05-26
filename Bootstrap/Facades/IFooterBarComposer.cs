#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj IFooterBarComposer.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Defines the contract for composing footer bar composer content in BootstrapBuilder pages.
    /// </summary>
    public interface IFooterBarComposer
    {
        #region Instance methods

        /// <summary>
        /// Gets footer bar for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="FooterBarBuilder"/> value or BootstrapBuilder result.</returns>
        public FooterBarBuilder GetFooterBar(TextWriter writer, IHtmlHelper html);

        #endregion
    }
}