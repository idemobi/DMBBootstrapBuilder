#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj Alert_HtmlHelpers.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder alert html helpers component or support type.
    /// </summary>
    public static class Alert_HtmlHelpers
    {
        #region Static methods

        /// <summary>
        /// Executes the BootstrapBuilder alert builder operation.
        /// </summary>
        /// <param name="htmlHelper">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="AlertBuilder"/> value or BootstrapBuilder result.</returns>
        [Documented]
        public static AlertBuilder AlertBuilder(this IHtmlHelper htmlHelper)
        {
            return new AlertBuilder(htmlHelper.ViewContext.Writer, htmlHelper);
        }

        /// <summary>
        /// Executes the BootstrapBuilder alert builder operation.
        /// </summary>
        /// <param name="htmlHelper">The Razor HTML helper used to access view context and services.</param>
        /// <param name="message">The message value.</param>
        /// <returns>The configured <see cref="AlertBuilder"/> value or BootstrapBuilder result.</returns>
        [Documented]
        public static AlertBuilder AlertBuilder(this IHtmlHelper htmlHelper, string? message)
        {
            return new AlertBuilder(htmlHelper.ViewContext.Writer, htmlHelper).SetMessage(message);
        }

        #endregion
    }
}