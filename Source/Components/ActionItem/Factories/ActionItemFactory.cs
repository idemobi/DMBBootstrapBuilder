#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBPageBuilder;
using JetBrains.Annotations;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the BootstrapBuilder action item factory component or support type.
    /// </summary>
    public static class ActionItemFactory
    {
        #region Static methods

        /// <summary>
        ///     Executes the BootstrapBuilder asp route operation.
        /// </summary>
        /// <param name="controller">The controller value.</param>
        /// <param name="action">The action value.</param>
        /// <param name="area">The area value.</param>
        /// <returns>The configured <see cref="AspRouteActionItem" /> value or BootstrapBuilder result.</returns>
        public static AspRouteActionItem AspRoute([AspMvcController] string controller, [AspMvcAction] string action, [AspMvcArea] string? area = null)
        {
            return new AspRouteActionItem
            {
                AspController = controller,
                AspAction = action,
                AspArea = area,
            };
        }

        /// <summary>
        ///     Executes the BootstrapBuilder asp route operation.
        /// </summary>
        /// <param name="controller">The controller value.</param>
        /// <param name="action">The action value.</param>
        /// <param name="key">The key value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="AspRouteActionItem" /> value or BootstrapBuilder result.</returns>
        public static AspRouteActionItem AspRoute([AspMvcController] string controller, [AspMvcAction] string action, string key, string value)
        {
            return new AspRouteActionItem
            {
                AspController = controller,
                AspAction = action,
                RouteValues = { { key, value } }
            };
        }

        /// <summary>
        ///     Executes the BootstrapBuilder clipboard button operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <param name="startText">The start text value.</param>
        /// <param name="endText">The end text value.</param>
        /// <param name="startIcon">The start icon value.</param>
        /// <param name="endIcon">The end icon value.</param>
        /// <param name="resetDelayMs">The reset delay ms value.</param>
        /// <returns>The configured <see cref="ClipboardActionItem" /> value or BootstrapBuilder result.</returns>
        public static ClipboardActionItem ClipboardButton(
            string value,
            string? startText = null,
            string? endText = null,
            IconStruct startIcon = default,
            IconStruct endIcon = default,
            int resetDelayMs = 5000
        )
        {
            return new ClipboardActionItem
            {
                Title = startText,
                Icon = startIcon,
                ClipboardValue = value,
                ClipboardStartText = startText,
                ClipboardEndText = endText,
                ClipboardStartIcon = startIcon,
                ClipboardEndIcon = endIcon,
                ClipboardResetDelayMs = resetDelayMs
            };
        }

        /// <summary>
        ///     Executes the BootstrapBuilder dismiss modal operation.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <param name="icon">The icon value.</param>
        /// <returns>The configured <see cref="DismissModalActionItem" /> value or BootstrapBuilder result.</returns>
        public static DismissModalActionItem DismissModal(string? title = "Close", IconStruct icon = default)
        {
            return new DismissModalActionItem()
                .SetTitle(title)
                .SetIcon(icon)
                .SetVariant(VariantStyle.Secondary);
        }

        /// <summary>
        ///     Executes the BootstrapBuilder divider operation.
        /// </summary>
        /// <returns>The configured <see cref="DividerActionItem" /> value or BootstrapBuilder result.</returns>
        public static DividerActionItem Divider()
        {
            return new DividerActionItem();
        }

        /// <summary>
        ///     Executes the BootstrapBuilder group operation.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <param name="icon">The icon value.</param>
        /// <param name="subtitle">The subtitle value.</param>
        /// <returns>The configured <see cref="GroupActionItem" /> value or BootstrapBuilder result.</returns>
        public static GroupActionItem Group(string? title = null, IconStruct icon = default, string? subtitle = null)
        {
            return new GroupActionItem
            {
                Title = title,
                Icon = icon,
                Subtitle = subtitle
            };
        }


        /// <summary>
        ///     Executes the BootstrapBuilder guarded operation.
        /// </summary>
        /// <typeparam name="TAction">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="action">The action value.</param>
        /// <returns>The configured <see cref="GuardedActionItem{TAction}" /> value or BootstrapBuilder result.</returns>
        public static GuardedActionItem<TAction> Guarded<TAction>(TAction action)
            where TAction : IActionItem
        {
            return new GuardedActionItem<TAction>(action);
        }

        /// <summary>
        ///     Executes the BootstrapBuilder java script operation.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <param name="script">The script value.</param>
        /// <param name="icon">The icon value.</param>
        /// <returns>The configured <see cref="JavaScriptActionItem" /> value or BootstrapBuilder result.</returns>
        public static JavaScriptActionItem JavaScript(string title, string script, IconStruct icon = default)
        {
            return new JavaScriptActionItem
            {
                Title = title,
                JavaScript = script,
                Icon = icon
            };
        }

        /// <summary>
        ///     Executes the BootstrapBuilder modal operation.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <param name="modalTargetId">The modal target id value.</param>
        /// <param name="icon">The icon value.</param>
        /// <returns>The configured <see cref="ModalActionItem" /> value or BootstrapBuilder result.</returns>
        public static ModalActionItem Modal(string title, string modalTargetId, IconStruct icon = default)
        {
            return new ModalActionItem
            {
                Title = title,
                ModalTargetId = modalTargetId,
                Icon = icon
            };
        }

        /// <summary>
        ///     Executes the BootstrapBuilder split operation.
        /// </summary>
        /// <param name="primary">The primary value.</param>
        /// <param name="secondaries">The secondaries value.</param>
        /// <returns>The configured <see cref="SplitActionItem" /> value or BootstrapBuilder result.</returns>
        public static SplitActionItem Split(IActionItem primary, params IActionItem[] secondaries)
        {
            if (primary == null)
            {
                throw new ArgumentNullException(nameof(primary));
            }

            var split = new SplitActionItem(primary);

            if (secondaries != null)
            {
                split.AddItems(secondaries);
            }

            return split;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder split operation.
        /// </summary>
        /// <param name="primary">The primary value.</param>
        /// <returns>The configured <see cref="SplitActionItem" /> value or BootstrapBuilder result.</returns>
        public static SplitActionItem Split(IActionItem primary)
        {
            if (primary == null)
            {
                throw new ArgumentNullException(nameof(primary));
            }

            return new SplitActionItem(primary);
        }

        /// <summary>
        ///     Executes the BootstrapBuilder toggle operation.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <param name="value">The value to apply.</param>
        /// <param name="icon">The icon value.</param>
        /// <param name="name">The name value.</param>
        /// <param name="javaScript">The java script value.</param>
        /// <returns>The configured <see cref="ToggleActionItem" /> value or BootstrapBuilder result.</returns>
        public static ToggleActionItem Toggle(string title, bool value, IconStruct icon = default, string? name = null, string? javaScript = null)
        {
            return new ToggleActionItem
            {
                Title = title,
                Icon = icon,
                SwitchValue = value,
                SwitchName = name,
                SwitchJavaScript = javaScript
            };
        }

        /// <summary>
        ///     Executes the BootstrapBuilder url operation.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <param name="url">The url value.</param>
        /// <param name="icon">The icon value.</param>
        /// <returns>The configured <see cref="UrlActionItem" /> value or BootstrapBuilder result.</returns>
        public static UrlActionItem Url(string title, string url, IconStruct icon = default)
        {
            return new UrlActionItem
            {
                Title = title,
                Url = url,
                Icon = icon
            };
        }

        #endregion
    }
}