#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj IHasTitle.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Defines a BootstrapBuilder contract for has title.
    /// </summary>
    public interface IHasTitle
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the title rendered by the component.
        /// </summary>
        string? Title { get; set; }

        #endregion
    }
}
