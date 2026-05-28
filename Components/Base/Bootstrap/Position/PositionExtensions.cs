#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj PositionExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring position in BootstrapBuilder components.
    /// </summary>
    public static class PositionExtensions
    {
        #region Static methods

        /// <summary>
        /// Configures bottom on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetBottom<TBuilder>(this TBuilder builder, PositionValue value)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUsePosition
        {
            PositionComposer composer = builder.GetOrCreateCssComposer(() => new PositionComposer());
            composer.SetBottom(value);
            return builder;
        }

        /// <summary>
        /// Configures end on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetEnd<TBuilder>(this TBuilder builder, PositionValue value)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUsePosition
        {
            PositionComposer composer = builder.GetOrCreateCssComposer(() => new PositionComposer());
            composer.SetEnd(value);
            return builder;
        }

        /// <summary>
        /// Configures position on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="position">The position value.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetPosition<TBuilder>(this TBuilder builder, Position position)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUsePosition
        {
            PositionComposer composer = builder.GetOrCreateCssComposer(() => new PositionComposer());
            composer.SetPosition(position);
            return builder;
        }

        /// <summary>
        /// Configures start on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetStart<TBuilder>(this TBuilder builder, PositionValue value)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUsePosition
        {
            PositionComposer composer = builder.GetOrCreateCssComposer(() => new PositionComposer());
            composer.SetStart(value);
            return builder;
        }

        /// <summary>
        /// Configures top on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTop<TBuilder>(this TBuilder builder, PositionValue value)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUsePosition
        {
            PositionComposer composer = builder.GetOrCreateCssComposer(() => new PositionComposer());
            composer.SetTop(value);
            return builder;
        }

        /// <summary>
        /// Configures translate on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="mode">The mode value.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTranslate<TBuilder>(this TBuilder builder, TranslateMode mode)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUsePosition
        {
            PositionComposer composer = builder.GetOrCreateCssComposer(() => new PositionComposer());
            composer.SetTranslate(mode);
            return builder;
        }

        #endregion
    }
}