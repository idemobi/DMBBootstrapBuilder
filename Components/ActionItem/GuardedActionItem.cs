#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj GuardedActionItem.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder guarded action item component or support type.
    /// </summary>
    /// <typeparam name="TAction">The BootstrapBuilder type configured by this member.</typeparam>
    public sealed class GuardedActionItem<TAction> : IGuardedActionItem
        where TAction : IActionItem
    {
        #region Instance fields and properties

        /// <summary>
        /// Gets or sets the typed inner action value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public TAction TypedInnerAction { get; }

        #region From interface IGuardedActionItem

        /// <summary>
        /// Gets or sets the inner action value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public IActionItem InnerAction => TypedInnerAction;

        #endregion

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GuardedActionItem{TAction}"/> class.
        /// </summary>
        /// <param name="innerAction">The inner action value.</param>
        public GuardedActionItem(TAction innerAction)
        {
            TypedInnerAction = innerAction ?? throw new ArgumentNullException(nameof(innerAction));
        }

        #endregion

        #region Instance methods

        #region From interface IGuardedActionItem

        /// <summary>
        /// Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IActionItem"/> value or BootstrapBuilder result.</returns>
        public IActionItem Clone()
        {
            return new GuardedActionItem<TAction>((TAction)TypedInnerAction.Clone())
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
                BadgeStyle = BadgeStyle,
                WarningText = WarningText,
                WarningIcon = WarningIcon,
                SwitchText = SwitchText,
                SwitchDefaultValue = SwitchDefaultValue,
                RenderAsButtonGroup = RenderAsButtonGroup
            };
        }

        #endregion

        #endregion

        #region IActionItem UI (warning zone)

        /// <summary>
        /// Gets or sets the id value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the title value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// Gets or sets the subtitle value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? Subtitle { get; set; }
        /// <summary>
        /// Gets or sets the icon value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public IconStruct Icon { get; set; }

        /// <summary>
        /// Gets or sets the debug only value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool DebugOnly { get; set; }
        /// <summary>
        /// Gets or sets the outline value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool Outline { get; set; }

        /// <summary>
        /// Gets or sets the variant value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public VariantStyle Variant { get; set; } = VariantStyle.Danger;
        /// <summary>
        /// Gets or sets the size value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public BoostrapButtonSize Size { get; set; } = BoostrapButtonSize.Small;
        /// <summary>
        /// Gets or sets the additional classes value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string AdditionalClasses { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the disabled value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// Gets or sets the active value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the badge text value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? BadgeText { get; set; }
        /// <summary>
        /// Gets or sets the badge style value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public VariantStyle BadgeStyle { get; set; } = VariantStyle.Danger;

        #endregion

        #region Guard configuration

        /// <summary>
        /// Gets or sets the warning text value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? WarningText { get; set; }
        /// <summary>
        /// Gets or sets the warning icon value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public IconStruct WarningIcon { get; set; }

        /// <summary>
        /// Gets or sets the switch text value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? SwitchText { get; set; }
        /// <summary>
        /// Gets or sets the switch default value value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool SwitchDefaultValue { get; set; }

        /// <summary>
        /// Gets or sets the render as button group value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool RenderAsButtonGroup { get; set; } = true;

        /// <summary>
        /// Gets or sets the html attributes value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public IReadOnlyDictionary<string, string> HtmlAttributes => new Dictionary<string, string>();

        #endregion

        #region Fluent helpers

        /// <summary>
        /// Configures id on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="id">The id value.</param>
        /// <returns>The configured <see cref="GuardedActionItem{TAction}"/> value or BootstrapBuilder result.</returns>
        public GuardedActionItem<TAction> WithId(string id)
        {
            Id = HtmlIdGenerator.CleanId(id) ?? string.Empty;
            return this;
        }

        /// <summary>
        /// Configures title on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <returns>The configured <see cref="GuardedActionItem{TAction}"/> value or BootstrapBuilder result.</returns>
        public GuardedActionItem<TAction> WithTitle(string? title)
        {
            Title = title;
            return this;
        }

        /// <summary>
        /// Configures subtitle on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="subtitle">The subtitle value.</param>
        /// <returns>The configured <see cref="GuardedActionItem{TAction}"/> value or BootstrapBuilder result.</returns>
        public GuardedActionItem<TAction> WithSubtitle(string? subtitle)
        {
            Subtitle = subtitle;
            return this;
        }

        /// <summary>
        /// Configures icon on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="icon">The icon value.</param>
        /// <returns>The configured <see cref="GuardedActionItem{TAction}"/> value or BootstrapBuilder result.</returns>
        public GuardedActionItem<TAction> WithIcon(IconStruct icon)
        {
            Icon = icon;
            return this;
        }

        /// <summary>
        /// Configures debug only on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="GuardedActionItem{TAction}"/> value or BootstrapBuilder result.</returns>
        public GuardedActionItem<TAction> SetDebugOnly(bool value = true)
        {
            DebugOnly = value;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder outlined operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="GuardedActionItem{TAction}"/> value or BootstrapBuilder result.</returns>
        public GuardedActionItem<TAction> Outlined(bool value = true)
        {
            Outline = value;
            return this;
        }

        /// <summary>
        /// Configures variant on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="variant">The variant value.</param>
        /// <returns>The configured <see cref="GuardedActionItem{TAction}"/> value or BootstrapBuilder result.</returns>
        public GuardedActionItem<TAction> WithVariant(VariantStyle variant)
        {
            Variant = variant;
            return this;
        }

        /// <summary>
        /// Configures size on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <returns>The configured <see cref="GuardedActionItem{TAction}"/> value or BootstrapBuilder result.</returns>
        public GuardedActionItem<TAction> WithSize(BoostrapButtonSize size)
        {
            Size = size;
            if (InnerAction != null)
            {
                InnerAction.Size = size;
            }

            return this;
        }

        /// <summary>
        /// Configures classes on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="classes">The classes value.</param>
        /// <returns>The configured <see cref="GuardedActionItem{TAction}"/> value or BootstrapBuilder result.</returns>
        public GuardedActionItem<TAction> WithClasses(string classes)
        {
            AdditionalClasses = classes ?? string.Empty;
            return this;
        }

        /// <summary>
        /// Configures disabled on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="GuardedActionItem{TAction}"/> value or BootstrapBuilder result.</returns>
        public GuardedActionItem<TAction> SetDisabled(bool value = true)
        {
            Disabled = value;
            return this;
        }

        /// <summary>
        /// Configures active on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="GuardedActionItem{TAction}"/> value or BootstrapBuilder result.</returns>
        public GuardedActionItem<TAction> SetActive(bool value = true)
        {
            Active = value;
            return this;
        }

        /// <summary>
        /// Adds badge to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <param name="style">The style value.</param>
        /// <returns>The configured <see cref="GuardedActionItem{TAction}"/> value or BootstrapBuilder result.</returns>
        public GuardedActionItem<TAction> AddBadge(string text, VariantStyle style = VariantStyle.Danger)
        {
            BadgeText = text;
            BadgeStyle = style;
            return this;
        }

        /// <summary>
        /// Configures warning text on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <returns>The configured <see cref="GuardedActionItem{TAction}"/> value or BootstrapBuilder result.</returns>
        public GuardedActionItem<TAction> WithWarningText(string? text)
        {
            WarningText = text;
            return this;
        }

        /// <summary>
        /// Configures warning icon on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="icon">The icon value.</param>
        /// <returns>The configured <see cref="GuardedActionItem{TAction}"/> value or BootstrapBuilder result.</returns>
        public GuardedActionItem<TAction> WithWarningIcon(IconStruct icon)
        {
            WarningIcon = icon;
            return this;
        }

        /// <summary>
        /// Configures switch text on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <returns>The configured <see cref="GuardedActionItem{TAction}"/> value or BootstrapBuilder result.</returns>
        public GuardedActionItem<TAction> WithSwitchText(string? text)
        {
            SwitchText = text;
            return this;
        }

        /// <summary>
        /// Configures switch default value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="GuardedActionItem{TAction}"/> value or BootstrapBuilder result.</returns>
        public GuardedActionItem<TAction> WithSwitchDefaultValue(bool value = true)
        {
            SwitchDefaultValue = value;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder no button group operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="GuardedActionItem{TAction}"/> value or BootstrapBuilder result.</returns>
        public GuardedActionItem<TAction> NoButtonGroup(bool value = true)
        {
            RenderAsButtonGroup = !value;
            return this;
        }

        #endregion
    }
}