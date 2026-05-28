#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj IHasBadge.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Defines a BootstrapBuilder contract for has badge.
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
