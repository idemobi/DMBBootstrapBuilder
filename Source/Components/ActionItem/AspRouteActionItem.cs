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
    ///     Represents the BootstrapBuilder asp route action item component or support type.
    /// </summary>
    public sealed class AspRouteActionItem : ActionLeafBase<AspRouteActionItem>
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the asp action value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? AspAction { get; set; }

        /// <summary>
        ///     Gets or sets the asp area value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? AspArea { get; set; }

        /// <summary>
        ///     Gets or sets the asp controller value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? AspController { get; set; }

        /// <summary>
        ///     Gets or sets the route values value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public Dictionary<string, string> RouteValues { get; set; } = new(StringComparer.OrdinalIgnoreCase);

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="AspRouteActionItem" /> class.
        /// </summary>
        public AspRouteActionItem()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AspRouteActionItem" /> class.
        /// </summary>
        /// <param name="controller">The controller value.</param>
        /// <param name="action">The action value.</param>
        /// <param name="area">The area value.</param>
        public AspRouteActionItem([AspMvcController] string controller, [AspMvcAction] string action, [AspMvcArea] string? area = null)
        {
            AspAction = action;
            AspController = controller;
            AspArea = area;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AspRouteActionItem" /> class.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <param name="icon">The icon value.</param>
        /// <param name="action">The action value.</param>
        /// <param name="controller">The controller value.</param>
        /// <param name="area">The area value.</param>
        public AspRouteActionItem(string title, IconStruct icon, [AspMvcAction] string action, [AspMvcController] string controller, [AspMvcArea] string? area = null)
        {
            Title = title.Trim();
            Icon = icon;
            AspAction = action;
            AspController = controller;
            AspArea = area;
        }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Adds route value to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="key">The key value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="AspRouteActionItem" /> value or BootstrapBuilder result.</returns>
        public AspRouteActionItem AddRouteValue(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Route key cannot be null or empty.", nameof(key));
            }

            RouteValues[key] = value;
            return this;
        }

        /// <summary>
        ///     Adds route value to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="key">The key value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="AspRouteActionItem" /> value or BootstrapBuilder result.</returns>
        public AspRouteActionItem AddRouteValue(string key, int value)
        {
            return AddRouteValue(key, value.ToString());
        }

        /// <summary>
        ///     Adds route value to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="key">The key value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="AspRouteActionItem" /> value or BootstrapBuilder result.</returns>
        public AspRouteActionItem AddRouteValue(string key, long value)
        {
            return AddRouteValue(key, value.ToString());
        }

        /// <summary>
        ///     Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IActionItem" /> value or BootstrapBuilder result.</returns>
        public override IActionItem Clone()
        {
            var clone = new AspRouteActionItem
            {
                Id = Id,
                Title = Title,
                Subtitle = Subtitle,
                Icon = Icon,
                DebugOnly = DebugOnly,
                Outline = Outline,
                Variant = Variant,
                Size = Size,
                AdditionalClasses = AdditionalClasses,
                AspController = AspController,
                AspAction = AspAction,
                AspArea = AspArea,
                Disabled = Disabled,
                Active = Active,
                BadgeText = BadgeText,
                BadgeStyle = BadgeStyle
            };

            foreach (var kvp in RouteValues)
            {
                clone.RouteValues[kvp.Key] = kvp.Value;
            }

            return clone;
        }

        #endregion
    }
}