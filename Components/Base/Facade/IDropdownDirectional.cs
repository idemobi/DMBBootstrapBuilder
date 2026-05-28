#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj IDropdownDirectional.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Defines a BootstrapBuilder contract for dropdown directional.
    /// </summary>
    public interface IDropdownDirectional
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the dropdown direction used by Bootstrap dropdown rendering.
        /// </summary>
        DropdownDirection DropdownDirection { get; set; }

        #endregion
    }
}
