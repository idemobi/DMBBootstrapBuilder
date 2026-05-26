#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ActionLeafBaseExtensions.cs create at 2026/04/08 09:04:40
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;
using DMBServerHelper;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring action leaf base in BootstrapBuilder components.
    /// </summary>
    public static class ActionLeafBaseExtensions
    {
        #region Static methods

        /// <summary>
        /// Stores the style value used by BootstrapBuilder rendering or composition.
        /// </summary>
        /// <typeparam name="TSelf">The BootstrapBuilder type configured by this member.</typeparam>
        public static TSelf SetLocalizedBadge<TSelf>(this TSelf builder, string badgeKey, VariantStyle style = VariantStyle.Danger) where TSelf : ActionItemBase<TSelf>
        {
            #if DEBUG
            builder.SetDataAttribut("badge-localized", true);
            builder.SetDataAttribut("badge-key", badgeKey);
            #endif
            builder.BadgeText = WebLocalizer.GetInternal(badgeKey);
            builder.BadgeStyle = style;
            return builder;
        }

        /// <summary>
        /// Configures localized icon bootstrap on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TSelf">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="iconBootstrapKey">The icon bootstrap key value.</param>
        /// <returns>The configured <see cref="TSelf"/> value or BootstrapBuilder result.</returns>
        public static TSelf SetLocalizedIconBootstrap<TSelf>(this TSelf builder, string iconBootstrapKey) where TSelf : ActionItemBase<TSelf>
        {
            #if DEBUG
            builder.SetDataAttribut("icon-bootstrap-localized", true);
            builder.SetDataAttribut("icon-bootstrap-key", iconBootstrapKey);
            #endif
            builder.Icon = IconStruct.Bootstrap(WebLocalizer.GetInternal(iconBootstrapKey));
            return builder;
        }


        /// <summary>
        /// Configures localized subtitle on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TSelf">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="subtitleKey">The subtitle key value.</param>
        /// <returns>The configured <see cref="TSelf"/> value or BootstrapBuilder result.</returns>
        public static TSelf SetLocalizedSubtitle<TSelf>(this TSelf builder, string subtitleKey) where TSelf : ActionItemBase<TSelf>
        {
            #if DEBUG
            builder.SetDataAttribut("subtitle-localized", true);
            builder.SetDataAttribut("subtitle-key", subtitleKey);
            #endif
            builder.Subtitle = WebLocalizer.GetInternal(subtitleKey);
            return builder;
        }

        /// <summary>
        /// Configures localized title on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TSelf">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="titleKey">The title key value.</param>
        /// <param name="args">The args value.</param>
        /// <returns>The configured <see cref="TSelf"/> value or BootstrapBuilder result.</returns>
        public static TSelf SetLocalizedTitle<TSelf>(this TSelf builder, string titleKey, params object[] args) where TSelf : ActionItemBase<TSelf>
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