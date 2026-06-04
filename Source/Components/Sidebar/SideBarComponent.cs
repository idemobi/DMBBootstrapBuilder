#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
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
    ///     Represents the BootstrapBuilder side bar component component or support type.
    /// </summary>
    public sealed class SideBarComponent
    {
        #region Static methods

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

        private static string BuildChildrenContainerCss(SideBarRenderMode mode)
        {
            return mode == SideBarRenderMode.Sidebar
                ? "d-flex flex-column gap-1 ps-3 pe-0 mt-1"
                : "d-flex flex-column gap-1 ps-3 pe-0 mt-1";
        }

        private static string BuildGroupToggleCss(SideBarRenderMode mode)
        {
            return mode == SideBarRenderMode.Sidebar
                ? "btn btn-link nav-link text-start w-100 d-flex align-items-center justify-content-between gap-2 px-0"
                : "btn btn-link nav-link text-start w-100 d-flex align-items-center justify-content-between gap-2 px-0";
        }

        private static string BuildItemKey(string sectionTitle, string parentPath, IActionItem item)
        {
            string iconKey = item.Icon.IsEmpty ? string.Empty : item.Icon.ToString();
            return $"{sectionTitle}|{parentPath}|{item.Title}|{iconKey}";
        }

        private static string BuildLeafCss(SideBarRenderMode mode)
        {
            return mode == SideBarRenderMode.Sidebar
                ? "nav-link text-start d-flex align-items-center justify-content-between gap-2 px-0"
                : "nav-link text-start d-flex align-items-center justify-content-between gap-2 px-0";
        }

        private static string BuildToggleLabelCss(SideBarRenderMode mode)
        {
            return mode == SideBarRenderMode.Sidebar
                ? "nav-link mb-0 px-0"
                : "nav-link mb-0 px-0";
        }

        private static string ComputeShortHash(string value)
        {
            byte[] bytes = SHA1.HashData(Encoding.UTF8.GetBytes(value ?? string.Empty));
            return Convert.ToHexString(bytes).ToLowerInvariant()[..12];
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

        private static string GetIndentCss(int level, SideBarRenderMode mode)
        {
            return string.Empty;
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
                    <span class="badge rounded-pill text-bg-{styleCss} dmb-sidebar-item-badge">
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

        private readonly List<SideBarSectionComponent> _sections = new();

        /// <summary>
        ///     Gets or sets the additional classes value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string AdditionalClasses { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the auto expand active path value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool AutoExpandActivePath { get; set; } = true;

        /// <summary>
        ///     Gets or sets the expand groups by default value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool ExpandGroupsByDefault { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether content is enabled for BootstrapBuilder rendering.
        /// </summary>
        public bool HasContent => _sections.Any(x => x.HasContent);

        /// <summary>
        ///     Gets or sets the id value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string Id { get; set; } = "dmb_sidebar";

        /// <summary>
        ///     Gets or sets the local storage key value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string LocalStorageKey { get; set; } = "dmb.sidebar.state";

        /// <summary>
        ///     Gets or sets the remember expanded state value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool RememberExpandedState { get; set; } = true;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Adds section to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="section">The section value.</param>
        /// <returns>The configured <see cref="SideBarComponent" /> value or BootstrapBuilder result.</returns>
        public SideBarComponent AddSection(SideBarSectionComponent section)
        {
            if (section == null)
            {
                throw new ArgumentNullException(nameof(section));
            }

            _sections.Add(section);
            return this;
        }

        /// <summary>
        ///     Adds section to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <param name="items">The items value.</param>
        /// <returns>The configured <see cref="SideBarComponent" /> value or BootstrapBuilder result.</returns>
        public SideBarComponent AddSection(string? title, params IActionItem[] items)
        {
            var section = new SideBarSectionComponent(title);
            section.Add(items);
            return AddSection(section);
        }

        private string BuildRootCss(SideBarRenderMode mode)
        {
            return string.Join(
                " ",
                new[]
                {
                    mode == SideBarRenderMode.Sidebar
                        ? "dmb-sidebar d-flex flex-column gap-1"
                        : "dmb-sidebar-offcanvas d-flex flex-column gap-1",
                    AdditionalClasses
                }.Where(x => !string.IsNullOrWhiteSpace(x)));
        }

        /// <summary>
        ///     Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="SideBarComponent" /> value or BootstrapBuilder result.</returns>
        public SideBarComponent Clone()
        {
            var clone = new SideBarComponent
            {
                Id = Id,
                AdditionalClasses = AdditionalClasses,
                LocalStorageKey = LocalStorageKey,
                RememberExpandedState = RememberExpandedState,
                AutoExpandActivePath = AutoExpandActivePath,
                ExpandGroupsByDefault = ExpandGroupsByDefault
            };

            foreach (var section in _sections)
            {
                clone.AddSection(section.Clone());
            }

            return clone;
        }

        private string GetStableItemId(IActionItem item, string itemKey)
        {
            if (!string.IsNullOrWhiteSpace(item.Id))
            {
                return HtmlIdGenerator.CleanId(item.Id) ?? item.Id;
            }

            string hash = ComputeShortHash(itemKey);
            return $"dmb_sb_{hash}";
        }

        private bool HasActiveDescendant(IActionItem item)
        {
            if (item == null)
            {
                return false;
            }

            if (item.Active)
            {
                return true;
            }

            if (item is IGuardedActionItem guarded)
            {
                return HasActiveDescendant(guarded.InnerAction);
            }

            if (item is IActionContainerItem container && container.HasChildren)
            {
                foreach (var child in container.Items)
                {
                    if (HasActiveDescendant(child))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        ///     Renders value for the BootstrapBuilder output.
        /// </summary>
        /// <param name="htmlHelper">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The rendered HTML content for the BootstrapBuilder component.</returns>
        public IHtmlContent Render(IHtmlHelper htmlHelper)
        {
            return Render(htmlHelper, SideBarRenderMode.Sidebar);
        }

        private IHtmlContent Render(IHtmlHelper htmlHelper, SideBarRenderMode mode)
        {
            if (htmlHelper == null)
            {
                throw new ArgumentNullException(nameof(htmlHelper));
            }

            string rootCss = BuildRootCss(mode);

            var sectionsHtml = new List<string>();

            for (int index = 0; index < _sections.Count; index++)
            {
                string sectionHtml = RenderSection(htmlHelper, _sections[index], mode, index);
                if (!string.IsNullOrWhiteSpace(sectionHtml))
                {
                    sectionsHtml.Add(sectionHtml);
                }
            }

            string script = RememberExpandedState
                ? RenderStateScript()
                : string.Empty;

            return new HtmlString($"""
                                   <div id="{WebUtility.HtmlEncode(Id)}"
                                        class="{WebUtility.HtmlEncode(rootCss)}"
                                        data-sidebar-root="true"
                                        data-sidebar-storage-key="{WebUtility.HtmlEncode(LocalStorageKey)}"
                                        data-sidebar-auto-expand-active="{AutoExpandActivePath.ToString().ToLowerInvariant()}"
                                        data-sidebar-default-expanded="{ExpandGroupsByDefault.ToString().ToLowerInvariant()}">
                                       {string.Join(Environment.NewLine, sectionsHtml)}
                                   </div>
                                   {script}
                                   """);
        }

        private string RenderClipboardItem(
            IHtmlHelper htmlHelper,
            ClipboardActionItem item,
            string indentCss,
            SideBarRenderMode mode
        )
        {
            string startText = item.ClipboardStartText ?? item.Title ?? string.Empty;
            string endText = item.ClipboardEndText ?? string.Empty;
            string value = item.ClipboardValue ?? string.Empty;

            IconStruct startIcon = item.ClipboardStartIcon.IsEmpty ? item.Icon : item.ClipboardStartIcon;
            IconStruct endIcon = item.ClipboardEndIcon.IsEmpty ? startIcon : item.ClipboardEndIcon;

            string startIconHtml = startIcon.IsEmpty
                ? string.Empty
                : HtmlLayoutExtensions.IconBuilder(htmlHelper, startIcon).ToString() ?? string.Empty;
            string startIconContainerHtml = string.IsNullOrWhiteSpace(startIconHtml)
                ? string.Empty
                : $"""<span class="action-item-clipboard-icon dmb-sidebar-item-icon">{startIconHtml}</span>""";

            string endIconHtml = endIcon.IsEmpty
                ? string.Empty
                : HtmlLayoutExtensions.IconBuilder(htmlHelper, endIcon).ToString() ?? string.Empty;

            string badgeHtml = GetInlineBadgeHtml(item);

            return $"""
                    <button type="button"
                            class="btn btn-link {BuildLeafCss(mode)} {indentCss}"
                            data-copy="{EncodeAttribute(value)}"
                            data-copy-reset-ms="{item.ClipboardResetDelayMs}"
                            data-copy-text-start="{EncodeAttribute(startText)}"
                            data-copy-text-end="{EncodeAttribute(endText)}"
                            data-copy-icon-start-html="{EncodeAttribute(startIconHtml)}"
                            data-copy-icon-end-html="{EncodeAttribute(endIconHtml)}"
                            onclick="DMBActionItemClipboard(this)">
                        <span class="dmb-sidebar-item-main d-inline-flex align-items-center gap-2">
                            {startIconContainerHtml}
                            <span class="action-item-clipboard-text dmb-sidebar-item-label" title="{EncodeAttribute(startText)}">{HtmlEncoder.Default.Encode(startText)}</span>
                        </span>
                        {badgeHtml}
                    </button>
                    """;
        }

        private string RenderContainer(
            IHtmlHelper htmlHelper,
            IActionItem rootItem,
            IActionContainerItem container,
            SideBarRenderMode mode,
            string sectionTitle,
            string parentPath,
            int level
        )
        {
            string itemKey = BuildItemKey(sectionTitle, parentPath, rootItem);
            string collapseId = GetStableItemId(rootItem, itemKey);
            string indentCss = GetIndentCss(level, mode);

            string title = rootItem.Title ?? string.Empty;
            string iconHtml = rootItem.Icon.IsEmpty
                ? string.Empty
                : HtmlLayoutExtensions.IconBuilder(htmlHelper, rootItem.Icon).ToString() ?? string.Empty;
            string iconContainerHtml = string.IsNullOrWhiteSpace(iconHtml)
                ? string.Empty
                : $"""<span class="dmb-sidebar-item-icon">{iconHtml}</span>""";

            string badgeHtml = GetInlineBadgeHtml(rootItem);

            string activeData = HasActiveDescendant(rootItem) || rootItem.Active ? """ data-sidebar-has-active="true" """ : string.Empty;
            string parentChain = string.IsNullOrWhiteSpace(parentPath) ? title : $"{parentPath}/{title}";

            var childrenHtml = new List<string>();
            foreach (var child in container.Items)
            {
                string childHtml = RenderItem(htmlHelper, child, mode, sectionTitle, parentChain, level + 1);
                if (!string.IsNullOrWhiteSpace(childHtml))
                {
                    childrenHtml.Add(childHtml);
                }
            }

            return $"""
                    <div class="{indentCss}" data-sidebar-group="true">
                        <button type="button"
                                class="{BuildGroupToggleCss(mode)}"
                                data-bs-toggle="collapse"
                                data-bs-target="#{WebUtility.HtmlEncode(collapseId)}"
                                aria-expanded="false"
                                aria-controls="{WebUtility.HtmlEncode(collapseId)}"
                                data-sidebar-toggle="true"
                                data-sidebar-item-id="{WebUtility.HtmlEncode(collapseId)}"{activeData}>
                            <span class="dmb-sidebar-item-main d-inline-flex align-items-center gap-2">
                                {iconContainerHtml}
                                <span class="dmb-sidebar-item-label" title="{EncodeAttribute(title)}">{WebUtility.HtmlEncode(title)}</span>
                            </span>
                            <span class="dmb-sidebar-item-actions d-inline-flex align-items-center gap-2">
                                {badgeHtml}
                                <i class="bi-chevron-down sidebar-chevron"></i>
                            </span>
                        </button>

                        <div class="collapse" id="{WebUtility.HtmlEncode(collapseId)}" data-sidebar-collapse="true">
                            <div class="{BuildChildrenContainerCss(mode)}">
                                {string.Join(Environment.NewLine, childrenHtml)}
                            </div>
                        </div>
                    </div>
                    """;
        }

        /// <summary>
        ///     Renders for offcanvas for the BootstrapBuilder output.
        /// </summary>
        /// <param name="htmlHelper">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The rendered HTML content for the BootstrapBuilder component.</returns>
        public IHtmlContent RenderForOffcanvas(IHtmlHelper htmlHelper)
        {
            return Render(htmlHelper, SideBarRenderMode.Offcanvas);
        }

        private string RenderGroup(
            IHtmlHelper htmlHelper,
            GroupActionItem group,
            SideBarRenderMode mode,
            string sectionTitle,
            string parentPath,
            int level
        )
        {
            string itemKey = BuildItemKey(sectionTitle, parentPath, group);
            string collapseId = GetStableItemId(group, itemKey);
            string indentCss = GetIndentCss(level, mode);

            string title = group.Title ?? string.Empty;
            string iconHtml = group.Icon.IsEmpty
                ? string.Empty
                : HtmlLayoutExtensions.IconBuilder(htmlHelper, group.Icon).ToString() ?? string.Empty;
            string iconContainerHtml = string.IsNullOrWhiteSpace(iconHtml)
                ? string.Empty
                : $"""<span class="dmb-sidebar-item-icon">{iconHtml}</span>""";

            string subtitleHtml = string.IsNullOrWhiteSpace(group.Subtitle)
                ? string.Empty
                : $"""<div class="small text-body-secondary">{WebUtility.HtmlEncode(group.Subtitle)}</div>""";

            string badgeHtml = GetInlineBadgeHtml(group);

            string activeData = HasActiveDescendant(group) || group.Active ? """ data-sidebar-has-active="true" """ : string.Empty;
            string parentChain = string.IsNullOrWhiteSpace(parentPath) ? title : $"{parentPath}/{title}";

            var childrenHtml = new List<string>();
            foreach (var child in group.Items)
            {
                string childHtml = RenderItem(htmlHelper, child, mode, sectionTitle, parentChain, level + 1);
                if (!string.IsNullOrWhiteSpace(childHtml))
                {
                    childrenHtml.Add(childHtml);
                }
            }

            return $"""
                    <div class="{indentCss}" data-sidebar-group="true">
                        <button type="button"
                                class="{BuildGroupToggleCss(mode)}"
                                data-bs-toggle="collapse"
                                data-bs-target="#{WebUtility.HtmlEncode(collapseId)}"
                                aria-expanded="false"
                                aria-controls="{WebUtility.HtmlEncode(collapseId)}"
                                data-sidebar-toggle="true"
                                data-sidebar-item-id="{WebUtility.HtmlEncode(collapseId)}"{activeData}>
                            <span class="dmb-sidebar-item-main d-inline-flex align-items-center gap-2">
                                {iconContainerHtml}
                                <span class="dmb-sidebar-item-label" title="{EncodeAttribute(title)}">
                                    <span class="fw-semibold dmb-sidebar-item-label">{WebUtility.HtmlEncode(title)}</span>
                                    {subtitleHtml}
                                </span>
                            </span>
                            <span class="dmb-sidebar-item-actions d-inline-flex align-items-center gap-2">
                                {badgeHtml}
                                <i class="bi-chevron-down sidebar-chevron"></i>
                            </span>
                        </button>

                        <div class="collapse" id="{WebUtility.HtmlEncode(collapseId)}" data-sidebar-collapse="true">
                            <div class="{BuildChildrenContainerCss(mode)}">
                                {string.Join(Environment.NewLine, childrenHtml)}
                            </div>
                        </div>
                    </div>
                    """;
        }

        private string RenderItem(
            IHtmlHelper htmlHelper,
            IActionItem item,
            SideBarRenderMode mode,
            string sectionTitle,
            string parentPath,
            int level
        )
        {
            if (item == null)
            {
                return string.Empty;
            }

            if (item is DividerActionItem)
            {
                return level == 0
                    ? """<hr class="my-2">"""
                    : """<hr class="my-1 ms-3">""";
            }

            if (item is IGuardedActionItem guarded)
            {
                return RenderItem(htmlHelper, guarded.InnerAction, mode, sectionTitle, parentPath, level);
            }

            if (item is GroupActionItem group)
            {
                return RenderGroup(htmlHelper, group, mode, sectionTitle, parentPath, level);
            }

            if (item is IActionContainerItem container && container.HasChildren)
            {
                return RenderContainer(htmlHelper, item, container, mode, sectionTitle, parentPath, level);
            }

            if (item is ToggleActionItem toggle)
            {
                return RenderToggleItem(toggle, mode, level);
            }

            return RenderLeafItem(htmlHelper, item, mode, level);
        }

        private string RenderLeafItem(IHtmlHelper htmlHelper, IActionItem item, SideBarRenderMode mode, int level)
        {
            string indentCss = GetIndentCss(level, mode);

            string title = item.Title ?? string.Empty;
            string iconHtml = item.Icon.IsEmpty
                ? string.Empty
                : HtmlLayoutExtensions.IconBuilder(htmlHelper, item.Icon).ToString() ?? string.Empty;
            string iconContainerHtml = string.IsNullOrWhiteSpace(iconHtml)
                ? string.Empty
                : $"""<span class="dmb-sidebar-item-icon">{iconHtml}</span>""";

            string disabledCss = item.Disabled ? " disabled" : string.Empty;
            string activeCss = item.Active ? " active" : string.Empty;
            string badgeHtml = GetInlineBadgeHtml(item);
            string lineCss = $"{BuildLeafCss(mode)}{activeCss}{disabledCss}";

            string content = $"""
                              <span class="dmb-sidebar-item-main d-inline-flex align-items-center gap-2">
                                  {iconContainerHtml}
                                  <span class="dmb-sidebar-item-label" title="{EncodeAttribute(title)}">{WebUtility.HtmlEncode(title)}</span>
                              </span>
                              {badgeHtml}
                              """;

            switch (item)
            {
                case UrlActionItem url:
                    return $"""
                            <a class="{lineCss} {indentCss}"
                               href="{WebUtility.HtmlEncode(url.Url ?? "#")}"{GetTargetAttribute(url)}{GetRelAttribute(url)}{GetAriaDisabledAttribute(item)}>
                                {content}
                            </a>
                            """;

                case AspRouteActionItem route:
                    return $"""
                            <a class="{lineCss} {indentCss}"
                               href="{WebUtility.HtmlEncode(BuildAspRouteUrl(htmlHelper, route))}"{GetAriaDisabledAttribute(item)}>
                                {content}
                            </a>
                            """;

                case JavaScriptActionItem js:
                    return $"""
                            <button type="button"
                                    class="btn btn-link {lineCss} {indentCss}"
                                    onclick="{HtmlEncoder.Default.Encode(js.JavaScript ?? string.Empty)}"{GetDisabledAttribute(item)}>
                                {content}
                            </button>
                            """;

                case ModalActionItem modal:
                    return $"""
                            <button type="button"
                                    class="btn btn-link {lineCss} {indentCss}"
                                    data-bs-toggle="modal"
                                    data-bs-target="#{WebUtility.HtmlEncode(modal.ModalTargetId ?? string.Empty)}"{GetDisabledAttribute(item)}>
                                {content}
                            </button>
                            """;

                case DismissModalActionItem:
                    return $"""
                            <button type="button"
                                    class="btn btn-link {lineCss} {indentCss}"
                                    data-bs-dismiss="modal"{GetDisabledAttribute(item)}>
                                {content}
                            </button>
                            """;

                case ClipboardActionItem clipboard:
                    return RenderClipboardItem(htmlHelper, clipboard, indentCss, mode);

                default:
                    return $"""
                            <div class="{lineCss} {indentCss}">
                                {content}
                            </div>
                            """;
            }
        }

        private string RenderSection(IHtmlHelper htmlHelper, SideBarSectionComponent section, SideBarRenderMode mode, int sectionIndex)
        {
            var itemsHtml = new List<string>();

            foreach (var item in section.Items)
            {
                string itemHtml = RenderItem(
                    htmlHelper,
                    item,
                    mode,
                    section.Title ?? string.Empty,
                    parentPath: string.Empty,
                    level: 0);

                if (!string.IsNullOrWhiteSpace(itemHtml))
                {
                    itemsHtml.Add(itemHtml);
                }
            }

            if (itemsHtml.Count == 0)
            {
                return string.Empty;
            }

            if (string.IsNullOrWhiteSpace(section.Title))
            {
                return string.Join(Environment.NewLine, itemsHtml);
            }

            string sectionKey = $"{section.Title}|{sectionIndex}";
            string collapseId = $"dmb_sb_section_{ComputeShortHash(sectionKey)}";
            string title = section.Title ?? string.Empty;
            string activeData = section.Items.Any(HasActiveDescendant) ? """ data-sidebar-has-active="true" """ : string.Empty;
            string sectionCss = string.Join(
                " ",
                new[]
                {
                    "btn",
                    "btn-link",
                    "dmb-sidebar-section-toggle",
                    "d-flex",
                    "align-items-center",
                    "gap-2",
                    "mt-3",
                    "mb-2",
                    "p-0",
                    "w-100",
                    "text-start",
                    "text-decoration-none",
                    section.AdditionalClasses
                }.Where(x => !string.IsNullOrWhiteSpace(x)));

            return $"""
                    <div data-sidebar-section-container="true">
                        <button type="button"
                                class="{WebUtility.HtmlEncode(sectionCss)}"
                                data-bs-toggle="collapse"
                                data-bs-target="#{WebUtility.HtmlEncode(collapseId)}"
                                aria-expanded="true"
                                aria-controls="{WebUtility.HtmlEncode(collapseId)}"
                                data-sidebar-toggle="true"
                                data-sidebar-section="true"
                                data-sidebar-item-id="{WebUtility.HtmlEncode(collapseId)}"{activeData}>
                            <span class="fw-semibold fs-5 dmb-sidebar-section-title" title="{EncodeAttribute(title)}">{WebUtility.HtmlEncode(title)}</span>
                            <span class="flex-grow-1 border-top opacity-50"></span>
                            <i class="bi-chevron-down sidebar-chevron"></i>
                        </button>

                        <div class="collapse show" id="{WebUtility.HtmlEncode(collapseId)}" data-sidebar-collapse="true">
                            <div class="d-flex flex-column gap-1">
                                {string.Join(Environment.NewLine, itemsHtml)}
                            </div>
                        </div>
                    </div>
                    """;
        }

        private string RenderStateScript()
        {
            return $@"
<script>
(function() {{
    var root = document.getElementById('{JavaScriptEncoder.Default.Encode(Id)}');
    if (!root) return;

    var storageKey = root.dataset.sidebarStorageKey || '{JavaScriptEncoder.Default.Encode(LocalStorageKey)}';
    var autoExpandActive = (root.dataset.sidebarAutoExpandActive || 'true') === 'true';
    var defaultExpanded = (root.dataset.sidebarDefaultExpanded || 'false') === 'true';

    function loadState() {{
        try {{
            var raw = localStorage.getItem(storageKey);
            if (!raw) return {{}};
            return JSON.parse(raw) || {{}};
        }}
        catch {{
            return {{}};
        }}
    }}

    function saveState(state) {{
        try {{
            localStorage.setItem(storageKey, JSON.stringify(state));
        }}
        catch {{
        }}
    }}

    var state = loadState();
    var toggles = root.querySelectorAll('[data-sidebar-toggle=""true""]');

    toggles.forEach(function(toggle) {{
        var itemId = toggle.getAttribute('data-sidebar-item-id');
        var targetSelector = toggle.getAttribute('data-bs-target');
        if (!itemId || !targetSelector) return;

        var collapseEl = root.querySelector(targetSelector);
        if (!collapseEl) return;

        var shouldOpen = false;

        if (autoExpandActive && toggle.getAttribute('data-sidebar-has-active') === 'true') {{
            shouldOpen = true;
        }}
        else if (Object.prototype.hasOwnProperty.call(state, itemId)) {{
            shouldOpen = !!state[itemId];
        }}
        else {{
            shouldOpen = toggle.getAttribute('data-sidebar-section') === 'true' ? true : defaultExpanded;
        }}

        if (shouldOpen) {{
            collapseEl.classList.add('show');
            toggle.setAttribute('aria-expanded', 'true');
        }}
        else {{
            collapseEl.classList.remove('show');
            toggle.setAttribute('aria-expanded', 'false');
        }}

        collapseEl.addEventListener('shown.bs.collapse', function() {{
            state[itemId] = true;
            saveState(state);
            toggle.setAttribute('aria-expanded', 'true');
        }});

        collapseEl.addEventListener('hidden.bs.collapse', function() {{
            state[itemId] = false;
            saveState(state);
            toggle.setAttribute('aria-expanded', 'false');
        }});
    }});
}})();
</script>";
        }

        private string RenderToggleItem(ToggleActionItem item, SideBarRenderMode mode, int level)
        {
            string switchId = !string.IsNullOrWhiteSpace(item.Id)
                ? item.Id
                : $"sidebar_toggle_{Guid.NewGuid():N}";

            string indentCss = GetIndentCss(level, mode);
            string checkedAttribute = item.SwitchValue ? """ checked="checked" """ : string.Empty;
            string disabledAttribute = item.Disabled ? """ disabled="disabled" """ : string.Empty;
            string onchangeAttribute = string.IsNullOrWhiteSpace(item.SwitchJavaScript)
                ? string.Empty
                : $""" onchange="{HtmlEncoder.Default.Encode(item.SwitchJavaScript)}" """;

            string badgeHtml = GetInlineBadgeHtml(item);
            string switchStyleCss = BootstrapStyleHelper.GetSwitchStyleCss(item.Variant);

            return $"""
                    <div class="d-flex align-items-center justify-content-between gap-3 {indentCss}">
                        <div class="dmb-sidebar-item-main d-flex align-items-center gap-2 flex-grow-1">
                            <label class="{BuildToggleLabelCss(mode)} dmb-sidebar-item-label flex-grow-1" for="{WebUtility.HtmlEncode(switchId)}" title="{EncodeAttribute(item.Title)}">
                                {WebUtility.HtmlEncode(item.Title ?? string.Empty)}
                            </label>
                            {badgeHtml}
                        </div>
                        <div class="m-0 d-inline-flex align-items-center">
                            <input id="{WebUtility.HtmlEncode(switchId)}"
                                   class="form-check-input guarded-switch {WebUtility.HtmlEncode(switchStyleCss)}"
                                   type="checkbox"{checkedAttribute}{disabledAttribute}{onchangeAttribute}>
                        </div>
                    </div>
                    """;
        }

        /// <summary>
        ///     Configures auto expand active path on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="SideBarComponent" /> value or BootstrapBuilder result.</returns>
        public SideBarComponent WithAutoExpandActivePath(bool value = true)
        {
            AutoExpandActivePath = value;
            return this;
        }

        /// <summary>
        ///     Configures classes on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="classes">The classes value.</param>
        /// <returns>The configured <see cref="SideBarComponent" /> value or BootstrapBuilder result.</returns>
        public SideBarComponent WithClasses(string classes)
        {
            AdditionalClasses = classes ?? string.Empty;
            return this;
        }

        /// <summary>
        ///     Configures expand groups by default on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="SideBarComponent" /> value or BootstrapBuilder result.</returns>
        public SideBarComponent WithExpandGroupsByDefault(bool value = true)
        {
            ExpandGroupsByDefault = value;
            return this;
        }

        /// <summary>
        ///     Configures id on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="id">The id value.</param>
        /// <returns>The configured <see cref="SideBarComponent" /> value or BootstrapBuilder result.</returns>
        public SideBarComponent WithId(string id)
        {
            Id = HtmlIdGenerator.CleanId(id) ?? "dmb_sidebar";
            return this;
        }

        /// <summary>
        ///     Configures local storage key on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="key">The key value.</param>
        /// <returns>The configured <see cref="SideBarComponent" /> value or BootstrapBuilder result.</returns>
        public SideBarComponent WithLocalStorageKey(string key)
        {
            LocalStorageKey = string.IsNullOrWhiteSpace(key) ? "dmb.sidebar.state" : key.Trim();
            return this;
        }

        /// <summary>
        ///     Configures remember expanded state on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="SideBarComponent" /> value or BootstrapBuilder result.</returns>
        public SideBarComponent WithRememberExpandedState(bool value = true)
        {
            RememberExpandedState = value;
            return this;
        }

        #endregion
    }
}