#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ToastBuilderExtensions.cs create at 2026/05/16
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides Razor helpers for creating <see cref="DMBBootstrapBuilder.ToastBuilder" /> instances.
    /// </summary>
    [Documented]
    public static class ToastBuilderExtensions
    {
        #region Static methods

        /// <summary>
        ///     Creates a <see cref="DMBBootstrapBuilder.ToastBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The current <see cref="IHtmlHelper" /> instance.</param>
        /// <returns>A new <see cref="DMBBootstrapBuilder.ToastBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="html" /> is <see langword="null" />.</exception>
        [Documented]
        public static ToastBuilder ToastBuilder(this IHtmlHelper html)
        {
            ArgumentNullException.ThrowIfNull(html);
            return new ToastBuilder(html.ViewContext.Writer, html);
        }

        /// <summary>
        ///     Creates a <see cref="DMBBootstrapBuilder.ToastBuilder" /> with an initial body message.
        /// </summary>
        /// <param name="html">The current <see cref="IHtmlHelper" /> instance.</param>
        /// <param name="message">The toast body message.</param>
        /// <returns>A new <see cref="DMBBootstrapBuilder.ToastBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="html" /> is <see langword="null" />.</exception>
        [Documented]
        public static ToastBuilder ToastBuilder(this IHtmlHelper html, string? message)
        {
            ArgumentNullException.ThrowIfNull(html);
            return new ToastBuilder(html.ViewContext.Writer, html).SetMessage(message);
        }

        /// <summary>
        ///     Creates a <see cref="DMBBootstrapBuilder.ToastBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The current <see cref="IHtmlHelper" /> instance.</param>
        /// <returns>A new <see cref="DMBBootstrapBuilder.ToastBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="html" /> is <see langword="null" />.</exception>
        [Documented]
        public static ToastBuilder Toast(this IHtmlHelper html)
        {
            return html.ToastBuilder();
        }

        #endregion
    }
}
