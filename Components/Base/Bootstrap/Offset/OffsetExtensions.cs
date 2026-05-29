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
    ///     Provides extension methods for configuring offset in BootstrapBuilder components.
    /// </summary>
    public static class OffsetExtensions
    {
        #region Static methods

        /// <summary>
        ///     Configures offset on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="offset">The offset value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetOffset<TBuilder>(
            this TBuilder builder,
            Offset offset,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseOffset
        {
            var composer = builder.GetOrCreateCssComposer(() => new OffsetComposer());
            composer.Set(offset, breakpoint);
            return builder;
        }

        #endregion
    }
}