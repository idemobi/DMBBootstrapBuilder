#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj BreadcrumbToggleActionItemExtension.cs create at 2026/05/18 13:56:18
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;
using DMBServerHelper;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring breadcrumb toggle action item in BootstrapBuilder components.
    /// </summary>
    public static class BreadcrumbToggleActionItemExtension
    {
        #region Static methods

        /// <summary>
        /// Configures localized icon bootstrap on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="iconBootstrapKey">The icon bootstrap key value.</param>
        /// <returns>The configured <see cref="BreadcrumbToggleActionItem"/> value or BootstrapBuilder result.</returns>
        public static BreadcrumbToggleActionItem SetLocalizedIconBootstrap(this BreadcrumbToggleActionItem builder, string iconBootstrapKey)
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
        /// <returns>The configured <see cref="BreadcrumbToggleActionItem"/> value or BootstrapBuilder result.</returns>
        public static BreadcrumbToggleActionItem SetLocalizedTitle(this BreadcrumbToggleActionItem builder, string titleKey, params object[] args)
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
