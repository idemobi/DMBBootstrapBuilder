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
    ///     Provides extension methods for configuring font size in BootstrapBuilder components.
    /// </summary>
    public static class FontSizeExtension
    {
        #region Static methods

        /// <summary>
        ///     Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this FontSize value)
        {
            return value switch
            {
                FontSize.Normal => "",
                FontSize.FS1 => "fs-1",
                FontSize.FS2 => "fs-2",
                FontSize.FS3 => "fs-3",
                FontSize.FS4 => "fs-4",
                FontSize.FS5 => "fs-5",
                FontSize.FS6 => "fs-6",
                _ => string.Empty
            };
        }

        /// <summary>
        ///     Configures font size on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="fontSize">The font size value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetFontSize<TBuilder>(
            this TBuilder builder,
            FontSize fontSize
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFontSize
        {
            FontSizeComposer composer =
                builder.GetOrCreateCssComposer(() => new FontSizeComposer());

            composer.Set(fontSize);

            return builder;
        }

        #endregion
    }
}