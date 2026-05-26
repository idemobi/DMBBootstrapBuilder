#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj AlertModel.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder alert model component or support type.
    /// </summary>
    public class AlertModel
    {
        #region Instance fields and properties

        private bool Dismissible;
        private bool Fade;
        private List<IActionItem>? FooterActions;
        private IconStruct Icon;
        private string? Message;
        private IHtmlContent? MessageHtml;
        private bool Show = true;
        private string? Title;
        private VariantStyle Variant = VariantStyle.Warning;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AlertModel"/> class.
        /// </summary>
        /// <param name="icon">The icon value.</param>
        /// <param name="title">The title value.</param>
        /// <param name="message">The message value.</param>
        public AlertModel(IconStruct icon, string? title, string? message)
        {
            Icon = icon;
            Title = title;
            Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlertModel"/> class.
        /// </summary>
        /// <param name="icon">The icon value.</param>
        /// <param name="title">The title value.</param>
        /// <param name="messageHtml">The message html value.</param>
        public AlertModel(IconStruct icon, string? title, IHtmlContent? messageHtml)
        {
            Icon = icon;
            Title = title;
            MessageHtml = messageHtml;
        }

        #endregion

        #region Instance methods

        /// <summary>
        /// Executes the BootstrapBuilder alert built operation.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="AlertBuilder"/> value or BootstrapBuilder result.</returns>
        public AlertBuilder AlertBuilt(TextWriter writer, IHtmlHelper html)
        {
            AlertBuilder alertPanel = new AlertBuilder(writer, html);
            alertPanel.SetVariant(Variant);
            alertPanel.SetDismissible(Dismissible);
            if (string.IsNullOrEmpty(Message) == false)
            {
                alertPanel.SetMessage(Message);
            }

            if (MessageHtml != null)
            {
                alertPanel.SetMessage(MessageHtml);
            }

            if (string.IsNullOrEmpty(Title) == false)
            {
                alertPanel.SetTitle(Title);
            }

            if (!Icon.IsEmpty)
            {
                alertPanel.SetIcon(Icon);
            }

            if (FooterActions != null)
            {
                alertPanel.AddFooterActions(FooterActions.ToArray());
            }

            alertPanel.SetAlertFade(Fade);
            alertPanel.SetAlertShow(Show);

            return alertPanel;
        }

        /// <summary>
        /// Configures dismissible on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="AlertModel"/> value or BootstrapBuilder result.</returns>
        public AlertModel SetDismissible(bool value = true)
        {
            Dismissible = value;
            return this;
        }

        /// <summary>
        /// Configures fade on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="AlertModel"/> value or BootstrapBuilder result.</returns>
        public AlertModel SetFade(bool value = true)
        {
            Fade = value;
            return this;
        }

        /// <summary>
        /// Configures footer actions on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="items">The items value.</param>
        /// <returns>The configured <see cref="AlertModel"/> value or BootstrapBuilder result.</returns>
        public AlertModel SetFooterActions(params IActionItem[] items)
        {
            if (FooterActions == null)
            {
                FooterActions = new List<IActionItem>();
            }

            FooterActions.AddRange(items);
            return this;
        }

        /// <summary>
        /// Configures show on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="AlertModel"/> value or BootstrapBuilder result.</returns>
        public AlertModel SetShow(bool value = true)
        {
            Show = value;
            return this;
        }

        /// <summary>
        /// Configures variant on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="variant">The variant value.</param>
        /// <returns>The configured <see cref="AlertModel"/> value or BootstrapBuilder result.</returns>
        public AlertModel SetVariant(VariantStyle variant)
        {
            Variant = variant;
            return this;
        }

        #endregion
    }
}