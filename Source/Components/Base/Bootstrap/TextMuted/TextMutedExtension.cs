#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring text muted in BootstrapBuilder components.
    /// </summary>
    public static class TextMutedExtension
    {
        #region Static methods

        /// <summary>
        ///     Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this TextMuted value)
        {
            return value switch
            {
                TextMuted.None => "",
                TextMuted.Muted => "text-muted",
                _ => string.Empty
            };
        }

        /// <summary>
        ///     Configures text muted on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="textMuted">The text muted value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTextMuted<TBuilder>(
            this TBuilder builder,
            TextMuted textMuted = TextMuted.Muted
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTextMuted
        {
            TextMutedComposer composer = builder.GetOrCreateCssComposer(() => new TextMutedComposer());
            composer.Set(textMuted);
            return builder;
        }

        #endregion
    }
}