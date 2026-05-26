#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj IProfileBarSectionProvider.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Defines the contract for providing profile bar section provider content to BootstrapBuilder page chrome.
    /// </summary>
    public interface IProfileBarSectionProvider
    {
        #region Instance fields and properties

        int Order { get; }

        #endregion

        #region Instance methods

        ProfilBarModuleResult Build(TextWriter writer, IHtmlHelper html); //HttpContext context = html.ViewContext.HttpContext;

        bool IsEnabled(IHtmlHelper html);

        #endregion
    }
}