#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj BootstrapPageAlertManager.cs create at 2026/05/07 00:00:00
// (c)2024-2026 ideMobi SARL FRANCE

#endregion

#region

using System.Net;
using System.Text;
using DMBPageBuilder;
using Microsoft.AspNetCore.Html;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder bootstrap page alert manager component or support type.
    /// </summary>
    public class BootstrapPageAlertManager : PageAlertManager, IBootstrapPageAlertManager
    {
        #region Instance methods

        /// <summary>
        /// Executes the BootstrapBuilder to alert models operation.
        /// </summary>
        /// <returns>The configured <see cref="IEnumerable"/> value or BootstrapBuilder result.</returns>
        public IEnumerable<AlertModel> ToAlertModels()
        {
            foreach (PageAlertModel alert in Alerts)
            {
                yield return ToAlertModel(alert);
            }
        }

        protected virtual AlertModel ToAlertModel(PageAlertModel alert)
        {
            AlertModel model = new AlertModel(GetIcon(alert), BuildTitle(alert), BuildMessage(alert))
                .SetVariant(ToVariant(alert.Style));

            if (alert.Style is PageAlertStyle.Info or PageAlertStyle.Success)
            {
                model.SetDismissible();
            }

            List<IActionItem> footerActions = BuildFooterActions(alert).ToList();
            if (footerActions.Count > 0)
            {
                model.SetFooterActions(footerActions.ToArray());
            }

            return model;
        }

        private static string? BuildTitle(PageAlertModel alert)
        {
            if (alert.Code.HasValue)
            {
                return string.IsNullOrWhiteSpace(alert.Title) ? alert.Code.Value.ToString() : $"{alert.Code.Value} - {alert.Title}";
            }

            return alert.Title;
        }

        private static IHtmlContent BuildMessage(PageAlertModel alert)
        {
            StringBuilder builder = new();

            if (!string.IsNullOrWhiteSpace(alert.Subtitle))
            {
                builder.Append("<p class=\"mb-1 small fw-semibold text-body-secondary\">");
                builder.Append(WebUtility.HtmlEncode(alert.Subtitle));
                builder.Append("</p>");
            }

            if (!string.IsNullOrWhiteSpace(alert.Message))
            {
                builder.Append("<p class=\"mb-0\">");
                builder.Append(WebUtility.HtmlEncode(alert.Message));
                builder.Append("</p>");
            }

            if (alert.Details.Count > 0)
            {
                builder.Append("<ul class=\"mb-0 mt-2 ps-3\">");
                foreach (string detail in alert.Details)
                {
                    builder.Append("<li>");
                    builder.Append(WebUtility.HtmlEncode(detail));
                    builder.Append("</li>");
                }

                builder.Append("</ul>");
            }

            return new HtmlString(builder.ToString());
        }

        private static IEnumerable<IActionItem> BuildFooterActions(PageAlertModel alert)
        {
            if (!string.IsNullOrWhiteSpace(alert.PrimaryUrl))
            {
                yield return ActionItemFactory.Url(string.IsNullOrWhiteSpace(alert.PrimaryText) ? "Open" : alert.PrimaryText, alert.PrimaryUrl, IconStruct.BootstrapEnum(BootStrapEnum.bi_arrow_right))
                    .SetVariant(VariantStyle.Primary);
            }

            if (!string.IsNullOrWhiteSpace(alert.SecondaryUrl))
            {
                yield return ActionItemFactory.Url(string.IsNullOrWhiteSpace(alert.SecondaryText) ? "More" : alert.SecondaryText, alert.SecondaryUrl, IconStruct.BootstrapEnum(BootStrapEnum.bi_arrow_right_circle))
                    .SetVariant(VariantStyle.Secondary);
            }
        }

        private static IconStruct GetIcon(PageAlertModel alert)
        {
            if (alert.Code.HasValue)
            {
                return alert.Code.Value switch
                {
                    401 or 403 => IconStruct.BootstrapEnum(BootStrapEnum.bi_shield_lock),
                    404 => IconStruct.BootstrapEnum(BootStrapEnum.bi_compass),
                    405 => IconStruct.BootstrapEnum(BootStrapEnum.bi_sign_stop),
                    >= 500 => IconStruct.BootstrapEnum(BootStrapEnum.bi_exclamation_octagon),
                    _ => GetIcon(alert.Style)
                };
            }

            return GetIcon(alert.Style);
        }

        private static IconStruct GetIcon(PageAlertStyle style)
        {
            return style switch
            {
                PageAlertStyle.Success => IconStruct.BootstrapEnum(BootStrapEnum.bi_check_circle),
                PageAlertStyle.Info => IconStruct.BootstrapEnum(BootStrapEnum.bi_info_circle),
                PageAlertStyle.Warning => IconStruct.BootstrapEnum(BootStrapEnum.bi_exclamation_triangle),
                PageAlertStyle.Danger => IconStruct.BootstrapEnum(BootStrapEnum.bi_exclamation_octagon),
                _ => IconStruct.BootstrapEnum(BootStrapEnum.bi_info_circle)
            };
        }

        private static VariantStyle ToVariant(PageAlertStyle style)
        {
            return style switch
            {
                PageAlertStyle.Primary => VariantStyle.Primary,
                PageAlertStyle.Secondary => VariantStyle.Secondary,
                PageAlertStyle.Success => VariantStyle.Success,
                PageAlertStyle.Info => VariantStyle.Info,
                PageAlertStyle.Warning => VariantStyle.Warning,
                PageAlertStyle.Danger => VariantStyle.Danger,
                PageAlertStyle.Light => VariantStyle.Light,
                PageAlertStyle.Dark => VariantStyle.Dark,
                _ => VariantStyle.Warning
            };
        }

        #endregion
    }
}
