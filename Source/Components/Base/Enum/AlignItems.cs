#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

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
        ///     Uses the default BootstrapBuilder or Bootstrap behavior.
        /// </summary>
        Default,

        /// <summary>
        ///     Align items along their <see cref="AlignItems.Baseline" />.
        /// </summary>
        Baseline = 0,

        /// <summary>
        ///     Align items to the <see cref="AlignItems.Start" /> of the container.
        /// </summary>
        Start,

        /// <summary>
        ///     Align items to the <see cref="AlignItems.Center" /> of the container.
        /// </summary>
        Center,

        /// <summary>
        ///     Align items to the <see cref="AlignItems.End" /> of the container.
        /// </summary>
        End,

        /// <summary>
        ///     <see cref="AlignItems.Stretch" /> items to fill the container.
        /// </summary>
        Stretch
    }
}