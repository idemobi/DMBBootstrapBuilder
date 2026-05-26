#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj CssGridSpanExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring css grid span in BootstrapBuilder components.
    /// </summary>
    public static class CssGridSpanExtensions
    {
        #region Static methods

        /// <summary>
        /// Configures css grid span on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="span">The span value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetCssGridSpan<TBuilder>(
            this TBuilder builder,
            CssGridSpan span,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseCssGridSpan
        {
            CssGridSpanComposer composer = builder.GetOrCreateCssComposer(() => new CssGridSpanComposer());
            composer.Set(span, breakpoint);
            return builder;
        }

        #endregion
    }
}