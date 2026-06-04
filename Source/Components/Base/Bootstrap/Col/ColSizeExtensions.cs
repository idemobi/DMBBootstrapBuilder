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
    ///     Provides extension methods for configuring col size in BootstrapBuilder components.
    /// </summary>
    public static class ColSizeExtensions
    {
        #region Static methods

        /// <summary>
        ///     Configures col on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="size">The size value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetCol<TBuilder>(
            this TBuilder builder,
            ColSize size,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseColSize
        {
            var composer = builder.GetOrCreateCssComposer(() => new ColSizeComposer());
            composer.Set(size, breakpoint);
            return builder;
        }

        /// <summary>
        ///     Configures col auto on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetColAuto<TBuilder>(
            this TBuilder builder,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseColSize
        {
            return builder.SetCol(ColSize.Auto, breakpoint);
        }

        /// <summary>
        ///     Configures col grow on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetColGrow<TBuilder>(
            this TBuilder builder,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseColSize
        {
            return builder.SetCol(ColSize.Col, breakpoint);
        }

        #endregion
    }
}