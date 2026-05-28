#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj IMenuBarSectionProvider.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Defines the contract for providing menu bar section provider content to BootstrapBuilder page chrome.
    /// </summary>
    public interface IMenuBarSectionProvider
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets the ordering value used when menu bar sections are composed.
        /// </summary>
        int Order { get; }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Builds the menu bar section for the current Razor view.
        /// </summary>
        /// <param name="writer">The writer associated with the current Razor output.</param>
        /// <param name="html">The Razor HTML helper for the current view.</param>
        /// <returns>The menu bar module result to include in the page chrome.</returns>
        MenuBarModuleResult Build(TextWriter writer, IHtmlHelper html); //HttpContext context = html.ViewContext.HttpContext;

        /// <summary>
        ///     Determines whether the menu bar section should render for the current view.
        /// </summary>
        /// <param name="html">The Razor HTML helper for the current view.</param>
        /// <returns><see langword="true"/> when the section should render; otherwise, <see langword="false"/>.</returns>
        bool IsEnabled(IHtmlHelper html);

        #endregion
    }
}
