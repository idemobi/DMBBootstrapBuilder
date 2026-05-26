#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ShadowExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring shadow in BootstrapBuilder components.
    /// </summary>
    public static class ShadowExtensions
    {
        #region Static methods

        /// <summary>
        /// Configures shadow on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="shadow">The shadow value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        [Documented]
        public static TBuilder SetShadow<TBuilder>(
            this TBuilder builder,
            Shadow shadow
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseShadow
        {
            ShadowComposer composer =
                builder.GetOrCreateCssComposer(() => new ShadowComposer());

            composer.Set(shadow);

            return builder;
        }

        /// <summary>
        /// Configures shadow large on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        [Documented]
        public static TBuilder SetShadowLarge<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseShadow
        {
            return builder.SetShadow(Shadow.Large);
        }

        /// <summary>
        /// Configures shadow none on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        [Documented]
        public static TBuilder SetShadowNone<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseShadow
        {
            return builder.SetShadow(Shadow.None);
        }

        /// <summary>
        /// Configures shadow normal on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        [Documented]
        public static TBuilder SetShadowNormal<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseShadow
        {
            return builder.SetShadow(Shadow.Normal);
        }

        /// <summary>
        /// Configures shadow regular on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        [Documented]
        public static TBuilder SetShadowRegular<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseShadow
        {
            return builder.SetShadow(Shadow.Regular);
        }

        /// <summary>
        /// Configures shadow small on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        [Documented]
        public static TBuilder SetShadowSmall<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseShadow
        {
            return builder.SetShadow(Shadow.Small);
        }

        /// <summary>
        /// Configures text shadow on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="shadow">The shadow value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        [Documented]
        public static TBuilder SetTextShadow<TBuilder>(
            this TBuilder builder,
            Shadow shadow
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTextShadow
        {
            TextShadowComposer composer =
                builder.GetOrCreateCssComposer(() => new TextShadowComposer());

            composer.Set(shadow);

            return builder;
        }

        #endregion
    }
}