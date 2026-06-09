#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Text;
using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the BootstrapBuilder button render component or support type.
    /// </summary>
    public sealed class ButtonRender : HtmlTagBuilder<ButtonRender>,
        ICanUseInteractive,
        ICanUseDebugOnly,
        ICanUseCustomClasses
    {
        #region Static fields and properties

        /// <summary>
        ///     Stores the gap icon value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public static string GapIcon = "gap-1";

        #endregion

        #region Instance fields and properties

        private readonly IActionItem _actionItem;

        private bool _noWrap
        {
            get => GetInternal("_noWrap", true);
            set => SetInternal("_noWrap", value);
        }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ButtonRender" /> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="actionItem">The action item value.</param>
        public ButtonRender(TextWriter writer, IHtmlHelper html, IActionItem actionItem)
            : base(writer, html)
        {
            _actionItem = actionItem ?? throw new ArgumentNullException(nameof(actionItem));

            if (!string.IsNullOrWhiteSpace(_actionItem.Id))
            {
                SetId(_actionItem.Id);
            }

            if (_actionItem.DebugOnly)
            {
                this.SetDebugOnly();
            }
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override ButtonRender CreateInstance()
        {
            return new ButtonRender(_textWriter, _htmlHelper, _actionItem);
        }

        /// <inheritdoc />
        protected override void InternalClone(ButtonRender source)
        {
            base.InternalClone(source);
            _noWrap = source._noWrap;
        }

        #region Main dispatch

        private IHtmlContent RenderAction(IActionItem item, bool applyId)
        {
            if (item is IGuardedActionItem guarded)
            {
                return RenderGuarded(guarded);
            }

            if (item is DividerActionItem)
            {
                return HtmlString.Empty;
            }

            if (item is ToggleActionItem toggle)
            {
                return RenderSwitchButton(toggle, applyId);
            }

            if (item is SplitActionItem split && split.HasChildren)
            {
                return RenderSplitDropdown(split, applyId);
            }

            if (item is GroupActionItem group)
            {
                return RenderGroupDropdown(group, applyId);
            }

            if (item is IActionContainerItem container && container.HasChildren)
            {
                return RenderContainerDropdown(item, container, applyId);
            }

            return RenderSingleAction(item, applyId);
        }

        #endregion

        /// <summary>
        ///     Configures nowrap on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="ButtonRender" /> value or BootstrapBuilder result.</returns>
        public ButtonRender WithNowrap(bool value = true)
        {
            _noWrap = value;
            return this;
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            RegisterRequiredAssets(_actionItem);
            RenderAction(_actionItem, applyId: true).WriteTo(writer, encoder);
        }

        #endregion

        #region Assets

        private void RegisterRequiredAssets(IActionItem item)
        {
            if (ContainsClipboardAction(item))
            {
                PageInformation page = PageRegistry.GetOrCreatePageInformation(_htmlHelper.ViewContext.HttpContext);
                page.SetScriptFile("/js/Clipboard.js");
            }
        }

        private static bool ContainsClipboardAction(IActionItem item)
        {
            if (item is ClipboardActionItem)
            {
                return true;
            }

            if (item is IGuardedActionItem guarded)
            {
                return ContainsClipboardAction(guarded.InnerAction);
            }

            if (item is SplitActionItem split)
            {
                if (ContainsClipboardAction(split.PrimaryAction))
                {
                    return true;
                }

                foreach (IActionItem child in split.Items)
                {
                    if (ContainsClipboardAction(child))
                    {
                        return true;
                    }
                }

                return false;
            }

            if (item is IActionContainerItem container)
            {
                foreach (IActionItem child in container.Items)
                {
                    if (ContainsClipboardAction(child))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        #endregion

        #region Single action rendering

        private IHtmlContent RenderSingleAction(IActionItem item, bool applyId)
        {
            string iconHtml = GetPrimaryIconHtml(item);
            string titleHtml = string.IsNullOrEmpty(item.Title) ? string.Empty : $"<span>{HtmlEncoder.Default.Encode(item.Title)}</span>";
            string badgeHtml = GetButtonBadgeHtml(item);
            string extraAttributes = BuildAdditionalAttributes(item);

            List<string> classParts = new()
            {
                "btn",
                item.Variant.GetBtnVariantCss(item.Outline),
                GetCommonCssFor(item)
            };

            if (!string.IsNullOrWhiteSpace(item.BadgeText))
            {
                classParts.Add("position-relative");
            }

            string classes = JoinClasses(classParts);
            string idAttribute = applyId ? GetActionItemIdAttribute(item) : string.Empty;
            string disabledAttribute = GetDisabledAttribute(item);
            string ariaDisabled = GetAriaDisabledAttribute(item);

            switch (item)
            {
                case UrlActionItem url:
                    return new HtmlString($"""
                                           <a href="{HtmlEncoder.Default.Encode(url.Url ?? "#")}"
                                              class="{classes} d-inline-flex {GapIcon}"{idAttribute}{extraAttributes}{GetTargetAttribute(url)}{GetRelAttribute(url)}{ariaDisabled}>
                                               {iconHtml}{titleHtml}{badgeHtml}
                                           </a>
                                           """);

                case JavaScriptActionItem js:
                    string buttonType = GetButtonType(item);
                    string onClickAttribute = string.IsNullOrWhiteSpace(js.JavaScript)
                        ? string.Empty
                        : $""" onclick="{HtmlEncoder.Default.Encode(js.JavaScript)}" """;
                    return new HtmlString($"""
                                           <button type="{buttonType}"
                                                   class="{classes} d-inline-flex {GapIcon}"{extraAttributes}{idAttribute}{disabledAttribute}{onClickAttribute}>
                                               {iconHtml}{titleHtml}{badgeHtml}
                                           </button>
                                           """);

                case AspRouteActionItem route:
                    return new HtmlString($"""
                                           <a href="{HtmlEncoder.Default.Encode(BuildAspRouteUrl(route))}"
                                              class="{classes} d-inline-flex {GapIcon}"{idAttribute}{extraAttributes}{ariaDisabled}>
                                               {iconHtml}{titleHtml}{badgeHtml}
                                           </a>
                                           """);

                case ModalActionItem modal:
                    return new HtmlString($"""
                                           <button type="button"
                                                   class="{classes} d-inline-flex {GapIcon}"{idAttribute}{extraAttributes}{disabledAttribute} data-bs-toggle="modal" data-bs-target="#{HtmlEncoder.Default.Encode(modal.ModalTargetId ?? string.Empty)}">
                                               {iconHtml}{titleHtml}{badgeHtml}
                                           </button>
                                           """);

                case DismissModalActionItem:
                    return new HtmlString($"""
                                           <button type="button" class="{classes} d-inline-flex {GapIcon}"{idAttribute}{extraAttributes} data-bs-dismiss="modal">
                                               {iconHtml}{titleHtml}{badgeHtml}
                                           </button>
                                           """);

                case ClipboardActionItem clipboard:
                    return RenderClipboardAction(clipboard, classes, idAttribute, disabledAttribute, badgeHtml);

                default:
                    return new HtmlString($"""
                                           <button type="button"
                                                   class="{classes} d-inline-flex {GapIcon}"{idAttribute}{extraAttributes}{disabledAttribute}>
                                               {iconHtml}{titleHtml}{badgeHtml}
                                           </button>
                                           """);
            }
        }

        private IHtmlContent RenderClipboardAction(
            ClipboardActionItem item,
            string classes,
            string idAttribute,
            string disabledAttribute,
            string badgeHtml
        )
        {
            string startText = item.ClipboardStartText ?? item.Title ?? string.Empty;
            string endText = item.ClipboardEndText ?? string.Empty;
            string value = item.ClipboardValue ?? string.Empty;
            string extraAttributes = BuildAdditionalAttributes(item);

            IconStruct startIcon = item.ClipboardStartIcon.IsEmpty ? item.Icon : item.ClipboardStartIcon;
            IconStruct endIcon = item.ClipboardEndIcon.IsEmpty ? startIcon : item.ClipboardEndIcon;

            string startIconHtml = RenderIconToString(startIcon);
            string endIconHtml = RenderIconToString(endIcon);

            string iconFinal = string.IsNullOrEmpty(startIconHtml) ? string.Empty : $"""<span class="action-item-clipboard-icon">{startIconHtml}</span>""";
            string textFinal = string.IsNullOrEmpty(startText) ? string.Empty : $"""<span class="action-item-clipboard-text">{HtmlEncoder.Default.Encode(startText)}</span>""";

            return new HtmlString($"""
                                   <button type="button"
                                           class="{classes} d-inline-flex {GapIcon}"
                                           {idAttribute}{disabledAttribute}
                                           {extraAttributes}
                                           data-copy="{EncodeAttribute(value)}"
                                           data-copy-reset-ms="{item.ClipboardResetDelayMs}"
                                           data-copy-text-start="{EncodeAttribute(startText)}"
                                           data-copy-text-end="{EncodeAttribute(endText)}"
                                           data-copy-icon-start-html="{EncodeAttribute(startIconHtml)}"
                                           data-copy-icon-end-html="{EncodeAttribute(endIconHtml)}"
                                           onclick="DMBActionItemClipboard(this)">
                                       {iconFinal}{textFinal}{badgeHtml}
                                   </button>
                                   """);
        }

        private IHtmlContent RenderSwitchButton(ToggleActionItem item, bool applyId)
        {
            string titleHtml = string.IsNullOrEmpty(item.Title) ? string.Empty : $"<span>{HtmlEncoder.Default.Encode(item.Title)}</span>";
            string iconHtml = GetPrimaryIconHtml(item);
            string badgeHtml = GetButtonBadgeHtml(item);
            string extraAttributes = BuildAdditionalAttributes(item);

            string switchId = !string.IsNullOrWhiteSpace(item.Id)
                ? item.Id
                : _htmlHelper.GenerateUniqueId("switch");

            string switchStyleCss = BootstrapStyleHelper.GetSwitchStyleCss(item.Variant);

            string classes = JoinClasses(
                "btn",
                item.Variant.GetBtnVariantCss(item.Outline),
                GetCommonCssFor(item));

            if (!string.IsNullOrWhiteSpace(item.BadgeText))
            {
                classes += " position-relative";
            }

            string checkedAttribute = item.SwitchValue ? """ checked="checked" """ : string.Empty;
            string onchangeAttribute = string.IsNullOrWhiteSpace(item.SwitchJavaScript)
                ? string.Empty
                : $""" onchange="{HtmlEncoder.Default.Encode(item.SwitchJavaScript)}" """;

            string idAttribute = applyId ? GetActionItemIdAttribute(item) : string.Empty;

            return new HtmlString($"""
                                   <div class="{classes}"{idAttribute}{extraAttributes}>
                                       <label for="{HtmlEncoder.Default.Encode(switchId)}" class="d-inline-flex {GapIcon}">
                                           {iconHtml}{titleHtml}{badgeHtml}
                                           <span class="form-check form-switch m-0 align-self-stretch">
                                               <input id="{HtmlEncoder.Default.Encode(switchId)}" class="form-check-input {switchStyleCss}" type="checkbox"{checkedAttribute}{onchangeAttribute}{GetDisabledAttribute(item)}>
                                           </span>
                                       </label>
                                   </div>
                                   """);
        }

        #endregion

        #region Dropdown rendering

        private IHtmlContent RenderContainerDropdown(IActionItem rootItem, IActionContainerItem container, bool applyId)
        {
            string dropdownId = !string.IsNullOrWhiteSpace(rootItem.Id)
                ? rootItem.Id
                : _htmlHelper.GenerateUniqueId("dropdown");

            string toggleId = $"{dropdownId}_toggle";

            string iconHtml = GetPrimaryIconHtml(rootItem);
            string titleHtml = string.IsNullOrEmpty(rootItem.Title) ? string.Empty : $"<span>{HtmlEncoder.Default.Encode(rootItem.Title)}</span>";
            string badgeHtml = GetButtonBadgeHtml(rootItem);
            string extraAttributes = BuildAdditionalAttributes(rootItem);

            string buttonClasses = JoinClasses(
                "btn",
                rootItem.Variant.GetBtnVariantCss(rootItem.Outline),
                GetCommonCssFor(rootItem),
                "dropdown-toggle");

            if (!string.IsNullOrWhiteSpace(rootItem.BadgeText))
            {
                buttonClasses += " position-relative";
            }

            List<string> itemsHtml = new();
            foreach (IActionItem child in container.Items)
            {
                itemsHtml.Add(RenderDropdownItem(child));
            }

            string idAttribute = applyId ? GetActionItemIdAttribute(rootItem) : string.Empty;
            string disabledAttribute = GetDisabledAttribute(rootItem);
            string wrapperCss = GetDropdownWrapperCss(rootItem);

            return new HtmlString($"""
                                   <div class="{wrapperCss} btn-group"{idAttribute}>
                                       <button id="{HtmlEncoder.Default.Encode(toggleId)}"
                                               type="button"
                                               class="{buttonClasses}"
                                               data-bs-toggle="dropdown"
                                               aria-expanded="false"{disabledAttribute}{extraAttributes}>
                                           <span class="d-inline-flex {GapIcon}">{iconHtml}{titleHtml}{badgeHtml}</span>
                                       </button>
                                       <ul class="dropdown-menu" aria-labelledby="{HtmlEncoder.Default.Encode(toggleId)}">
                                           {string.Join(Environment.NewLine, itemsHtml)}
                                       </ul>
                                   </div>
                                   """);
        }

        private IHtmlContent RenderGroupDropdown(GroupActionItem group, bool applyId)
        {
            return RenderContainerDropdown(group, group, applyId);
        }

        private IHtmlContent RenderSplitDropdown(SplitActionItem split, bool applyId)
        {
            string rootId = !string.IsNullOrWhiteSpace(split.Id)
                ? split.Id
                : _htmlHelper.GenerateUniqueId("splitdropdown");

            string actionId = $"{rootId}_action";
            string toggleId = $"{rootId}_toggle";
            string extraAttributes = BuildAdditionalAttributes(split);

            IActionItem primaryClone = split.PrimaryAction.Clone();
            primaryClone.Id = actionId;

            if (split.Disabled || primaryClone.Disabled)
            {
                primaryClone.Disabled = true;
            }

            using StringWriter writer = new();
            RenderAction(primaryClone, applyId: true).WriteTo(writer, HtmlEncoder.Default);
            string primaryHtml = writer.ToString();

            string toggleClasses = JoinClasses(
                "btn",
                split.Variant.GetBtnVariantCss(split.Outline),
                GetCommonCssFor(split),
                "dropdown-toggle",
                "dropdown-toggle-split");

            List<string> itemsHtml = new();
            foreach (IActionItem child in split.Items)
            {
                itemsHtml.Add(RenderDropdownItem(child));
            }

            string wrapperCss = GetDropdownWrapperCss(split, "btn-group");

            return new HtmlString($"""
                                   <div class="{wrapperCss}"{extraAttributes}>
                                       {primaryHtml}
                                       <button id="{HtmlEncoder.Default.Encode(toggleId)}"
                                               type="button"
                                               class="{toggleClasses}"
                                               data-bs-toggle="dropdown"
                                               aria-expanded="false"{GetDisabledAttribute(split)}>
                                           <span class="visually-hidden">Toggle Dropdown</span>
                                       </button>
                                       <ul class="dropdown-menu" aria-labelledby="{HtmlEncoder.Default.Encode(toggleId)}">
                                           {string.Join(Environment.NewLine, itemsHtml)}
                                       </ul>
                                   </div>
                                   """);
        }

        private string RenderDropdownItem(IActionItem item)
        {
            return RenderDropdownItem(item, false);
        }

        private string RenderDropdownItem(IActionItem item, bool indented)
        {
            if (item is DividerActionItem)
            {
                return RenderDropdownDivider();
            }

            if (item is GroupActionItem group)
            {
                return RenderDropdownGroup(group);
            }

            if (item is SplitActionItem split)
            {
                using StringWriter writer = new();
                RenderSplitDropdown(split, applyId: true).WriteTo(writer, HtmlEncoder.Default);

                return $"""
                        <li>
                            <div class="dropdown-item-text p-0">
                                {writer}
                            </div>
                        </li>
                        """;
            }

            if (item is ToggleActionItem toggle)
            {
                return RenderDropdownSwitchItem(toggle, indented);
            }

            if (item is IGuardedActionItem guarded)
            {
                return RenderDropdownItem(guarded.InnerAction, indented);
            }

            string titleHtml = string.IsNullOrEmpty(item.Title) ? string.Empty : $"<span>{HtmlEncoder.Default.Encode(item.Title)}</span>";
            string iconHtml = GetPrimaryIconHtml(item);
            string badgeHtml = GetInlineBadgeHtml(item);
            string extraAttributes = BuildAdditionalAttributes(item);

            string activeCss = item.Active ? " active" : string.Empty;
            string disabledCss = item.Disabled ? " disabled" : string.Empty;
            string textStyleCss = GetDropdownTextStyleCss(item);
            string innerIndentCss = indented ? " ps-4" : string.Empty;

            string itemCss = $"dropdown-item{activeCss}{disabledCss}";
            if (!string.IsNullOrWhiteSpace(textStyleCss))
            {
                itemCss += $" {textStyleCss}";
            }

            string innerContent = $"""
                                   <span class="d-flex align-items-center justify-content-between w-100">
                                       <span class="d-inline-flex align-items-center {GapIcon} {innerIndentCss}">
                                           {iconHtml}{titleHtml}
                                       </span>
                                       {badgeHtml}
                                   </span>
                                   """;

            switch (item)
            {
                case UrlActionItem url:
                    return $"""
                            <li>
                                <a class="{itemCss}" href="{HtmlEncoder.Default.Encode(url.Url ?? "#")}"{GetTargetAttribute(url)}{GetRelAttribute(url)}{extraAttributes}>
                                    {innerContent}
                                </a>
                            </li>
                            """;

                case JavaScriptActionItem js:
                    return $"""
                            <li>
                                <button type="button" class="{itemCss}" onclick="{HtmlEncoder.Default.Encode(js.JavaScript ?? string.Empty)}"{extraAttributes}>
                                    {innerContent}
                                </button>
                            </li>
                            """;

                case AspRouteActionItem route:
                    return $"""
                            <li>
                                <a class="{itemCss}" href="{HtmlEncoder.Default.Encode(BuildAspRouteUrl(route))}"{extraAttributes}>
                                    {innerContent}
                                </a>
                            </li>
                            """;

                case ModalActionItem modal:
                    return $"""
                            <li>
                                <button type="button"
                                        class="{itemCss}"
                                        data-bs-toggle="modal"
                                        data-bs-target="#{HtmlEncoder.Default.Encode(modal.ModalTargetId ?? string.Empty)}"{extraAttributes}>
                                    {innerContent}
                                </button>
                            </li>
                            """;

                case DismissModalActionItem:
                    return $"""
                            <li>
                                <button type="button"
                                        class="{itemCss}"
                                        data-bs-dismiss="modal">
                                    {innerContent}
                                </button>
                            </li>
                            """;

                case ClipboardActionItem clipboard:
                    return RenderDropdownClipboardItem(clipboard, itemCss, innerIndentCss, badgeHtml);

                default:
                    return $"""
                            <li>
                                <button type="button" class="{itemCss}">
                                    {innerContent}
                                </button>
                            </li>
                            """;
            }
        }

        private string RenderDropdownClipboardItem(ClipboardActionItem item, string itemCss, string innerIndentCss, string badgeHtml)
        {
            string startText = item.ClipboardStartText ?? item.Title ?? string.Empty;
            string endText = item.ClipboardEndText ?? string.Empty;
            string value = item.ClipboardValue ?? string.Empty;
            string extraAttributes = BuildAdditionalAttributes(item);

            IconStruct startIcon = item.ClipboardStartIcon.IsEmpty ? item.Icon : item.ClipboardStartIcon;
            IconStruct endIcon = item.ClipboardEndIcon.IsEmpty ? startIcon : item.ClipboardEndIcon;

            string startIconHtml = RenderIconToString(startIcon);
            string endIconHtml = RenderIconToString(endIcon);

            return $"""
                    <li>
                        <button type="button"
                                class="{itemCss}"
                                {extraAttributes}
                                data-copy="{EncodeAttribute(value)}"
                                data-copy-reset-ms="{item.ClipboardResetDelayMs}"
                                data-copy-text-start="{EncodeAttribute(startText)}"
                                data-copy-text-end="{EncodeAttribute(endText)}"
                                data-copy-icon-start-html="{EncodeAttribute(startIconHtml)}"
                                data-copy-icon-end-html="{EncodeAttribute(endIconHtml)}"
                                onclick="DMBActionItemClipboard(this)">
                            <span class="d-flex align-items-center justify-content-between w-100">
                                <span class="d-inline-flex align-items-center {GapIcon} {innerIndentCss}">
                                    <span class="action-item-clipboard-icon">{startIconHtml}</span>
                                    <span class="action-item-clipboard-text">{HtmlEncoder.Default.Encode(startText)}</span>
                                </span>
                                {badgeHtml}
                            </span>
                        </button>
                    </li>
                    """;
        }

        private string RenderDropdownDivider()
        {
            return """<li><hr class="dropdown-divider"></li>""";
        }

        private string RenderDropdownGroup(GroupActionItem group)
        {
            string iconHtml = GetPrimaryIconHtml(group);
            string titleHtml = string.IsNullOrEmpty(group.Title) ? string.Empty : $"<span>{HtmlEncoder.Default.Encode(group.Title)}</span>";
            string badgeHtml = GetInlineBadgeHtml(group);
            string titleVariantCss = GetDropdownTextStyleCss(group);
            string extraAttributes = BuildAdditionalAttributes(group);

            string subtitleHtml = string.IsNullOrWhiteSpace(group.Subtitle)
                ? string.Empty
                : $"""<div class="small text-body-secondary">{HtmlEncoder.Default.Encode(group.Subtitle)}</div>""";

            List<string> groupItemsHtml = new();

            foreach (IActionItem child in group.Items)
            {
                groupItemsHtml.Add(RenderDropdownItem(child, true));
            }

            string titleCss = "fw-semibold";
            if (!string.IsNullOrWhiteSpace(titleVariantCss))
            {
                titleCss += $" {titleVariantCss}";
            }

            return $"""
                    <li{extraAttributes}>
                        <div class="dropdown-item-text py-2">
                            <div class="d-flex align-items-start {GapIcon}">
                                <div class="flex-shrink-0">{iconHtml}</div>
                                <div class="flex-grow-1">
                                    <div class="d-inline-flex align-items-center justify-content-between {GapIcon}">
                                        <span class="{titleCss}">{titleHtml}</span>
                                        {badgeHtml}
                                    </div>
                                    {subtitleHtml}
                                </div>
                            </div>
                        </div>
                    </li>
                    {string.Join(Environment.NewLine, groupItemsHtml)}
                    """;
        }

        private string RenderDropdownSwitchItem(ToggleActionItem item, bool indented)
        {
            string switchId = !string.IsNullOrWhiteSpace(item.Id)
                ? item.Id
                : _htmlHelper.GenerateUniqueId("dropdown-switch");

            string iconHtml = GetPrimaryIconHtml(item);
            string titleHtml = string.IsNullOrEmpty(item.Title) ? string.Empty : $"<span>{HtmlEncoder.Default.Encode(item.Title)}</span>";
            string badgeHtml = GetInlineBadgeHtml(item);
            string extraAttributes = BuildAdditionalAttributes(item);

            string checkedAttribute = item.SwitchValue ? """ checked="checked" """ : string.Empty;
            string disabledAttribute = GetDisabledAttribute(item);
            string onchangeAttribute = string.IsNullOrWhiteSpace(item.SwitchJavaScript)
                ? string.Empty
                : $""" onchange="{HtmlEncoder.Default.Encode(item.SwitchJavaScript)}" """;

            string innerIndentCss = indented ? " ps-4" : string.Empty;
            string textStyleCss = GetDropdownTextStyleCss(item);
            string switchStyleCss = BootstrapStyleHelper.GetSwitchStyleCss(item.Variant);

            string containerCss = "dropdown-item-text";
            if (!string.IsNullOrWhiteSpace(textStyleCss))
            {
                containerCss += $" {textStyleCss}";
            }

            return $"""
                    <li>
                        <div class="{containerCss}">
                            <div class="d-flex align-items-center justify-content-between gap-3 {innerIndentCss}">
                                <div class="d-flex align-items-center gap-2 flex-grow-1">
                                    <label for="{HtmlEncoder.Default.Encode(switchId)}" class="d-inline-flex align-items-center {GapIcon}">
                                        {iconHtml}{titleHtml}
                                        <span class="form-check form-switch">
                                            <input id="{HtmlEncoder.Default.Encode(switchId)}" class="form-check-input {switchStyleCss}" type="checkbox"{checkedAttribute}{disabledAttribute}{onchangeAttribute}{extraAttributes}>
                                        </span>
                                    </label>
                                </div>
                                {badgeHtml}
                            </div>
                        </div>
                    </li>
                    """;
        }

        #endregion

        #region Guarded rendering

        private IHtmlContent RenderGuarded(IGuardedActionItem guarded)
        {
            string rootId = !string.IsNullOrWhiteSpace(guarded.Id)
                ? guarded.Id
                : _htmlHelper.GenerateUniqueId("guarded");

            string saltId = _htmlHelper.GenerateUniqueId("salt");
            string buttonId = $"{rootId}_button";
            string switchId = $"{rootId}_{saltId}_switch";
            string functionId = $"{rootId}_{saltId}_function";
            string extraAttributes = BuildAdditionalAttributes(guarded);

            string wrapperCss = guarded.RenderAsButtonGroup
                ? "btn-group"
                : "d-inline-flex align-items-stretch flex-wrap";

            string warningIconHtml = GetIconHtml(guarded.WarningIcon.IsEmpty ? guarded.Icon : guarded.WarningIcon);
            string warningTextHtml = HtmlEncoder.Default.Encode(guarded.WarningText ?? guarded.Title ?? string.Empty);
            string warningTextHtmlFinal = string.IsNullOrWhiteSpace(warningTextHtml) ? string.Empty : $"<span>{warningTextHtml}</span>";
            string switchTextHtml = HtmlEncoder.Default.Encode(guarded.SwitchText ?? string.Empty);
            string checkedAttribute = guarded.SwitchDefaultValue ? """ checked="checked" """ : string.Empty;
            string warningBadgeHtml = GetButtonBadgeHtml(guarded);

            string warningCss = BuildWarningContainerCss(guarded);
            string warningSwitchStyleCss = BootstrapStyleHelper.GetSwitchStyleCss(guarded.Variant);

            string actionButtonHtml = BuildGuardedActionButtonHtml(guarded, buttonId, !guarded.SwitchDefaultValue);

            bool isContainer = guarded.InnerAction is IActionContainerItem c && c.HasChildren;
            bool isSplit = guarded.InnerAction is SplitActionItem;

            string actionElementId = isSplit ? $"{buttonId}_action" : buttonId;
            string toggleElementId = isContainer ? $"{buttonId}_toggle" : string.Empty;

            return new HtmlString(@$"
<div id=""{rootId}"" class=""btn-group"" >
    <div class=""{warningCss} {GapIcon}"">
        {warningIconHtml}
        {warningTextHtmlFinal}
        {warningBadgeHtml}
        <span class=""form-check form-switch"">
            <input id=""{switchId}"" class=""form-check-input {warningSwitchStyleCss}"" type=""checkbox""{checkedAttribute}{extraAttributes}>
        </span>
        {(string.IsNullOrWhiteSpace(switchTextHtml) ? "" : $@"<label class="" "" for=""{switchId}"">{switchTextHtml}</label>")}
    </div>
    {actionButtonHtml}
</div>

<script>
(function() {{

    var switchElement = document.getElementById('{switchId}');
    var actionElement = document.getElementById('{actionElementId}');
    var toggleElement = '{toggleElementId}' ? document.getElementById('{toggleElementId}') : null;

    if (!switchElement || !actionElement) {{
        return;
    }}

    function setElementEnabledState(element, enabled) {{
        if (!element) {{
            return;
        }}

        if (element.tagName === 'BUTTON') {{
            if (enabled) {{
                element.disabled = false;
                element.removeAttribute('disabled');
                element.classList.remove('disabled');
            }}
            else {{
                element.disabled = true;
                element.setAttribute('disabled', 'disabled');
                element.classList.add('disabled');
            }}
        }}

        if (element.tagName === 'A') {{
            if (enabled) {{
                element.classList.remove('disabled');
                element.setAttribute('aria-disabled', 'false');

                if (element.dataset.guardHref) {{
                    element.setAttribute('href', element.dataset.guardHref);
                }}
            }}
            else {{
                element.classList.add('disabled');
                element.setAttribute('aria-disabled', 'true');
                element.setAttribute('href', '#');
            }}
        }}
    }}

    function {functionId}() {{
        var enabled = !!switchElement.checked;
        setElementEnabledState(actionElement, enabled);
        setElementEnabledState(toggleElement, enabled);
    }}

    switchElement.addEventListener('change', {functionId});
    {functionId}();

}})();
</script>");
        }

        private string BuildGuardedActionButtonHtml(IGuardedActionItem guarded, string buttonId, bool disabledByGuard)
        {
            IActionItem cloned;

            if (guarded.InnerAction is SplitActionItem split)
            {
                SplitActionItem splitClone = (SplitActionItem)split.Clone();
                splitClone.Id = buttonId;

                if (disabledByGuard || splitClone.Disabled)
                {
                    splitClone.Disabled = true;
                }

                splitClone.PrimaryAction.Id = buttonId;
                cloned = splitClone;
            }
            else
            {
                cloned = guarded.InnerAction.Clone();
                cloned.Id = buttonId;

                if (disabledByGuard || cloned.Disabled)
                {
                    cloned.Disabled = true;
                }
            }

            IHtmlContent rendered = new ButtonRender(_textWriter, _htmlHelper, cloned)
                .WithNowrap(_noWrap);

            using StringWriter writer = new();
            rendered.WriteTo(writer, HtmlEncoder.Default);
            string html = writer.ToString();

            string targetId = GetGuardedRenderedTargetId(cloned, buttonId);

            if (guarded.RenderAsButtonGroup)
            {
                html = AddClassToElementById(html, targetId, "align-items-center");
            }

            if (cloned is SplitActionItem splitAction)
            {
                IActionItem primary = splitAction.PrimaryAction;

                if (primary is UrlActionItem primaryUrl)
                {
                    string originalHref = HtmlEncoder.Default.Encode(primaryUrl.Url ?? "#");

                    if (disabledByGuard || primary.Disabled)
                    {
                        html = ReplaceHrefOnElementById(html, targetId, "#");
                    }

                    html = InjectAttributeIntoElementById(html, targetId, $""" data-guard-href="{originalHref}" """);
                }
                else if (primary is AspRouteActionItem primaryRoute)
                {
                    string originalHref = HtmlEncoder.Default.Encode(BuildAspRouteUrl(primaryRoute));

                    if (disabledByGuard || primary.Disabled)
                    {
                        html = ReplaceHrefOnElementById(html, targetId, "#");
                    }

                    html = InjectAttributeIntoElementById(html, targetId, $""" data-guard-href="{originalHref}" """);
                }

                return html;
            }

            if (cloned is UrlActionItem url)
            {
                string originalHref = HtmlEncoder.Default.Encode(url.Url ?? "#");

                if (disabledByGuard || cloned.Disabled)
                {
                    html = ReplaceHrefOnElementById(html, targetId, "#");
                }

                html = InjectAttributeIntoElementById(html, targetId, $""" data-guard-href="{originalHref}" """);
            }
            else if (cloned is AspRouteActionItem route)
            {
                string originalHref = HtmlEncoder.Default.Encode(BuildAspRouteUrl(route));

                if (disabledByGuard || cloned.Disabled)
                {
                    html = ReplaceHrefOnElementById(html, targetId, "#");
                }

                html = InjectAttributeIntoElementById(html, targetId, $""" data-guard-href="{originalHref}" """);
            }

            return html;
        }

        private string GetGuardedRenderedTargetId(IActionItem action, string baseId)
        {
            if (action is SplitActionItem)
            {
                return $"{baseId}_action";
            }

            if (action is IActionContainerItem container && container.HasChildren)
            {
                return $"{baseId}_toggle";
            }

            return baseId;
        }

        private string BuildWarningContainerCss(IGuardedActionItem guarded)
        {
            string roundedCss = guarded.RenderAsButtonGroup ? string.Empty : "rounded";

            return JoinClasses(
                "btn",
                guarded.Variant.GetBtnVariantCss(guarded.Outline),
                GetCommonCssFor(guarded),
                "d-inline-flex",
                "align-items-center",
                "gap-2",
                roundedCss);
        }

        #endregion

        #region Shared helpers

        private string BuildAdditionalAttributes(IActionItem item)
        {
            if (item?.HtmlAttributes == null || item.HtmlAttributes.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new();

            foreach (KeyValuePair<string, string> kvp in item.HtmlAttributes)
            {
                if (string.IsNullOrWhiteSpace(kvp.Key) || string.IsNullOrWhiteSpace(kvp.Value))
                {
                    continue;
                }

                sb.Append(' ');
                sb.Append(HtmlEncoder.Default.Encode(kvp.Key));
                sb.Append("=\"");
                sb.Append(HtmlEncoder.Default.Encode(kvp.Value));
                sb.Append('"');
            }

            return sb.ToString();
        }

        private string BuildAspRouteUrl(AspRouteActionItem item)
        {
            IUrlHelperFactory factory = _htmlHelper.ViewContext.HttpContext.RequestServices.GetRequiredService<IUrlHelperFactory>();
            IUrlHelper urlHelper = factory.GetUrlHelper(_htmlHelper.ViewContext);

            Dictionary<string, object?> routeValues = new();

            if (!string.IsNullOrWhiteSpace(item.AspArea))
            {
                routeValues["area"] = item.AspArea;
            }

            foreach (KeyValuePair<string, string> kvp in item.RouteValues)
            {
                routeValues[kvp.Key] = kvp.Value;
            }

            UrlActionContext actionContext = new()
            {
                Action = item.AspAction,
                Controller = item.AspController,
                Values = routeValues
            };

            return urlHelper.Action(actionContext) ?? "#";
        }

        private string GetButtonBadgeHtml(IActionItem item)
        {
            if (string.IsNullOrWhiteSpace(item.BadgeText))
            {
                return string.Empty;
            }

            string styleCss = item.BadgeStyle.ToString().ToLowerInvariant();
            string text = HtmlEncoder.Default.Encode(item.BadgeText);

            return $"""
                    <span class="badge rounded-pill text-bg-{styleCss} position-absolute top-0 start-100 translate-middle z-3">
                        {text}
                    </span>
                    """;
        }

        private string GetInlineBadgeHtml(IActionItem item)
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

        private string GetTargetAttribute(UrlActionItem item)
        {
            if (string.IsNullOrWhiteSpace(item.Target))
            {
                return string.Empty;
            }

            return $""" target="{HtmlEncoder.Default.Encode(item.Target)}" """;
        }

        private string GetRelAttribute(UrlActionItem item)
        {
            if (string.IsNullOrWhiteSpace(item.Rel))
            {
                return string.Empty;
            }

            return $""" rel="{HtmlEncoder.Default.Encode(item.Rel)}" """;
        }

        private string GetActionItemIdAttribute(IActionItem item)
        {
            if (string.IsNullOrWhiteSpace(item.Id))
            {
                return string.Empty;
            }

            return $""" id="{HtmlEncoder.Default.Encode(item.Id)}" """;
        }

        private string GetDisabledAttribute(IActionItem item)
        {
            return item.Disabled ? """ disabled="disabled" """ : string.Empty;
        }

        private string GetButtonType(IActionItem item)
        {
            if (item.HtmlAttributes.TryGetValue("type", out string? value) == true && !string.IsNullOrWhiteSpace(value))
            {
                return HtmlEncoder.Default.Encode(value);
            }

            return "button";
        }

        private string GetAriaDisabledAttribute(IActionItem item)
        {
            return item.Disabled ? """ aria-disabled="true" """ : """ aria-disabled="false" """;
        }

        private string GetCommonCssFor(IActionItem item)
        {
            List<string> classes = new();

            if (_noWrap)
            {
                classes.Add("text-nowrap");
            }

            string sizeCss = item.Size.GetBtnSizeCss();
            if (!string.IsNullOrWhiteSpace(sizeCss))
            {
                classes.Add(sizeCss);
            }

            if (item.Disabled)
            {
                classes.Add("disabled");
            }

            if (item.DebugOnly)
            {
                classes.Add("theme-debug-only");
            }

            if (!string.IsNullOrWhiteSpace(item.AdditionalClasses))
            {
                classes.Add(item.AdditionalClasses);
            }

            return JoinClasses(classes);
        }

        private string GetDropdownTextStyleCss(IActionItem item)
        {
            if (item.Active)
            {
                return string.Empty;
            }

            return GetDropdownVariantTextCss(item.Variant);
        }

        private string GetDropdownVariantTextCss(VariantStyle variant)
        {
            return variant switch
            {
                VariantStyle.Primary => "text-primary",
                VariantStyle.Secondary => "text-secondary",
                VariantStyle.Success => "text-success",
                VariantStyle.Warning => "text-warning",
                VariantStyle.Danger => "text-danger",
                VariantStyle.Info => "text-info",
                VariantStyle.Light => "text-light",
                VariantStyle.Dark => "text-dark",
                _ => string.Empty
            };
        }

        private string GetPrimaryIconHtml(IActionItem item)
        {
            return GetIconHtml(item.Icon);
        }

        private string GetIconHtml(IconStruct icon)
        {
            if (icon.IsEmpty)
            {
                return string.Empty;
            }

            return $"""<span>{RenderIconToString(icon)}</span>""";
        }

        private string RenderIconToString(IconStruct icon)
        {
            if (icon.IsEmpty)
            {
                return string.Empty;
            }

            using StringWriter writer = new();
            HtmlLayoutExtensions.IconBuilder(_htmlHelper, icon).WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        }

        private string GetDropdownWrapperCss(object item, params string[] baseClasses)
        {
            List<string> classes = new(baseClasses);

            string directionCss = GetDropdownDirectionCss(item);
            if (!string.IsNullOrWhiteSpace(directionCss))
            {
                classes.Add(directionCss);
            }

            return JoinClasses(classes);
        }

        private string GetDropdownDirectionCss(object item)
        {
            if (item is IDropdownDirectional directional)
            {
                return directional.DropdownDirection switch
                {
                    DropdownDirection.Centered => "dropdown-center",
                    DropdownDirection.Dropup => "dropup",
                    DropdownDirection.DropupCentered => "dropup dropup-center",
                    DropdownDirection.Dropend => "dropend",
                    DropdownDirection.Dropstart => "dropstart",
                    _ => string.Empty
                };
            }

            return string.Empty;
        }

        private static string EncodeAttribute(string? value)
        {
            return HtmlEncoder.Default.Encode(value ?? string.Empty);
        }

        private static string JoinClasses(params string[] values)
        {
            return string.Join(" ", values.Where(x => !string.IsNullOrWhiteSpace(x)));
        }

        private static string JoinClasses(IEnumerable<string> values)
        {
            return string.Join(" ", values.Where(x => !string.IsNullOrWhiteSpace(x)).Distinct(StringComparer.Ordinal));
        }

        private string AddClassToElementById(string html, string elementId, string cssClass)
        {
            if (string.IsNullOrWhiteSpace(elementId) || string.IsNullOrWhiteSpace(cssClass))
            {
                return html;
            }

            if (!TryGetTagBoundsById(html, elementId, out int tagStart, out int tagEnd))
            {
                return html;
            }

            string tag = html.Substring(tagStart, tagEnd - tagStart + 1);
            string classNeedle = "class=";
            int classIndex = tag.IndexOf(classNeedle, StringComparison.OrdinalIgnoreCase);

            if (classIndex >= 0)
            {
                int valueStart = classIndex + classNeedle.Length;
                int valueEnd = tag.IndexOf('"', valueStart);
                if (valueEnd > valueStart)
                {
                    string current = tag.Substring(valueStart, valueEnd - valueStart);
                    if (!current.Split(' ', StringSplitOptions.RemoveEmptyEntries).Contains(cssClass, StringComparer.Ordinal))
                    {
                        string updated = string.IsNullOrWhiteSpace(current) ? cssClass : $"{current} {cssClass}";
                        tag = tag.Substring(0, valueStart) + updated + tag.Substring(valueEnd);
                    }
                }
            }
            else
            {
                tag = tag.Insert(tag.Length - 1, $""" class="{cssClass}" """);
            }

            return html.Substring(0, tagStart) + tag + html.Substring(tagEnd + 1);
        }

        private string InjectAttributeIntoElementById(string html, string elementId, string attribute)
        {
            if (string.IsNullOrWhiteSpace(elementId) || string.IsNullOrWhiteSpace(attribute))
            {
                return html;
            }

            if (!TryGetTagBoundsById(html, elementId, out int tagStart, out int tagEnd))
            {
                return html;
            }

            string tag = html.Substring(tagStart, tagEnd - tagStart + 1);
            tag = tag.Insert(tag.Length - 1, attribute);

            return html.Substring(0, tagStart) + tag + html.Substring(tagEnd + 1);
        }

        private string ReplaceHrefOnElementById(string html, string elementId, string newHref)
        {
            if (string.IsNullOrWhiteSpace(elementId))
            {
                return html;
            }

            if (!TryGetTagBoundsById(html, elementId, out int tagStart, out int tagEnd))
            {
                return html;
            }

            string tag = html.Substring(tagStart, tagEnd - tagStart + 1);
            int hrefIndex = tag.IndexOf("href=", StringComparison.OrdinalIgnoreCase);
            if (hrefIndex < 0)
            {
                return html;
            }

            int valueStart = hrefIndex + 6;
            int valueEnd = tag.IndexOf('"', valueStart);
            if (valueEnd < 0)
            {
                return html;
            }

            tag = tag.Substring(0, valueStart) + newHref + tag.Substring(valueEnd);

            return html.Substring(0, tagStart) + tag + html.Substring(tagEnd + 1);
        }

        private bool TryGetTagBoundsById(string html, string elementId, out int tagStart, out int tagEnd)
        {
            tagStart = -1;
            tagEnd = -1;

            string idNeedle = $"id=\"{elementId}\"";
            int idIndex = html.IndexOf(idNeedle, StringComparison.Ordinal);
            if (idIndex < 0)
            {
                return false;
            }

            tagStart = html.LastIndexOf('<', idIndex);
            if (tagStart < 0)
            {
                return false;
            }

            tagEnd = html.IndexOf('>', idIndex);
            if (tagEnd < 0)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}