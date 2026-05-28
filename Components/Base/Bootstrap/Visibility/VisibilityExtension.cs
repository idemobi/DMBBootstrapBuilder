#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj VisibilityExtension.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring visibility in BootstrapBuilder components.
    /// </summary>
    public static class VisibilityExtension
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="visibility">The visibility value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this Visibility visibility)
        {
            return visibility switch
            {
                Visibility.Normal => string.Empty,
                Visibility.Visible => "visible",
                Visibility.Invisible => "invisible",
                _ => string.Empty
            };
        }

        /// <summary>
        /// Configures invisible on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetInvisible<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseVisibility
        {
            return builder.SetVisibility(Visibility.Invisible);
        }

        /// <summary>
        /// Configures visibility on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="visibility">The visibility value.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetVisibility<TBuilder>(
            this TBuilder builder,
            Visibility visibility
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseVisibility
        {
            VisibilityComposer composer =
                builder.GetOrCreateCssComposer(() => new VisibilityComposer());

            composer.Set(visibility);

            return builder;
        }

        /// <summary>
        /// Configures visibility normal on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetVisibilityNormal<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseVisibility
        {
            return builder.SetVisibility(Visibility.Normal);
        }

        /// <summary>
        /// Configures visible on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetVisible<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseVisibility
        {
            return builder.SetVisibility(Visibility.Visible);
        }

        #endregion
    }
}