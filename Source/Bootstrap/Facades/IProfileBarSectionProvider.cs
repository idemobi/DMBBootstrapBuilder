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
    ///     Defines the contract for providing profile bar section provider content to BootstrapBuilder page chrome.
    /// </summary>
    public interface IProfileBarSectionProvider
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets the ordering value used when profile bar sections are composed.
        /// </summary>
        int Order { get; }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Builds the profile bar section for the current Razor view.
        /// </summary>
        /// <param name="writer">The writer associated with the current Razor output.</param>
        /// <param name="html">The Razor HTML helper for the current view.</param>
        /// <returns>The profile bar module result to include in the page chrome.</returns>
        ProfilBarModuleResult Build(TextWriter writer, IHtmlHelper html); //HttpContext context = html.ViewContext.HttpContext;

        /// <summary>
        ///     Determines whether the profile bar section should render for the current view.
        /// </summary>
        /// <param name="html">The Razor HTML helper for the current view.</param>
        /// <returns><see langword="true" /> when the section should render; otherwise, <see langword="false" />.</returns>
        bool IsEnabled(IHtmlHelper html);

        #endregion
    }
}