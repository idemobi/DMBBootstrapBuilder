#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj IBootstrapPageAlertManager.cs create at 2026/05/07 00:00:00
// (c)2024-2026 ideMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Defines a BootstrapBuilder contract for bootstrap page alert manager.
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
