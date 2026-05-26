#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj TextDecorationExtension.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring text decoration in BootstrapBuilder components.
    /// </summary>
    public static class TextDecorationExtension
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this TextDecoration value)
        {
            return value switch
            {
                TextDecoration.None => "",
                TextDecoration.CancelDecoration => "text-decoration-none",
                TextDecoration.Underline => "text-decoration-underline",
                TextDecoration.LineThrough => "text-decoration-line-through",
                _ => string.Empty
            };
        }

        /// <summary>
        /// Configures text decoration on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="textDecoration">The text decoration value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTextDecoration<TBuilder>(
            this TBuilder builder,
            TextDecoration textDecoration
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTextDecoration
        {
            TextDecorationComposer composer =
                builder.GetOrCreateCssComposer(() => new TextDecorationComposer());

            composer.Set(textDecoration);

            return builder;
        }

        /// <summary>
        /// Configures text line through on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTextLineThrough<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTextDecoration
        {
            return builder.SetTextDecoration(TextDecoration.LineThrough);
        }

        /// <summary>
        /// Configures text no decoration on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTextNoDecoration<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTextDecoration
        {
            return builder.SetTextDecoration(TextDecoration.None);
        }

        /// <summary>
        /// Configures text underline on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetTextUnderline<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTextDecoration
        {
            return builder.SetTextDecoration(TextDecoration.Underline);
        }

        #endregion
    }
}