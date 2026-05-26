#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj IIsInlineStyleComposer.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Defines the contract for composing is inline style composer content in BootstrapBuilder pages.
    /// </summary>
    public interface IIsInlineStyleComposer
    {
        #region Instance methods

        IReadOnlyList<string> BuildStyles();

        #endregion
    }
}