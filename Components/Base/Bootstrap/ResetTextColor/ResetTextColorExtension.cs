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
    ///     Provides extension methods for configuring reset text color in BootstrapBuilder components.
    /// </summary>
    public static class ResetTextColorExtension
    {
        #region Static methods

        /// <summary>
        ///     Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this ResetTextColor value)
        {
            return value switch
            {
                ResetTextColor.Normal => string.Empty,
                ResetTextColor.Reset => "text-reset",
                _ => string.Empty
            };
        }

        /// <summary>
        ///     Configures reset text color on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="resetTextColor">The reset text color value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetResetTextColor<TBuilder>(
            this TBuilder builder,
            ResetTextColor resetTextColor
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseResetTextColor
        {
            ResetTextColorComposer composer =
                builder.GetOrCreateCssComposer(() => new ResetTextColorComposer());

            composer.Set(resetTextColor);

            return builder;
        }

        #endregion
    }
}