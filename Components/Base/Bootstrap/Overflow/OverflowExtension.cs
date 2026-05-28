#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj OverflowExtension.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring overflow in BootstrapBuilder components.
    /// </summary>
    public static class OverflowExtensions
    {
        #region Static methods

        /// <summary>
        /// Configures overflow on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="overflow">The overflow value.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetOverflow<TBuilder>(
            this TBuilder builder,
            OverflowValue overflow
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseOverflow
        {
            OverflowComposer composer =
                builder.GetOrCreateCssComposer(() => new OverflowComposer());

            composer.Set(overflow);

            return builder;
        }

        /// <summary>
        /// Configures overflow auto on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetOverflowAuto<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseOverflow
        {
            return builder.SetOverflow(OverflowValue.Auto);
        }

        /// <summary>
        /// Configures overflow hidden on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetOverflowHidden<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseOverflow
        {
            return builder.SetOverflow(OverflowValue.Hidden);
        }

        /// <summary>
        /// Configures overflow scroll on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetOverflowScroll<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseOverflow
        {
            return builder.SetOverflow(OverflowValue.Scroll);
        }

        /// <summary>
        /// Configures overflow visible on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetOverflowVisible<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseOverflow
        {
            return builder.SetOverflow(OverflowValue.Visible);
        }

        /// <summary>
        /// Configures overflow x on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="overflow">The overflow value.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetOverflowX<TBuilder>(
            this TBuilder builder,
            OverflowValue overflow
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseOverflow
        {
            OverflowComposer composer =
                builder.GetOrCreateCssComposer(() => new OverflowComposer());

            composer.SetX(overflow);

            return builder;
        }

        /// <summary>
        /// Configures overflow x auto on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetOverflowXAuto<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseOverflow
        {
            return builder.SetOverflowX(OverflowValue.Auto);
        }

        /// <summary>
        /// Configures overflow x hidden on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetOverflowXHidden<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseOverflow
        {
            return builder.SetOverflowX(OverflowValue.Hidden);
        }

        /// <summary>
        /// Configures overflow x scroll on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetOverflowXScroll<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseOverflow
        {
            return builder.SetOverflowX(OverflowValue.Scroll);
        }

        /// <summary>
        /// Configures overflow x visible on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetOverflowXVisible<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseOverflow
        {
            return builder.SetOverflowX(OverflowValue.Visible);
        }

        /// <summary>
        /// Configures overflow y on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="overflow">The overflow value.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetOverflowY<TBuilder>(
            this TBuilder builder,
            OverflowValue overflow
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseOverflow
        {
            OverflowComposer composer =
                builder.GetOrCreateCssComposer(() => new OverflowComposer());

            composer.SetY(overflow);

            return builder;
        }

        /// <summary>
        /// Configures overflow y auto on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetOverflowYAuto<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseOverflow
        {
            return builder.SetOverflowY(OverflowValue.Auto);
        }

        /// <summary>
        /// Configures overflow y hidden on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetOverflowYHidden<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseOverflow
        {
            return builder.SetOverflowY(OverflowValue.Hidden);
        }

        /// <summary>
        /// Configures overflow y scroll on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetOverflowYScroll<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseOverflow
        {
            return builder.SetOverflowY(OverflowValue.Scroll);
        }

        /// <summary>
        /// Configures overflow y visible on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetOverflowYVisible<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseOverflow
        {
            return builder.SetOverflowY(OverflowValue.Visible);
        }

        #endregion
    }
}