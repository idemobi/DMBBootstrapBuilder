#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj FlexWrapExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring flex wrap in BootstrapBuilder components.
    /// </summary>
    public static class FlexWrapExtensions
    {
        #region Static methods

        /// <summary>
        /// Configures flex no wrap on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFlexNoWrap<TBuilder>(
            this TBuilder builder,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlexWrap
        {
            return builder.SetFlexWrap(FlexWrap.NoWrap, breakpoint);
        }

        /// <summary>
        /// Configures flex wrap on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="flexWrap">The flex wrap value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFlexWrap<TBuilder>(
            this TBuilder builder,
            FlexWrap flexWrap,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlexWrap
        {
            FlexWrapComposer composer =
                builder.GetOrCreateCssComposer(() => new FlexWrapComposer());

            composer.Set(flexWrap, breakpoint);

            return builder;
        }

        /// <summary>
        /// Configures flex wrap normal on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFlexWrapNormal<TBuilder>(
            this TBuilder builder,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlexWrap
        {
            return builder.SetFlexWrap(FlexWrap.Wrap, breakpoint);
        }

        /// <summary>
        /// Configures flex wrap reverse on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFlexWrapReverse<TBuilder>(
            this TBuilder builder,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlexWrap
        {
            return builder.SetFlexWrap(FlexWrap.WrapReverse, breakpoint);
        }

        #endregion
    }
}