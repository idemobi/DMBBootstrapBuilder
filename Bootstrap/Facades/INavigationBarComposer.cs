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

        NavbarBuilder GetDesktopNavbar(TextWriter writer, IHtmlHelper html);
        NavbarBuilder GetMobileNavbar(TextWriter writer, IHtmlHelper html, SideBarComponent? sideBar);

        #endregion
    }
}