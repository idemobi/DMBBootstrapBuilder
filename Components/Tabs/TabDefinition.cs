using DMBPageBuilder;

namespace DMBBootstrapBuilder
{
    internal sealed class TabDefinition
    {
        #region Instance fields and properties

        /// <summary>
        /// Gets or sets the active value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// Gets or sets the badges value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public List<BadgeBuilder> Badges { get; set; } = new();
        /// <summary>
        /// Gets or sets the content html value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string ContentHtml { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the disabled value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// Gets or sets the fade value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool Fade { get; set; } = true;
        /// <summary>
        /// Gets or sets the icon value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public IconStruct Icon { get; set; }
        /// <summary>
        /// Gets or sets the id value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the pane id value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string PaneId { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the subtitle value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? Subtitle { get; set; }
        /// <summary>
        /// Gets or sets the title value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? Title { get; set; }

        #endregion

        #region Instance methods

        /// <summary>
        /// Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="TabDefinition"/> value or BootstrapBuilder result.</returns>
        public TabDefinition Clone()
        {
            return new TabDefinition
            {
                Active = Active,
                Badges = Badges.Select(x => x.Clone()).ToList(),
                ContentHtml = ContentHtml,
                Disabled = Disabled,
                Fade = Fade,
                Icon = Icon,
                Id = Id,
                PaneId = PaneId,
                Subtitle = Subtitle,
                Title = Title
            };
        }

        #endregion
    }
}