#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Globalization;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Builds a Bootstrap pagination navigation from PageBuilder action items.
    /// </summary>
    /// <remarks>
    ///     Use <see cref="SetPageWindow" /> for standard page navigation, or compose the control manually with
    ///     <see cref="SetFirstAction" />, <see cref="SetPreviousAction" />, <see cref="AddPageAction" />,
    ///     <see cref="AddGap" />, <see cref="SetNextAction" />, and <see cref="SetLastAction" />.
    /// </remarks>
    public sealed class PaginationBuilder :
        HtmlBuilderBase<PaginationBuilder>,
        ICanUseMargin,
        ICanUsePadding,
        ICanUseCustomClasses
    {
        #region Nested types

        private sealed class PaginationPageEntry
        {
            public IActionItem? Action { get; init; }

            public bool Gap { get; init; }

            public string? GapText { get; init; }

            public int? PageNumber { get; init; }
        }

        #endregion

        #region Instance fields and properties

        private IActionItem? _firstAction;

        private IActionItem? _lastAction;

        private IActionItem? _nextAction;

        private readonly List<PaginationPageEntry> _pageEntries;

        private IActionItem? _previousAction;

        private string? _emptyText
        {
            get => GetInternal<string?>("_emptyText", null);
            set => SetInternal("_emptyText", value);
        }

        private string? _errorText
        {
            get => GetInternal<string?>("_errorText", null);
            set => SetInternal("_errorText", value);
        }

        private string _gapText
        {
            get => GetInternal("_gapText", "...");
            set => SetInternal("_gapText", value);
        }

        private BoostrapButtonSize _size
        {
            get => GetInternal("_size", BoostrapButtonSize.Medium);
            set => SetInternal("_size", value);
        }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PaginationBuilder" /> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public PaginationBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _pageEntries = new List<PaginationPageEntry>();
            _tag = "nav";
            _classesOfComponent.Add("dmb-pagination-nav");
            SetAria("label", "Pagination");
            SetData("pagination", "true");
        }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Adds a visual gap between page links.
        /// </summary>
        /// <param name="text">The optional gap text. When omitted, the builder-level gap text is used.</param>
        /// <returns>The configured <see cref="PaginationBuilder" /> value or BootstrapBuilder result.</returns>
        public PaginationBuilder AddGap(string? text = null)
        {
            _pageEntries.Add(new PaginationPageEntry
            {
                Gap = true,
                GapText = text
            });

            return This();
        }

        /// <summary>
        ///     Adds one numbered page action to the pagination window.
        /// </summary>
        /// <param name="pageNumber">The page number represented by the action.</param>
        /// <param name="actionItem">The action item used to navigate to the page.</param>
        /// <returns>The configured <see cref="PaginationBuilder" /> value or BootstrapBuilder result.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="pageNumber" /> is less than one.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="actionItem" /> is <see langword="null" />.</exception>
        public PaginationBuilder AddPageAction(int pageNumber, IActionItem actionItem)
        {
            if (pageNumber < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be greater than zero.");
            }

            ArgumentNullException.ThrowIfNull(actionItem);

            _pageEntries.Add(new PaginationPageEntry
            {
                Action = actionItem,
                PageNumber = pageNumber
            });

            return This();
        }

        /// <summary>
        ///     Removes every numbered page action and visual gap from the pagination window.
        /// </summary>
        /// <returns>The configured <see cref="PaginationBuilder" /> value or BootstrapBuilder result.</returns>
        public PaginationBuilder ClearPageActions()
        {
            _pageEntries.Clear();
            return This();
        }

        /// <inheritdoc />
        protected override PaginationBuilder CreateInstance()
        {
            return new PaginationBuilder(_textWriter, _htmlHelper);
        }

        /// <inheritdoc />
        protected override void InternalClone(PaginationBuilder source)
        {
            base.InternalClone(source);

            _firstAction = source._firstAction;
            _previousAction = source._previousAction;
            _nextAction = source._nextAction;
            _lastAction = source._lastAction;
            _pageEntries.Clear();
            _pageEntries.AddRange(source._pageEntries);
            _gapText = source._gapText;
            _emptyText = source._emptyText;
            _errorText = source._errorText;
            _size = source._size;
        }

        /// <summary>
        ///     Configures the text rendered when no pagination action is available.
        /// </summary>
        /// <param name="emptyText">The empty-state text, or <see langword="null" /> to render nothing when empty.</param>
        /// <returns>The configured <see cref="PaginationBuilder" /> value or BootstrapBuilder result.</returns>
        public PaginationBuilder SetEmptyText(string? emptyText)
        {
            _emptyText = emptyText;
            return This();
        }

        /// <summary>
        ///     Configures the error-state text rendered instead of pagination actions.
        /// </summary>
        /// <param name="errorText">The error-state text, or <see langword="null" /> to clear the error state.</param>
        /// <returns>The configured <see cref="PaginationBuilder" /> value or BootstrapBuilder result.</returns>
        public PaginationBuilder SetErrorText(string? errorText)
        {
            _errorText = errorText;
            return This();
        }

        /// <summary>
        ///     Configures the action that navigates to the first page.
        /// </summary>
        /// <param name="actionItem">The action item, or <see langword="null" /> to remove the control.</param>
        /// <returns>The configured <see cref="PaginationBuilder" /> value or BootstrapBuilder result.</returns>
        public PaginationBuilder SetFirstAction(IActionItem? actionItem)
        {
            _firstAction = actionItem;
            return This();
        }

        /// <summary>
        ///     Configures the text used by visual gap items.
        /// </summary>
        /// <param name="gapText">The gap text. Empty values fall back to three periods.</param>
        /// <returns>The configured <see cref="PaginationBuilder" /> value or BootstrapBuilder result.</returns>
        public PaginationBuilder SetGapText(string? gapText)
        {
            _gapText = string.IsNullOrWhiteSpace(gapText) ? "..." : gapText;
            return This();
        }

        /// <summary>
        ///     Configures the action that navigates to the last page.
        /// </summary>
        /// <param name="actionItem">The action item, or <see langword="null" /> to remove the control.</param>
        /// <returns>The configured <see cref="PaginationBuilder" /> value or BootstrapBuilder result.</returns>
        public PaginationBuilder SetLastAction(IActionItem? actionItem)
        {
            _lastAction = actionItem;
            return This();
        }

        /// <summary>
        ///     Configures the action that navigates to the next page.
        /// </summary>
        /// <param name="actionItem">The action item, or <see langword="null" /> to remove the control.</param>
        /// <returns>The configured <see cref="PaginationBuilder" /> value or BootstrapBuilder result.</returns>
        public PaginationBuilder SetNextAction(IActionItem? actionItem)
        {
            _nextAction = actionItem;
            return This();
        }

        /// <summary>
        ///     Configures a complete pagination window from the current page, total pages, and page action factory.
        /// </summary>
        /// <param name="currentPage">The current one-based page number.</param>
        /// <param name="totalPages">The total number of pages.</param>
        /// <param name="pageActionFactory">The factory that creates an action item for a one-based page number.</param>
        /// <param name="surroundingPageCount">The number of page links kept on each side of the current page.</param>
        /// <returns>The configured <see cref="PaginationBuilder" /> value or BootstrapBuilder result.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="pageActionFactory" /> is <see langword="null" />.</exception>
        public PaginationBuilder SetPageWindow(
            int currentPage,
            int totalPages,
            Func<int, IActionItem> pageActionFactory,
            int surroundingPageCount = 2
        )
        {
            ArgumentNullException.ThrowIfNull(pageActionFactory);

            _errorText = null;
            _pageEntries.Clear();

            if (totalPages < 1)
            {
                _firstAction = null;
                _previousAction = null;
                _nextAction = null;
                _lastAction = null;
                return This();
            }

            int normalizedCurrentPage = Math.Clamp(currentPage, 1, totalPages);
            int normalizedSurroundingPageCount = Math.Max(0, surroundingPageCount);

            _firstAction = CreateControlAction(
                pageActionFactory,
                1,
                "",
                IconStruct.Bootstrap("bi-chevron-double-left"),
                normalizedCurrentPage == 1);

            _previousAction = CreateControlAction(
                pageActionFactory,
                Math.Max(1, normalizedCurrentPage - 1),
                "",
                IconStruct.Bootstrap("bi-chevron-left"),
                normalizedCurrentPage == 1);

            AddWindowPageActions(normalizedCurrentPage, totalPages, normalizedSurroundingPageCount, pageActionFactory);

            _nextAction = CreateControlAction(
                pageActionFactory,
                Math.Min(totalPages, normalizedCurrentPage + 1),
                "",
                IconStruct.Bootstrap("bi-chevron-right"),
                normalizedCurrentPage == totalPages);

            _lastAction = CreateControlAction(
                pageActionFactory,
                totalPages,
                "",
                IconStruct.Bootstrap("bi-chevron-double-right"),
                normalizedCurrentPage == totalPages);

            return This();
        }

        /// <summary>
        ///     Configures the action that navigates to the previous page.
        /// </summary>
        /// <param name="actionItem">The action item, or <see langword="null" /> to remove the control.</param>
        /// <returns>The configured <see cref="PaginationBuilder" /> value or BootstrapBuilder result.</returns>
        public PaginationBuilder SetPreviousAction(IActionItem? actionItem)
        {
            _previousAction = actionItem;
            return This();
        }

        /// <summary>
        ///     Configures the Bootstrap pagination size.
        /// </summary>
        /// <param name="size">The Bootstrap size to apply to the pagination list.</param>
        /// <returns>The configured <see cref="PaginationBuilder" /> value or BootstrapBuilder result.</returns>
        public PaginationBuilder SetSize(BoostrapButtonSize size)
        {
            _size = size;
            return This();
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            if (!HasRenderableContent())
            {
                return;
            }

            writer.Write($"<{GetTag()}{BuildAttributes()}>");
            writer.Write("<ul class=\"");
            writer.Write(WebUtility.HtmlEncode(BuildPaginationListClassValue()));
            writer.Write("\">");

            if (!string.IsNullOrWhiteSpace(_errorText))
            {
                WriteMessageItem(writer, _errorText, "text-danger");
            }
            else if (HasActionContent())
            {
                WriteControlItem(_firstAction, writer);
                WriteControlItem(_previousAction, writer);

                foreach (PaginationPageEntry entry in _pageEntries)
                {
                    if (entry.Gap)
                    {
                        WriteGapItem(entry.GapText, writer);
                    }
                    else
                    {
                        WritePageItem(entry.Action, writer, entry.PageNumber);
                    }
                }

                WriteControlItem(_nextAction, writer);
                WriteControlItem(_lastAction, writer);
            }
            else
            {
                WriteMessageItem(writer, _emptyText, "text-body-secondary");
            }

            writer.Write("</ul>");
            writer.Write($"</{GetTag()}>");
        }

        #endregion

        #region Private methods

        private void AddWindowPageActions(
            int currentPage,
            int totalPages,
            int surroundingPageCount,
            Func<int, IActionItem> pageActionFactory
        )
        {
            SortedSet<int> pages = new()
            {
                1,
                totalPages
            };

            int start = Math.Max(1, currentPage - surroundingPageCount);
            int end = Math.Min(totalPages, currentPage + surroundingPageCount);

            for (int pageNumber = start; pageNumber <= end; pageNumber++)
            {
                pages.Add(pageNumber);
            }

            int? previousPage = null;

            foreach (int pageNumber in pages)
            {
                if (previousPage.HasValue && pageNumber - previousPage.Value > 1)
                {
                    AddGap();
                }

                IActionItem action = pageActionFactory(pageNumber).Clone();
                if (string.IsNullOrWhiteSpace(action.Title))
                {
                    action.Title = pageNumber.ToString(CultureInfo.InvariantCulture);
                }

                if (pageNumber == currentPage)
                {
                    action.Active = true;
                }

                AddPageAction(pageNumber, action);
                previousPage = pageNumber;
            }
        }

        private string BuildAdditionalAttributes(IActionItem item)
        {
            if (item.HtmlAttributes.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder builder = new();

            foreach (KeyValuePair<string, string> attribute in item.HtmlAttributes)
            {
                if (string.IsNullOrWhiteSpace(attribute.Key) || string.IsNullOrWhiteSpace(attribute.Value))
                {
                    continue;
                }

                builder.Append(' ');
                builder.Append(HtmlEncoder.Default.Encode(attribute.Key));
                builder.Append("=\"");
                builder.Append(HtmlEncoder.Default.Encode(attribute.Value));
                builder.Append('"');
            }

            return builder.ToString();
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

            foreach (KeyValuePair<string, string> routeValue in item.RouteValues)
            {
                routeValues[routeValue.Key] = routeValue.Value;
            }

            UrlActionContext actionContext = new()
            {
                Action = item.AspAction,
                Controller = item.AspController,
                Values = routeValues
            };

            return urlHelper.Action(actionContext) ?? "#";
        }

        private string BuildLinkAttributes(IActionItem actionItem)
        {
            string additionalAttributes = BuildAdditionalAttributes(actionItem);

            return actionItem switch
            {
                UrlActionItem urlActionItem =>
                    $" href=\"{HtmlEncoder.Default.Encode(urlActionItem.Url ?? "#")}\"{additionalAttributes}{GetTargetAttribute(urlActionItem)}{GetRelAttribute(urlActionItem)}",
                AspRouteActionItem aspRouteActionItem =>
                    $" href=\"{HtmlEncoder.Default.Encode(BuildAspRouteUrl(aspRouteActionItem))}\"{additionalAttributes}",
                JavaScriptActionItem javaScriptActionItem =>
                    $" href=\"#\"{additionalAttributes}{GetOnClickAttribute(javaScriptActionItem)}",
                ModalActionItem modalActionItem =>
                    $" href=\"#\"{additionalAttributes} data-bs-toggle=\"modal\" data-bs-target=\"#{HtmlEncoder.Default.Encode(modalActionItem.ModalTargetId ?? string.Empty)}\"",
                _ => $" href=\"#\"{additionalAttributes}"
            };
        }

        private string BuildPaginationListClassValue()
        {
            List<string> classes = new()
            {
                "pagination",
                "mb-0"
            };

            string sizeCss = _size switch
            {
                BoostrapButtonSize.Small => "pagination-sm",
                BoostrapButtonSize.Large => "pagination-lg",
                _ => string.Empty
            };

            if (!string.IsNullOrWhiteSpace(sizeCss))
            {
                classes.Add(sizeCss);
            }

            return string.Join(" ", classes);
        }

        private static IActionItem CreateControlAction(
            Func<int, IActionItem> pageActionFactory,
            int pageNumber,
            string title,
            IconStruct icon,
            bool disabled
        )
        {
            IActionItem action = pageActionFactory(pageNumber).Clone();
            action.Title = title;
            action.Icon = icon;
            action.Disabled = disabled;
            return action;
        }

        private string GetActionContent(IActionItem actionItem, int? pageNumber)
        {
            string title = actionItem.Title ?? pageNumber?.ToString(CultureInfo.InvariantCulture) ?? string.Empty;
            string iconHtml = GetIconHtml(actionItem.Icon);
            string titleHtml = string.IsNullOrWhiteSpace(title)
                ? string.Empty
                : $"<span>{HtmlEncoder.Default.Encode(title)}</span>";

            if (string.IsNullOrWhiteSpace(iconHtml))
            {
                return string.IsNullOrWhiteSpace(titleHtml)
                    ? HtmlEncoder.Default.Encode(pageNumber?.ToString(CultureInfo.InvariantCulture) ?? string.Empty)
                    : titleHtml;
            }

            if (string.IsNullOrWhiteSpace(titleHtml))
            {
                return iconHtml;
            }

            return iconHtml + titleHtml;
        }

        private string GetIconHtml(IconStruct icon)
        {
            if (icon.IsEmpty)
            {
                return string.Empty;
            }

            using StringWriter writer = new();
            HtmlLayoutExtensions.IconBuilder(_htmlHelper, icon).WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        }

        private static string GetItemClassValue(IActionItem actionItem)
        {
            List<string> classes = new()
            {
                "page-item"
            };

            if (actionItem.Active)
            {
                classes.Add("active");
            }

            if (actionItem.Disabled)
            {
                classes.Add("disabled");
            }

            if (actionItem.DebugOnly)
            {
                classes.Add("theme-debug-only");
            }

            if (!string.IsNullOrWhiteSpace(actionItem.AdditionalClasses))
            {
                classes.Add(actionItem.AdditionalClasses);
            }

            return string.Join(" ", classes);
        }

        private static string GetRelAttribute(UrlActionItem actionItem)
        {
            return string.IsNullOrWhiteSpace(actionItem.Rel)
                ? string.Empty
                : $" rel=\"{HtmlEncoder.Default.Encode(actionItem.Rel)}\"";
        }

        private static string GetTargetAttribute(UrlActionItem actionItem)
        {
            return string.IsNullOrWhiteSpace(actionItem.Target)
                ? string.Empty
                : $" target=\"{HtmlEncoder.Default.Encode(actionItem.Target)}\"";
        }

        private static string GetOnClickAttribute(JavaScriptActionItem actionItem)
        {
            return string.IsNullOrWhiteSpace(actionItem.JavaScript)
                ? string.Empty
                : $" onclick=\"{HtmlEncoder.Default.Encode(actionItem.JavaScript)}\"";
        }

        private bool HasActionContent()
        {
            return _firstAction is not null
                   || _previousAction is not null
                   || _pageEntries.Count > 0
                   || _nextAction is not null
                   || _lastAction is not null;
        }

        private bool HasRenderableContent()
        {
            return !string.IsNullOrWhiteSpace(_errorText)
                   || HasActionContent()
                   || !string.IsNullOrWhiteSpace(_emptyText);
        }

        private void WriteControlItem(IActionItem? actionItem, TextWriter writer)
        {
            if (actionItem is null)
            {
                return;
            }

            WritePageItem(actionItem, writer, null);
        }

        private void WriteGapItem(string? text, TextWriter writer)
        {
            writer.Write("<li class=\"page-item disabled\" aria-hidden=\"true\"><span class=\"page-link\">");
            writer.Write(WebUtility.HtmlEncode(string.IsNullOrWhiteSpace(text) ? _gapText : text));
            writer.Write("</span></li>");
        }

        private void WriteMessageItem(TextWriter writer, string? text, string cssClass)
        {
            writer.Write("<li class=\"page-item disabled\"><span class=\"page-link ");
            writer.Write(WebUtility.HtmlEncode(cssClass));
            writer.Write("\">");
            writer.Write(WebUtility.HtmlEncode(text));
            writer.Write("</span></li>");
        }

        private void WritePageItem(IActionItem? actionItem, TextWriter writer, int? pageNumber)
        {
            if (actionItem is null)
            {
                return;
            }

            string itemClassValue = GetItemClassValue(actionItem);
            string ariaCurrent = actionItem.Active ? " aria-current=\"page\"" : string.Empty;
            string ariaDisabled = actionItem.Disabled ? " aria-disabled=\"true\"" : string.Empty;
            string title = actionItem.Title ?? pageNumber?.ToString(CultureInfo.InvariantCulture) ?? string.Empty;
            string ariaLabel = string.IsNullOrWhiteSpace(title)
                ? string.Empty
                : $" aria-label=\"{HtmlEncoder.Default.Encode(title)}\"";

            writer.Write("<li class=\"");
            writer.Write(WebUtility.HtmlEncode(itemClassValue));
            writer.Write("\"");
            writer.Write(ariaCurrent);
            writer.Write(">");

            if (actionItem.Disabled || actionItem.Active)
            {
                writer.Write("<span class=\"page-link d-inline-flex align-items-center gap-1\"");
                writer.Write(ariaDisabled);
                writer.Write(ariaLabel);
                writer.Write(">");
                writer.Write(GetActionContent(actionItem, pageNumber));
                writer.Write("</span>");
            }
            else
            {
                writer.Write("<a class=\"page-link d-inline-flex align-items-center gap-1\"");
                writer.Write(BuildLinkAttributes(actionItem));
                writer.Write(ariaLabel);
                writer.Write(">");
                writer.Write(GetActionContent(actionItem, pageNumber));
                writer.Write("</a>");
            }

            writer.Write("</li>");
        }

        #endregion
    }
}
