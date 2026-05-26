#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj NavCollapseContentComponent.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using System.Net;
using DMBPageBuilder;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder nav collapse content component component or support type.
    /// </summary>
    public sealed class NavCollapseContentComponent : INavbarComponent
    {
        #region Instance fields and properties

        /// <summary>
        /// Gets or sets the content value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public IHtmlContent Content { get; }
        /// <summary>
        /// Gets or sets the id value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string Id { get; }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NavCollapseContentComponent"/> class.
        /// </summary>
        /// <param name="id">The id value.</param>
        /// <param name="content">The content value.</param>
        public NavCollapseContentComponent(string id, IHtmlContent content)
        {
            Id = HtmlIdGenerator.CleanId(id) ?? throw new ArgumentNullException(nameof(id));
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
                                   <div class="collapse navbar-collapse" id="{WebUtility.HtmlEncode(Id)}">
                                       {writer}
                                   </div>
                                   """);
        }

        #endregion

        #endregion
    }
}