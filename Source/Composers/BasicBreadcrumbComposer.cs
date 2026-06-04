#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Collections.Generic;
using System.IO;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Composes Bootstrap CSS classes or page chrome for basic breadcrumb.
    /// </summary>
    public class BasicBreadcrumbComposer : IBreadcrumbComposer
    {
        #region Instance methods

        #region From interface IBreadcrumbComposer

        /// <summary>
        ///     Gets breadcrumb for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="actionItems">The action items value.</param>
        /// <returns>The configured <see cref="BreadcrumbBuilder" /> value or BootstrapBuilder result.</returns>
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