#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj VerticalAlignExtension.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring vertical align in BootstrapBuilder components.
    /// </summary>
    public static class VerticalAlignExtension
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="verticalAlign">The vertical align value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this VerticalAlign verticalAlign)
        {
            return verticalAlign switch
            {
                VerticalAlign.Baseline => "align-baseline",
                VerticalAlign.Top => "align-top",
                VerticalAlign.Middle => "align-middle",
                VerticalAlign.Bottom => "align-bottom",
                VerticalAlign.TextTop => "align-text-top",
                VerticalAlign.TextBottom => "align-text-bottom",
                _ => string.Empty
            };
        }

        /// <summary>
        /// Configures vertical align on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="verticalAlign">The vertical align value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetVerticalAlign<TBuilder>(
            this TBuilder builder,
            VerticalAlign verticalAlign
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseVerticalAlign
        {
            VerticalAlignComposer composer =
                builder.GetOrCreateCssComposer(() => new VerticalAlignComposer());

            composer.Set(verticalAlign);

            return builder;
        }

        #endregion
    }
}