#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using System.IO;
using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Builds and renders the BootstrapBuilder tab block component or page region.
    /// </summary>
    public sealed class TabBlockBuilder :
        HtmlBuilderBase<TabBlockBuilder>,
        ICanUseTabBlock,
        IDisposable
    {
        #region Instance fields and properties

        private BadgeBuilderCollection _badges = new();

        private StringWriter? _captureWriter;

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

        private TextWriter? _originalWriter;

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
        ///     Initializes a new instance of the <see cref="TabBlockBuilder" /> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public TabBlockBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "div";
            SetData("tab-block", "true");
        }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Executes the BootstrapBuilder active operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TabBlockBuilder" /> value or BootstrapBuilder result.</returns>
        public TabBlockBuilder Active(bool value = true)
        {
            return this.SetTabBlockActive(value);
        }

        /// <summary>
        ///     Adds badge to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="badge">The badge value.</param>
        /// <param name="others">The others value.</param>
        /// <returns>The configured <see cref="TabBlockBuilder" /> value or BootstrapBuilder result.</returns>
        public TabBlockBuilder AddBadge(BadgeBuilder badge, params BadgeBuilder[] others)
        {
            _badges.Add(badge, others);
            return this;
        }

        /// <summary>
        ///     Adds badge to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <param name="style">The style value.</param>
        /// <returns>The configured <see cref="TabBlockBuilder" /> value or BootstrapBuilder result.</returns>
        public TabBlockBuilder AddBadge(string text, VariantStyle style = VariantStyle.Danger)
        {
            BadgeBuilder badge = new BadgeBuilder(_textWriter, _htmlHelper)
                .SetText(text)
                .SetBadgeVariant(style);

            _badges.Add(badge);
            return this;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder begin operation.
        /// </summary>
        /// <returns>The configured <see cref="TabBlockBuilder" /> value or BootstrapBuilder result.</returns>
        public TabBlockBuilder Begin()
        {
            if (_started)
            {
                return this;
            }

            TabAreaBuilder? tabArea = TabAreaBuilder.GetCurrent(_htmlHelper);
            if (tabArea == null)
            {
                throw new InvalidOperationException("TabBlockBuilder must be used inside a TabAreaBuilder.");
            }

            _started = true;
            _originalWriter = _htmlHelper.ViewContext.Writer;
            _captureWriter = new StringWriter();
            _htmlHelper.ViewContext.Writer = _captureWriter;

            return this;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder clear badges operation.
        /// </summary>
        /// <returns>The configured <see cref="TabBlockBuilder" /> value or BootstrapBuilder result.</returns>
        public TabBlockBuilder ClearBadges()
        {
            _badges.Clear();
            return this;
        }

        /// <inheritdoc />
        protected override TabBlockBuilder CreateInstance()
        {
            return new TabBlockBuilder(_textWriter, _htmlHelper);
        }

        /// <summary>
        ///     Executes the BootstrapBuilder disabled operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TabBlockBuilder" /> value or BootstrapBuilder result.</returns>
        public TabBlockBuilder Disabled(bool value = true)
        {
            return this.SetTabBlockDisabled(value);
        }

        /// <summary>
        ///     Executes the BootstrapBuilder fade operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TabBlockBuilder" /> value or BootstrapBuilder result.</returns>
        public TabBlockBuilder Fade(bool value = true)
        {
            return this.SetTabBlockFade(value);
        }

        /// <inheritdoc />
        protected override void InternalClone(TabBlockBuilder source)
        {
            base.InternalClone(source);

            _badges = source._badges.Clone();
            _captureWriter = null;
            _disposed = false;
            _icon = source._icon;
            _originalWriter = null;
            _started = false;
            _subtitle = source._subtitle;
            _title = source._title;
        }

        /// <summary>
        ///     Configures badge on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="badge">The badge value.</param>
        /// <returns>The configured <see cref="TabBlockBuilder" /> value or BootstrapBuilder result.</returns>
        public TabBlockBuilder SetBadge(BadgeBuilder badge)
        {
            _badges.Set(badge);
            return this;
        }

        /// <summary>
        ///     Configures icon on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="icon">The icon value.</param>
        /// <returns>The configured <see cref="TabBlockBuilder" /> value or BootstrapBuilder result.</returns>
        public TabBlockBuilder WithIcon(IconStruct icon)
        {
            _icon = icon;
            return this;
        }

        /// <summary>
        ///     Configures subtitle on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="subtitle">The subtitle value.</param>
        /// <returns>The configured <see cref="TabBlockBuilder" /> value or BootstrapBuilder result.</returns>
        public TabBlockBuilder WithSubtitle(string? subtitle)
        {
            _subtitle = subtitle;
            return this;
        }

        /// <summary>
        ///     Configures title on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <returns>The configured <see cref="TabBlockBuilder" /> value or BootstrapBuilder result.</returns>
        public TabBlockBuilder WithTitle(string? title)
        {
            _title = title;
            return this;
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            throw new InvalidOperationException("TabBlockBuilder does not render directly. Use Begin()/Dispose() inside a TabAreaBuilder.");
        }

        #region From interface IDisposable

        /// <summary>
        ///     Executes the BootstrapBuilder dispose operation.
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

            TabAreaBuilder? tabArea = TabAreaBuilder.GetCurrent(_htmlHelper);
            if (tabArea == null)
            {
                throw new InvalidOperationException("No current TabAreaBuilder found while disposing TabBlockBuilder.");
            }

            TabBlockComposer? composer = GetCssComposer<TabBlockComposer>();

            tabArea.RegisterTab(new TabDefinition
            {
                Id = GetId(),
                Title = _title,
                Subtitle = _subtitle,
                Icon = _icon,
                Badges = _badges.ToClonedList(),
                Active = composer?.IsActive == true,
                Disabled = composer?.IsDisabled == true,
                Fade = composer?.IsFade != false,
                ContentHtml = _captureWriter?.ToString() ?? string.Empty
            });
        }

        #endregion

        #endregion
    }
}