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
    ///     Provides extension methods for configuring margin in BootstrapBuilder components.
    /// </summary>
    public static class MarginExtensions
    {
        #region Static methods

        /// <summary>
        ///     Configures margin on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="side">The side value.</param>
        /// <param name="size">The size value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <param name="negative">The negative value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        [Documented]
        public static TBuilder SetMargin<TBuilder>(
            this TBuilder builder,
            SpacingSide side,
            SpacingSize size,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs,
            bool negative = false
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseMargin
        {
            SpacingComposer composer = builder.GetOrCreateCssComposer(() => new SpacingComposer());
            composer.Margin(side, size, breakpoint, negative);
            return builder;
        }

        #endregion
    }
}