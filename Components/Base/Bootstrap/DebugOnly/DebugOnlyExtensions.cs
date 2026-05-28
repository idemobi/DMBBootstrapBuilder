#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj DebugOnlyExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring debug only in BootstrapBuilder components.
    /// </summary>
    public static class DebugOnlyExtensions
    {
        #region Static methods

        /// <summary>
        /// Executes the BootstrapBuilder disable debug only operation.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder DisableDebugOnly<TBuilder>(
            this TBuilder builder
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseDebugOnly
        {
            return builder.SetDebugOnly(false);
        }

        /// <summary>
        /// Configures debug only on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="enabled">The enabled value.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetDebugOnly<TBuilder>(
            this TBuilder builder,
            bool enabled = true
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseDebugOnly
        {
            DebugOnlyComposer composer = builder.GetOrCreateCssComposer(() => new DebugOnlyComposer());
            composer.Set(enabled);
            return builder;
        }

        #endregion
    }
}