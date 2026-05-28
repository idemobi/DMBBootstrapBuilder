#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj WidthExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring width in BootstrapBuilder components.
    /// </summary>
    public static class WidthExtensions
    {
        #region Static methods

        /// <summary>
        /// Stores the unit value used by BootstrapBuilder rendering or composition.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The builder that receives the CSS maximum width style.</param>
        /// <param name="size">The numeric maximum width value.</param>
        /// <param name="unit">The CSS unit appended to <paramref name="size"/>.</param>
        /// <param name="important">Whether the style should be emitted with <c>!important</c>.</param>
        /// <returns>The configured builder for fluent chaining.</returns>
        public static TBuilder SetMaxWidth<TBuilder>(this TBuilder builder, uint size, UnitSize unit = UnitSize.percent, bool important = false) where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseWidth
        {
            builder.SetStyle("max-width", $"{size}{unit.GetCss()}", important);
            return builder;
        }

        /// <summary>
        /// Stores the unit value used by BootstrapBuilder rendering or composition.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The builder that receives the CSS minimum width style.</param>
        /// <param name="size">The numeric minimum width value.</param>
        /// <param name="unit">The CSS unit appended to <paramref name="size"/>.</param>
        /// <param name="important">Whether the style should be emitted with <c>!important</c>.</param>
        /// <returns>The configured builder for fluent chaining.</returns>
        public static TBuilder SetMinWidth<TBuilder>(this TBuilder builder, uint size, UnitSize unit = UnitSize.percent, bool important = false) where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseWidth
        {
            return builder.SetStyle("min-width", $"{size}{unit.GetCss()}", important);
        }

        /// <summary>
        /// Stores the unit value used by BootstrapBuilder rendering or composition.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The builder that receives the CSS width style.</param>
        /// <param name="size">The numeric width value.</param>
        /// <param name="unit">The CSS unit appended to <paramref name="size"/>.</param>
        /// <param name="important">Whether the style should be emitted with <c>!important</c>.</param>
        /// <returns>The configured builder for fluent chaining.</returns>
        public static TBuilder SetWidth<TBuilder>(this TBuilder builder, uint size, UnitSize unit = UnitSize.percent, bool important = false) where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseWidth
        {
            builder.SetStyle("width", $"{size}{unit.GetCss()}", important);
            return builder;
        }

        #endregion
    }
}
