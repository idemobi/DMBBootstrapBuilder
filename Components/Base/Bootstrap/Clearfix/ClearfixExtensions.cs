#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ClearfixExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring clearfix in BootstrapBuilder components.
    /// </summary>
    public static class ClearfixExtensions
    {
        #region Static methods

        /// <summary>
        /// Configures clearfix on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="clearfix">The clearfix value.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetClearfix<TBuilder>(
            this TBuilder builder,
            Clearfix clearfix
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseClearfix
        {
            ClearfixComposer composer =
                builder.GetOrCreateCssComposer(() => new ClearfixComposer());

            composer.Set(clearfix);

            return builder;
        }

        /// <summary>
        /// Configures clearfix on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetClearfix<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseClearfix
        {
            return builder.SetClearfix(Clearfix.Clearfix);
        }

        /// <summary>
        /// Configures clearfix normal on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetClearfixNormal<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseClearfix
        {
            return builder.SetClearfix(Clearfix.Normal);
        }

        #endregion
    }
}