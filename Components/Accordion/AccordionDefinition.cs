#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj AccordionDefinition.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder accordion definition component or support type.
    /// </summary>
    public sealed class AccordionDefinition
    {
        #region Properties

        /// <summary>
        /// Gets or sets the id value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the header id value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string HeaderId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the collapse id value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string CollapseId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the title value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the subtitle value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? Subtitle { get; set; }

        /// <summary>
        /// Gets or sets the icon value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public IconStruct Icon { get; set; }

        /// <summary>
        /// Gets or sets the badges value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public IReadOnlyList<BadgeBuilder> Badges { get; set; } = Array.Empty<BadgeBuilder>();

        /// <summary>
        /// Gets or sets the open value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool Open { get; set; }

        /// <summary>
        /// Gets or sets the disabled value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// Gets or sets the content html value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string ContentHtml { get; set; } = string.Empty;

        #endregion

        #region Methods

        /// <summary>
        /// Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="AccordionDefinition"/> value or BootstrapBuilder result.</returns>
        public AccordionDefinition Clone()
        {
            return new AccordionDefinition
            {
                Id = Id,
                HeaderId = HeaderId,
                CollapseId = CollapseId,
                Title = Title,
                Subtitle = Subtitle,
                Icon = Icon,
                Badges = Badges
                    .Select(b => b.Clone())
                    .ToList(),
                Open = Open,
                Disabled = Disabled,
                ContentHtml = ContentHtml
            };
        }

        #endregion
    }
}
