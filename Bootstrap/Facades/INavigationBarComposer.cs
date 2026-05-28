#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj INavigationBarComposer.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Defines the contract for composing navigation bar composer content in BootstrapBuilder pages.
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
