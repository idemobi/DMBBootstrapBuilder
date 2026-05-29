#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Net;
using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Builds and renders the BootstrapBuilder breadcrumb component or page region.
    /// </summary>
    public sealed class BreadcrumbBuilder :
        HtmlBuilderBase<BreadcrumbBuilder>,
        ICanUseMargin,
        ICanUsePadding,
        ICanUseBorder,
        ICanUseBorderRadius,
        ICanUseBreadcrumb
    {
        #region Instance fields and properties

        private int? _collapseAfter
        {
            get => GetInternal<int?>("_collapseAfter", null);
            set => SetInternal("_collapseAfter", value);
        }

        private BreadcrumbDisplayMode _displayMode
        {
            get => GetInternal("_displayMode", BreadcrumbDisplayMode.TitleOnly);
            set => SetInternal("_displayMode", value);
        }

        private readonly List<IActionItem> _items;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="BreadcrumbBuilder" /> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public BreadcrumbBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _items = new List<IActionItem>();
            _tag = "nav";
            _classesOfComponent.Add("breadcrumb-nav");
            SetAttribute("aria-label", "breadcrumb");
            SetData("breadcrumb", "true");
        }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Adds item to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="actionItem">The action item value.</param>
        /// <returns>The configured <see cref="BreadcrumbBuilder" /> value or BootstrapBuilder result.</returns>
        public BreadcrumbBuilder AddItem(IActionItem actionItem)
        {
            if (actionItem is not null)
            {
                _items.Add(actionItem);
            }

            return This();
        }

        /// <summary>
        ///     Adds items to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="actionItems">The action items value.</param>
        /// <returns>The configured <see cref="BreadcrumbBuilder" /> value or BootstrapBuilder result.</returns>
        public BreadcrumbBuilder AddItems(params IActionItem[] actionItems)
        {
            if (actionItems is null)
            {
                return This();
            }

            foreach (IActionItem actionItem in actionItems)
            {
                AddItem(actionItem);
            }

            return This();
        }

        /// <summary>
        ///     Adds items to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="actionItems">The action items value.</param>
        /// <returns>The configured <see cref="BreadcrumbBuilder" /> value or BootstrapBuilder result.</returns>
        public BreadcrumbBuilder AddItems(IEnumerable<IActionItem> actionItems)
        {
            if (actionItems is null)
            {
                return This();
            }

            foreach (IActionItem actionItem in actionItems)
            {
                AddItem(actionItem);
            }

            return This();
        }

        /// <inheritdoc />
        protected override BreadcrumbBuilder CreateInstance()
        {
            return new BreadcrumbBuilder(_textWriter, _htmlHelper);
        }

        /// <inheritdoc />
        protected override void InternalClone(BreadcrumbBuilder source)
        {
            base.InternalClone(source);

            _items.Clear();
            _items.AddRange(source._items);

            _displayMode = source._displayMode;
            _collapseAfter = source._collapseAfter;
        }

        /// <summary>
        ///     Configures collapse after on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="maxVisibleItems">The max visible items value.</param>
        /// <returns>The configured <see cref="BreadcrumbBuilder" /> value or BootstrapBuilder result.</returns>
        public BreadcrumbBuilder SetCollapseAfter(int maxVisibleItems)
        {
            _collapseAfter = maxVisibleItems >= 3 ? maxVisibleItems : null;
            return This();
        }

        /// <summary>
        ///     Configures display mode on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="displayMode">The display mode value.</param>
        /// <returns>The configured <see cref="BreadcrumbBuilder" /> value or BootstrapBuilder result.</returns>
        public BreadcrumbBuilder SetDisplayMode(BreadcrumbDisplayMode displayMode)
        {
            _displayMode = displayMode;
            return This();
        }

        /// <summary>
        ///     Configures separator on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="separator">The separator value.</param>
        /// <returns>The configured <see cref="BreadcrumbBuilder" /> value or BootstrapBuilder result.</returns>
        public BreadcrumbBuilder SetSeparator(string? separator)
        {
            return this.SetBreadcrumbDivider(separator);
        }

        /// <summary>
        ///     Configures style on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="style">The style value.</param>
        /// <returns>The configured <see cref="BreadcrumbBuilder" /> value or BootstrapBuilder result.</returns>
        public BreadcrumbBuilder SetStyle(BreadcrumbStyle style)
        {
            return this.SetBreadcrumbStyle(style);
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            if (_items.Count == 0)
            {
                return;
            }

            string? previousDividerStyle = GetAttributeValue("style");

            try
            {
                BreadcrumbComposer? composer = GetCssComposer<BreadcrumbComposer>();
                string? divider = composer?.GetDivider();
                if (string.IsNullOrEmpty(divider) == false)
                {
                    SetStyle("--bs-breadcrumb-divider", string.Empty);
                }
                else
                {
                    SetStyle("--bs-breadcrumb-divider", "/");
                }

                writer.Write($"<{GetTag()}{BuildAttributes()}>");
                writer.Write("<ol class=\"breadcrumb mb-0\">");
                WriteItems(writer, encoder, divider ?? string.Empty);
                writer.Write("</ol>");
                writer.Write($"</{GetTag()}>");
            }
            finally
            {
                if (previousDividerStyle is null)
                {
                    RemoveStyle("--bs-breadcrumb-divider");
                }
            }
        }

        #endregion

        #region Private methods

        private IEnumerable<(IActionItem? Item, bool IsLast, bool IsCollapsed)> EnumerateVisibleItems()
        {
            int itemCount = _items.Count;

            if (!_collapseAfter.HasValue || itemCount <= _collapseAfter.Value)
            {
                for (int index = 0; index < itemCount; index++)
                {
                    yield return (_items[index], index == itemCount - 1, false);
                }

                yield break;
            }

            int tailCount = _collapseAfter.Value - 2;
            int startIndex = itemCount - tailCount;

            yield return (_items[0], false, false);
            yield return (null, false, true);

            for (int index = startIndex; index < itemCount; index++)
            {
                bool isLast = index == itemCount - 1;
                yield return (_items[index], isLast, false);
            }
        }

        private string? GenerateAspUrl(AspRouteActionItem aspRouteActionItem)
        {
            IUrlHelperFactory? urlHelperFactory = _htmlHelper.ViewContext.HttpContext.RequestServices
                .GetService(typeof(IUrlHelperFactory)) as IUrlHelperFactory;

            if (urlHelperFactory is null)
            {
                return null;
            }

            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(_htmlHelper.ViewContext);

            return urlHelper.Action(
                aspRouteActionItem.AspAction,
                aspRouteActionItem.AspController,
                aspRouteActionItem.RouteValues);
        }

        private IconStruct ResolveIcon(IActionItem actionItem)
        {
            return actionItem switch
            {
                UrlActionItem urlActionItem => urlActionItem.Icon,
                AspRouteActionItem aspRouteActionItem => aspRouteActionItem.Icon,
                _ => IconStruct.Empty
            };
        }

        private string? ResolveTitle(IActionItem actionItem)
        {
            return actionItem switch
            {
                UrlActionItem urlActionItem => urlActionItem.Title,
                AspRouteActionItem aspRouteActionItem => aspRouteActionItem.Title,
                _ => null
            };
        }

        private string? ResolveUrl(IActionItem actionItem)
        {
            return actionItem switch
            {
                UrlActionItem urlActionItem => urlActionItem.Url,
                AspRouteActionItem aspRouteActionItem => GenerateAspUrl(aspRouteActionItem),
                _ => null
            };
        }

        private void WriteCollapsedItem(TextWriter writer)
        {
            writer.Write("<li class=\"breadcrumb-item mx-1\">…</li>");
        }

        private void WriteIcon(IconStruct icon, TextWriter writer)
        {
            HtmlLayoutExtensions
                .IconBuilder(_htmlHelper, icon, null, null)
                .WriteTo(writer, HtmlEncoder.Default);
        }

        private void WriteItemContent(IActionItem actionItem, TextWriter writer)
        {
            string? title = ResolveTitle(actionItem);
            IconStruct icon = ResolveIcon(actionItem);

            bool hasTitle = !string.IsNullOrWhiteSpace(title);
            bool hasIcon = !icon.IsEmpty;

            switch (_displayMode)
            {
                case BreadcrumbDisplayMode.TitleOnly:
                {
                    if (hasTitle)
                    {
                        writer.Write(WebUtility.HtmlEncode(title));
                    }
                    else if (hasIcon)
                    {
                        WriteIcon(icon, writer);
                    }

                    break;
                }

                case BreadcrumbDisplayMode.IconOnly:
                {
                    if (hasIcon)
                    {
                        WriteIcon(icon, writer);
                    }
                    else if (hasTitle)
                    {
                        writer.Write(WebUtility.HtmlEncode(title));
                    }

                    break;
                }

                case BreadcrumbDisplayMode.IconAndTitle:
                {
                    if (hasIcon)
                    {
                        WriteIcon(icon, writer);

                        if (hasTitle)
                        {
                            writer.Write(" ");
                        }
                    }

                    if (hasTitle)
                    {
                        writer.Write(WebUtility.HtmlEncode(title));
                    }

                    break;
                }
            }
        }

        private void WriteItem(IActionItem actionItem, bool isLast, TextWriter writer, string divider)
        {
            writer.Write(isLast
                ? "<li class=\"breadcrumb-item active mx-1\" aria-current=\"page\">"
                : "<li class=\"breadcrumb-item mx-1\">");

            if (isLast)
            {
                WriteItemContent(actionItem, writer);
                writer.Write("</li>");
                return;
            }

            string? url = ResolveUrl(actionItem);

            if (string.IsNullOrWhiteSpace(url))
            {
                WriteItemContent(actionItem, writer);
                writer.Write("</li>");
                if (string.IsNullOrWhiteSpace(divider) == false)
                {
                    writer.Write("<li class=\"mx-1\">" + WebUtility.HtmlEncode(divider) + "</li>");
                }

                return;
            }

            writer.Write("<a class=\"link-underline link-underline-opacity-10\" href=\"");
            writer.Write(WebUtility.HtmlEncode(url));
            writer.Write("\">");

            WriteItemContent(actionItem, writer);

            writer.Write("</a>");
            writer.Write("</li>");
            if (string.IsNullOrWhiteSpace(divider) == false)
            {
                writer.Write("<li class=\"mx-1\">" + WebUtility.HtmlEncode(divider) + "</li>");
            }
        }

        private void WriteItems(TextWriter writer, HtmlEncoder encoder, string divider)
        {
            foreach ((IActionItem? item, bool isLast, bool isCollapsed) in EnumerateVisibleItems())
            {
                if (isCollapsed)
                {
                    WriteCollapsedItem(writer);
                    continue;
                }

                if (item is not null)
                {
                    WriteItem(item, isLast, writer, divider);
                }
            }
        }

        #endregion
    }
}