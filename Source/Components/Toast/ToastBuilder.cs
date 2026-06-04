#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Renders a Bootstrap toast notification with a fluent PageBuilder API.
    /// </summary>
    /// <remarks>
    ///     <see cref="ToastBuilder" /> renders the standard Bootstrap toast structure:
    ///     a root <c>.toast</c> element, an optional header, and a <c>.toast-body</c> content area.
    /// </remarks>
    [Documented]
    public sealed class ToastBuilder :
        HtmlBuilderBase<ToastBuilder>,
        IDisposable,
        ICanUseCustomClasses,
        IHasTitle,
        IHasSubtitle,
        IHasIcon
    {
        #region Instance fields and properties

        private bool _autoHide
        {
            get => GetInternal("_autoHide", false);
            set => SetInternal("_autoHide", value);
        }

        private string _closeLabel
        {
            get => GetInternal("_closeLabel", "Close");
            set => SetInternal("_closeLabel", value);
        }

        private int _delay
        {
            get => GetInternal("_delay", 5000);
            set => SetInternal("_delay", value);
        }

        private bool _dismissible
        {
            get => GetInternal("_dismissible", true);
            set => SetInternal("_dismissible", value);
        }

        private bool _headerVisible
        {
            get => GetInternal("_headerVisible", true);
            set => SetInternal("_headerVisible", value);
        }

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

        private bool _show
        {
            get => GetInternal("_show", true);
            set => SetInternal("_show", value);
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

        private VariantStyle _variant
        {
            get => GetInternal("_variant", VariantStyle.Normal);
            set => SetInternal("_variant", value);
        }

        #endregion

        #region Instance constructors and destructors

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ToastBuilder" /> class.
        /// </summary>
        /// <param name="writer">The <see cref="TextWriter" /> used by the current Razor response.</param>
        /// <param name="html">The current <see cref="IHtmlHelper" /> instance.</param>
        public ToastBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "div";

            InternalAddClass("toast");
            SetAttribute("role", "alert");
            SetAria("live", "assertive");
            SetAria("atomic", "true");
            SetData("bs-autohide", false);
        }

        #endregion

        #endregion

        #region Interface properties

        string? IHasTitle.Title
        {
            get => _title;
            set => _title = value;
        }

        string? IHasSubtitle.Subtitle
        {
            get => _subtitle;
            set => _subtitle = value;
        }

        IconStruct IHasIcon.Icon
        {
            get => _icon;
            set => _icon = value;
        }

        #endregion

        #region Public API

        /// <summary>
        ///     Sets whether Bootstrap should automatically hide the toast.
        /// </summary>
        /// <param name="value">A value indicating whether the toast should hide automatically.</param>
        /// <param name="delay">The delay, in milliseconds, before an auto-hidden toast closes.</param>
        /// <returns>The current <see cref="ToastBuilder" /> instance.</returns>
        [Documented]
        public ToastBuilder SetAutoHide(bool value = true, int delay = 5000)
        {
            _autoHide = value;
            _delay = Math.Max(0, delay);

            SetData("bs-autohide", _autoHide);
            SetData("bs-delay", _autoHide ? _delay.ToString(CultureInfo.InvariantCulture) : null);

            return this;
        }

        /// <summary>
        ///     Sets the accessible label used by the close button.
        /// </summary>
        /// <param name="label">The close button label.</param>
        /// <returns>The current <see cref="ToastBuilder" /> instance.</returns>
        [Documented]
        public ToastBuilder SetCloseLabel(string label)
        {
            _closeLabel = string.IsNullOrWhiteSpace(label) ? "Close" : label;
            return this;
        }

        /// <summary>
        ///     Sets whether the toast header contains a Bootstrap dismiss button.
        /// </summary>
        /// <param name="value">A value indicating whether the close button should be rendered.</param>
        /// <returns>The current <see cref="ToastBuilder" /> instance.</returns>
        [Documented]
        public ToastBuilder SetDismissible(bool value = true)
        {
            _dismissible = value;
            return this;
        }

        /// <summary>
        ///     Sets whether the toast header should be rendered.
        /// </summary>
        /// <param name="value">A value indicating whether the header should be rendered when it has content.</param>
        /// <returns>The current <see cref="ToastBuilder" /> instance.</returns>
        [Documented]
        public ToastBuilder SetHeaderVisible(bool value = true)
        {
            _headerVisible = value;
            return this;
        }

        /// <summary>
        ///     Sets the icon displayed in the toast header.
        /// </summary>
        /// <param name="icon">The <see cref="IconStruct" /> displayed before the title.</param>
        /// <returns>The current <see cref="ToastBuilder" /> instance.</returns>
        [Documented]
        public ToastBuilder SetIcon(IconStruct icon)
        {
            _icon = icon;
            return this;
        }

        /// <summary>
        ///     Sets the Bootstrap icon displayed in the toast header.
        /// </summary>
        /// <param name="iconBootstrap">The Bootstrap icon class or name.</param>
        /// <returns>The current <see cref="ToastBuilder" /> instance.</returns>
        [Documented]
        public ToastBuilder SetIconBootstrap(string iconBootstrap)
        {
            _icon = IconStruct.Bootstrap(iconBootstrap);
            return this;
        }

        /// <summary>
        ///     Sets the text message displayed in the toast body.
        /// </summary>
        /// <param name="message">The toast body message.</param>
        /// <returns>The current <see cref="ToastBuilder" /> instance.</returns>
        [Documented]
        public ToastBuilder SetMessage(string? message)
        {
            _message = message;
            _messageHtml = null;
            return this;
        }

        /// <summary>
        ///     Sets the HTML content displayed in the toast body.
        /// </summary>
        /// <param name="content">The toast body content.</param>
        /// <returns>The current <see cref="ToastBuilder" /> instance.</returns>
        [Documented]
        public ToastBuilder SetMessage(IHtmlContent? content)
        {
            _messageHtml = content;
            _message = null;
            return this;
        }

        /// <summary>
        ///     Sets whether the toast should render with Bootstrap's visible <c>show</c> class.
        /// </summary>
        /// <param name="value">A value indicating whether the toast should be visible immediately.</param>
        /// <returns>The current <see cref="ToastBuilder" /> instance.</returns>
        [Documented]
        public ToastBuilder SetShow(bool value = true)
        {
            _show = value;
            return this;
        }

        /// <summary>
        ///     Sets the secondary header text, usually a timestamp.
        /// </summary>
        /// <param name="subtitle">The secondary header text.</param>
        /// <returns>The current <see cref="ToastBuilder" /> instance.</returns>
        [Documented]
        public ToastBuilder SetSubtitle(string? subtitle)
        {
            _subtitle = subtitle;
            return this;
        }

        /// <summary>
        ///     Sets the toast title.
        /// </summary>
        /// <param name="title">The toast title.</param>
        /// <returns>The current <see cref="ToastBuilder" /> instance.</returns>
        [Documented]
        public ToastBuilder SetTitle(string? title)
        {
            _title = title;
            return this;
        }

        /// <summary>
        ///     Sets the Bootstrap variant applied to the toast root.
        /// </summary>
        /// <param name="variant">The <see cref="VariantStyle" /> used for the toast.</param>
        /// <returns>The current <see cref="ToastBuilder" /> instance.</returns>
        [Documented]
        public ToastBuilder SetVariant(VariantStyle variant)
        {
            _variant = variant;
            return this;
        }

        /// <summary>
        ///     Begins rendering a toast so Razor content can be written into its body.
        /// </summary>
        /// <returns>The current <see cref="ToastBuilder" /> instance.</returns>
        [Documented]
        public ToastBuilder Begin()
        {
            if (_started)
            {
                return this;
            }

            OnRenderDebug();
            WriteOpeningTag(_textWriter);
            WriteHeader(_textWriter);
            WriteBodyStart(_textWriter);
            WriteMessageContent(_textWriter);

            _started = true;

            return this;
        }

        /// <summary>
        ///     Completes a toast started with <see cref="Begin" />.
        /// </summary>
        public void Dispose()
        {
            if (!_started)
            {
                return;
            }

            WriteBodyEnd(_textWriter);
            WriteClosingTag(_textWriter);

            _started = false;
        }

        #endregion

        #region Protected methods

        /// <inheritdoc />
        protected override ToastBuilder CreateInstance()
        {
            return new ToastBuilder(_textWriter, _htmlHelper);
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            WriteOpeningTag(writer);
            WriteHeader(writer);
            WriteBodyStart(writer);
            WriteMessageContent(writer);
            WriteBodyEnd(writer);
            WriteClosingTag(writer);
        }

        #endregion

        #region Private methods

        private string GetVariantClass()
        {
            string variantCss = _variant.GetVariantCss();
            return string.IsNullOrWhiteSpace(variantCss) ? string.Empty : $"text-bg-{variantCss}";
        }

        private bool HasHeaderContent()
        {
            return _headerVisible && (!_icon.IsEmpty || !string.IsNullOrWhiteSpace(_title) || !string.IsNullOrWhiteSpace(_subtitle) || _dismissible);
        }

        private bool ShouldUseWhiteCloseButton()
        {
            return _variant.GetRecommendedTextVariant() == VariantStyle.Light;
        }

        private void WriteBodyEnd(TextWriter writer)
        {
            writer.Write("</div>");
        }

        private void WriteBodyStart(TextWriter writer)
        {
            writer.Write("<div class=\"toast-body\">");
        }

        private void WriteClosingTag(TextWriter writer)
        {
            writer.Write($"</{GetTag()}>");
        }

        private void WriteHeader(TextWriter writer)
        {
            if (!HasHeaderContent())
            {
                return;
            }

            string headerVariantClass = GetVariantClass();
            string headerClass = string.IsNullOrWhiteSpace(headerVariantClass) ? "toast-header" : $"toast-header {headerVariantClass}";
            writer.Write($"""<div class="{headerClass}">""");

            if (!_icon.IsEmpty)
            {
                _htmlHelper.IconBuilder(_icon, "me-2").WriteTo(writer, HtmlEncoder.Default);
            }

            if (!string.IsNullOrWhiteSpace(_title))
            {
                writer.Write("<strong class=\"me-auto\">");
                writer.Write(WebUtility.HtmlEncode(_title));
                writer.Write("</strong>");
            }
            else
            {
                writer.Write("<span class=\"me-auto\"></span>");
            }

            if (!string.IsNullOrWhiteSpace(_subtitle))
            {
                writer.Write("<small>");
                writer.Write(WebUtility.HtmlEncode(_subtitle));
                writer.Write("</small>");
            }

            if (_dismissible)
            {
                string closeCss = ShouldUseWhiteCloseButton() ? " btn-close-white" : string.Empty;
                writer.Write($"""<button type="button" class="btn-close{closeCss}" data-bs-dismiss="toast" aria-label="{WebUtility.HtmlEncode(_closeLabel)}"></button>""");
            }

            writer.Write("</div>");
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

        private void WriteOpeningTag(TextWriter writer)
        {
            using (PushInternalClasses(_show ? "show" : string.Empty, GetVariantClass()))
            {
                writer.Write($"<{GetTag()}{BuildAttributes()}>");
            }
        }

        #endregion
    }
}