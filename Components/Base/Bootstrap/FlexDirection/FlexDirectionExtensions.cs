#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj FlexDirectionExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring flex direction in BootstrapBuilder components.
    /// </summary>
    public static class FlexDirectionExtensions
    {
        #region Static methods

        /// <summary>
        /// Configures flex column on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFlexColumn<TBuilder>(
            this TBuilder builder,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlexDirection
        {
            return builder.SetFlexDirection(FlexDirection.Column, breakpoint);
        }

        /// <summary>
        /// Configures flex column reverse on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFlexColumnReverse<TBuilder>(
            this TBuilder builder,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlexDirection
        {
            return builder.SetFlexDirection(FlexDirection.ColumnReverse, breakpoint);
        }

        /// <summary>
        /// Configures flex direction on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="flexDirection">The flex direction value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFlexDirection<TBuilder>(
            this TBuilder builder,
            FlexDirection flexDirection,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlexDirection
        {
            FlexDirectionComposer composer =
                builder.GetOrCreateCssComposer(() => new FlexDirectionComposer());

            composer.Set(flexDirection, breakpoint);

            return builder;
        }

        /// <summary>
        /// Configures flex row on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFlexRow<TBuilder>(
            this TBuilder builder,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlexDirection
        {
            return builder.SetFlexDirection(FlexDirection.Row, breakpoint);
        }

        /// <summary>
        /// Configures flex row reverse on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFlexRowReverse<TBuilder>(
            this TBuilder builder,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlexDirection
        {
            return builder.SetFlexDirection(FlexDirection.RowReverse, breakpoint);
        }

        #endregion
    }
}