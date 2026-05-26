#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj LayoutToggleActionItemBase.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder layout toggle action item base component or support type.
    /// </summary>
    public abstract class LayoutToggleActionItemBase : ToggleActionItem
    {
        #region Instance fields and properties

        /// <summary>
        /// Gets or sets the setting key value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public abstract string SettingKey { get; }

        /// <summary>
        /// Gets or sets the setting value value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string SettingValue => SwitchValue ? "true" : "false";

        #endregion

        #region Instance constructors and destructors

        protected LayoutToggleActionItemBase(bool value)
        {
            SwitchValue = value;
        }

        #endregion

        #region Instance methods

        protected void ConfigureStateAttributes()
        {
            SetAttribut("data-dmb-setting", SettingKey);
            SetAttribut("data-dmb-value", SettingValue);
            SetAttribut("data-dmb-role", "layout-toggle");
        }

        #endregion
    }
}