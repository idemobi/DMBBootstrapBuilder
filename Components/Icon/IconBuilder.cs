#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj IconBuilder.cs create at 2026/04/07 21:04:27
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
    /// Provides extension methods for configuring html layout in BootstrapBuilder components.
    /// </summary>
    public static partial class HtmlLayoutExtensions
    {
        #region Static methods

        /// <summary>
        /// Executes the BootstrapBuilder icon builder operation.
        /// </summary>
        /// <param name="htmlHelper">The Razor HTML helper used to access view context and services.</param>
        /// <param name="iconStruct">The icon struct value.</param>
        /// <param name="additionalCss">The additional css value.</param>
        /// <param name="id">The id value.</param>
        /// <returns>The rendered HTML content for the BootstrapBuilder component.</returns>
        public static IHtmlContent IconBuilder(this IHtmlHelper htmlHelper, IconStruct iconStruct, string? additionalCss = null, string? id = null)
        {
            if (iconStruct.IsEmpty)
            {
                return HtmlString.Empty;
            }

            string css = $"{additionalCss}".Trim();
            string idHtml = string.IsNullOrWhiteSpace(id) ? string.Empty : $""" id="{WebUtility.HtmlEncode(id)}" """;

            switch (iconStruct.Kind)
            {
                case IconKind.Bootstrap:
                {
                    string cls = iconStruct.Value.StartsWith("bi ", StringComparison.Ordinal)
                        ? iconStruct.Value
                        : $"bi {iconStruct.Value}";

                    return new HtmlString($"""<i{idHtml} class="{WebUtility.HtmlEncode(cls)} {WebUtility.HtmlEncode(css)}"></i>""");
                }

                case IconKind.Google:
                {
                    string value = iconStruct.Value
                        .Replace("google-", string.Empty, StringComparison.Ordinal)
                        .Replace("google ", string.Empty, StringComparison.Ordinal);

                    return new HtmlString($"""<span{idHtml} class="material-symbols-outlined {WebUtility.HtmlEncode(css)}">{WebUtility.HtmlEncode(value)}</span>""");
                }

                case IconKind.FontAwesome:
                {
                    string cls = iconStruct.Value.StartsWith("fa ", StringComparison.Ordinal)
                        ? iconStruct.Value
                        : $"fa {iconStruct.Value}";

                    return new HtmlString($"""<i{idHtml} class="{WebUtility.HtmlEncode(cls)} {WebUtility.HtmlEncode(css)}"></i>""");
                }

                case IconKind.Image:
                {
                    return new HtmlString($"""<img{idHtml} src="{WebUtility.HtmlEncode(iconStruct.Value)}" class="{WebUtility.HtmlEncode(css)}" alt="{WebUtility.HtmlEncode(iconStruct.Value)}" onerror="this.style.display='none';">""");
                }

                default:
                {
                    return HtmlString.Empty;
                }
            }
        }

        /// <summary>
        /// Executes the BootstrapBuilder icon builder operation.
        /// </summary>
        /// <param name="htmlHelper">The Razor HTML helper used to access view context and services.</param>
        /// <param name="icon">The icon value.</param>
        /// <param name="additionalCss">The additional css value.</param>
        /// <param name="id">The id value.</param>
        /// <returns>The rendered HTML content for the BootstrapBuilder component.</returns>
        public static IHtmlContent IconBuilder(this IHtmlHelper htmlHelper, string? icon, string? additionalCss = null, string? id = null)
        {
            return IconBuilder(htmlHelper, IconStruct.Parse(icon), additionalCss, id);
        }

        /// <summary>
        /// Executes the BootstrapBuilder icon render operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="icon">The icon value.</param>
        /// <returns>The rendered HTML content for the BootstrapBuilder component.</returns>
        public static IHtmlContent IconRender(this IHtmlHelper html, IconStruct icon)
        {
            return IconBuilder(html, icon);
        }

        #endregion
    }
}
