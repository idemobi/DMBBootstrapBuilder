#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj PageQualificationDebugExtensions.cs create at 2026/05/12
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides Razor helper methods for page qualification diagnostics.
    /// </summary>
    public static class PageQualificationDebugExtensions
    {
        /// <summary>
        /// Creates a configured page qualification debug builder.
        /// </summary>
        /// <param name="html">The current HTML helper.</param>
        /// <param name="status">The qualification status.</param>
        /// <param name="sourcePath">The Razor source path.</param>
        /// <returns>A configured debug builder.</returns>
        public static PageQualificationDebugBuilder PageQualificationDebugBuilder(
            this IHtmlHelper html,
            PageQualificationStatus status = PageQualificationStatus.Validated,
            string sourcePath = "")
        {
            return new PageQualificationDebugBuilder(html.ViewContext.Writer, html)
                .SetStatus(status)
                .SetSourcePath(sourcePath);
        }

        /// <summary>
        /// Begins a diagnostic wrapper around a page or partial view.
        /// </summary>
        /// <param name="html">The current HTML helper.</param>
        /// <param name="status">The qualification status.</param>
        /// <param name="callerFilePath">The Razor source path, supplied automatically by the compiler.</param>
        /// <returns>A disposable diagnostic wrapper.</returns>
        public static IDisposable DebugPageComment(
            this IHtmlHelper html,
            PageQualificationStatus status = PageQualificationStatus.Validated,
            [CallerFilePath] string callerFilePath = "")
        {
            return html.PageQualificationDebugBuilder(status, callerFilePath).Begin();
        }

        /// <summary>
        /// Renders only the visible page qualification marker.
        /// </summary>
        /// <param name="html">The current HTML helper.</param>
        /// <param name="status">The qualification status.</param>
        /// <param name="callerFilePath">The Razor source path, supplied automatically by the compiler.</param>
        /// <returns>The generated marker content.</returns>
        public static IHtmlContent DebugPageQualification(
            this IHtmlHelper html,
            PageQualificationStatus status = PageQualificationStatus.Validated,
            [CallerFilePath] string callerFilePath = "")
        {
            return html.PageQualificationDebugBuilder(status, callerFilePath).RenderMarker();
        }
    }
}
