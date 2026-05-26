#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj AlertBuilder.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using System.Net;
using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Builds and renders the BootstrapBuilder alert component or page region.
    /// </summary>
    [Documented]
    public sealed class AlertBuilder :
        HtmlBuilderBase<AlertBuilder>,
        ICanUseAlert,
        ICanUseCustomClasses,
        IDisposable
    {
        #region Fields

        private readonly List<IActionItem> _footerActions;

        private IconStruct _icon
        {
            get => GetInternal("_icon", IconStruct.Empty);
            set => SetInternal("_icon", value);
        }

        private string? _message
        {
            get => GetInternal<string?>("_message", null);
            set => SetInternal("_message", value);
        }

        private IHtmlContent? _messageHtml
        {
            get => GetInternal<IHtmlContent?>("_messageHtml", null);
            set => SetInternal("_messageHtml", value);
        }

        private bool _started
        {
            get => GetInternal("_started", false);
            set => SetInternal("_started", value);
        }

        private string? _title
        {
            get => GetInternal<string?>("_title", null);
            set => SetInternal("_title", value);
        }

        private TitleLevel _titleLevel
        {
            get => GetInternal("_titleLevel", TitleLevel.Four);
            set => SetInternal("_titleLevel", value);
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AlertBuilder"/> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public AlertBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _footerActions = new List<IActionItem>();

            _tag = "div";

            SetAttribute("role", "alert");
            SetData("alert", "true");

            this.SetAlertVariant(VariantStyle.Primary);
            this.SetAlertShow(true);
        }

        #endregion

        #region Public API

        /// <summary>
        /// Configures title on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <returns>The configured <see cref="AlertBuilder"/> value or BootstrapBuilder result.</returns>
        [Documented]
        public AlertBuilder SetTitle(string? title)
        {
            _title = title;
            return this;
        }

        /// <summary>
        /// Configures title level on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="level">The level value.</param>
        /// <returns>The configured <see cref="AlertBuilder"/> value or BootstrapBuilder result.</returns>
        [Documented]
        public AlertBuilder SetTitleLevel(TitleLevel level)
        {
            _titleLevel = level;
            return this;
        }

        /// <summary>
        /// Configures icon on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="icon">The icon value.</param>
        /// <returns>The configured <see cref="AlertBuilder"/> value or BootstrapBuilder result.</returns>
        [Documented]
        public AlertBuilder SetIcon(IconStruct icon)
        {
            _icon = icon;
            return this;
        }

        /// <summary>
        /// Configures message on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="message">The message value.</param>
        /// <returns>The configured <see cref="AlertBuilder"/> value or BootstrapBuilder result.</returns>
        [Documented]
        public AlertBuilder SetMessage(string? message)
        {
            _message = message;
            _messageHtml = null;
            return this;
        }

        /// <summary>
        /// Configures message on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="content">The content value.</param>
        /// <returns>The configured <see cref="AlertBuilder"/> value or BootstrapBuilder result.</returns>
        [Documented]
        public AlertBuilder SetMessage(IHtmlContent? content)
        {
            _messageHtml = content;
            _message = null;
            return this;
        }

        /// <summary>
        /// Configures dismissible on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <param name="animated">The animated value.</param>
        /// <returns>The configured <see cref="AlertBuilder"/> value or BootstrapBuilder result.</returns>
        [Documented]
        public AlertBuilder SetDismissible(bool value = true, bool animated = false)
        {
            this.SetAlertDismissible(value);
            this.SetAlertFade(value && animated);
            this.SetAlertShow(true);

            return this;
        }

        /// <summary>
        /// Configures variant on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="variant">The variant value.</param>
        /// <returns>The configured <see cref="AlertBuilder"/> value or BootstrapBuilder result.</returns>
        [Documented]
        public AlertBuilder SetVariant(VariantStyle variant)
        {
            return this.SetAlertVariant(variant);
        }

        /// <summary>
        /// Adds footer action to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="actionItem">The action item value.</param>
        /// <returns>The configured <see cref="AlertBuilder"/> value or BootstrapBuilder result.</returns>
        [Documented]
        public AlertBuilder AddFooterAction(IActionItem actionItem)
        {
            if (actionItem != null)
            {
                _footerActions.Add(actionItem);
            }

            return this;
        }

        /// <summary>
        /// Adds footer actions to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="actionItems">The action items value.</param>
        /// <returns>The configured <see cref="AlertBuilder"/> value or BootstrapBuilder result.</returns>
        [Documented]
        public AlertBuilder AddFooterActions(params IActionItem[] actionItems)
        {
            if (actionItems == null)
            {
                return this;
            }

            foreach (IActionItem actionItem in actionItems)
            {
                AddFooterAction(actionItem);
            }

            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder begin operation.
        /// </summary>
        /// <returns>The configured <see cref="AlertBuilder"/> value or BootstrapBuilder result.</returns>
        [Documented]
        public AlertBuilder Begin()
        {
            if (_started)
            {
                return this;
            }

            OnRenderDebug();

            _textWriter.Write($"<{GetTag()}{BuildAttributes()}>");

            WriteTitle(_textWriter);
            WriteMessageContent(_textWriter);

            _started = true;

            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder dispose operation.
        /// </summary>
        public void Dispose()
        {
            if (!_started)
            {
                return;
            }

            WriteFooter(_textWriter);
            WriteDismissButton(_textWriter);

            _textWriter.Write($"</{GetTag()}>");

            _started = false;
        }

        #endregion

        #region Protected methods

        protected override AlertBuilder CreateInstance()
        {
            AlertBuilder clone = new AlertBuilder(_textWriter, _htmlHelper);
            return clone;
        }

        protected override void InternalClone(AlertBuilder source)
        {
            base.InternalClone(source);

            _footerActions.Clear();
            _footerActions.AddRange(source._footerActions);
        }

        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write($"<{GetTag()}{BuildAttributes()}>");

            WriteTitle(writer);
            WriteMessageContent(writer);
            WriteFooter(writer);
            WriteDismissButton(writer);

            writer.Write($"</{GetTag()}>");
        }

        #endregion

        #region Private methods

        private AlertComposer? GetAlertComposer()
        {
            return GetCssComposer<AlertComposer>();
        }

        private void WriteTitle(TextWriter writer)
        {
            if (string.IsNullOrWhiteSpace(_title) && _icon.IsEmpty)
            {
                return;
            }

            TitleBuilder titleBuilder = new TitleBuilder(writer, _htmlHelper)
                .AddClass("alert-heading")
                .SetTitle(_title ?? string.Empty, _titleLevel);

            if (!_icon.IsEmpty)
            {
                titleBuilder.SetIcon(_icon);
            }

            titleBuilder.WriteTo(writer, HtmlEncoder.Default);
        }

        private void WriteMessageContent(TextWriter writer)
        {
            if (_messageHtml != null)
            {
                _messageHtml.WriteTo(writer, HtmlEncoder.Default);
                return;
            }

            if (!string.IsNullOrWhiteSpace(_message))
            {
                writer.Write(WebUtility.HtmlEncode(_message));
            }
        }

        private void WriteFooter(TextWriter writer)
        {
            if (_footerActions.Count == 0)
            {
                return;
            }

            writer.Write("<hr>");
            writer.Write("<div class=\"mt-3 d-flex flex-wrap gap-2\">");

            foreach (IActionItem action in _footerActions)
            {
                _htmlHelper.Button(action).WriteTo(writer, HtmlEncoder.Default);
            }

            writer.Write("</div>");
        }

        private void WriteDismissButton(TextWriter writer)
        {
            AlertComposer? composer = GetAlertComposer();

            if (composer?.IsDismissible != true)
            {
                return;
            }

            writer.Write("<button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>");
        }

        #endregion
    }
}