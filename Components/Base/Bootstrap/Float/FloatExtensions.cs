#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj FloatExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring float in BootstrapBuilder components.
    /// </summary>
    public static class FloatExtensions
    {
        #region Static methods

        /// <summary>
        /// Configures float on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFloat<TBuilder>(
            this TBuilder builder,
            Float value,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFloat
        {
            FloatComposer composer =
                builder.GetOrCreateCssComposer(() => new FloatComposer());

            composer.Set(value, breakpoint);

            return builder;
        }

        /// <summary>
        /// Configures float end on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFloatEnd<TBuilder>(
            this TBuilder builder,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFloat
        {
            return builder.SetFloat(Float.End, breakpoint);
        }

        /// <summary>
        /// Configures float none on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFloatNone<TBuilder>(
            this TBuilder builder,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFloat
        {
            return builder.SetFloat(Float.None, breakpoint);
        }

        /// <summary>
        /// Configures float normal on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFloatNormal<TBuilder>(
            this TBuilder builder,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFloat
        {
            return builder.SetFloat(Float.Normal, breakpoint);
        }

        /// <summary>
        /// Configures float start on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFloatStart<TBuilder>(
            this TBuilder builder,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFloat
        {
            return builder.SetFloat(Float.Start, breakpoint);
        }

        #endregion
    }
}