using DMBPageBuilder;

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Composes Bootstrap CSS classes or page chrome for flex.
    /// </summary>
    public sealed class FlexComposer : IIsCssClassComposer
    {
        /// <summary>
        /// Gets or sets the align items value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public AlignItems AlignItems { get; set; } = AlignItems.Default;
        /// <summary>
        /// Gets or sets the justify content value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public JustifyContent JustifyContent { get; set; } = JustifyContent.Default;
        /// <summary>
        /// Gets or sets the wrap value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool Wrap { get; set; } = true;
        /// <summary>
        /// Gets or sets the gap value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public Old_Gap Gap { get; set; } = Old_Gap.Default;
        /// <summary>
        /// Gets or sets the additional classes value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string AdditionalClasses { get; set; } = string.Empty;

        /// <summary>
        /// Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            List<string> classes = new()
            {
                "d-flex"
            };

            string alignCss = AlignItems.GetAlignItemsCss();
            if (!string.IsNullOrWhiteSpace(alignCss))
            {
                classes.Add(alignCss);
            }

            string justifyCss = JustifyContent.GetJustifyCss();
            if (!string.IsNullOrWhiteSpace(justifyCss))
            {
                classes.Add(justifyCss);
            }

            string gapCss = Gap.GetGapCss();
            if (!string.IsNullOrWhiteSpace(gapCss))
            {
                classes.Add(gapCss);
            }

            classes.Add(Wrap ? "flex-wrap" : "flex-nowrap");

            if (!string.IsNullOrWhiteSpace(AdditionalClasses))
            {
                classes.AddRange(AdditionalClasses.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            }

            return classes
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct(StringComparer.Ordinal)
                .ToList();
        }

        /// <summary>
        /// Builds joined classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public string BuildJoinedClasses()
        {
            return string.Join(" ", BuildClasses());
        }

        /// <summary>
        /// Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IIsCssClassComposer"/> value or BootstrapBuilder result.</returns>
        public IIsCssClassComposer Clone()
        {
            return new FlexComposer
            {
                AlignItems = AlignItems,
                JustifyContent = JustifyContent,
                Wrap = Wrap,
                Gap = Gap,
                AdditionalClasses = AdditionalClasses
            };
        }
    }
}