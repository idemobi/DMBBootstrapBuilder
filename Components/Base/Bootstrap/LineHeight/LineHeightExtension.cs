#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj LineHeightExtension.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring line height in BootstrapBuilder components.
    /// </summary>
    public static class LineHeightExtension
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this LineHeight value)
        {
            return value switch
            {
                LineHeight.Normal => "",
                LineHeight.LH1 => "lh-1",
                LineHeight.LHsm => "lh-sm",
                LineHeight.LHbase => "lh-base",
                LineHeight.LHlg => "lh-lg",
                _ => string.Empty
            };
        }

        /// <summary>
        /// Configures line height on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="lineHeight">The line height value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetLineHeight<TBuilder>(
            this TBuilder builder,
            LineHeight lineHeight
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseLineHeight
        {
            LineHeightComposer composer =
                builder.GetOrCreateCssComposer(() => new LineHeightComposer());

            composer.Set(lineHeight);

            return builder;
        }

        #endregion
    }
}