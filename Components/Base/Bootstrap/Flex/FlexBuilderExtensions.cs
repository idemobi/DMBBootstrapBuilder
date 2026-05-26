using DMBPageBuilder;

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring flex builder in BootstrapBuilder components.
    /// </summary>
    public static class FlexBuilderExtensions
    {
        private static FlexComposer GetFlexComposer<TBuilder>(TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlex
        {
            return builder.GetOrCreateCssComposer(() => new FlexComposer());
        }

        /// <summary>
        /// Builds flex css classes for BootstrapBuilder rendering.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string BuildFlexCssClasses<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlex
        {
            return GetFlexComposer(builder).BuildJoinedClasses();
        }

        /// <summary>
        /// Configures align items center on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetAlignItemsCenter<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlex
        {
            GetFlexComposer(builder).AlignItems = AlignItems.Center;
            return builder;
        }

        /// <summary>
        /// Configures align items start on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetAlignItemsStart<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlex
        {
            GetFlexComposer(builder).AlignItems = AlignItems.Start;
            return builder;
        }

        /// <summary>
        /// Configures align items end on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetAlignItemsEnd<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlex
        {
            GetFlexComposer(builder).AlignItems = AlignItems.End;
            return builder;
        }

        /// <summary>
        /// Configures align items stretch on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetAlignItemsStretch<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlex
        {
            GetFlexComposer(builder).AlignItems = AlignItems.Stretch;
            return builder;
        }

        /// <summary>
        /// Configures justify content center on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetJustifyContentCenter<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlex
        {
            GetFlexComposer(builder).JustifyContent = JustifyContent.Center;
            return builder;
        }

        /// <summary>
        /// Configures justify content start on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetJustifyContentStart<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlex
        {
            GetFlexComposer(builder).JustifyContent = JustifyContent.Start;
            return builder;
        }

        /// <summary>
        /// Configures justify content end on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetJustifyContentEnd<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlex
        {
            GetFlexComposer(builder).JustifyContent = JustifyContent.End;
            return builder;
        }

        /// <summary>
        /// Configures justify content between on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetJustifyContentBetween<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlex
        {
            GetFlexComposer(builder).JustifyContent = JustifyContent.Between;
            return builder;
        }

        /// <summary>
        /// Configures justify content around on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetJustifyContentAround<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlex
        {
            GetFlexComposer(builder).JustifyContent = JustifyContent.Around;
            return builder;
        }

        /// <summary>
        /// Configures justify content evenly on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetJustifyContentEvenly<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlex
        {
            GetFlexComposer(builder).JustifyContent = JustifyContent.Evenly;
            return builder;
        }

        /// <summary>
        /// Configures no wrap on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder SetNoWrap<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlex
        {
            GetFlexComposer(builder).Wrap = false;
            return builder;
        }

        /// <summary>
        /// Stores the wrap value used by BootstrapBuilder rendering or composition.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        public static TBuilder WithWrap<TBuilder>(this TBuilder builder, bool wrap = true)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlex
        {
            GetFlexComposer(builder).Wrap = wrap;
            return builder;
        }

        /// <summary>
        /// Stores the gap value used by BootstrapBuilder rendering or composition.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        public static TBuilder WithGap<TBuilder>(this TBuilder builder, Old_Gap gap = Old_Gap.Default)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlex
        {
            GetFlexComposer(builder).Gap = gap;
            return builder;
        }

        /// <summary>
        /// Configures flex additional classes on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="classes">The classes value.</param>
        /// <returns>The configured <see cref="TBuilder"/> value or BootstrapBuilder result.</returns>
        public static TBuilder WithFlexAdditionalClasses<TBuilder>(this TBuilder builder, string classes)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseFlex
        {
            GetFlexComposer(builder).AdditionalClasses = classes ?? string.Empty;
            return builder;
        }
    }
}