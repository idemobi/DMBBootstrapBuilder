#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Defines BootstrapBuilder values for navbar placement.
    /// </summary>
    public enum NavbarPlacement
    {
        /// <summary>
        ///     Uses the default BootstrapBuilder or Bootstrap behavior.
        /// </summary>
        Default = 0,

        /// <summary>
        ///     Represents the fixed top BootstrapBuilder option.
        /// </summary>
        FixedTop,

        /// <summary>
        ///     Represents the fixed bottom BootstrapBuilder option.
        /// </summary>
        FixedBottom,

        /// <summary>
        ///     Represents the sticky top BootstrapBuilder option.
        /// </summary>
        StickyTop,

        /// <summary>
        ///     Represents the sticky bottom BootstrapBuilder option.
        /// </summary>
        StickyBottom
    }
}