#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj NavbarPlacement.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Defines BootstrapBuilder values for navbar placement.
    /// </summary>
    public enum NavbarPlacement
    {
        /// <summary>
        /// Uses the default BootstrapBuilder or Bootstrap behavior.
        /// </summary>
        Default = 0,
        /// <summary>
        /// Represents the fixed top BootstrapBuilder option.
        /// </summary>
        FixedTop,
        /// <summary>
        /// Represents the fixed bottom BootstrapBuilder option.
        /// </summary>
        FixedBottom,
        /// <summary>
        /// Represents the sticky top BootstrapBuilder option.
        /// </summary>
        StickyTop,
        /// <summary>
        /// Represents the sticky bottom BootstrapBuilder option.
        /// </summary>
        StickyBottom
    }
}