#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj WordBreakExtension.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring word break in BootstrapBuilder components.
    /// </summary>
    public static class WordBreakExtension
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this WordBreak value)
        {
            return value switch
            {
                WordBreak.None => "",
                WordBreak.Break => "text-break",
                _ => string.Empty
            };
        }

        /// <summary>
        /// Configures word break on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="wordBreak">The word break value.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetWordBreak<TBuilder>(
            this TBuilder builder,
            WordBreak wordBreak
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseWordBreak
        {
            WordBreakComposer composer =
                builder.GetOrCreateCssComposer(() => new WordBreakComposer());

            composer.Set(wordBreak);

            return builder;
        }

        #endregion
    }
}