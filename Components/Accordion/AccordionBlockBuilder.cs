#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj AccordionBlockBuilder.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Builds and renders the BootstrapBuilder accordion block component or page region.
    /// </summary>
    public sealed class AccordionBlockBuilder :
        HtmlBuilderBase<AccordionBlockBuilder>,
        IDisposable
    {
        #region Instance fields and properties

        private BadgeBuilderCollection _badges = new();

        private StringWriter? _captureWriter;
        private TextWriter? _originalWriter;

        private bool _disabled
        {
            get => GetInternal("_disabled", false);
            set => SetInternal("_disabled", value);
        }

        private bool _disposed
        {
            get => GetInternal("_disposed", false);
            set => SetInternal("_disposed", value);
        }

        private IconStruct _icon
        {
            get => GetInternal("_icon", IconStruct.Empty);
            set => SetInternal("_icon", value);
        }

        private bool _open
        {
            get => GetInternal("_open", false);
            set => SetInternal("_open", value);
        }

        private bool _started
        {
            get => GetInternal("_started", false);
            set => SetInternal("_started", value);
        }

        private string? _subtitle
        {
            get => GetInternal<string?>("_subtitle", null);
            set => SetInternal("_subtitle", value);
        }

        private string? _title
        {
            get => GetInternal<string?>("_title", null);
            set => SetInternal("_title", value);
        }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AccordionBlockBuilder"/> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public AccordionBlockBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
        }

        #endregion

        #region Fluent API

        /// <summary>
        /// Executes the BootstrapBuilder id operation.
        /// </summary>
        /// <param name="id">The id value.</param>
        /// <returns>The configured <see cref="AccordionBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public AccordionBlockBuilder Id(string id)
        {
            SetId(HtmlIdGenerator.CleanId(id) ?? string.Empty);
            return this;
        }

        /// <summary>
        /// Configures title on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <returns>The configured <see cref="AccordionBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public AccordionBlockBuilder WithTitle(string? title)
        {
            _title = title;
            return this;
        }

        /// <summary>
        /// Configures subtitle on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="subtitle">The subtitle value.</param>
        /// <returns>The configured <see cref="AccordionBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public AccordionBlockBuilder WithSubtitle(string? subtitle)
        {
            _subtitle = subtitle;
            return this;
        }

        /// <summary>
        /// Configures icon on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="icon">The icon value.</param>
        /// <returns>The configured <see cref="AccordionBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public AccordionBlockBuilder WithIcon(IconStruct icon)
        {
            _icon = icon;
            return this;
        }

        /// <summary>
        /// Configures badge on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="badge">The badge value.</param>
        /// <returns>The configured <see cref="AccordionBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public AccordionBlockBuilder SetBadge(BadgeBuilder badge)
        {
            _badges.Set(badge);
            return this;
        }

        /// <summary>
        /// Adds badge to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="badge">The badge value.</param>
        /// <param name="others">The others value.</param>
        /// <returns>The configured <see cref="AccordionBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public AccordionBlockBuilder AddBadge(BadgeBuilder badge, params BadgeBuilder[] others)
        {
            _badges.Add(badge, others);
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder clear badges operation.
        /// </summary>
        /// <returns>The configured <see cref="AccordionBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public AccordionBlockBuilder ClearBadges()
        {
            _badges.Clear();
            return this;
        }

        /// <summary>
        /// Adds badge to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <param name="style">The style value.</param>
        /// <returns>The configured <see cref="AccordionBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public AccordionBlockBuilder AddBadge(string text, VariantStyle style = VariantStyle.Danger)
        {
            BadgeBuilder badge = new BadgeBuilder(_textWriter, _htmlHelper)
                .SetText(text)
                .SetBadgeVariant(style);

            _badges.Add(badge);
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder open operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="AccordionBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public AccordionBlockBuilder Open(bool value = true)
        {
            _open = value;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder disabled operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="AccordionBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public AccordionBlockBuilder Disabled(bool value = true)
        {
            _disabled = value;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder begin operation.
        /// </summary>
        /// <returns>The configured <see cref="AccordionBlockBuilder"/> value or BootstrapBuilder result.</returns>
        public AccordionBlockBuilder Begin()
        {
            if (_started)
            {
                return this;
            }

            AccordionAreaBuilder? area = AccordionAreaBuilder.GetCurrent(_htmlHelper);
            if (area == null)
            {
                throw new InvalidOperationException("AccordionBlockBuilder must be used inside an AccordionAreaBuilder.");
            }

            _started = true;
            _originalWriter = _htmlHelper.ViewContext.Writer;
            _captureWriter = new StringWriter();
            _htmlHelper.ViewContext.Writer = _captureWriter;

            return this;
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

            if (!_started)
            {
                return;
            }

            if (_originalWriter != null)
            {
                _htmlHelper.ViewContext.Writer = _originalWriter;
            }

            AccordionAreaBuilder? area = AccordionAreaBuilder.GetCurrent(_htmlHelper);
            if (area == null)
            {
                throw new InvalidOperationException("No current AccordionAreaBuilder found while disposing AccordionBlockBuilder.");
            }

            area.RegisterItem(new AccordionDefinition
            {
                Id = GetId(),
                Title = _title,
                Subtitle = _subtitle,
                Icon = _icon,
                Badges = _badges.Clone().GetAll().ToList(),
                Open = _open,
                Disabled = _disabled,
                ContentHtml = _captureWriter?.ToString() ?? string.Empty
            });
        }

        /// <inheritdoc />
        protected override AccordionBlockBuilder CreateInstance()
        {
            return new AccordionBlockBuilder(_textWriter, _htmlHelper);
        }

        /// <inheritdoc />
        protected override void InternalClone(AccordionBlockBuilder source)
        {
            base.InternalClone(source);

            _badges = source._badges.Clone();
            _disabled = source._disabled;
            _icon = source._icon;
            _open = source._open;
            _subtitle = source._subtitle;
            _title = source._title;

            _captureWriter = null;
            _originalWriter = null;
            _disposed = false;
            _started = false;
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            throw new InvalidOperationException("AccordionBlockBuilder does not render directly. Use Begin()/Dispose() inside an AccordionAreaBuilder.");
        }

        #endregion
    }
}