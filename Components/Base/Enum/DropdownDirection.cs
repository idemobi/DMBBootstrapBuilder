#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj DropdownDirection.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Defines BootstrapBuilder values for dropdown direction.
    /// </summary>
    public enum DropdownDirection
    {
        /// <summary>
        /// Uses the default BootstrapBuilder or Bootstrap behavior.
        /// </summary>
        Default = 0,
        /// <summary>
        /// Represents the centered BootstrapBuilder option.
        /// </summary>
        Centered,
        /// <summary>
        /// Represents the dropup BootstrapBuilder option.
        /// </summary>
        Dropup,
        /// <summary>
        /// Represents the dropup centered BootstrapBuilder option.
        /// </summary>
        DropupCentered,
        /// <summary>
        /// Represents the dropend BootstrapBuilder option.
        /// </summary>
        Dropend,
        /// <summary>
        /// Represents the dropstart BootstrapBuilder option.
        /// </summary>
        Dropstart
    }
}