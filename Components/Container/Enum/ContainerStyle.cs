#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ContainerStyle.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Defines BootstrapBuilder values for container style.
    /// </summary>
    public enum ContainerStyle
    {
        /// <summary>
        /// Disables the related BootstrapBuilder option.
        /// </summary>
        None = -1,

        /// <summary>
        /// Uses the default BootstrapBuilder or Bootstrap behavior.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Represents the fluid BootstrapBuilder option.
        /// </summary>
        Fluid = 1,

        /// <summary>
        /// Represents the sm BootstrapBuilder option.
        /// </summary>
        Sm = 2,

        /// <summary>
        /// Represents the md BootstrapBuilder option.
        /// </summary>
        Md = 3,

        /// <summary>
        /// Represents the lg BootstrapBuilder option.
        /// </summary>
        Lg = 4,

        /// <summary>
        /// Represents the xl BootstrapBuilder option.
        /// </summary>
        Xl = 5,

        /// <summary>
        /// Represents the xxl BootstrapBuilder option.
        /// </summary>
        Xxl = 6,
        /// <summary>
        /// Represents the landing page BootstrapBuilder option.
        /// </summary>
        LandingPage = 7,
    }
}