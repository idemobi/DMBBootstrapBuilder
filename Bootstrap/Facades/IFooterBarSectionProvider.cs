#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Defines the contract for providing footer bar section provider content to BootstrapBuilder page chrome.
    /// </summary>
    public interface IFooterBarSectionProvider
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets the ordering value used when footer bar sections are composed.
        /// </summary>
        int Order { get; }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Builds the footer bar section for the current Razor view.
        /// </summary>
        /// <param name="writer">The writer associated with the current Razor output.</param>
        /// <param name="html">The Razor HTML helper for the current view.</param>
        /// <returns>The footer bar module result to include in the page chrome.</returns>
        FooterBarModuleResult Build(TextWriter writer, IHtmlHelper html);

        /// <summary>
        ///     Determines whether the footer bar section should render for the current view.
        /// </summary>
        /// <param name="html">The Razor HTML helper for the current view.</param>
        /// <returns><see langword="true" /> when the section should render; otherwise, <see langword="false" />.</returns>
        bool IsEnabled(IHtmlHelper html);

        #endregion
    }
}