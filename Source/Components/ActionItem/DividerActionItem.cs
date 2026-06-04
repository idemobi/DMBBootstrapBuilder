#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Collections.Generic;
using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the BootstrapBuilder divider action item component or support type.
    /// </summary>
    public sealed class DividerActionItem : IActionItem
    {
        #region Instance fields and properties

        #region From interface IActionItem

        /// <summary>
        ///     Gets or sets the active value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        ///     Gets or sets the additional classes value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string AdditionalClasses { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the badge style value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public VariantStyle BadgeStyle { get; set; } = VariantStyle.Danger;

        /// <summary>
        ///     Gets or sets the badge text value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? BadgeText { get; set; }

        /// <summary>
        ///     Gets or sets the debug only value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool DebugOnly { get; set; }

        /// <summary>
        ///     Gets or sets the disabled value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        ///     Gets or sets the html attributes value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public IReadOnlyDictionary<string, string> HtmlAttributes => new Dictionary<string, string>();

        /// <summary>
        ///     Gets or sets the icon value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public IconStruct Icon { get; set; }

        /// <summary>
        ///     Gets or sets the id value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the outline value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool Outline { get; set; }

        /// <summary>
        ///     Gets or sets the size value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public BoostrapButtonSize Size { get; set; } = BoostrapButtonSize.Small;

        /// <summary>
        ///     Gets or sets the subtitle value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? Subtitle { get; set; }

        /// <summary>
        ///     Gets or sets the title value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        ///     Gets or sets the variant value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public VariantStyle Variant { get; set; } = VariantStyle.Primary;

        #endregion

        #endregion

        #region Instance methods

        #region From interface IActionItem

        /// <summary>
        ///     Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IActionItem" /> value or BootstrapBuilder result.</returns>
        public IActionItem Clone()
        {
            return new DividerActionItem
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
                Disabled = Disabled,
                Active = Active,
                BadgeText = BadgeText,
                BadgeStyle = BadgeStyle
            };
        }

        #endregion

        #endregion
    }
}