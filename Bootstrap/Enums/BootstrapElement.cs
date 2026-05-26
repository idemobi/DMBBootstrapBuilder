#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj BootstrapElement.cs create at 2026/04/07 21:04:27
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
    public enum BootstrapElement : int
    {
        /// <summary>
        /// Represents the navbar BootstrapBuilder option.
        /// </summary>
        navbar,
        /// <summary>
        /// Represents the sidebar BootstrapBuilder option.
        /// </summary>
        sidebar,
        /// <summary>
        /// Represents the footer BootstrapBuilder option.
        /// </summary>
        footer,
        /// <summary>
        /// Represents the logo BootstrapBuilder option.
        /// </summary>
        logo
    }
}