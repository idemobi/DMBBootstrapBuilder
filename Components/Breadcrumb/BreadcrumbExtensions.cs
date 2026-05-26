#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj BreadcrumbExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring breadcrumb in BootstrapBuilder components.
    /// </summary>
    public static class BreadcrumbExtensions
    {
        #region Static methods

        /// <summary>
        /// Executes the BootstrapBuilder breadcrumb builder operation.
        /// </summary>
        /// <param name="htmlHelper">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="BreadcrumbBuilder"/> value or BootstrapBuilder result.</returns>
        public static BreadcrumbBuilder BreadcrumbBuilder(this IHtmlHelper htmlHelper)
        {
            return new BreadcrumbBuilder(htmlHelper.ViewContext.Writer, htmlHelper);
        }

        private static BreadcrumbComposer GetBreadcrumbComposer<TBuilder>(TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseBreadcrumb
        {
            return builder.GetOrCreateCssComposer(() => new BreadcrumbComposer());
        }

        /// <summary>
        /// Configures breadcrumb divider on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="divider">The divider value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetBreadcrumbDivider<TBuilder>(
            this TBuilder builder,
            string? divider
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseBreadcrumb
        {
            GetBreadcrumbComposer(builder).SetDivider(divider);
            return builder;
        }

        /// <summary>
        /// Configures breadcrumb style on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="style">The style value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetBreadcrumbStyle<TBuilder>(
            this TBuilder builder,
            BreadcrumbStyle style
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseBreadcrumb
        {
            GetBreadcrumbComposer(builder).SetStyle(style);
            return builder;
        }

        #endregion
    }
}