#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj BootstrapKindOfStyle.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the kind of bootstrap style for HTML elements.
    /// </summary>
    [Serializable]
    public enum BootstrapKindOfStyle : int
    {
        /// <summary>
        /// Represents the primary BootstrapBuilder option.
        /// </summary>
        Primary,

        /// <summary>
        /// Represents the secondary BootstrapBuilder option.
        /// </summary>
        Secondary,

        /// <summary>
        /// Represents the tertiary BootstrapBuilder option.
        /// </summary>
        Tertiary,

        /// <summary>
        /// Represents the success BootstrapBuilder option.
        /// </summary>
        Success,

        /// <summary>
        /// Represents the warning BootstrapBuilder option.
        /// </summary>
        Warning,

        /// <summary>
        /// Represents the danger BootstrapBuilder option.
        /// </summary>
        Danger,

        /// <summary>
        /// Represents the info BootstrapBuilder option.
        /// </summary>
        Info,

        /// <summary>
        /// Represents the normal BootstrapBuilder option.
        /// </summary>
        Normal,

        /// <summary>
        /// Represents the light BootstrapBuilder option.
        /// </summary>
        Light,
        /// <summary>
        /// Represents the dark BootstrapBuilder option.
        /// </summary>
        Dark,
    }
}