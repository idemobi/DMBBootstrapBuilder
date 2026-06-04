#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring tab block in BootstrapBuilder components.
    /// </summary>
    public static class TabBlockExtensions
    {
        #region Static methods

        private static TabBlockComposer GetTabBlockComposer<TBuilder>(TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTabBlock
        {
            return builder.GetOrCreateCssComposer(() => new TabBlockComposer());
        }

        /// <summary>
        ///     Configures tab block active on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTabBlockActive<TBuilder>(
            this TBuilder builder,
            bool value = true
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTabBlock
        {
            GetTabBlockComposer(builder).SetActive(value);
            return builder;
        }

        /// <summary>
        ///     Configures tab block disabled on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTabBlockDisabled<TBuilder>(
            this TBuilder builder,
            bool value = true
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTabBlock
        {
            GetTabBlockComposer(builder).SetDisabled(value);
            return builder;
        }

        /// <summary>
        ///     Configures tab block fade on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTabBlockFade<TBuilder>(
            this TBuilder builder,
            bool value = true
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTabBlock
        {
            GetTabBlockComposer(builder).SetFade(value);
            return builder;
        }

        #endregion
    }
}