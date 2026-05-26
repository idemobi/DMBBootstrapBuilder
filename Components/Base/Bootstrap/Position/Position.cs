#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj Position.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Defines BootstrapBuilder values for position.
    /// </summary>
    public enum Position
    {
        /// <summary>
        /// Represents the normal BootstrapBuilder option.
        /// </summary>
        Normal,
        /// <summary>
        /// Represents the static BootstrapBuilder option.
        /// </summary>
        Static,
        /// <summary>
        /// Represents the relative BootstrapBuilder option.
        /// </summary>
        Relative,
        /// <summary>
        /// Represents the absolute BootstrapBuilder option.
        /// </summary>
        Absolute,
        /// <summary>
        /// Represents the fixed BootstrapBuilder option.
        /// </summary>
        Fixed,
        /// <summary>
        /// Represents the sticky BootstrapBuilder option.
        /// </summary>
        Sticky
    }
}