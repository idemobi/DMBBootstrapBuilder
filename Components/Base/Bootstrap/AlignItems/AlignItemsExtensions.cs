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
    ///     Provides extension methods for configuring align items in BootstrapBuilder components.
    /// </summary>
    public static class AlignItemsExtensions
    {
        #region Static methods

        /// <summary>
        ///     Configures align items on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="alignItems">The align items value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetAlignItems<TBuilder>(
            this TBuilder builder,
            AlignItems alignItems,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseAlignItems
        {
            AlignItemsComposer composer =
                builder.GetOrCreateCssComposer(() => new AlignItemsComposer());

            composer.Set(alignItems, breakpoint);

            return builder;
        }

        #endregion
    }
}