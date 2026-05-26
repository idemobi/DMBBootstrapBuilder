#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj SideBarModuleResult.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder side bar module result component or support type.
    /// </summary>
    public sealed class SideBarModuleResult
    {
        #region Instance fields and properties

        /// <summary>
        /// Gets or sets the sections value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public List<SideBarSectionComponent> Sections { get; } = new();

        #endregion
    }
}