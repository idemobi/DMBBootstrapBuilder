#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Defines the contract for composing footer bar composer content in BootstrapBuilder pages.
    /// </summary>
    public interface IFooterBarComposer
    {
        #region Instance methods

        /// <summary>
        ///     Gets footer bar for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="FooterBarBuilder" /> value or BootstrapBuilder result.</returns>
        public FooterBarBuilder GetFooterBar(TextWriter writer, IHtmlHelper html);

        #endregion
    }
}