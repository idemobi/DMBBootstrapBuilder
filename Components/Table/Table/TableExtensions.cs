#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj TableExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring table in BootstrapBuilder components.
    /// </summary>
    public static class TableExtensions
    {
        #region Static methods

        private static TableComposer GetTableComposer<TBuilder>(TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTable
        {
            return builder.GetOrCreateCssComposer(() => new TableComposer());
        }


        /// <summary>
        /// Configures caption top on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetCaptionTop<TBuilder>(
            this TBuilder builder,
            bool value = true
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTable
        {
            GetTableComposer(builder).SetCaptionTop(value);
            return builder;
        }

        /// <summary>
        /// Configures table bordered on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTableBordered<TBuilder>(
            this TBuilder builder,
            bool value = true
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTable
        {
            GetTableComposer(builder).SetBordered(value);
            return builder;
        }

        /// <summary>
        /// Configures table borderless on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTableBorderless<TBuilder>(
            this TBuilder builder,
            bool value = true
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTable
        {
            GetTableComposer(builder).SetBorderless(value);
            return builder;
        }

        /// <summary>
        /// Configures table dark on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTableDark<TBuilder>(
            this TBuilder builder,
            bool value = true
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTable
        {
            GetTableComposer(builder).SetDark(value);
            return builder;
        }

        /// <summary>
        /// Configures table hover on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTableHover<TBuilder>(
            this TBuilder builder,
            bool value = true
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTable
        {
            GetTableComposer(builder).SetHover(value);
            return builder;
        }

        /// <summary>
        /// Configures table small on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTableSmall<TBuilder>(
            this TBuilder builder,
            bool value = true
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTable
        {
            GetTableComposer(builder).SetSmall(value);
            return builder;
        }

        /// <summary>
        /// Configures table sortable on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTableSortable<TBuilder>(
            this TBuilder builder,
            bool value = true
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTable
        {
            GetTableComposer(builder).SetSortable(value);

            if (value)
            {
                builder.SetData("sortable", "true");
            }

            return builder;
        }

        /// <summary>
        /// Configures table striped on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTableStriped<TBuilder>(
            this TBuilder builder,
            bool value = true
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTable
        {
            GetTableComposer(builder).SetStriped(value);
            return builder;
        }

        /// <summary>
        /// Configures table striped columns on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTableStripedColumns<TBuilder>(
            this TBuilder builder,
            bool value = true
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTable
        {
            GetTableComposer(builder).SetStripedColumns(value);
            return builder;
        }

        #endregion
    }
}