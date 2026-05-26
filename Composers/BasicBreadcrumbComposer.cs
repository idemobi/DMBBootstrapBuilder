#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj BasicBreadcrumbComposer.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Composes Bootstrap CSS classes or page chrome for basic breadcrumb.
    /// </summary>
    public class BasicBreadcrumbComposer : IBreadcrumbComposer
    {
        #region Instance methods

        #region From interface IBreadcrumbComposer

        /// <summary>
        /// Gets breadcrumb for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="actionItems">The action items value.</param>
        /// <returns>The configured <see cref="BreadcrumbBuilder"/> value or BootstrapBuilder result.</returns>
        public BreadcrumbBuilder? GetBreadcrumb(TextWriter writer, IHtmlHelper html, List<IActionItem> actionItems)
        {
            if (actionItems.Count == 0)
            {
                return null;
            }

            BreadcrumbBuilder result = new BreadcrumbBuilder(writer, html);
            result.SetBreadcrumbDivider("/");
            result.SetDisplayMode(BreadcrumbDisplayMode.IconAndTitle);
            result.SetMargin(SpacingSide.Y, SpacingSize.Three);
            result.SetPadding(SpacingSide.All, SpacingSize.Two);
            result.SetBorder(BorderSide.All);
            result.SetRounded(BorderRadiusSize.Small, BorderRadiusSide.All);
            result.AddItems(actionItems.ToArray());
            return result;
        }

        #endregion

        #endregion
    }
}