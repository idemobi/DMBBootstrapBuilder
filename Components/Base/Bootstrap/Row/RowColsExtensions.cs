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
    ///     Provides extension methods for configuring row cols in BootstrapBuilder components.
    /// </summary>
    public static class RowColsExtensions
    {
        #region Static methods

        /// <summary>
        ///     Configures row cols on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="size">The size value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetRowCols<TBuilder>(
            this TBuilder builder,
            RowColsSize size,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseRowCols
        {
            var composer = builder.GetOrCreateCssComposer(() => new RowColsComposer());
            composer.Set(size, breakpoint);
            return builder;
        }

        #endregion
    }
}