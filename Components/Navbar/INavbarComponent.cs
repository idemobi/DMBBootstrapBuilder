#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj INavbarComponent.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Defines a BootstrapBuilder contract for navbar component.
    /// </summary>
    public interface INavbarComponent
    {
        #region Instance methods

        /// <summary>
        ///     Renders the navbar component for the current Razor view.
        /// </summary>
        /// <param name="htmlHelper">The Razor HTML helper for the current view.</param>
        /// <returns>The rendered navbar content.</returns>
        IHtmlContent Render(IHtmlHelper htmlHelper);

        #endregion
    }
}
