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
    ///     Defines the contract for composing breadcrumb composer content in BootstrapBuilder pages.
    /// </summary>
    public interface IBreadcrumbComposer
    {
        #region Instance methods

        /// <summary>
        ///     Gets breadcrumb for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="actionItems">The action items value.</param>
        /// <returns>The configured <see cref="BreadcrumbBuilder" /> value or BootstrapBuilder result.</returns>
        public BreadcrumbBuilder? GetBreadcrumb(TextWriter writer, IHtmlHelper html, List<IActionItem> actionItems);

        #endregion
    }
}