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
    ///     Provides extension methods for configuring font italic in BootstrapBuilder components.
    /// </summary>
    public static class FontItalicExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this FontItalic value)
        {
            return value switch
            {
                FontItalic.Normal => "",
                FontItalic.Italic => "fw-italic",
                _ => string.Empty
            };
        }

        /// <summary>
        ///     Configures font italic on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="fontItalic">The font italic value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFontItalic<TBuilder>(
            this TBuilder builder,
            FontItalic fontItalic
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFontItalic
        {
            FontItalicComposer composer = builder.GetOrCreateCssComposer(() => new FontItalicComposer());

            composer.Set(fontItalic);

            return builder;
        }

        /// <summary>
        ///     Configures italic on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetItalic<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFontItalic
        {
            return builder.SetFontItalic(FontItalic.Italic);
        }

        /// <summary>
        ///     Configures not italic on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetNotItalic<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFontItalic
        {
            return builder.SetFontItalic(FontItalic.Normal);
        }

        #endregion
    }
}