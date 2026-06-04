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
    ///     Provides extension methods for working with <see cref="TextTransform" /> enumeration
    ///     and applying text transformation styles to classes derived from
    ///     <see cref="HtmlBuilderBase{TBuilder}" />.
    /// </summary>
    public static class TextTransformExtension
    {
        #region Static methods

        /// <summary>
        ///     Converts a <see cref="TextTransform" /> value to its corresponding CSS class string representation.
        /// </summary>
        /// <param name="value">The <see cref="TextTransform" /> value to convert.</param>
        /// <returns>
        ///     A string representing the CSS class for the given <see cref="TextTransform" /> value.
        ///     If the value is <see cref="TextTransform.Normal" />, an empty string is returned.
        ///     For unrecognized values, an empty string is also returned.
        /// </returns>
        public static string GetCss(this TextTransform value)
        {
            return value switch
            {
                TextTransform.Normal => "",
                TextTransform.Uppercase => "text-uppercase",
                TextTransform.Lowercase => "text-lowercase",
                TextTransform.Capitalize => "text-capitalize",
                _ => string.Empty
            };
        }

        /// <summary>
        ///     Sets the text transform style for a builder instance.
        /// </summary>
        /// <typeparam name="TBuilder">
        ///     The type of the builder, which must derive from <see cref="HtmlBuilderBase{TBuilder}" /> and
        ///     implement <see cref="ICanUseTextTransform" />.
        /// </typeparam>
        /// <param name="builder">The builder instance that this method extends.</param>
        /// <param name="textTransform">The <see cref="TextTransform" /> enum value that specifies the desired text transformation.</param>
        /// <returns>The builder instance of type <typeparamref name="TBuilder" /> with the text transform style applied.</returns>
        [Documented]
        public static TBuilder SetTextTransform<TBuilder>(
            this TBuilder builder,
            TextTransform textTransform
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseTextTransform
        {
            TextTransformComposer composer =
                builder.GetOrCreateCssComposer(() => new TextTransformComposer());

            composer.Set(textTransform);

            return builder;
        }

        #endregion
    }
}