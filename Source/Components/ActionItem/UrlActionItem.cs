#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the BootstrapBuilder url action item component or support type.
    /// </summary>
    public sealed class UrlActionItem : ActionLeafBase<UrlActionItem>
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the rel value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? Rel { get; set; }

        /// <summary>
        ///     Gets or sets the target value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? Target { get; set; }

        /// <summary>
        ///     Gets or sets the url value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? Url { get; set; }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IActionItem" /> value or BootstrapBuilder result.</returns>
        public override IActionItem Clone()
        {
            var clone = new UrlActionItem
            {
                Id = Id,
                Title = Title,
                Subtitle = Subtitle,
                Icon = Icon,
                DebugOnly = DebugOnly,
                Outline = Outline,
                Variant = Variant,
                Size = Size,
                AdditionalClasses = AdditionalClasses,
                Url = Url,
                Target = Target,
                Rel = Rel,
                Disabled = Disabled,
                Active = Active,
                BadgeText = BadgeText,
                BadgeStyle = BadgeStyle
            };

            return clone;
        }

        /// <summary>
        ///     Configures target on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="target">The target value.</param>
        /// <param name="rel">The rel value.</param>
        /// <returns>The configured <see cref="UrlActionItem" /> value or BootstrapBuilder result.</returns>
        public UrlActionItem WithTarget(string? target, string? rel = null)
        {
            Target = target;
            Rel = rel;
            return this;
        }

        /// <summary>
        ///     Configures url on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="url">The url value.</param>
        /// <returns>The configured <see cref="UrlActionItem" /> value or BootstrapBuilder result.</returns>
        public UrlActionItem WithUrl(string? url)
        {
            Url = url;
            return this;
        }

        #endregion
    }
}