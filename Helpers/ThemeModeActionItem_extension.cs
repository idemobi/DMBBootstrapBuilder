#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ThemeModeActionItem_extension.cs create at 2026/04/08 09:04:40
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;
using DMBServerHelper;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring theme mode action item in BootstrapBuilder components.
    /// </summary>
    public static class ThemeModeActionItemExtension
    {
        #region Static methods

        /// <summary>
        /// Configures localized icon bootstrap on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="iconBootstrapKey">The icon bootstrap key value.</param>
        /// <returns>The configured <see cref="ThemeModeActionItem"/> value or BootstrapBuilder result.</returns>
        public static ThemeModeActionItem SetLocalizedIconBootstrap(this ThemeModeActionItem builder, string iconBootstrapKey)
        {
            #if DEBUG
            builder.SetDataAttribut("icon-bootstrap-localized", true);
            builder.SetDataAttribut("icon-bootstrap-key", iconBootstrapKey);
            #endif
            builder.Icon = IconStruct.Bootstrap(WebLocalizer.GetInternal(iconBootstrapKey));
            return builder;
        }

        /// <summary>
        /// Configures localized title on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="titleKey">The title key value.</param>
        /// <param name="args">The args value.</param>
        /// <returns>The configured <see cref="ThemeModeActionItem"/> value or BootstrapBuilder result.</returns>
        public static ThemeModeActionItem SetLocalizedTitle(this ThemeModeActionItem builder, string titleKey, params object[] args)
        {
            #if DEBUG
            builder.SetDataAttribut("title-localized", true);
            builder.SetDataAttribut("title-key", titleKey);
            #endif
            builder.Title = WebLocalizer.GetInternal(titleKey, args);
            return builder;
        }

        #endregion
    }
}