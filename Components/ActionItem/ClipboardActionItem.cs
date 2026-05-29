#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the BootstrapBuilder clipboard action item component or support type.
    /// </summary>
    public sealed class ClipboardActionItem : ActionLeafBase<ClipboardActionItem>
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the clipboard end icon value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public IconStruct ClipboardEndIcon { get; set; }

        /// <summary>
        ///     Gets or sets the clipboard end text value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? ClipboardEndText { get; set; }

        /// <summary>
        ///     Gets or sets the clipboard reset delay ms value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public int ClipboardResetDelayMs { get; set; } = 5000;

        /// <summary>
        ///     Gets or sets the clipboard start icon value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public IconStruct ClipboardStartIcon { get; set; }

        /// <summary>
        ///     Gets or sets the clipboard start text value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? ClipboardStartText { get; set; }

        /// <summary>
        ///     Gets or sets the clipboard value value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? ClipboardValue { get; set; }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IActionItem" /> value or BootstrapBuilder result.</returns>
        public override IActionItem Clone()
        {
            var clone = new ClipboardActionItem
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
                ClipboardValue = ClipboardValue,
                ClipboardStartIcon = ClipboardStartIcon,
                ClipboardEndIcon = ClipboardEndIcon,
                ClipboardStartText = ClipboardStartText,
                ClipboardEndText = ClipboardEndText,
                ClipboardResetDelayMs = ClipboardResetDelayMs,
                Disabled = Disabled,
                Active = Active,
                BadgeText = BadgeText,
                BadgeStyle = BadgeStyle
            };

            return clone;
        }

        /// <summary>
        ///     Configures clipboard end icon on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="icon">The icon value.</param>
        /// <returns>The configured <see cref="ClipboardActionItem" /> value or BootstrapBuilder result.</returns>
        public ClipboardActionItem WithClipboardEndIcon(IconStruct icon)
        {
            ClipboardEndIcon = icon;
            return this;
        }

        /// <summary>
        ///     Configures clipboard end text on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <returns>The configured <see cref="ClipboardActionItem" /> value or BootstrapBuilder result.</returns>
        public ClipboardActionItem WithClipboardEndText(string? text)
        {
            ClipboardEndText = text;
            return this;
        }

        /// <summary>
        ///     Configures clipboard reset delay ms on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="delayMs">The delay ms value.</param>
        /// <returns>The configured <see cref="ClipboardActionItem" /> value or BootstrapBuilder result.</returns>
        public ClipboardActionItem WithClipboardResetDelayMs(int delayMs)
        {
            if (delayMs < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(delayMs));
            }

            ClipboardResetDelayMs = delayMs;
            return this;
        }

        /// <summary>
        ///     Configures clipboard start icon on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="icon">The icon value.</param>
        /// <returns>The configured <see cref="ClipboardActionItem" /> value or BootstrapBuilder result.</returns>
        public ClipboardActionItem WithClipboardStartIcon(IconStruct icon)
        {
            ClipboardStartIcon = icon;
            return this;
        }

        /// <summary>
        ///     Configures clipboard start text on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <returns>The configured <see cref="ClipboardActionItem" /> value or BootstrapBuilder result.</returns>
        public ClipboardActionItem WithClipboardStartText(string? text)
        {
            ClipboardStartText = text;
            return this;
        }

        /// <summary>
        ///     Configures clipboard value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="ClipboardActionItem" /> value or BootstrapBuilder result.</returns>
        public ClipboardActionItem WithClipboardValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Clipboard value cannot be null or empty.", nameof(value));
            }

            ClipboardValue = value;
            return this;
        }

        #endregion
    }
}