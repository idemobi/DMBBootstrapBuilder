#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj HtmlFlexOptions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder html flex options component or support type.
    /// </summary>
    public sealed class HtmlFlexOptions
    {
        #region Instance fields and properties

        /// <summary>
        /// Gets or sets the additional classes value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? AdditionalClasses { get; set; }
        /// <summary>
        /// Gets or sets the align items value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public AlignItems AlignItems { get; set; } = AlignItems.Center;
        /// <summary>
        /// Gets or sets the justify content value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public JustifyContent JustifyContent { get; set; } = JustifyContent.Start;

        /// <summary>
        /// Gets or sets the old gap style value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public Old_Gap OldGapStyle { get; set; } = Old_Gap.Default;
        /// <summary>
        /// Gets or sets the wrap value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool Wrap { get; set; }

        #endregion

        #region Instance methods

        /// <summary>
        /// Builds css classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public string BuildCssClasses()
        {
            var classes = new List<string> { "d-flex" };

            classes.Add(JustifyContent.GetJustifyCss());

            classes.Add(AlignItems.GetAlignItemsCss());

            classes.Add(Wrap ? "flex-wrap" : "flex-nowrap");

            classes.Add(OldGapStyle.GetGapCss());

            if (!string.IsNullOrWhiteSpace(AdditionalClasses))
            {
                classes.Add(AdditionalClasses);
            }

            return string.Join(" ", classes.Where(x => !string.IsNullOrWhiteSpace(x)));
        }

        #endregion
    }
}