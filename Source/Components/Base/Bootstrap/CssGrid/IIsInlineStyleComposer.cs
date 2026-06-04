#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

using System.Collections.Generic;

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Defines the contract for composing is inline style composer content in BootstrapBuilder pages.
    /// </summary>
    public interface IIsInlineStyleComposer
    {
        #region Instance methods

        /// <summary>
        ///     Builds inline CSS style declarations for the current composer.
        /// </summary>
        /// <returns>The inline style declarations to append to the rendered element.</returns>
        IReadOnlyList<string> BuildStyles();

        #endregion
    }
}