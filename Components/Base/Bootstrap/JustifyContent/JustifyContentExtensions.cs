#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj JustifyContentExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring justify content in BootstrapBuilder components.
    /// </summary>
    public static class JustifyContentExtensions
    {
        #region Static methods

        /// <summary>
        /// Configures justify content on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="justifyContent">The justify content value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetJustifyContent<TBuilder>(
            this TBuilder builder,
            JustifyContent justifyContent,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseJustifyContent
        {
            JustifyContentComposer composer =
                builder.GetOrCreateCssComposer(() => new JustifyContentComposer());

            composer.Set(justifyContent, breakpoint);

            return builder;
        }

        #endregion
    }
}