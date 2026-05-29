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
    ///     Represents the BootstrapBuilder menu bar module result component or support type.
    /// </summary>
    public sealed class MenuBarModuleResult
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the action list value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public List<IActionItem> ActionList { get; } = new();

        /// <summary>
        ///     Gets navbar components contributed by the menu provider.
        /// </summary>
        public List<INavbarComponent> NavbarComponents { get; } = new();

        #endregion
    }
}