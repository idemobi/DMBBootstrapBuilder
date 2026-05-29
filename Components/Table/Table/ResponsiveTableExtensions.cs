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
    ///     Provides extension methods for configuring responsive table in BootstrapBuilder components.
    /// </summary>
    public static class ResponsiveTableExtensions
    {
        #region Static methods

        /// <summary>
        ///     Configures responsive table on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetResponsiveTable<TBuilder>(
            this TBuilder builder,
            TableResponsiveBreakpoint breakpoint = TableResponsiveBreakpoint.Always
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseResponsiveTable
        {
            ResponsiveTableComposer composer =
                builder.GetOrCreateCssComposer(() => new ResponsiveTableComposer());

            composer.Set(breakpoint);

            return builder;
        }

        /// <summary>
        ///     Configures responsive table always on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetResponsiveTableAlways<TBuilder>(
            this TBuilder builder
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseResponsiveTable
        {
            return builder.SetResponsiveTable(TableResponsiveBreakpoint.Always);
        }

        /// <summary>
        ///     Configures responsive table lg on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetResponsiveTableLg<TBuilder>(
            this TBuilder builder
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseResponsiveTable
        {
            return builder.SetResponsiveTable(TableResponsiveBreakpoint.Lg);
        }

        /// <summary>
        ///     Configures responsive table md on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetResponsiveTableMd<TBuilder>(
            this TBuilder builder
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseResponsiveTable
        {
            return builder.SetResponsiveTable(TableResponsiveBreakpoint.Md);
        }

        /// <summary>
        ///     Configures responsive table none on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetResponsiveTableNone<TBuilder>(
            this TBuilder builder
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseResponsiveTable
        {
            return builder.SetResponsiveTable(TableResponsiveBreakpoint.None);
        }

        /// <summary>
        ///     Configures responsive table sm on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetResponsiveTableSm<TBuilder>(
            this TBuilder builder
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseResponsiveTable
        {
            return builder.SetResponsiveTable(TableResponsiveBreakpoint.Sm);
        }

        /// <summary>
        ///     Configures responsive table xl on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetResponsiveTableXl<TBuilder>(
            this TBuilder builder
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseResponsiveTable
        {
            return builder.SetResponsiveTable(TableResponsiveBreakpoint.Xl);
        }

        /// <summary>
        ///     Configures responsive table xxl on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetResponsiveTableXxl<TBuilder>(
            this TBuilder builder
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseResponsiveTable
        {
            return builder.SetResponsiveTable(TableResponsiveBreakpoint.Xxl);
        }

        #endregion
    }
}