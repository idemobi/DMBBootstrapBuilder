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
    ///     Provides extension methods for configuring font weight in BootstrapBuilder components.
    /// </summary>
    public static class FontWeightExtension
    {
        #region Static methods

        /// <summary>
        ///     Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this FontWeight value)
        {
            return value switch
            {
                FontWeight.None => "",
                FontWeight.Bold => "fw-bold",
                FontWeight.Bolder => "fw-bolder",
                FontWeight.SemiBold => "fw-semibold",
                FontWeight.Normal => "fw-normal",
                FontWeight.Medium => "fw-medium",
                FontWeight.Light => "fw-light",
                FontWeight.Lighter => "fw-lighter",
                _ => string.Empty
            };
        }

        /// <summary>
        ///     Configures font weight on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="fontWeight">The font weight value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFontWeight<TBuilder>(
            this TBuilder builder,
            FontWeight fontWeight
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFontWeight
        {
            FontWeightComposer composer =
                builder.GetOrCreateCssComposer(() => new FontWeightComposer());

            composer.Set(fontWeight);

            return builder;
        }

        /// <summary>
        ///     Configures font weight bold on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFontWeightBold<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFontWeight
        {
            return builder.SetFontWeight(FontWeight.Bold);
        }

        /// <summary>
        ///     Configures font weight bolder on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFontWeightBolder<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFontWeight
        {
            return builder.SetFontWeight(FontWeight.Bolder);
        }

        /// <summary>
        ///     Configures font weight light on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFontWeightLight<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFontWeight
        {
            return builder.SetFontWeight(FontWeight.Light);
        }

        /// <summary>
        ///     Configures font weight normal on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFontWeightNormal<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFontWeight
        {
            return builder.SetFontWeight(FontWeight.Normal);
        }

        #endregion
    }
}