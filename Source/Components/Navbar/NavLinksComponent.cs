#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the BootstrapBuilder nav links component component or support type.
    /// </summary>
    public sealed class NavLinksComponent : NavbarComponentBase
    {
        #region Static methods

        private static string BuildAdditionalAttributes(IActionItem item)
        {
            if (item?.HtmlAttributes == null || item.HtmlAttributes.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, string> kvp in item.HtmlAttributes)
            {
                if (string.IsNullOrWhiteSpace(kvp.Key) || string.IsNullOrWhiteSpace(kvp.Value))
                {
                    continue;
                }

                sb.Append(' ');
                sb.Append(WebUtility.HtmlEncode(kvp.Key));
                sb.Append("=\"");
                sb.Append(WebUtility.HtmlEncode(kvp.Value));
                sb.Append('"');
            }

            return sb.ToString();
        }

        private static string BuildAspRouteUrl(IHtmlHelper htmlHelper, AspRouteActionItem item)
        {
            var factory = htmlHelper.ViewContext.HttpContext.RequestServices.GetRequiredService<IUrlHelperFactory>();
            var urlHelper = factory.GetUrlHelper(htmlHelper.ViewContext);

            var routeValues = new Dictionary<string, object?>();

            if (!string.IsNullOrWhiteSpace(item.AspArea))
            {
                routeValues["area"] = item.AspArea;
            }

            foreach (var kvp in item.RouteValues)
            {
                routeValues[kvp.Key] = kvp.Value;
            }

            var actionContext = new UrlActionContext
            {
                Action = item.AspAction,
                Controller = item.AspController,
                Values = routeValues
            };

            return urlHelper.Action(actionContext) ?? "#";
        }

        private static string BuildTextColorCss(IActionItem item)
        {
            if (item == null)
            {
                return string.Empty;
            }

            return item.Variant switch
            {
                VariantStyle.Primary => " text-primary",
                VariantStyle.Secondary => " text-secondary",
                // VariantStyle.Tertiary => " text-tertiary",
                VariantStyle.Success => " text-success",
                VariantStyle.Warning => " text-warning",
                VariantStyle.Danger => " text-danger",
                VariantStyle.Info => " text-info",
                VariantStyle.Light => " text-light",
                VariantStyle.Dark => " text-dark",
                VariantStyle.Normal => string.Empty,
                _ => string.Empty
            };
        }

        private static string EncodeAttribute(string? value)
        {
            return HtmlEncoder.Default.Encode(value ?? string.Empty);
        }

        private static string GetAriaDisabledAttribute(IActionItem item)
        {
            return item.Disabled ? """ aria-disabled="true" """ : string.Empty;
        }

        private static string GetDisabledAttribute(IActionItem item)
        {
            return item.Disabled ? """ disabled="disabled" """ : string.Empty;
        }

        private static string GetInlineBadgeHtml(IActionItem item)
        {
            if (string.IsNullOrWhiteSpace(item.BadgeText))
            {
                return string.Empty;
            }

            string styleCss = item.BadgeStyle.ToString().ToLowerInvariant();
            string text = HtmlEncoder.Default.Encode(item.BadgeText);

            return $"""
                    <span class="badge rounded-pill text-bg-{styleCss}">
                        {text}
                    </span>
                    """;
        }

        private static string GetRelAttribute(UrlActionItem item)
        {
            if (string.IsNullOrWhiteSpace(item.Rel))
            {
                return string.Empty;
            }

            return $""" rel="{WebUtility.HtmlEncode(item.Rel)}" """;
        }

        private static string GetTargetAttribute(UrlActionItem item)
        {
            if (string.IsNullOrWhiteSpace(item.Target))
            {
                return string.Empty;
            }

            return $""" target="{WebUtility.HtmlEncode(item.Target)}" """;
        }

        #endregion

        #region Instance fields and properties

        private readonly List<IActionItem> _items = new();

        /// <summary>
        ///     Gets or sets the align items value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public AlignItems AlignItems { get; set; } = AlignItems.Center;

        /// <summary>
        ///     Gets or sets the dropdown align value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public NavbarDropdownAlign DropdownAlign { get; set; } = NavbarDropdownAlign.Start;

        /// <summary>
        ///     Gets or sets the dropdown auto columns value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool DropdownAutoColumns { get; set; } = true;

        /// <summary>
        ///     Gets or sets the dropdown break on divider value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool DropdownBreakOnDivider { get; set; } = true;

        /// <summary>
        ///     Gets or sets the dropdown column gap rem value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public decimal DropdownColumnGapRem { get; set; } = 1m;

        /// <summary>
        ///     Gets or sets the dropdown column width rem value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public decimal DropdownColumnWidthRem { get; set; } = 14m;

        /// <summary>
        ///     Gets or sets the dropdown grid columns value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public int DropdownGridColumns { get; set; } = 2;

        /// <summary>
        ///     Gets or sets the dropdown horizontal padding rem value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public decimal DropdownHorizontalPaddingRem { get; set; } = 1.5m;

        /// <summary>
        ///     Gets or sets the dropdown layout value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public NavbarDropdownLayout DropdownLayout { get; set; } = NavbarDropdownLayout.Grid;

        /// <summary>
        ///     Gets or sets the dropdown max columns value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public int DropdownMaxColumns { get; set; } = 3;

        /// <summary>
        ///     Gets or sets the dropdown max items per column value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public int DropdownMaxItemsPerColumn { get; set; } = 15;

        /// <summary>
        ///     Gets or sets the dropdown scrollable value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool DropdownScrollable { get; set; } = true;

        /// <summary>
        ///     Gets or sets the icon only value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool IconOnly { get; set; }

        /// <summary>
        ///     Gets or sets the justify value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public JustifyContent Justify { get; set; } = JustifyContent.Start;

        /// <summary>
        ///     Gets or sets the old gap value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public Old_Gap OldGap { get; set; } = Old_Gap.Gap2;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Adds value to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="item">The item value.</param>
        /// <returns>The configured <see cref="NavLinksComponent" /> value or BootstrapBuilder result.</returns>
        public NavLinksComponent Add(IActionItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _items.Add(item);
            return this;
        }

        /// <summary>
        ///     Adds value to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="items">The items value.</param>
        /// <returns>The configured <see cref="NavLinksComponent" /> value or BootstrapBuilder result.</returns>
        public NavLinksComponent Add(params IActionItem[] items)
        {
            if (items == null)
            {
                return this;
            }

            foreach (var item in items.Where(x => x != null))
            {
                Add(item);
            }

            return this;
        }

        private List<List<IActionItem>> BuildDropdownColumns(IActionContainerItem container)
        {
            var columns = new List<List<IActionItem>>();
            var currentColumn = new List<IActionItem>();

            int maxItemsPerColumn = Math.Max(1, DropdownMaxItemsPerColumn);
            int maxColumns = Math.Max(1, DropdownMaxColumns);

            int currentVisualWeight = 0;

            foreach (var item in container.Items)
            {
                bool isDivider = item is DividerActionItem;
                int itemWeight = GetVisualWeight(item);

                bool shouldBreakBeforeItem =
                    columns.Count < maxColumns - 1 &&
                    currentColumn.Count > 0 &&
                    (
                        currentVisualWeight + itemWeight > maxItemsPerColumn ||
                        (
                            DropdownBreakOnDivider &&
                            isDivider &&
                            currentVisualWeight >= Math.Max(2, maxItemsPerColumn / 2)
                        )
                    );

                if (shouldBreakBeforeItem)
                {
                    columns.Add(currentColumn);
                    currentColumn = new List<IActionItem>();
                    currentVisualWeight = 0;

                    if (isDivider)
                    {
                        continue;
                    }
                }

                currentColumn.Add(item);
                currentVisualWeight += itemWeight;
            }

            if (currentColumn.Count > 0)
            {
                columns.Add(currentColumn);
            }

            if (columns.Count == 0)
            {
                columns.Add(new List<IActionItem>());
            }

            return columns;
        }

        private string BuildDropdownWidthStyle(int columnCount)
        {
            columnCount = Math.Max(1, columnCount);

            if (DropdownLayout != NavbarDropdownLayout.Grid)
            {
                return $"min-width: {DropdownColumnWidthRem.ToString(CultureInfo.InvariantCulture)}rem;";
            }

            int clampedColumns = Math.Min(columnCount, Math.Max(1, DropdownMaxColumns));

            decimal totalWidth = (clampedColumns * DropdownColumnWidthRem)
                                 + ((clampedColumns - 1) * DropdownColumnGapRem)
                                 + DropdownHorizontalPaddingRem;

            return $"width: min(95vw, {totalWidth.ToString(CultureInfo.InvariantCulture)}rem);";
        }

        private List<List<IActionItem>> BuildFixedGridColumns(IActionContainerItem container)
        {
            int columns = Math.Max(1, DropdownGridColumns);

            var result = new List<List<IActionItem>>();
            for (int i = 0; i < columns; i++)
            {
                result.Add(new List<IActionItem>());
            }

            int index = 0;
            foreach (var item in container.Items)
            {
                result[index].Add(item);
                index = (index + 1) % columns;
            }

            return result;
        }

        private string GetDropdownAlignCss()
        {
            return DropdownAlign switch
            {
                NavbarDropdownAlign.Start => "dropdown-menu-start",
                NavbarDropdownAlign.End => "dropdown-menu-end",
                _ => string.Empty
            };
        }

        private int GetVisualWeight(IActionItem item)
        {
            switch (item)
            {
                case null:
                    return 0;

                case DividerActionItem:
                    return 0;

                case IGuardedActionItem guarded:
                    return GetVisualWeight(guarded.InnerAction);

                case GroupActionItem group:
                {
                    int weight = 1;

                    foreach (var child in group.Items)
                    {
                        weight += GetVisualWeight(child);
                    }

                    return Math.Max(1, weight);
                }

                case IActionContainerItem container when container.HasChildren:
                    return 1;

                default:
                    return 1;
            }
        }

        /// <summary>
        ///     Renders value for the BootstrapBuilder output.
        /// </summary>
        /// <param name="htmlHelper">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The rendered HTML content for the BootstrapBuilder component.</returns>
        public override IHtmlContent Render(IHtmlHelper htmlHelper)
        {
            if (htmlHelper == null)
            {
                throw new ArgumentNullException(nameof(htmlHelper));
            }

            var itemsHtml = _items
                .Select(x => RenderNavRootItem(htmlHelper, x))
                .Where(x => !string.IsNullOrWhiteSpace(x));

            string css = BuildCommonCss(
                "navbar-nav",
                "d-flex",
                "flex-row",
                Justify.GetJustifyCss(),
                AlignItems.GetAlignItemsCss(),
                OldGap.GetGapCss());

            return new HtmlString($"""
                                   <ul class="{WebUtility.HtmlEncode(css)}">
                                       {string.Join(Environment.NewLine, itemsHtml)}
                                   </ul>
                                   """);
        }

        private string RenderDropdownClipboardItem(IHtmlHelper htmlHelper, ClipboardActionItem item, string badgeHtml, string textColorCss)
        {
            string startText = item.ClipboardStartText ?? item.Title ?? string.Empty;
            string endText = item.ClipboardEndText ?? string.Empty;
            string value = item.ClipboardValue ?? string.Empty;
            string extraAttributes = BuildAdditionalAttributes(item);

            IconStruct startIcon = item.ClipboardStartIcon.IsEmpty ? item.Icon : item.ClipboardStartIcon;
            IconStruct endIcon = item.ClipboardEndIcon.IsEmpty ? startIcon : item.ClipboardEndIcon;

            string startIconHtml = startIcon.IsEmpty
                ? string.Empty
                : HtmlLayoutExtensions.IconBuilder(htmlHelper, startIcon).ToString() ?? string.Empty;

            string endIconHtml = endIcon.IsEmpty
                ? string.Empty
                : HtmlLayoutExtensions.IconBuilder(htmlHelper, endIcon).ToString() ?? string.Empty;

            return $"""
                    <button type="button"
                            class="dropdown-item{textColorCss}"
                            {extraAttributes}
                            data-copy="{EncodeAttribute(value)}"
                            data-copy-reset-ms="{item.ClipboardResetDelayMs}"
                            data-copy-text-start="{EncodeAttribute(startText)}"
                            data-copy-text-end="{EncodeAttribute(endText)}"
                            data-copy-icon-start-html="{EncodeAttribute(startIconHtml)}"
                            data-copy-icon-end-html="{EncodeAttribute(endIconHtml)}"
                            onclick="DMBActionItemClipboard(this)">
                        <span class="d-flex align-items-center justify-content-between gap-2 w-100">
                            <span class="d-inline-flex align-items-center gap-2">
                                <span class="action-item-clipboard-icon">{startIconHtml}</span>
                                <span class="action-item-clipboard-text">{HtmlEncoder.Default.Encode(startText)}</span>
                            </span>
                            {badgeHtml}
                        </span>
                    </button>
                    """;
        }

        private string RenderDropdownGroup(IHtmlHelper htmlHelper, GroupActionItem group)
        {
            string title = group.Title ?? string.Empty;
            string iconHtml = group.Icon.IsEmpty
                ? string.Empty
                : HtmlLayoutExtensions.IconBuilder(htmlHelper, group.Icon).ToString() ?? string.Empty;

            string badgeHtml = GetInlineBadgeHtml(group);
            string subtitleHtml = string.IsNullOrWhiteSpace(group.Subtitle)
                ? string.Empty
                : $"""<div class="small text-body-secondary">{WebUtility.HtmlEncode(group.Subtitle)}</div>""";

            string textColorCss = BuildTextColorCss(group);
            string extraAttributes = BuildAdditionalAttributes(group);

            var childrenHtml = new List<string>();
            foreach (var child in group.Items)
            {
                string childHtml = RenderDropdownMenuItem(htmlHelper, child);
                if (!string.IsNullOrWhiteSpace(childHtml))
                {
                    childrenHtml.Add(childHtml);
                }
            }

            return $"""
                    <div class="dropdown-item-text px-0 py-2 {textColorCss}"{extraAttributes}>
                        <div class="d-flex align-items-start gap-2">
                            <div class="flex-shrink-0">{iconHtml}</div>
                            <div class="flex-grow-1">
                                <div class="d-flex align-items-center justify-content-between gap-2">
                                    <div class="fw-semibold text-muted dmb-dropdown-label">{WebUtility.HtmlEncode(title)}</div>
                                    {badgeHtml}
                                </div>
                                {subtitleHtml}
                            </div>
                        </div>
                    </div>
                    {string.Join(Environment.NewLine, childrenHtml)}
                    """;
        }

        private DropdownRenderResult RenderDropdownMenuBody(IHtmlHelper htmlHelper, IActionContainerItem container)
        {
            return DropdownLayout switch
            {
                NavbarDropdownLayout.Grid => RenderDropdownMenuGrid(htmlHelper, container),
                _ => RenderDropdownMenuVertical(htmlHelper, container)
            };
        }

        private DropdownRenderResult RenderDropdownMenuGrid(IHtmlHelper htmlHelper, IActionContainerItem container)
        {
            List<List<IActionItem>> columns = DropdownAutoColumns
                ? BuildDropdownColumns(container)
                : BuildFixedGridColumns(container);

            int columnCount = Math.Max(1, columns.Count);
            int colSize = Math.Max(1, 12 / Math.Min(columnCount, 4));

            var htmlColumns = new List<string>();

            foreach (var column in columns)
            {
                var itemsHtml = new List<string>();

                foreach (var item in column)
                {
                    string childHtml = RenderDropdownMenuItem(htmlHelper, item);
                    if (!string.IsNullOrWhiteSpace(childHtml))
                    {
                        itemsHtml.Add(childHtml);
                    }
                }

                htmlColumns.Add($"""
                                 <div class="col-12 col-md-{colSize}">
                                     {string.Join(Environment.NewLine, itemsHtml)}
                                 </div>
                                 """);
            }

            return new DropdownRenderResult
            {
                Html = $"""
                        <div class="row g-2">
                            {string.Join(Environment.NewLine, htmlColumns)}
                        </div>
                        """,
                ColumnCount = columnCount
            };
        }

        private string RenderDropdownMenuItem(IHtmlHelper htmlHelper, IActionItem item)
        {
            if (item is DividerActionItem)
            {
                return """<hr class="dropdown-divider my-1">""";
            }

            if (item is GroupActionItem group)
            {
                return RenderDropdownGroup(htmlHelper, group);
            }

            if (item is ToggleActionItem toggle)
            {
                return RenderDropdownToggleItem(htmlHelper, toggle);
            }

            if (item is IGuardedActionItem guarded)
            {
                return RenderDropdownMenuItem(htmlHelper, guarded.InnerAction);
            }

            string title = item.Title ?? string.Empty;
            string iconHtml = item.Icon.IsEmpty
                ? string.Empty
                : HtmlLayoutExtensions.IconBuilder(htmlHelper, item.Icon).ToString() ?? string.Empty;

            string disabledCss = item.Disabled ? " disabled" : string.Empty;
            string activeCss = item.Active ? " active" : string.Empty;
            string textColorCss = BuildTextColorCss(item);
            string badgeHtml = GetInlineBadgeHtml(item);
            string extraAttributes = BuildAdditionalAttributes(item);

            string inner = $"""
                            <span class="d-flex align-items-center justify-content-between gap-2 w-100">
                                <span class="d-inline-flex align-items-center gap-2">
                                    {iconHtml}<span class="dmb-dropdown-label">{WebUtility.HtmlEncode(title)}</span>
                                </span>
                                {badgeHtml}
                            </span>
                            """;

            switch (item)
            {
                case UrlActionItem url:
                    return $"""
                            <a class="dropdown-item{activeCss}{disabledCss}{textColorCss}" href="{WebUtility.HtmlEncode(url.Url ?? "#")}"{GetTargetAttribute(url)}{GetRelAttribute(url)}{extraAttributes}>
                                {inner}
                            </a>
                            """;

                case AspRouteActionItem route:
                    return $"""
                            <a class="dropdown-item{activeCss}{disabledCss}{textColorCss}" href="{WebUtility.HtmlEncode(BuildAspRouteUrl(htmlHelper, route))}"{extraAttributes}>
                                {inner}
                            </a>
                            """;

                case JavaScriptActionItem js:
                    return $"""
                            <button type="button" class="dropdown-item{activeCss}{disabledCss}{textColorCss}" onclick="{HtmlEncoder.Default.Encode(js.JavaScript ?? string.Empty)}"{extraAttributes}>
                                {inner}
                            </button>
                            """;

                case ModalActionItem modal:
                    return $"""
                            <button type="button" class="dropdown-item{activeCss}{disabledCss}{textColorCss}" data-bs-toggle="modal" data-bs-target="#{WebUtility.HtmlEncode(modal.ModalTargetId ?? string.Empty)}"{extraAttributes}>
                                {inner}
                            </button>
                            """;

                case DismissModalActionItem:
                    return $"""
                            <button type="button" class="dropdown-item{activeCss}{disabledCss}{textColorCss}" data-bs-dismiss="modal"{extraAttributes}>
                                {inner}
                            </button>
                            """;

                case ClipboardActionItem clipboard:
                    return RenderDropdownClipboardItem(htmlHelper, clipboard, badgeHtml, textColorCss);

                default:
                    return $"""
                            <div class="dropdown-item-text{textColorCss}"{extraAttributes}>
                                {inner}
                            </div>
                            """;
            }
        }

        private DropdownRenderResult RenderDropdownMenuVertical(IHtmlHelper htmlHelper, IActionContainerItem container)
        {
            var itemsHtml = new List<string>();

            foreach (var child in container.Items)
            {
                string childHtml = RenderDropdownMenuItem(htmlHelper, child);
                if (!string.IsNullOrWhiteSpace(childHtml))
                {
                    itemsHtml.Add(childHtml);
                }
            }

            return new DropdownRenderResult
            {
                Html = string.Join(Environment.NewLine, itemsHtml),
                ColumnCount = 1
            };
        }

        private string RenderDropdownToggleItem(IHtmlHelper htmlHelper, ToggleActionItem item)
        {
            string iconHtml = item.Icon.IsEmpty
                ? string.Empty
                : HtmlLayoutExtensions.IconBuilder(htmlHelper, item.Icon).ToString() ?? string.Empty;
            string switchId = !string.IsNullOrWhiteSpace(item.Id)
                ? item.Id
                : $"dropdown_toggle_{Guid.NewGuid():N}";

            string checkedAttribute = item.SwitchValue ? """ checked="checked" """ : string.Empty;
            string disabledAttribute = item.Disabled ? """ disabled="disabled" """ : string.Empty;
            string onchangeAttribute = string.IsNullOrWhiteSpace(item.SwitchJavaScript)
                ? string.Empty
                : $""" onchange="{HtmlEncoder.Default.Encode(item.SwitchJavaScript)}" """;

            string badgeHtml = GetInlineBadgeHtml(item);
            string switchStyleCss = BootstrapStyleHelper.GetSwitchStyleCss(item.Variant);
            string extraAttributes = BuildAdditionalAttributes(item);
            string textColorCss = BuildTextColorCss(item);

            return $"""
                    <div class="dropdown-item-text{textColorCss}">
                        <div class="d-flex align-items-center justify-content-between gap-2">
                        {iconHtml}
                         <div class="d-flex align-items-center gap-2 flex-grow-1">
                                <label class="mb-0 flex-grow-1 dmb-dropdown-label" for="{WebUtility.HtmlEncode(switchId)}">{WebUtility.HtmlEncode(item.Title ?? string.Empty)}</label>
                                {badgeHtml}
                            </div>
                            <div class="m-0 d-inline-flex align-items-center form-check form-switch">
                                <input id="{WebUtility.HtmlEncode(switchId)}"
                                       class="form-check-input guarded-switch {WebUtility.HtmlEncode(switchStyleCss)}"
                                       type="checkbox"{checkedAttribute}{disabledAttribute}{onchangeAttribute}{extraAttributes}>
                            </div>
                        </div>
                    </div>
                    """;
        }

        private string RenderNavbarClipboardItem(
            IHtmlHelper htmlHelper,
            ClipboardActionItem item,
            string iconHtml,
            string title,
            string activeCss,
            string disabledCss,
            string textColorCss
        )
        {
            string startText = item.ClipboardStartText ?? title;
            string endText = item.ClipboardEndText ?? string.Empty;
            string value = item.ClipboardValue ?? string.Empty;
            string extraAttributes = BuildAdditionalAttributes(item);

            IconStruct startIcon = item.ClipboardStartIcon.IsEmpty ? item.Icon : item.ClipboardStartIcon;
            IconStruct endIcon = item.ClipboardEndIcon.IsEmpty ? startIcon : item.ClipboardEndIcon;

            string startIconHtml = startIcon.IsEmpty
                ? iconHtml
                : HtmlLayoutExtensions.IconBuilder(htmlHelper, startIcon).ToString() ?? string.Empty;

            string endIconHtml = endIcon.IsEmpty
                ? string.Empty
                : HtmlLayoutExtensions.IconBuilder(htmlHelper, endIcon).ToString() ?? string.Empty;

            return $"""
                    <li class="nav-item">
                        <button type="button"
                                class="nav-link d-inline-flex gap-1 btn btn-link text-decoration-none{activeCss}{disabledCss}{textColorCss}"
                                {extraAttributes}
                                data-copy="{EncodeAttribute(value)}"
                                data-copy-reset-ms="{item.ClipboardResetDelayMs}"
                                data-copy-text-start="{EncodeAttribute(startText)}"
                                data-copy-text-end="{EncodeAttribute(endText)}"
                                data-copy-icon-start-html="{EncodeAttribute(startIconHtml)}"
                                data-copy-icon-end-html="{EncodeAttribute(endIconHtml)}"
                                onclick="DMBActionItemClipboard(this)"{GetDisabledAttribute(item)}>
                            <span class="action-item-clipboard-icon">{startIconHtml}</span><span class="action-item-clipboard-text">{HtmlEncoder.Default.Encode(startText)}</span>
                        </button>
                    </li>
                    """;
        }

        private string RenderNavbarDropdown(IHtmlHelper htmlHelper, IActionItem rootItem, IActionContainerItem container)
        {
            string IconOnlyCss = IconOnly ? " nav-icon-only" : string.Empty;
            string dropdownId = !string.IsNullOrWhiteSpace(rootItem.Id)
                ? rootItem.Id
                : htmlHelper.GenerateUniqueId("nav_dropdown");

            string title = IconOnly ? string.Empty : (rootItem.Title ?? string.Empty);
            string iconHtml = rootItem.Icon.IsEmpty
                ? string.Empty
                : HtmlLayoutExtensions.IconBuilder(htmlHelper, rootItem.Icon).ToString() ?? string.Empty;

            string disabledCss = rootItem.Disabled ? " disabled" : string.Empty;
            string activeCss = rootItem.Active ? " active" : string.Empty;
            string textColorCss = BuildTextColorCss(rootItem);
            string extraAttributes = BuildAdditionalAttributes(rootItem);

            string menuAlignCss = GetDropdownAlignCss();
            string menuBodyCss = DropdownLayout == NavbarDropdownLayout.Grid
                ? "dmb-dropdown-body dropdown-grid"
                : "dmb-dropdown-body";

            DropdownRenderResult menuBody = RenderDropdownMenuBody(htmlHelper, container);
            string menuWidthStyle = BuildDropdownWidthStyle(menuBody.ColumnCount);

            if (DropdownScrollable)
            {
                return $"""
                        <li class="nav-item dropdown{IconOnlyCss}">
                            <a class="nav-link d-inline-flex gap-1 align-items-center dropdown-toggle{activeCss}{disabledCss}{textColorCss}" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false" id="{WebUtility.HtmlEncode(dropdownId)}"{GetAriaDisabledAttribute(rootItem)}{extraAttributes}>
                                {iconHtml}{WebUtility.HtmlEncode(title)}
                            </a>
                            <div class="dropdown-menu {WebUtility.HtmlEncode(menuAlignCss)} p-0" aria-labelledby="{WebUtility.HtmlEncode(dropdownId)}" style="{WebUtility.HtmlEncode(menuWidthStyle)}">
                                <div class="dmb-dropdown-scroll-wrap">
                                    <div class="dmb-dropdown-scrollbar">
                                        <div class="{WebUtility.HtmlEncode(menuBodyCss)} max-h-dropdown p-2">
                                            {menuBody.Html}
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </li>
                        """;
            }

            return $"""
                    <li class="nav-item dropdown{IconOnlyCss}">
                        <a class="nav-link d-inline-flex gap-1 align-items-center dropdown-toggle{activeCss}{disabledCss}{textColorCss}" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false" id="{WebUtility.HtmlEncode(dropdownId)}"{GetAriaDisabledAttribute(rootItem)}{extraAttributes}>
                            {iconHtml}{WebUtility.HtmlEncode(title)}
                        </a>
                        <div class="dropdown-menu {WebUtility.HtmlEncode(menuAlignCss)} p-0" aria-labelledby="{WebUtility.HtmlEncode(dropdownId)}" style="{WebUtility.HtmlEncode(menuWidthStyle)}">
                            <div class="{WebUtility.HtmlEncode(menuBodyCss)} max-h-dropdown p-2">
                                {menuBody.Html}
                            </div>
                        </div>
                    </li>
                    """;
        }

        private string RenderNavbarSingleItem(IHtmlHelper htmlHelper, IActionItem item)
        {
            string title = IconOnly ? string.Empty : (item.Title ?? string.Empty);
            string iconHtml = item.Icon.IsEmpty
                ? string.Empty
                : HtmlLayoutExtensions.IconBuilder(htmlHelper, item.Icon).ToString() ?? string.Empty;

            string disabledCss = item.Disabled ? " disabled" : string.Empty;
            string activeCss = item.Active ? " active" : string.Empty;
            string textColorCss = BuildTextColorCss(item);
            string extraAttributes = BuildAdditionalAttributes(item);

            switch (item)
            {
                case UrlActionItem url:
                    return $"""
                            <li class="nav-item">
                                <a class="nav-link d-inline-flex gap-1 {activeCss}{disabledCss}{textColorCss}" href="{WebUtility.HtmlEncode(url.Url ?? "#")}"{GetTargetAttribute(url)}{GetRelAttribute(url)}{GetAriaDisabledAttribute(item)}{extraAttributes}>
                                    {iconHtml}{WebUtility.HtmlEncode(title)}
                                </a>
                            </li>
                            """;

                case AspRouteActionItem route:
                    return $"""
                            <li class="nav-item">
                                <a class="nav-link d-inline-flex gap-1 {activeCss}{disabledCss}{textColorCss}" href="{WebUtility.HtmlEncode(BuildAspRouteUrl(htmlHelper, route))}"{GetAriaDisabledAttribute(item)}{extraAttributes}>
                                    {iconHtml}{WebUtility.HtmlEncode(title)}
                                </a>
                            </li>
                            """;

                case JavaScriptActionItem js:
                    return $"""
                            <li class="nav-item">
                                <button type="button" class="nav-link d-inline-flex gap-1 btn btn-link text-decoration-none{activeCss}{disabledCss}{textColorCss}" onclick="{HtmlEncoder.Default.Encode(js.JavaScript ?? string.Empty)}"{GetDisabledAttribute(item)}{extraAttributes}>
                                    {iconHtml}{WebUtility.HtmlEncode(title)}
                                </button>
                            </li>
                            """;

                case ModalActionItem modal:
                    return $"""
                            <li class="nav-item">
                                <button type="button" class="nav-link d-inline-flex gap-1 btn btn-link text-decoration-none{activeCss}{disabledCss}{textColorCss}" data-bs-toggle="modal" data-bs-target="#{WebUtility.HtmlEncode(modal.ModalTargetId ?? string.Empty)}"{GetDisabledAttribute(item)}{extraAttributes}>
                                    {iconHtml}{WebUtility.HtmlEncode(title)}
                                </button>
                            </li>
                            """;

                case DismissModalActionItem:
                    return $"""
                            <li class="nav-item">
                                <button type="button" class="nav-link d-inline-flex gap-1 btn btn-link text-decoration-none{activeCss}{disabledCss}{textColorCss}" data-bs-dismiss="modal"{GetDisabledAttribute(item)}{extraAttributes}>
                                    {iconHtml}{WebUtility.HtmlEncode(title)}
                                </button>
                            </li>
                            """;

                case ClipboardActionItem clipboard:
                    return RenderNavbarClipboardItem(htmlHelper, clipboard, iconHtml, title, activeCss, disabledCss, textColorCss);

                default:
                    return $"""
                            <li class="nav-item">
                                <span class="nav-link d-inline-flex gap-1 {activeCss}{disabledCss}{textColorCss}"{extraAttributes}>
                                    {iconHtml}{WebUtility.HtmlEncode(title)}
                                </span>
                            </li>
                            """;
            }
        }

        private string RenderNavRootItem(IHtmlHelper htmlHelper, IActionItem item)
        {
            if (item is DividerActionItem)
            {
                return string.Empty;
            }

            if (item is IActionContainerItem container && container.HasChildren)
            {
                return RenderNavbarDropdown(htmlHelper, item, container);
            }

            return RenderNavbarSingleItem(htmlHelper, item);
        }

        /// <summary>
        ///     Configures align items on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="alignItems">The align items value.</param>
        /// <returns>The configured <see cref="NavLinksComponent" /> value or BootstrapBuilder result.</returns>
        public NavLinksComponent WithAlignItems(AlignItems alignItems)
        {
            AlignItems = alignItems;
            return this;
        }

        /// <summary>
        ///     Configures dropdown align on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="dropdownAlign">The dropdown align value.</param>
        /// <returns>The configured <see cref="NavLinksComponent" /> value or BootstrapBuilder result.</returns>
        public NavLinksComponent WithDropdownAlign(NavbarDropdownAlign dropdownAlign)
        {
            DropdownAlign = dropdownAlign;
            return this;
        }

        /// <summary>
        ///     Configures dropdown layout on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="dropdownLayout">The dropdown layout value.</param>
        /// <returns>The configured <see cref="NavLinksComponent" /> value or BootstrapBuilder result.</returns>
        public NavLinksComponent WithDropdownLayout(NavbarDropdownLayout dropdownLayout)
        {
            DropdownLayout = dropdownLayout;
            return this;
        }

        /// <summary>
        ///     Configures justify on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="justify">The justify value.</param>
        /// <returns>The configured <see cref="NavLinksComponent" /> value or BootstrapBuilder result.</returns>
        public NavLinksComponent WithJustify(JustifyContent justify)
        {
            Justify = justify;
            return this;
        }

        #endregion

        #region Nested type: DropdownRenderResult

        private sealed class DropdownRenderResult
        {
            #region Instance fields and properties

            /// <summary>
            ///     Gets or sets the column count value used by BootstrapBuilder rendering or composition.
            /// </summary>
            public int ColumnCount { get; set; } = 1;

            /// <summary>
            ///     Gets or sets the html value used by BootstrapBuilder rendering or composition.
            /// </summary>
            public string Html { get; set; } = string.Empty;

            #endregion
        }

        #endregion
    }
}