#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj TextAlignExtension.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring text align in BootstrapBuilder components.
    /// </summary>
    public static class TextAlignExtension
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="textAlign">The text align value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this TextAlign textAlign)
        {
            return textAlign switch
            {
                TextAlign.Start => "start",
                TextAlign.Center => "center",
                TextAlign.End => "end",
                _ => "start"
            };
        }

        /// <summary>
        /// Gets text css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="align">The align value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetTextCss(this TextAlign align)
        {
            return align switch
            {
                TextAlign.Start => "text-start",
                TextAlign.Center => "text-center",
                TextAlign.End => "text-end",
                _ => string.Empty
            };
        }

        /// <summary>
        /// Configures text align on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="textAlign">The text align value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTextAlign<TBuilder>(
            this TBuilder builder,
            TextAlign textAlign,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTextAlign
        {
            TextAlignComposer composer =
                builder.GetOrCreateCssComposer(() => new TextAlignComposer());

            composer.Set(textAlign, breakpoint);

            return builder;
        }

        #endregion
    }
}