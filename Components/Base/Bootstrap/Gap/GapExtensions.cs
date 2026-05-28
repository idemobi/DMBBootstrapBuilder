#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj GapExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring gap in BootstrapBuilder components.
    /// </summary>
    public static class GapExtensions
    {
        #region Static methods

        /// <summary>
        /// Configures gap on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="gap">The gap value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetGap<TBuilder>(
            this TBuilder builder,
            Gap gap,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseGridGap
        {
            GapComposer composer = builder.GetOrCreateCssComposer(() => new GapComposer());
            composer.Set(gap, breakpoint);
            return builder;
        }

        /// <summary>
        /// Configures gap x on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="gap">The gap value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetGapX<TBuilder>(
            this TBuilder builder,
            Gap gap,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseGridGapX
        {
            GapComposer composer = builder.GetOrCreateCssComposer(() => new GapComposer());
            composer.SetX(gap, breakpoint);
            return builder;
        }

        /// <summary>
        /// Configures gap y on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="gap">The gap value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetGapY<TBuilder>(
            this TBuilder builder,
            Gap gap,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseGridGapY
        {
            GapComposer composer = builder.GetOrCreateCssComposer(() => new GapComposer());
            composer.SetY(gap, breakpoint);
            return builder;
        }

        #endregion
    }
}