#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ObjectFit.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Defines BootstrapBuilder values for object fit.
    /// </summary>
    public enum ObjectFit
    {
        /// <summary>
        /// Represents the normal BootstrapBuilder option.
        /// </summary>
        Normal,
        /// <summary>
        /// Represents the contain BootstrapBuilder option.
        /// </summary>
        Contain,
        /// <summary>
        /// Represents the cover BootstrapBuilder option.
        /// </summary>
        Cover,
        /// <summary>
        /// Represents the fill BootstrapBuilder option.
        /// </summary>
        Fill,
        /// <summary>
        /// Represents the scale BootstrapBuilder option.
        /// </summary>
        Scale,
        /// <summary>
        /// Disables the related BootstrapBuilder option.
        /// </summary>
        None
    }
}