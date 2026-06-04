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
    ///     Provides extension methods for configuring css grid start in BootstrapBuilder components.
    /// </summary>
    public static class CssGridStartExtensions
    {
        #region Static methods

        /// <summary>
        ///     Configures css grid start on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="start">The start value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetCssGridStart<TBuilder>(
            this TBuilder builder,
            CssGridStart start,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseCssGridStart
        {
            CssGridStartComposer composer = builder.GetOrCreateCssComposer(() => new CssGridStartComposer());
            composer.Set(start, breakpoint);
            return builder;
        }

        #endregion
    }
}