#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj TitleBuilder_Extensions.cs create at 2026/04/08 09:04:40
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;
using DMBServerHelper;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring title builder in BootstrapBuilder components.
    /// </summary>
    public static class TitleBuilderExtensions
    {
        #region Static methods

        /// <summary>
        /// Configures localized icon bootstrap on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="iconBootstrapKey">The icon bootstrap key value.</param>
        /// <returns>The configured <see cref="TitleBuilder"/> value or BootstrapBuilder result.</returns>
        public static TitleBuilder SetLocalizedIconBootstrap(this TitleBuilder builder, string iconBootstrapKey)
        {
            #if DEBUG
            builder.SetData("icon-bootstrap-localized", true);
            builder.SetData("icon-bootstrap-key", iconBootstrapKey);
            #endif
            builder.SetIcon(IconStruct.Bootstrap(WebLocalizer.GetInternal(iconBootstrapKey)));
            return builder;
        }

        /// <summary>
        /// Configures localized title on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="titleKey">The title key value.</param>
        /// <param name="args">The args value.</param>
        /// <returns>The configured <see cref="TitleBuilder"/> value or BootstrapBuilder result.</returns>
        public static TitleBuilder SetLocalizedTitle(this TitleBuilder builder, string titleKey, params object[] args)
        {
            #if DEBUG
            builder.SetData("title-localized", true);
            builder.SetData("title-key", titleKey);
            #endif
            builder.SetTitle(WebLocalizer.GetInternal(titleKey, args));
            return builder;
        }

        #endregion
    }
}