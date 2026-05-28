#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj IHasIcon.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Defines a BootstrapBuilder contract for has icon.
    /// </summary>
    public interface IHasIcon
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the icon rendered by the component.
        /// </summary>
        IconStruct Icon { get; set; }

        #endregion
    }
}
