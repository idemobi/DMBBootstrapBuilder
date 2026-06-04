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
    ///     Defines the contract for composing navigation bar composer content in BootstrapBuilder pages.
    /// </summary>
    public interface INavigationBarComposer
    {
        #region Instance methods

        /// <summary>
        ///     Builds the desktop Bootstrap navbar for the current Razor view.
        /// </summary>
        /// <param name="writer">The writer associated with the current Razor output.</param>
        /// <param name="html">The Razor HTML helper for the current view.</param>
        /// <returns>The configured desktop navbar builder.</returns>
        NavbarBuilder GetDesktopNavbar(TextWriter writer, IHtmlHelper html);

        /// <summary>
        ///     Builds the mobile Bootstrap navbar for the current Razor view.
        /// </summary>
        /// <param name="writer">The writer associated with the current Razor output.</param>
        /// <param name="html">The Razor HTML helper for the current view.</param>
        /// <param name="sideBar">The optional sidebar paired with the mobile navbar.</param>
        /// <returns>The configured mobile navbar builder.</returns>
        NavbarBuilder GetMobileNavbar(TextWriter writer, IHtmlHelper html, SideBarComponent? sideBar);

        #endregion
    }
}