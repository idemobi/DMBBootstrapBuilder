#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj TextWrappingExtension.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring text wrapping in BootstrapBuilder components.
    /// </summary>
    public static class TextWrappingExtension
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this TextWrapping value)
        {
            return value switch
            {
                TextWrapping.Normal => "",
                TextWrapping.Wrap => "text-wrap",
                TextWrapping.NoWrap => "text-nowrap",
                _ => string.Empty
            };
        }

        /// <summary>
        /// Configures text wrapping on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="textWrapping">The text wrapping value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTextWrapping<TBuilder>(
            this TBuilder builder,
            TextWrapping textWrapping
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTextWrapping
        {
            TextWrappingComposer composer =
                builder.GetOrCreateCssComposer(() => new TextWrappingComposer());

            composer.Set(textWrapping);

            return builder;
        }

        #endregion
    }
}