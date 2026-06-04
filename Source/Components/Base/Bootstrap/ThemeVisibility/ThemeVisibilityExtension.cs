#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Collections.Generic;
using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Defines the contract for BootstrapBuilder components that can configure theme visibility.
    /// </summary>
    public interface ICanUseThemeVisibility
    {
    }

    /// <summary>
    ///     Composes Bootstrap CSS classes or page chrome for theme visibility.
    /// </summary>
    public sealed class ThemeVisibilityComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private ThemeVisibility _visibility = ThemeVisibility.Always;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="visibility">The visibility value.</param>
        /// <returns>The configured <see cref="ThemeVisibilityComposer" /> value or BootstrapBuilder result.</returns>
        public ThemeVisibilityComposer Set(ThemeVisibility visibility)
        {
            _visibility = visibility;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        ///     Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            string css = _visibility.GetCss();

            if (string.IsNullOrWhiteSpace(css))
            {
                return Array.Empty<string>();
            }

            return new[] { css };
        }

        /// <summary>
        ///     Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IIsCssClassComposer" /> value or BootstrapBuilder result.</returns>
        public IIsCssClassComposer Clone()
        {
            var clone = new ThemeVisibilityComposer();
            clone.Set(_visibility);
            return clone;
        }

        #endregion

        #endregion
    }

    /// <summary>
    ///     Provides extension methods for configuring theme visibility in BootstrapBuilder components.
    /// </summary>
    public static class ThemeVisibilityExtension
    {
        #region Static methods

        /// <summary>
        ///     Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this ThemeVisibility value)
        {
            return value switch
            {
                ThemeVisibility.Always => "",
                ThemeVisibility.DarkOnly => "theme-dark-only",
                ThemeVisibility.LightOnly => "theme-light-only",
                _ => string.Empty
            };
        }

        /// <summary>
        ///     Configures dark only on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetDarkOnly<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseThemeVisibility
        {
            return builder.SetThemeVisibility(ThemeVisibility.DarkOnly);
        }

        /// <summary>
        ///     Configures light only on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetLightOnly<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseThemeVisibility
        {
            return builder.SetThemeVisibility(ThemeVisibility.LightOnly);
        }

        /// <summary>
        ///     Configures theme always on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetThemeAlways<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseThemeVisibility
        {
            return builder.SetThemeVisibility(ThemeVisibility.Always);
        }

        /// <summary>
        ///     Configures theme visibility on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="visibility">The visibility value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetThemeVisibility<TBuilder>(
            this TBuilder builder,
            ThemeVisibility visibility
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseThemeVisibility
        {
            ThemeVisibilityComposer composer = builder.GetOrCreateCssComposer(() => new ThemeVisibilityComposer());
            composer.Set(visibility);
            return builder;
        }

        #endregion
    }
}