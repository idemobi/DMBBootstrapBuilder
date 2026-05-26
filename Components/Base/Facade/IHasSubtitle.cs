#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj IHasSubtitle.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Defines a BootstrapBuilder contract for has subtitle.
    /// </summary>
    public interface IHasSubtitle
    {
        #region Instance fields and properties

        string? Subtitle { get; set; }

        #endregion
    }
}