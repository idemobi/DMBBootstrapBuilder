#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using System.Collections.Generic;
using System.IO;
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
    ///     Represents the BootstrapBuilder nav offcanvas component component or support type.
    /// </summary>
    public sealed class NavOffcanvasComponent : NavbarComponentBase
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

        private readonly List<INavbarComponent> _components = new();
        private bool _isHidden = false;

        private readonly List<IActionItem> _items = new();
        private readonly List<SideBarComponent> _sidebars = new();

        /// <summary>
        ///     Gets or sets the id value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the placement value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public OffcanvasPlacement Placement { get; set; } = OffcanvasPlacement.End;

        /// <summary>
        ///     Gets or sets the title value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        ///     Gets or sets the toggle icon value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public IconStruct ToggleIcon { get; set; } = IconStruct.Bootstrap("bi-list");

        /// <summary>
        ///     Gets or sets the toggle outline value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool ToggleOutline { get; set; } = false;

        /// <summary>
        ///     Gets or sets the toggle size value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public BoostrapButtonSize ToggleSize { get; set; } = BoostrapButtonSize.Medium;

        /// <summary>
        ///     Gets or sets the toggle text value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string ToggleText { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the toggle variant value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public VariantStyle ToggleVariant { get; set; } = VariantStyle.Normal;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="NavOffcanvasComponent" /> class.
        /// </summary>
        /// <param name="id">The id value.</param>
        /// <param name="title">The title value.</param>
        public NavOffcanvasComponent(string id, string? title = null)
        {
            Id = HtmlIdGenerator.CleanId(id) ?? throw new ArgumentNullException(nameof(id));
            Title = title;
        }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Adds value to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="item">The item value.</param>
        /// <returns>The configured <see cref="NavOffcanvasComponent" /> value or BootstrapBuilder result.</returns>
        public NavOffcanvasComponent Add(IActionItem item)
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
        /// <returns>The configured <see cref="NavOffcanvasComponent" /> value or BootstrapBuilder result.</returns>
        public NavOffcanvasComponent Add(params IActionItem[] items)
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

        /// <summary>
        ///     Adds navbar component content to the current BootstrapBuilder offcanvas.
        /// </summary>
        /// <param name="component">The navbar component value.</param>
        /// <returns>The configured <see cref="NavOffcanvasComponent" /> value or BootstrapBuilder result.</returns>
        public NavOffcanvasComponent Add(INavbarComponent component)
        {
            if (component == null)
            {
                throw new ArgumentNullException(nameof(component));
            }

            _components.Add(component);
            return this;
        }

        /// <summary>
        ///     Adds navbar component content to the current BootstrapBuilder offcanvas.
        /// </summary>
        /// <param name="components">The navbar components to add.</param>
        /// <returns>The configured <see cref="NavOffcanvasComponent" /> value or BootstrapBuilder result.</returns>
        public NavOffcanvasComponent Add(params INavbarComponent[] components)
        {
            if (components == null)
            {
                return this;
            }

            foreach (INavbarComponent component in components.Where(x => x != null))
            {
                Add(component);
            }

            return this;
        }

        /// <summary>
        ///     Adds sidebar to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="sideBar">The side bar value.</param>
        /// <returns>The configured <see cref="NavOffcanvasComponent" /> value or BootstrapBuilder result.</returns>
        public NavOffcanvasComponent AddSidebar(SideBarComponent sideBar)
        {
            if (sideBar == null)
            {
                throw new ArgumentNullException(nameof(sideBar));
            }

            _sidebars.Add(sideBar);
            return this;
        }


        /// <summary>
        ///     Executes the BootstrapBuilder has actions operation.
        /// </summary>
        /// <returns>True when the requested BootstrapBuilder condition is active; otherwise, false.</returns>
        public bool HasActions()
        {
            return _items.Count > 0 || _sidebars.Count > 0;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder hide operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="NavOffcanvasComponent" /> value or BootstrapBuilder result.</returns>
        public NavOffcanvasComponent Hide(bool value = true)
        {
            _isHidden = value;
            return this;
        }

        /// <summary>
        ///     Renders value for the BootstrapBuilder output.
        /// </summary>
        /// <param name="htmlHelper">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The rendered HTML content for the BootstrapBuilder component.</returns>
        public override IHtmlContent Render(IHtmlHelper htmlHelper)
        {
            string disabled = string.Empty;
            if (_items.Count == 0 && _components.Count == 0 && _sidebars.Count == 0)
            {
                disabled = " disabled";
            }

            if (htmlHelper == null)
            {
                throw new ArgumentNullException(nameof(htmlHelper));
            }

            string placementCss = Placement == OffcanvasPlacement.Start
                ? "offcanvas-start"
                : "offcanvas-end";

            string opacityCss = _isHidden ? " opacity-0" : string.Empty;

            string iconHtml = HtmlLayoutExtensions
                .IconBuilder(htmlHelper, ToggleIcon)
                .ToString() ?? string.Empty;

            string buttonCss = BuildCommonCss(
                "btn",
                ToggleVariant.GetBtnVariantCss(ToggleOutline),
                ToggleSize.GetBtnSizeCss());

            var blocksHtml = new List<string>();

            foreach (INavbarComponent component in _components)
            {
                using var writer = new StringWriter();
                component.Render(htmlHelper).WriteTo(writer, HtmlEncoder.Default);
                string html = writer.ToString();

                if (!string.IsNullOrWhiteSpace(html))
                {
                    blocksHtml.Add(html);
                }
            }

            foreach (var item in _items)
            {
                string html = RenderOffcanvasItem(htmlHelper, item, 0);
                if (!string.IsNullOrWhiteSpace(html))
                {
                    blocksHtml.Add(html);
                }
            }

            foreach (var sidebar in _sidebars)
            {
                using var writer = new StringWriter();
                sidebar.RenderForOffcanvas(htmlHelper).WriteTo(writer, HtmlEncoder.Default);
                string html = writer.ToString();

                if (!string.IsNullOrWhiteSpace(html))
                {
                    blocksHtml.Add(html);
                }
            }

            return new HtmlString($"""
                                   <button class="border-0 btn-navbar {WebUtility.HtmlEncode(buttonCss)}{opacityCss}"
                                           type="button"
                                           data-bs-toggle="offcanvas"
                                           data-bs-target="#{WebUtility.HtmlEncode(Id)}"
                                           aria-controls="{WebUtility.HtmlEncode(Id)}" {disabled}>
                                       {iconHtml}{WebUtility.HtmlEncode(ToggleText)}
                                   </button>

                                   <div class="offcanvas {placementCss}{opacityCss}"
                                        tabindex="-1"
                                        id="{WebUtility.HtmlEncode(Id)}"
                                        aria-labelledby="{WebUtility.HtmlEncode(Id)}_label">

                                       <div class="offcanvas-header">
                                           <h5 class="offcanvas-title"
                                               id="{WebUtility.HtmlEncode(Id)}_label">
                                               {WebUtility.HtmlEncode(Title ?? string.Empty)}
                                           </h5>

                                           <button type="button"
                                                   class="btn-close"
                                                   data-bs-dismiss="offcanvas"
                                                   aria-label="Close">
                                           </button>
                                       </div>

                                       <div class="offcanvas-body">
                                           <nav class="d-flex flex-column gap-2">
                                               {string.Join(Environment.NewLine, blocksHtml)}
                                           </nav>
                                       </div>

                                   </div>
                                   """);
        }

        private string RenderOffcanvasClipboardItem(
            IHtmlHelper htmlHelper,
            ClipboardActionItem item,
            string indentCss,
            string textColorCss
        )
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

            string badgeHtml = GetInlineBadgeHtml(item);

            return $"""
                    <button type="button"
                            class="btn btn-link nav-link text-start d-flex align-items-center justify-content-between gap-2 px-0{textColorCss} {indentCss}"
                            {extraAttributes}
                            data-copy="{EncodeAttribute(value)}"
                            data-copy-reset-ms="{item.ClipboardResetDelayMs}"
                            data-copy-text-start="{EncodeAttribute(startText)}"
                            data-copy-text-end="{EncodeAttribute(endText)}"
                            data-copy-icon-start-html="{EncodeAttribute(startIconHtml)}"
                            data-copy-icon-end-html="{EncodeAttribute(endIconHtml)}"
                            onclick="DMBActionItemClipboard(this)">
                        <span class="d-inline-flex align-items-center gap-2">
                            <span class="action-item-clipboard-icon">{startIconHtml}</span>
                            <span class="action-item-clipboard-text">{HtmlEncoder.Default.Encode(startText)}</span>
                        </span>
                        {badgeHtml}
                    </button>
                    """;
        }

        private string RenderOffcanvasContainer(IHtmlHelper htmlHelper, IActionItem rootItem, IActionContainerItem container, int level)
        {
            string collapseId = $"{Id}_{Guid.NewGuid():N}";
            string indentCss = level > 0 ? $"ms-{Math.Min(level, 4)}" : string.Empty;

            string title = rootItem.Title ?? string.Empty;
            string iconHtml = rootItem.Icon.IsEmpty
                ? string.Empty
                : HtmlLayoutExtensions.IconBuilder(htmlHelper, rootItem.Icon).ToString() ?? string.Empty;

            string badgeHtml = GetInlineBadgeHtml(rootItem);
            string textColorCss = BuildTextColorCss(rootItem);
            string extraAttributes = BuildAdditionalAttributes(rootItem);

            var childrenHtml = new List<string>();
            foreach (var child in container.Items)
            {
                string childHtml = RenderOffcanvasItem(htmlHelper, child, level + 1);
                if (!string.IsNullOrWhiteSpace(childHtml))
                {
                    childrenHtml.Add(childHtml);
                }
            }

            return $"""
                    <div class="{indentCss}">
                        <button type="button"
                                class="btn btn-link nav-link text-start w-100 d-flex align-items-center justify-content-between gap-2 px-0{textColorCss}"
                                data-bs-toggle="collapse"
                                data-bs-target="#{WebUtility.HtmlEncode(collapseId)}"
                                aria-expanded="false"
                                aria-controls="{WebUtility.HtmlEncode(collapseId)}"{extraAttributes}>
                            <span class="d-inline-flex align-items-center gap-2">
                                {iconHtml}
                                <span>{WebUtility.HtmlEncode(title)}</span>
                            </span>
                            <span class="d-inline-flex align-items-center gap-2">
                                {badgeHtml}
                                <i class="bi-chevron-down navbar-chevron"></i>
                            </span>
                        </button>

                        <div class="collapse" id="{WebUtility.HtmlEncode(collapseId)}">
                            <div class="d-flex flex-column gap-1 ps-3 mt-1">
                                {string.Join(Environment.NewLine, childrenHtml)}
                            </div>
                        </div>
                    </div>
                    """;
        }

        private string RenderOffcanvasGroup(IHtmlHelper htmlHelper, GroupActionItem group, int level)
        {
            string collapseId = $"{Id}_{Guid.NewGuid():N}";
            string indentCss = level > 0 ? $"ms-{Math.Min(level, 4)}" : string.Empty;

            string title = group.Title ?? string.Empty;
            string iconHtml = group.Icon.IsEmpty
                ? string.Empty
                : HtmlLayoutExtensions.IconBuilder(htmlHelper, group.Icon).ToString() ?? string.Empty;

            string subtitleHtml = string.IsNullOrWhiteSpace(group.Subtitle)
                ? string.Empty
                : $"""<div class="small text-body-secondary">{WebUtility.HtmlEncode(group.Subtitle)}</div>""";

            string badgeHtml = GetInlineBadgeHtml(group);
            string textColorCss = BuildTextColorCss(group);
            string extraAttributes = BuildAdditionalAttributes(group);

            var childrenHtml = new List<string>();
            foreach (var child in group.Items)
            {
                string childHtml = RenderOffcanvasItem(htmlHelper, child, level + 1);
                if (!string.IsNullOrWhiteSpace(childHtml))
                {
                    childrenHtml.Add(childHtml);
                }
            }

            return $"""
                    <div class="{indentCss}">
                        <button type="button"
                                class="btn btn-link nav-link text-start w-100 d-flex align-items-center justify-content-between gap-2 px-0{textColorCss}"
                                data-bs-toggle="collapse"
                                data-bs-target="#{WebUtility.HtmlEncode(collapseId)}"
                                aria-expanded="false"
                                aria-controls="{WebUtility.HtmlEncode(collapseId)}"{extraAttributes}>
                            <span class="d-inline-flex align-items-center gap-2">
                                {iconHtml}
                                <span>
                                    <span class="fw-semibold">{WebUtility.HtmlEncode(title)}</span>
                                    {subtitleHtml}
                                </span>
                            </span>
                            <span class="d-inline-flex align-items-center gap-2">
                                {badgeHtml}
                                <i class="bi-chevron-down navbar-chevron"></i>
                            </span>
                        </button>

                        <div class="collapse" id="{WebUtility.HtmlEncode(collapseId)}">
                            <div class="d-flex flex-column gap-1 ps-3 mt-1">
                                {string.Join(Environment.NewLine, childrenHtml)}
                            </div>
                        </div>
                    </div>
                    """;
        }

        private string RenderOffcanvasItem(IHtmlHelper htmlHelper, IActionItem item, int level)
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
                return RenderOffcanvasItem(htmlHelper, guarded.InnerAction, level);
            }

            if (item is GroupActionItem group)
            {
                return RenderOffcanvasGroup(htmlHelper, group, level);
            }

            if (item is IActionContainerItem container && container.HasChildren)
            {
                return RenderOffcanvasContainer(htmlHelper, item, container, level);
            }

            if (item is ToggleActionItem toggle)
            {
                return RenderOffcanvasToggleItem(htmlHelper, toggle, level);
            }

            return RenderOffcanvasLeafItem(htmlHelper, item, level);
        }

        private string RenderOffcanvasLeafItem(IHtmlHelper htmlHelper, IActionItem item, int level)
        {
            string indentCss = level > 0 ? $"ms-{Math.Min(level, 4)}" : string.Empty;

            string title = item.Title ?? string.Empty;
            string iconHtml = item.Icon.IsEmpty
                ? string.Empty
                : HtmlLayoutExtensions.IconBuilder(htmlHelper, item.Icon).ToString() ?? string.Empty;

            string disabledCss = item.Disabled ? " disabled" : string.Empty;
            string activeCss = item.Active ? " active" : string.Empty;
            string textColorCss = BuildTextColorCss(item);
            string badgeHtml = GetInlineBadgeHtml(item);
            string extraAttributes = BuildAdditionalAttributes(item);
            string lineCss = $"nav-link text-start d-flex align-items-center justify-content-between gap-2 px-0{activeCss}{disabledCss}{textColorCss}";

            string content = $"""
                              <span class="d-inline-flex align-items-center gap-2">
                                  {iconHtml}
                                  <span>{WebUtility.HtmlEncode(title)}</span>
                              </span>
                              {badgeHtml}
                              """;

            switch (item)
            {
                case UrlActionItem url:
                    return $"""
                            <a class="{lineCss} {indentCss}"
                               href="{WebUtility.HtmlEncode(url.Url ?? "#")}"{GetTargetAttribute(url)}{GetRelAttribute(url)}{GetAriaDisabledAttribute(item)}{extraAttributes}>
                                {content}
                            </a>
                            """;

                case AspRouteActionItem route:
                    return $"""
                            <a class="{lineCss} {indentCss}"
                               href="{WebUtility.HtmlEncode(BuildAspRouteUrl(htmlHelper, route))}"{GetAriaDisabledAttribute(item)}{extraAttributes}>
                                {content}
                            </a>
                            """;

                case JavaScriptActionItem js:
                    return $"""
                            <button type="button"
                                    class="btn btn-link {lineCss} {indentCss}"
                                    onclick="{HtmlEncoder.Default.Encode(js.JavaScript ?? string.Empty)}"{GetDisabledAttribute(item)}{extraAttributes}>
                                {content}
                            </button>
                            """;

                case ModalActionItem modal:
                    return $"""
                            <button type="button"
                                    class="btn btn-link {lineCss} {indentCss}"
                                    data-bs-toggle="modal"
                                    data-bs-target="#{WebUtility.HtmlEncode(modal.ModalTargetId ?? string.Empty)}"{GetDisabledAttribute(item)}{extraAttributes}>
                                {content}
                            </button>
                            """;

                case DismissModalActionItem:
                    return $"""
                            <button type="button"
                                    class="btn btn-link {lineCss} {indentCss}"
                                    data-bs-dismiss="modal"{GetDisabledAttribute(item)}{extraAttributes}>
                                {content}
                            </button>
                            """;

                case ClipboardActionItem clipboard:
                    return RenderOffcanvasClipboardItem(htmlHelper, clipboard, indentCss, textColorCss);

                default:
                    return $"""
                            <div class="{lineCss} {indentCss}"{extraAttributes}>
                                {content}
                            </div>
                            """;
            }
        }

        private string RenderOffcanvasToggleItem(IHtmlHelper htmlHelper, ToggleActionItem item, int level)
        {
            string switchId = !string.IsNullOrWhiteSpace(item.Id)
                ? item.Id
                : $"offcanvas_toggle_{Guid.NewGuid():N}";
            string iconHtml = item.Icon.IsEmpty
                ? string.Empty
                : HtmlLayoutExtensions.IconBuilder(htmlHelper, item.Icon).ToString() ?? string.Empty;

            string indentCss = level > 0 ? $"ms-{Math.Min(level, 4)}" : string.Empty;
            string checkedAttribute = item.SwitchValue ? """ checked="checked" """ : string.Empty;
            string disabledAttribute = item.Disabled ? """ disabled="disabled" """ : string.Empty;
            string onchangeAttribute = string.IsNullOrWhiteSpace(item.SwitchJavaScript)
                ? string.Empty
                : $""" onchange="{HtmlEncoder.Default.Encode(item.SwitchJavaScript)}" """;

            string badgeHtml = GetInlineBadgeHtml(item);
            string switchStyleCss = BootstrapStyleHelper.GetSwitchStyleCss(item.Variant);
            string textColorCss = BuildTextColorCss(item);
            string extraAttributes = BuildAdditionalAttributes(item);

            return $"""
                    <div class="d-flex align-items-center justify-content-between gap-3 px-0 {indentCss}{textColorCss}">
                        <div class="d-flex align-items-center gap-2 flex-grow-1">
                        {iconHtml}
                         <label class="nav-link mb-0 px-0 flex-grow-1{textColorCss}" for="{WebUtility.HtmlEncode(switchId)}">
                                {WebUtility.HtmlEncode(item.Title ?? string.Empty)}
                            </label>
                            {badgeHtml}
                        </div>
                        <div class="m-0 d-inline-flex align-items-center form-check form-switch">
                            <input id="{WebUtility.HtmlEncode(switchId)}"
                                   class="form-check-input guarded-switch {WebUtility.HtmlEncode(switchStyleCss)}"
                                   type="checkbox"{checkedAttribute}{disabledAttribute}{onchangeAttribute}{extraAttributes}>
                        </div>
                    </div>
                    """;
        }

        /// <summary>
        ///     Configures placement on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="placement">The placement value.</param>
        /// <returns>The configured <see cref="NavOffcanvasComponent" /> value or BootstrapBuilder result.</returns>
        public NavOffcanvasComponent WithPlacement(OffcanvasPlacement placement)
        {
            Placement = placement;
            return this;
        }

        /// <summary>
        ///     Configures toggle outlined on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="NavOffcanvasComponent" /> value or BootstrapBuilder result.</returns>
        public NavOffcanvasComponent WithToggleOutlined(bool value = true)
        {
            ToggleOutline = value;
            return this;
        }

        /// <summary>
        ///     Configures toggle size on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <returns>The configured <see cref="NavOffcanvasComponent" /> value or BootstrapBuilder result.</returns>
        public NavOffcanvasComponent WithToggleSize(BoostrapButtonSize size)
        {
            ToggleSize = size;
            return this;
        }

        /// <summary>
        ///     Configures toggle variant on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="variant">The variant value.</param>
        /// <returns>The configured <see cref="NavOffcanvasComponent" /> value or BootstrapBuilder result.</returns>
        public NavOffcanvasComponent WithToggleVariant(VariantStyle variant)
        {
            ToggleVariant = variant;
            return this;
        }

        #endregion
    }
}