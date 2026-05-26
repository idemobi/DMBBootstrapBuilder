#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj IFooterBarSectionProvider.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Defines the contract for providing footer bar section provider content to BootstrapBuilder page chrome.
    /// </summary>
    public interface IFooterBarSectionProvider
    {
        #region Instance fields and properties

        int Order { get; }

        #endregion

        #region Instance methods

        FooterBarModuleResult Build(TextWriter writer, IHtmlHelper html);

        bool IsEnabled(IHtmlHelper html);

        #endregion
    }
}