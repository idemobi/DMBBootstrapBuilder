#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

using System.Collections.Generic;

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the BootstrapBuilder footer bar module result component or support type.
    /// </summary>
    public sealed class FooterBarModuleResult
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the columns value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public List<FooterBarColumnDefinition> Columns { get; } = new();

        #endregion
    }
}