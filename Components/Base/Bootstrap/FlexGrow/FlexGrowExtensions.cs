#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj FlexGrowExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring flex grow in BootstrapBuilder components.
    /// </summary>
    public static class FlexGrowExtensions
    {
        #region Static methods

        /// <summary>
        /// Configures flex grow on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFlexGrow<TBuilder>(
            this TBuilder builder,
            FlexGrow value
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlexGrow
        {
            var composer = builder.GetOrCreateCssComposer(() => new FlexGrowComposer());
            composer.Set(value);
            return builder;
        }

        /// <summary>
        /// Configures flex grow on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFlexGrow<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlexGrow
            => builder.SetFlexGrow(FlexGrow.Grow);

        /// <summary>
        /// Configures flex no grow on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFlexNoGrow<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlexGrow
            => builder.SetFlexGrow(FlexGrow.NoGrow);

        #endregion
    }
}