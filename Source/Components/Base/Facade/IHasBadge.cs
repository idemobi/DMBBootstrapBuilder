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
    ///     Defines a BootstrapBuilder contract for has badge.
    /// </summary>
    public interface IHasBadge
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the Bootstrap variant used by the badge.
        /// </summary>
        VariantStyle BadgeStyle { get; set; }

        /// <summary>
        ///     Gets or sets the badge text rendered by the component.
        /// </summary>
        string? BadgeText { get; set; }

        #endregion
    }
}