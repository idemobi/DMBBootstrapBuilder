#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj MonospaceExtension.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring monospace in BootstrapBuilder components.
    /// </summary>
    public static class MonospaceExtension
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this Monospace value)
        {
            return value switch
            {
                Monospace.None => "",
                Monospace.Monospace => "font-monospace",
                _ => string.Empty
            };
        }

        /// <summary>
        /// Configures monospace on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="monospace">The monospace value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetMonospace<TBuilder>(
            this TBuilder builder,
            Monospace monospace
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseMonospace
        {
            MonospaceComposer composer =
                builder.GetOrCreateCssComposer(() => new MonospaceComposer());

            composer.Set(monospace);

            return builder;
        }

        #endregion
    }
}