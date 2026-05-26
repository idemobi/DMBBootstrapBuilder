#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj NavFormComponent.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder nav form component component or support type.
    /// </summary>
    public sealed class NavFormComponent : INavbarComponent
    {
        #region Instance fields and properties

        /// <summary>
        /// Gets or sets the content value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public IHtmlContent Content { get; }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NavFormComponent"/> class.
        /// </summary>
        /// <param name="content">The content value.</param>
        public NavFormComponent(IHtmlContent content)
        {
            Content = content ?? HtmlString.Empty;
        }

        #endregion

        #region Instance methods

        #region From interface INavbarComponent

        /// <summary>
        /// Renders value for the BootstrapBuilder output.
        /// </summary>
        /// <param name="htmlHelper">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The rendered HTML content for the BootstrapBuilder component.</returns>
        public IHtmlContent Render(IHtmlHelper htmlHelper)
        {
            using var writer = new StringWriter();
            Content.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);

            return new HtmlString($"""
                                   <form class="d-flex" role="search">
                                       {writer}
                                   </form>
                                   """);
        }

        #endregion

        #endregion
    }
}