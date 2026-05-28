#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj StateThemeActionItemBase.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder state theme action item base component or support type.
    /// </summary>
    /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
    public abstract class StateThemeActionItemBase<TBuilder>
        : ActionLeafBase<TBuilder>
        where TBuilder : StateThemeActionItemBase<TBuilder>
    {
        #region Instance fields and properties

        /// <summary>
        /// Gets or sets the setting key value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public abstract string SettingKey { get; }
        /// <summary>
        /// Gets or sets the setting value value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public abstract string SettingValue { get; }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Adds state action data attributes to the rendered Bootstrap tag.
        /// </summary>
        /// <param name="tag">The tag builder that receives the state attributes.</param>
        protected virtual void BuildAttributes(TagBuilder tag)
        {
            tag.Attributes["data-dmb-setting"] = SettingKey;
            tag.Attributes["data-dmb-value"] = SettingValue;
            tag.Attributes["data-dmb-role"] = "state-action";
        }

        #endregion
    }
}
