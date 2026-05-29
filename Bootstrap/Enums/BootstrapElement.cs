#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

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
        ///     Represents the navbar BootstrapBuilder option.
        /// </summary>
        navbar,

        /// <summary>
        ///     Represents the sidebar BootstrapBuilder option.
        /// </summary>
        sidebar,

        /// <summary>
        ///     Represents the footer BootstrapBuilder option.
        /// </summary>
        footer,

        /// <summary>
        ///     Represents the logo BootstrapBuilder option.
        /// </summary>
        logo
    }
}