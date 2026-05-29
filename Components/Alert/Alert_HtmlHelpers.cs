#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the BootstrapBuilder alert html helpers component or support type.
    /// </summary>
    public static class Alert_HtmlHelpers
    {
        #region Static methods

        /// <summary>
        ///     Executes the BootstrapBuilder alert builder operation.
        /// </summary>
        /// <param name="htmlHelper">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="DMBBootstrapBuilder.AlertBuilder" /> value or BootstrapBuilder result.</returns>
        [Documented]
        public static AlertBuilder AlertBuilder(this IHtmlHelper htmlHelper)
        {
            return new AlertBuilder(htmlHelper.ViewContext.Writer, htmlHelper);
        }

        /// <summary>
        ///     Executes the BootstrapBuilder alert builder operation.
        /// </summary>
        /// <param name="htmlHelper">The Razor HTML helper used to access view context and services.</param>
        /// <param name="message">The message value.</param>
        /// <returns>The configured <see cref="DMBBootstrapBuilder.AlertBuilder" /> value or BootstrapBuilder result.</returns>
        [Documented]
        public static AlertBuilder AlertBuilder(this IHtmlHelper htmlHelper, string? message)
        {
            return new AlertBuilder(htmlHelper.ViewContext.Writer, htmlHelper).SetMessage(message);
        }

        #endregion
    }
}