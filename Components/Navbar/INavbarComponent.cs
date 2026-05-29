#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Defines a BootstrapBuilder contract for navbar component.
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