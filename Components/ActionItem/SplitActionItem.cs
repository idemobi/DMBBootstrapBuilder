#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj SplitActionItem.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder split action item component or support type.
    /// </summary>
    public sealed class SplitActionItem : IActionContainerItem, IDropdownDirectional
    {
        #region Instance fields and properties

        private readonly List<IActionItem> _items = new();

        /// <summary>
        /// Gets or sets the primary action value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public IActionItem PrimaryAction { get; set; }

        #region From interface IActionContainerItem

        /// <summary>
        /// Gets or sets a value indicating whether children is enabled for BootstrapBuilder rendering.
        /// </summary>
        public bool HasChildren => _items.Count > 0;
        /// <summary>
        /// Gets or sets the html attributes value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public IReadOnlyDictionary<string, string> HtmlAttributes => new Dictionary<string, string>();

        /// <summary>
        /// Gets or sets the items value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public List<IActionItem> Items => _items;

        #endregion

        #region From interface IDropdownDirectional

        /// <summary>
        /// Gets or sets the dropdown direction value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public DropdownDirection DropdownDirection { get; set; } = DropdownDirection.Default;

        #endregion

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SplitActionItem"/> class.
        /// </summary>
        /// <param name="primaryAction">The primary action value.</param>
        public SplitActionItem(IActionItem primaryAction)
        {
            PrimaryAction = primaryAction ?? throw new ArgumentNullException(nameof(primaryAction));
        }

        #endregion

        #region Instance methods

        #region From interface IActionContainerItem

        /// <summary>
        /// Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IActionItem"/> value or BootstrapBuilder result.</returns>
        public IActionItem Clone()
        {
            var clone = new SplitActionItem(PrimaryAction.Clone())
            {
                DropdownDirection = DropdownDirection
            };

            foreach (var item in _items)
            {
                clone.Add(item.Clone());
            }

            return clone;
        }

        #endregion

        #endregion

        #region Delegated IActionItem properties

        public string Id
        {
            get => PrimaryAction.Id;
            set => PrimaryAction.Id = value;
        }

        public string? Title
        {
            get => PrimaryAction.Title;
            set => PrimaryAction.Title = value;
        }

        public string? Subtitle
        {
            get => PrimaryAction.Subtitle;
            set => PrimaryAction.Subtitle = value;
        }

        public IconStruct Icon
        {
            get => PrimaryAction.Icon;
            set => PrimaryAction.Icon = value;
        }

        public bool DebugOnly
        {
            get => PrimaryAction.DebugOnly;
            set => PrimaryAction.DebugOnly = value;
        }

        public bool Outline
        {
            get => PrimaryAction.Outline;
            set => PrimaryAction.Outline = value;
        }

        public VariantStyle Variant
        {
            get => PrimaryAction.Variant;
            set => PrimaryAction.Variant = value;
        }

        public BoostrapButtonSize Size
        {
            get => PrimaryAction.Size;
            set => PrimaryAction.Size = value;
        }

        public string AdditionalClasses
        {
            get => PrimaryAction.AdditionalClasses;
            set => PrimaryAction.AdditionalClasses = value;
        }

        public bool Disabled
        {
            get => PrimaryAction.Disabled;
            set => PrimaryAction.Disabled = value;
        }

        public bool Active
        {
            get => PrimaryAction.Active;
            set => PrimaryAction.Active = value;
        }

        public string? BadgeText
        {
            get => PrimaryAction.BadgeText;
            set => PrimaryAction.BadgeText = value;
        }

        public VariantStyle BadgeStyle
        {
            get => PrimaryAction.BadgeStyle;
            set => PrimaryAction.BadgeStyle = value;
        }

        #endregion

        #region Fluent API

        /// <summary>
        /// Executes the BootstrapBuilder outlined operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="SplitActionItem"/> value or BootstrapBuilder result.</returns>
        public SplitActionItem Outlined(bool value = true)
        {
            Outline = value;
            return this;
        }

        /// <summary>
        /// Configures variant on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="variant">The variant value.</param>
        /// <returns>The configured <see cref="SplitActionItem"/> value or BootstrapBuilder result.</returns>
        public SplitActionItem WithVariant(VariantStyle variant)
        {
            Variant = variant;
            return this;
        }

        /// <summary>
        /// Configures size on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <returns>The configured <see cref="SplitActionItem"/> value or BootstrapBuilder result.</returns>
        public SplitActionItem WithSize(BoostrapButtonSize size)
        {
            Size = size;
            return this;
        }

        /// <summary>
        /// Configures disabled on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="SplitActionItem"/> value or BootstrapBuilder result.</returns>
        public SplitActionItem SetDisabled(bool value = true)
        {
            Disabled = value;
            return this;
        }

        /// <summary>
        /// Configures active on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="SplitActionItem"/> value or BootstrapBuilder result.</returns>
        public SplitActionItem SetActive(bool value = true)
        {
            Active = value;
            return this;
        }

        /// <summary>
        /// Adds badge to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <param name="style">The style value.</param>
        /// <returns>The configured <see cref="SplitActionItem"/> value or BootstrapBuilder result.</returns>
        public SplitActionItem AddBadge(string text, VariantStyle style = VariantStyle.Danger)
        {
            BadgeText = text;
            BadgeStyle = style;
            return this;
        }

        /// <summary>
        /// Configures classes on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="classes">The classes value.</param>
        /// <returns>The configured <see cref="SplitActionItem"/> value or BootstrapBuilder result.</returns>
        public SplitActionItem WithClasses(string classes)
        {
            AdditionalClasses = classes ?? string.Empty;
            return this;
        }

        /// <summary>
        /// Configures title on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <returns>The configured <see cref="SplitActionItem"/> value or BootstrapBuilder result.</returns>
        public SplitActionItem WithTitle(string? title)
        {
            Title = title;
            return this;
        }

        /// <summary>
        /// Configures subtitle on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="subtitle">The subtitle value.</param>
        /// <returns>The configured <see cref="SplitActionItem"/> value or BootstrapBuilder result.</returns>
        public SplitActionItem WithSubtitle(string? subtitle)
        {
            Subtitle = subtitle;
            return this;
        }

        /// <summary>
        /// Configures icon on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="icon">The icon value.</param>
        /// <returns>The configured <see cref="SplitActionItem"/> value or BootstrapBuilder result.</returns>
        public SplitActionItem WithIcon(IconStruct icon)
        {
            Icon = icon;
            return this;
        }


        /// <summary>
        /// Adds value to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="item">The item value.</param>
        /// <returns>The configured <see cref="SplitActionItem"/> value or BootstrapBuilder result.</returns>
        public SplitActionItem Add(IActionItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _items.Add(item);
            return this;
        }

        /// <summary>
        /// Adds value to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="items">The items value.</param>
        /// <returns>The configured <see cref="SplitActionItem"/> value or BootstrapBuilder result.</returns>
        public SplitActionItem Add(params IActionItem[] items)
        {
            if (items == null)
            {
                return this;
            }

            foreach (var item in items.Where(x => x != null))
            {
                Add(item);
            }

            return this;
        }

        /// <summary>
        /// Adds items to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="items">The items value.</param>
        /// <returns>The configured <see cref="SplitActionItem"/> value or BootstrapBuilder result.</returns>
        public SplitActionItem AddItems(params IActionItem[] items)
        {
            return Add(items);
        }

        /// <summary>
        /// Configures dropdown direction on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="direction">The direction value.</param>
        /// <returns>The configured <see cref="SplitActionItem"/> value or BootstrapBuilder result.</returns>
        public SplitActionItem WithDropdownDirection(DropdownDirection direction)
        {
            DropdownDirection = direction;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder centered operation.
        /// </summary>
        /// <returns>The configured <see cref="SplitActionItem"/> value or BootstrapBuilder result.</returns>
        public SplitActionItem Centered()
        {
            DropdownDirection = DropdownDirection.Centered;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder dropup operation.
        /// </summary>
        /// <returns>The configured <see cref="SplitActionItem"/> value or BootstrapBuilder result.</returns>
        public SplitActionItem Dropup()
        {
            DropdownDirection = DropdownDirection.Dropup;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder dropup centered operation.
        /// </summary>
        /// <returns>The configured <see cref="SplitActionItem"/> value or BootstrapBuilder result.</returns>
        public SplitActionItem DropupCentered()
        {
            DropdownDirection = DropdownDirection.DropupCentered;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder dropend operation.
        /// </summary>
        /// <returns>The configured <see cref="SplitActionItem"/> value or BootstrapBuilder result.</returns>
        public SplitActionItem Dropend()
        {
            DropdownDirection = DropdownDirection.Dropend;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder dropstart operation.
        /// </summary>
        /// <returns>The configured <see cref="SplitActionItem"/> value or BootstrapBuilder result.</returns>
        public SplitActionItem Dropstart()
        {
            DropdownDirection = DropdownDirection.Dropstart;
            return this;
        }

        #endregion
    }
}