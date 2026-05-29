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
    ///     Defines a BootstrapBuilder contract for bootstrap page alert manager.
    /// </summary>
    public interface IBootstrapPageAlertManager : IPageAlertManager
    {
        #region Instance methods

        /// <summary>
        ///     Converts stored page alerts into Bootstrap alert models.
        /// </summary>
        /// <returns>The Bootstrap alert models in rendering order.</returns>
        IEnumerable<AlertModel> ToAlertModels();

        #endregion
    }
}