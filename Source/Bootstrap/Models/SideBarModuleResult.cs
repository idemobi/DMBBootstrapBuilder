#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the BootstrapBuilder side bar module result component or support type.
    /// </summary>
    public sealed class SideBarModuleResult
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the sections value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public List<SideBarSectionComponent> Sections { get; } = new();

        #endregion
    }
}