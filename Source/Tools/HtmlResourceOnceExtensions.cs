#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring html resource once in BootstrapBuilder components.
    /// </summary>
    public static class HtmlResourceOnceExtensions
    {
        #region Static methods

        /// <summary>
        ///     Executes the BootstrapBuilder register once operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="key">The key value.</param>
        /// <returns>True when the requested BootstrapBuilder condition is active; otherwise, false.</returns>
        public static bool RegisterOnce(this IHtmlHelper html, string key)
        {
            if (html == null)
            {
                throw new ArgumentNullException(nameof(html));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Key cannot be null or empty.", nameof(key));
            }

            var items = html.ViewContext.HttpContext.Items;

            if (items.ContainsKey(key))
            {
                return false;
            }

            items[key] = true;
            return true;
        }

        #endregion
    }
}