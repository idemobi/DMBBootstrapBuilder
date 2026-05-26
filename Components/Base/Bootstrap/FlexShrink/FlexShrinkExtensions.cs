#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj FlexShrinkExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring flex shrink in BootstrapBuilder components.
    /// </summary>
    public static class FlexShrinkExtensions
    {
        #region Static methods

        /// <summary>
        /// Configures flex no shrink on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFlexNoShrink<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlexShrink
            => builder.SetFlexShrink(FlexShrink.NoShrink);

        /// <summary>
        /// Configures flex shrink on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFlexShrink<TBuilder>(
            this TBuilder builder,
            FlexShrink value
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlexShrink
        {
            var composer = builder.GetOrCreateCssComposer(() => new FlexShrinkComposer());
            composer.Set(value);
            return builder;
        }

        /// <summary>
        /// Configures flex shrink on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFlexShrink<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlexShrink
            => builder.SetFlexShrink(FlexShrink.Shrink);

        #endregion
    }
}