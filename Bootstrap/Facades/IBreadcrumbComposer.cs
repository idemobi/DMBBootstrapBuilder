#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj IBreadcrumbComposer.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Defines the contract for composing breadcrumb composer content in BootstrapBuilder pages.
    /// </summary>
    public interface IBreadcrumbComposer
    {
        #region Instance methods

        /// <summary>
        /// Gets breadcrumb for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="actionItems">The action items value.</param>
        /// <returns>The configured <see cref="BreadcrumbBuilder"/> value or BootstrapBuilder result.</returns>
        public BreadcrumbBuilder? GetBreadcrumb(TextWriter writer, IHtmlHelper html, List<IActionItem> actionItems);

        #endregion
    }
}