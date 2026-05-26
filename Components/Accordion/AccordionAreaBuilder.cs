#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj AccordionAreaBuilder.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using System.Net;
using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Builds and renders the BootstrapBuilder accordion area component or page region.
    /// </summary>
    public sealed class AccordionAreaBuilder :
        HtmlBuilderBase<AccordionAreaBuilder>,
        IDisposable
    {
        #region Constants

        internal const string CurrentContextKey = "__DMB_CURRENT_ACCORDIONAREA__";

        #endregion

        #region Instance fields and properties

        private BadgeBuilder? _badgeBuilder;

        private bool _disposed
        {
            get => GetInternal("_disposed", false);
            set => SetInternal("_disposed", value);
        }

        private bool _flush
        {
            get => GetInternal("_flush", false);
            set => SetInternal("_flush", value);
        }

        private bool _started
        {
            get => GetInternal("_started", false);
            set => SetInternal("_started", value);
        }

        private bool _stayOpen
        {
            get => GetInternal("_stayOpen", false);
            set => SetInternal("_stayOpen", value);
        }

        private readonly List<AccordionDefinition> _items = new();

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AccordionAreaBuilder"/> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public AccordionAreaBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "div";
            InternalAddClass("accordion");
        }

        #endregion

        #region Fluent API

        /// <summary>
        /// Executes the BootstrapBuilder id operation.
        /// </summary>
        /// <param name="id">The id value.</param>
        /// <returns>The configured <see cref="AccordionAreaBuilder"/> value or BootstrapBuilder result.</returns>
        public AccordionAreaBuilder Id(string id)
        {
            SetId(HtmlIdGenerator.CleanId(id) ?? string.Empty);
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder flush operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="AccordionAreaBuilder"/> value or BootstrapBuilder result.</returns>
        public AccordionAreaBuilder Flush(bool value = true)
        {
            _flush = value;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder stay open operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="AccordionAreaBuilder"/> value or BootstrapBuilder result.</returns>
        public AccordionAreaBuilder StayOpen(bool value = true)
        {
            _stayOpen = value;
            return this;
        }

        /// <summary>
        /// Configures classes on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="classes">The classes value.</param>
        /// <returns>The configured <see cref="AccordionAreaBuilder"/> value or BootstrapBuilder result.</returns>
        public AccordionAreaBuilder WithClasses(string classes)
        {
            InternalAddClass(classes);
            return this;
        }

        /// <summary>
        /// Configures badge on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="badge">The badge value.</param>
        /// <returns>The configured <see cref="AccordionAreaBuilder"/> value or BootstrapBuilder result.</returns>
        public AccordionAreaBuilder SetBadge(BadgeBuilder badge)
        {
            ArgumentNullException.ThrowIfNull(badge);
            _badgeBuilder = badge.Clone();
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder clear badge operation.
        /// </summary>
        /// <returns>The configured <see cref="AccordionAreaBuilder"/> value or BootstrapBuilder result.</returns>
        public AccordionAreaBuilder ClearBadge()
        {
            _badgeBuilder = null;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder begin operation.
        /// </summary>
        /// <returns>The configured <see cref="AccordionAreaBuilder"/> value or BootstrapBuilder result.</returns>
        public AccordionAreaBuilder Begin()
        {
            if (_started)
            {
                return this;
            }

            _started = true;

            if (string.IsNullOrWhiteSpace(GetId()))
            {
                SetId(_htmlHelper.GenerateUniqueId("accordion"));
            }

            SetCurrent(_htmlHelper, this);
            return this;
        }

        #endregion

        #region Internal registration

        internal void RegisterItem(AccordionDefinition item)
        {
            ArgumentNullException.ThrowIfNull(item);

            int index = _items.Count;

            string itemId = string.IsNullOrWhiteSpace(item.Id)
                ? $"{GetId()}_item_{index}"
                : HtmlIdGenerator.CleanId(item.Id) ?? $"{GetId()}_item_{index}";

            item.Id = itemId;
            item.HeaderId = $"{itemId}_header";
            item.CollapseId = $"{itemId}_collapse";

            _items.Add(item);
        }

        internal static AccordionAreaBuilder? GetCurrent(IHtmlHelper html)
        {
            if (html?.ViewContext?.HttpContext?.Items == null)
            {
                return null;
            }

            return html.ViewContext.HttpContext.Items.TryGetValue(CurrentContextKey, out object? value)
                ? value as AccordionAreaBuilder
                : null;
        }

        private static void SetCurrent(IHtmlHelper html, AccordionAreaBuilder? builder)
        {
            if (html?.ViewContext?.HttpContext?.Items == null)
            {
                return;
            }

            if (builder == null)
            {
                html.ViewContext.HttpContext.Items.Remove(CurrentContextKey);
            }
            else
            {
                html.ViewContext.HttpContext.Items[CurrentContextKey] = builder;
            }
        }

        #endregion

        #region Rendering

        /// <summary>
        /// Executes the BootstrapBuilder dispose operation.
        /// </summary>
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;
            SetCurrent(_htmlHelper, null);

            if (!_started)
            {
                return;
            }

            WriteTo(_textWriter, HtmlEncoder.Default);
        }

        protected override AccordionAreaBuilder CreateInstance()
        {
            return new AccordionAreaBuilder(_textWriter, _htmlHelper);
        }

        protected override void InternalClone(AccordionAreaBuilder source)
        {
            base.InternalClone(source);

            _items.Clear();
            foreach (AccordionDefinition item in source._items)
            {
                _items.Add(item.Clone());
            }

            _badgeBuilder = source._badgeBuilder?.Clone();
            _disposed = false;
            _started = false;
        }

        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            if (_items.Count == 0)
            {
                return;
            }

            EnsureOpenItem();

            using (PushInternalClasses(_flush ? "accordion-flush" : string.Empty))
            {
                writer.Write($"<{GetTag()}{BuildAttributes()}>");

                if (_badgeBuilder != null)
                {
                    writer.Write("""<div class="accordion-area-badge mb-2">""");
                    _badgeBuilder.WriteTo(writer, encoder);
                    writer.Write("</div>");
                }

                foreach (AccordionDefinition item in _items)
                {
                    writer.Write(RenderItem(item));
                }

                writer.Write($"</{GetTag()}>");
            }
        }

        private void EnsureOpenItem()
        {
            if (_stayOpen)
            {
                return;
            }

            AccordionDefinition? firstOpen = _items.FirstOrDefault(x => x.Open && !x.Disabled);
            if (firstOpen == null)
            {
                AccordionDefinition? firstEnabled = _items.FirstOrDefault(x => !x.Disabled);
                if (firstEnabled != null)
                {
                    firstEnabled.Open = true;
                }

                return;
            }

            bool seen = false;

            foreach (AccordionDefinition item in _items)
            {
                if (item.Disabled)
                {
                    item.Open = false;
                    continue;
                }

                if (item.Open && !seen)
                {
                    seen = true;
                }
                else
                {
                    item.Open = false;
                }
            }
        }

        private string RenderItem(AccordionDefinition item)
        {
            string buttonCss = item.Open ? "accordion-button" : "accordion-button collapsed";
            string collapseCss = item.Open ? "accordion-collapse collapse show" : "accordion-collapse collapse";
            string expanded = item.Open ? "true" : "false";
            string disabledAttribute = item.Disabled ? """ disabled="disabled" """ : string.Empty;
            string parentAttribute = _stayOpen ? string.Empty : $""" data-bs-parent="#{WebUtility.HtmlEncode(GetId())}" """;

            string iconHtml = item.Icon.IsEmpty
                ? string.Empty
                : GetIconHtml(item.Icon);

            string badgeHtml = RenderBadge(item);

            string subtitleHtml = string.IsNullOrWhiteSpace(item.Subtitle)
                ? string.Empty
                : $"""<div class="small text-body-secondary">{WebUtility.HtmlEncode(item.Subtitle)}</div>""";

            return $"""
                    <div class="accordion-item">
                        <h2 class="accordion-header" id="{WebUtility.HtmlEncode(item.HeaderId)}">
                            <button class="{buttonCss}"
                                    type="button"
                                    data-bs-toggle="collapse"
                                    data-bs-target="#{WebUtility.HtmlEncode(item.CollapseId)}"
                                    aria-expanded="{expanded}"
                                    aria-controls="{WebUtility.HtmlEncode(item.CollapseId)}"{disabledAttribute}>
                                <span class="d-inline-flex align-items-center justify-content-between gap-2 w-100 me-3">
                                    <span class="d-inline-flex align-items-center gap-2">
                                        {iconHtml}
                                        <span>
                                            <span>{WebUtility.HtmlEncode(item.Title ?? string.Empty)}</span>
                                            {subtitleHtml}
                                        </span>
                                    </span>
                                    {badgeHtml}
                                </span>
                            </button>
                        </h2>
                        <div id="{WebUtility.HtmlEncode(item.CollapseId)}"
                             class="{collapseCss}"
                             aria-labelledby="{WebUtility.HtmlEncode(item.HeaderId)}"{parentAttribute}>
                            <div class="accordion-body">
                                {item.ContentHtml}
                            </div>
                        </div>
                    </div>
                    """;
        }

        private string RenderBadge(AccordionDefinition item)
        {
            if (item.Badges == null || item.Badges.Count == 0)
            {
                return string.Empty;
            }

            using StringWriter writer = new();

            writer.Write("""<span class="d-inline-flex align-items-center gap-1">""");

            foreach (var badge in item.Badges)
            {
                badge.WriteTo(writer, HtmlEncoder.Default);
            }

            writer.Write("</span>");

            return writer.ToString();
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

        #endregion
    }
}