#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj AlignItems.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the alignment options for items within a flex container.
    ///     Maps to <see cref="AlignItems" /> Bootstrap's align-items utility classes.
    /// </summary>
    public enum AlignItems
    {
        /// <summary>
        /// Uses the default BootstrapBuilder or Bootstrap behavior.
        /// </summary>
        Default,
        
        /// <summary>
        ///     Align items along their <see cref="Baseline" />.
        /// </summary>
        Baseline = 0,

        /// <summary>
        ///     Align items to the <see cref="Start" /> of the container.
        /// </summary>
        Start,

        /// <summary>
        ///     Align items to the <see cref="Center" /> of the container.
        /// </summary>
        Center,

        /// <summary>
        ///     Align items to the <see cref="End" /> of the container.
        /// </summary>
        End,

        /// <summary>
        ///     <see cref="Stretch" /> items to fill the container.
        /// </summary>
        Stretch
    }
}