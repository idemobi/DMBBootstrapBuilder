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
    ///     Provides extension methods for configuring border radius in BootstrapBuilder components.
    /// </summary>
    public static class BorderRadiusExtensions
    {
        #region Static methods

        /// <summary>
        ///     Configures rounded on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="size">The size value.</param>
        /// <param name="side">The side value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetRounded<TBuilder>(
            this TBuilder builder,
            BorderRadiusSize size = BorderRadiusSize.Normal,
            BorderRadiusSide side = BorderRadiusSide.All,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseBorderRadius
        {
            BorderComposer composer = builder.GetOrCreateCssComposer(() => new BorderComposer());
            composer.Rounded(size, side, breakpoint);
            return builder;
        }

        #endregion
    }
}