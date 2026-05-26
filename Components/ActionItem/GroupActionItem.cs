#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj GroupActionItem.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    #region Copyright

    // Game-Data-Forge Solution
    // Written by CONTART Jean-François & BOULOGNE Quentin
    // BootstrapBuilder.csproj SplitActionItem.cs
    // ©2024-2026 idéMobi SARL FRANCE

    #endregion

    namespace BootstrapBuilder
    {
    }

    /// <summary>
    /// Represents the BootstrapBuilder group action item component or support type.
    /// </summary>
    public sealed class GroupActionItem : ActionContainerBase<GroupActionItem>,
        IDropdownDirectional
    {
        #region Instance fields and properties

        #region From interface IDropdownDirectional

        /// <summary>
        /// Gets or sets the dropdown direction value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public DropdownDirection DropdownDirection { get; set; } = DropdownDirection.Default;

        #endregion

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupActionItem"/> class.
        /// </summary>
        public GroupActionItem()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupActionItem"/> class.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <param name="icon">The icon value.</param>
        public GroupActionItem(string title, IconStruct icon)
        {
            Title = title;
            Icon = icon;
        }

        #endregion

        #region Instance methods

        /// <summary>
        /// Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IActionItem"/> value or BootstrapBuilder result.</returns>
        public override IActionItem Clone()
        {
            var clone = new GroupActionItem
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
                DropdownDirection = DropdownDirection
            };

            foreach (var item in Items)
            {
                clone.Items.Add(item.Clone());
            }

            return clone;
        }

        /// <summary>
        /// Executes the BootstrapBuilder dropdown operation.
        /// </summary>
        /// <returns>The configured <see cref="GroupActionItem"/> value or BootstrapBuilder result.</returns>
        public GroupActionItem Dropdown()
        {
            DropdownDirection = DropdownDirection.Default;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder dropdown centered operation.
        /// </summary>
        /// <returns>The configured <see cref="GroupActionItem"/> value or BootstrapBuilder result.</returns>
        public GroupActionItem DropdownCentered()
        {
            DropdownDirection = DropdownDirection.Centered;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder dropend operation.
        /// </summary>
        /// <returns>The configured <see cref="GroupActionItem"/> value or BootstrapBuilder result.</returns>
        public GroupActionItem Dropend()
        {
            DropdownDirection = DropdownDirection.Dropend;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder dropstart operation.
        /// </summary>
        /// <returns>The configured <see cref="GroupActionItem"/> value or BootstrapBuilder result.</returns>
        public GroupActionItem Dropstart()
        {
            DropdownDirection = DropdownDirection.Dropstart;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder dropup operation.
        /// </summary>
        /// <returns>The configured <see cref="GroupActionItem"/> value or BootstrapBuilder result.</returns>
        public GroupActionItem Dropup()
        {
            DropdownDirection = DropdownDirection.Dropup;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder dropup centered operation.
        /// </summary>
        /// <returns>The configured <see cref="GroupActionItem"/> value or BootstrapBuilder result.</returns>
        public GroupActionItem DropupCentered()
        {
            DropdownDirection = DropdownDirection.DropupCentered;
            return this;
        }

        /// <summary>
        /// Configures dropdown direction on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="direction">The direction value.</param>
        /// <returns>The configured <see cref="GroupActionItem"/> value or BootstrapBuilder result.</returns>
        public GroupActionItem WithDropdownDirection(DropdownDirection direction)
        {
            DropdownDirection = direction;
            return this;
        }

        #endregion
    }
}