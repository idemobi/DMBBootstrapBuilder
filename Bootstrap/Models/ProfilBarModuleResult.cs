#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the BootstrapBuilder profil bar module result component or support type.
    /// </summary>
    public sealed class ProfilBarModuleResult
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the action list value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public List<IActionItem> ActionList { get; } = new();

        /// <summary>
        ///     Gets navbar components contributed by the profile provider.
        /// </summary>
        public List<INavbarComponent> NavbarComponents { get; } = new();

        #endregion
    }
}