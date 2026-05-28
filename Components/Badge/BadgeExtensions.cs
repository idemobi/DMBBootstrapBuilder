#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj BadgeExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring badge in BootstrapBuilder components.
    /// </summary>
    public static class BadgeExtensions
    {
        #region Static methods

        /// <summary>
        /// Executes the BootstrapBuilder badge builder operation.
        /// </summary>
        /// <param name="htmlHelper">The Razor HTML helper used to access view context and services.</param>
        /// <param name="text">The text value.</param>
        /// <returns>The configured <see cref="BadgeBuilder"/> value or BootstrapBuilder result.</returns>
        public static BadgeBuilder BadgeBuilder(this IHtmlHelper htmlHelper, string? text = null)
        {
            return new BadgeBuilder(htmlHelper.ViewContext.Writer, htmlHelper).SetText(text);
        }

        private static BadgeComposer GetBadgeComposer<TBuilder>(TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseBadge
        {
            return builder.GetOrCreateCssComposer(() => new BadgeComposer());
        }

        /// <summary>
        /// Configures as notification on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetAsNotification<TBuilder>(
            this TBuilder builder,
            bool value = true
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseBadge
        {
            GetBadgeComposer(builder).SetAsNotification(value);
            return builder;
        }

        /// <summary>
        /// Configures badge pill on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetBadgePill<TBuilder>(
            this TBuilder builder,
            bool value = true
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseBadge
        {
            GetBadgeComposer(builder).SetPill(value);
            return builder;
        }

        /// <summary>
        /// Configures badge variant on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="variant">The variant value.</param>
        /// <returns>The configured <typeparamref name="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetBadgeVariant<TBuilder>(
            this TBuilder builder,
            VariantStyle variant
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseBadge
        {
            GetBadgeComposer(builder).SetVariant(variant);
            return builder;
        }

        #endregion
    }
}