#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj PaddingExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring padding in BootstrapBuilder components.
    /// </summary>
    public static class PaddingExtensions
    {
        #region Static methods

        /// <summary>
        /// Configures padding on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="side">The side value.</param>
        /// <param name="size">The size value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetPadding<TBuilder>(
            this TBuilder builder,
            SpacingSide side,
            SpacingSize size,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUsePadding
        {
            SpacingComposer composer = builder.GetOrCreateCssComposer(() => new SpacingComposer());
            composer.Padding(side, size, breakpoint);
            return builder;
        }

        #endregion
    }
}