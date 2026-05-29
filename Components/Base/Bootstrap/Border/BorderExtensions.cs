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
    ///     Provides extension methods for configuring border in BootstrapBuilder components.
    /// </summary>
    public static class BorderExtensions
    {
        #region Static methods

        /// <summary>
        ///     Removes border from the current BootstrapBuilder component or composer.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="side">The side value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder RemoveBorder<TBuilder>(
            this TBuilder builder,
            BorderSide side = BorderSide.All,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseBorder
        {
            BorderComposer composer = builder.GetOrCreateCssComposer(() => new BorderComposer());
            composer.NoBorder(side, breakpoint);
            return builder;
        }

        /// <summary>
        ///     Configures border on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="side">The side value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetBorder<TBuilder>(
            this TBuilder builder,
            BorderSide side = BorderSide.All,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseBorder
        {
            BorderComposer composer = builder.GetOrCreateCssComposer(() => new BorderComposer());
            composer.Border(side, breakpoint);
            return builder;
        }

        /// <summary>
        ///     Configures border color on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="color">The color value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetBorderColor<TBuilder>(
            this TBuilder builder,
            BorderColor color,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseBorder
        {
            BorderComposer composer = builder.GetOrCreateCssComposer(() => new BorderComposer());
            composer.BorderColor(color, breakpoint);
            return builder;
        }

        /// <summary>
        ///     Configures border opacity on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="opacity">The opacity value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetBorderOpacity<TBuilder>(
            this TBuilder builder,
            BorderOpacity opacity,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseBorder
        {
            BorderComposer composer = builder.GetOrCreateCssComposer(() => new BorderComposer());
            composer.BorderOpacity(opacity, breakpoint);
            return builder;
        }

        #endregion
    }
}