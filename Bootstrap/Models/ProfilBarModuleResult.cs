#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ProfilBarModuleResult.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder profil bar module result component or support type.
    /// </summary>
    public sealed class ProfilBarModuleResult
    {
        #region Instance fields and properties

        /// <summary>
        /// Gets or sets the action list value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public List<IActionItem> ActionList { get; } = new();

        /// <summary>
        /// Gets navbar components contributed by the profile provider.
        /// </summary>
        public List<INavbarComponent> NavbarComponents { get; } = new();

        #endregion
    }
}
