using DMBPageBuilder;

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring tab area in BootstrapBuilder components.
    /// </summary>
    public static class TabAreaExtensions
    {
        #region Static methods

        private static TabAreaComposer GetTabAreaComposer<TBuilder>(TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTabArea
        {
            return builder.GetOrCreateCssComposer(() => new TabAreaComposer());
        }

        /// <summary>
        /// Configures tab area fill on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTabAreaFill<TBuilder>(
            this TBuilder builder,
            bool value = true
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTabArea
        {
            GetTabAreaComposer(builder).SetFill(value);
            return builder;
        }

        /// <summary>
        /// Configures tab area justified on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTabAreaJustified<TBuilder>(
            this TBuilder builder,
            bool value = true
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTabArea
        {
            GetTabAreaComposer(builder).SetJustified(value);
            return builder;
        }

        /// <summary>
        /// Configures tab area style on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="style">The style value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTabAreaStyle<TBuilder>(
            this TBuilder builder,
            TabAreaStyle style
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTabArea
        {
            GetTabAreaComposer(builder).SetStyle(style);
            return builder;
        }

        #endregion
    }
}