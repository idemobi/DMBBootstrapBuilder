#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides Razor helper methods for BootstrapBuilder overridable view debug markers.
    /// </summary>
    public static class OverridableViewDebugExtensions
    {
        #region Static methods

        /// <summary>
        ///     Renders a debug marker describing the current overridable view path.
        /// </summary>
        /// <param name="html">The current HTML helper.</param>
        /// <param name="callerFilePath">The Razor source path, supplied automatically by the compiler.</param>
        /// <returns>The generated marker content.</returns>
        public static IHtmlContent DebugOverridablePath(this IHtmlHelper html, [CallerFilePath] string callerFilePath = "")
        {
            return html.OverridableViewDebugBuilder(callerFilePath).RenderMarker();
        }

        /// <summary>
        ///     Begins a debug wrapper around content that can be overridden by a host application.
        /// </summary>
        /// <param name="html">The current HTML helper.</param>
        /// <param name="viewPath">The Razor source path.</param>
        /// <returns>A disposable wrapper.</returns>
        public static IDisposable DebugOverridablePathSection(this IHtmlHelper html, string viewPath)
        {
            return html.OverridableViewDebugBuilder(viewPath).Begin();
        }

        /// <summary>
        ///     Begins a debug wrapper around content that can be overridden by a host application.
        /// </summary>
        /// <param name="html">The current HTML helper.</param>
        /// <param name="callerFilePath">The Razor source path, supplied automatically by the compiler.</param>
        /// <returns>A disposable wrapper.</returns>
        public static IDisposable DebugOverridableSection(this IHtmlHelper html, [CallerFilePath] string callerFilePath = "")
        {
            return html.OverridableViewDebugBuilder(callerFilePath).Begin();
        }

        /// <summary>
        ///     Renders a debug marker describing the current view as an override.
        /// </summary>
        /// <param name="html">The current HTML helper.</param>
        /// <param name="callerFilePath">The Razor source path, supplied automatically by the compiler.</param>
        /// <returns>The generated marker content.</returns>
        public static IHtmlContent DebugOverridingPath(this IHtmlHelper html, [CallerFilePath] string callerFilePath = "")
        {
            return html.OverridableViewDebugBuilder(callerFilePath)
                .SetOverride()
                .RenderMarker();
        }

        /// <summary>
        ///     Creates a configured overridable view debug builder.
        /// </summary>
        /// <param name="html">The current HTML helper.</param>
        /// <param name="sourcePath">The Razor source path.</param>
        /// <returns>A configured debug builder.</returns>
        public static OverridableViewDebugBuilder OverridableViewDebugBuilder(this IHtmlHelper html, string sourcePath)
        {
            return new OverridableViewDebugBuilder(html.ViewContext.Writer, html)
                .SetSourcePath(sourcePath);
        }

        #endregion
    }
}