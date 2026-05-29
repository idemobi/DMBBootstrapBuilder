#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the BootstrapBuilder layout toggle action item base component or support type.
    /// </summary>
    public abstract class LayoutToggleActionItemBase : ToggleActionItem
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the setting key value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public abstract string SettingKey { get; }

        /// <summary>
        ///     Gets or sets the setting value value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string SettingValue => SwitchValue ? "true" : "false";

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new layout toggle action item with the specified state.
        /// </summary>
        /// <param name="value">The initial toggle state rendered by the action item.</param>
        protected LayoutToggleActionItemBase(bool value)
        {
            SwitchValue = value;
        }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Applies data attributes used by client-side layout toggle behavior.
        /// </summary>
        protected void ConfigureStateAttributes()
        {
            SetAttribut("data-dmb-setting", SettingKey);
            SetAttribut("data-dmb-value", SettingValue);
            SetAttribut("data-dmb-role", "layout-toggle");
        }

        #endregion
    }
}