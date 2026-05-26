#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ModalActionItem.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder dismiss modal action item component or support type.
    /// </summary>
    public sealed class DismissModalActionItem : ActionItemBase<DismissModalActionItem>
    {
        #region Instance methods

        /// <summary>
        /// Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IActionItem"/> value or BootstrapBuilder result.</returns>
        public override IActionItem Clone()
        {
            return new DismissModalActionItem();
        }

        #endregion
    }

    /// <summary>
    /// Represents the BootstrapBuilder modal action item component or support type.
    /// </summary>
    public sealed class ModalActionItem : ActionContainerBase<ModalActionItem>
    {
        #region Instance fields and properties

        /// <summary>
        /// Gets or sets the modal target id value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? ModalTargetId { get; set; }

        #endregion

        #region Instance methods

        /// <summary>
        /// Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IActionItem"/> value or BootstrapBuilder result.</returns>
        public override IActionItem Clone()
        {
            var clone = new ModalActionItem
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
                ModalTargetId = ModalTargetId,
                Disabled = Disabled,
                Active = Active,
                BadgeText = BadgeText,
                BadgeStyle = BadgeStyle
            };

            foreach (var item in Items)
            {
                clone.Items.Add(item.Clone());
            }

            return clone;
        }

        #endregion
    }
}