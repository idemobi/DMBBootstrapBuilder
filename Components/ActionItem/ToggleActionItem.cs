#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ToggleActionItem.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder toggle action item component or support type.
    /// </summary>
    public class ToggleActionItem : ActionLeafBase<ToggleActionItem>
    {
        #region Instance fields and properties

        /// <summary>
        /// Gets or sets the switch java script value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? SwitchJavaScript { get; set; }
        /// <summary>
        /// Gets or sets the switch name value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? SwitchName { get; set; }
        /// <summary>
        /// Gets or sets the switch value value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool SwitchValue { get; set; }

        #endregion

        #region Instance methods

        /// <summary>
        /// Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IActionItem"/> value or BootstrapBuilder result.</returns>
        public override IActionItem Clone()
        {
            return new ToggleActionItem
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
                SwitchValue = SwitchValue,
                SwitchName = SwitchName,
                SwitchJavaScript = SwitchJavaScript,
                Disabled = Disabled,
                Active = Active,
                BadgeText = BadgeText,
                BadgeStyle = BadgeStyle
            };
        }

        /// <summary>
        /// Configures switch java script on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="javaScript">The java script value.</param>
        /// <returns>The configured <see cref="ToggleActionItem"/> value or BootstrapBuilder result.</returns>
        public ToggleActionItem WithSwitchJavaScript(string? javaScript)
        {
            SwitchJavaScript = javaScript;
            return this;
        }

        /// <summary>
        /// Configures switch name on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <returns>The configured <see cref="ToggleActionItem"/> value or BootstrapBuilder result.</returns>
        public ToggleActionItem WithSwitchName(string? name)
        {
            SwitchName = name;
            return this;
        }

        /// <summary>
        /// Configures switch value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="ToggleActionItem"/> value or BootstrapBuilder result.</returns>
        public ToggleActionItem WithSwitchValue(bool value)
        {
            SwitchValue = value;
            return this;
        }

        #endregion
    }
}