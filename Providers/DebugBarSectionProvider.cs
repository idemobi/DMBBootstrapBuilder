#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// labs_idemobi_com.csproj DebugBarSectionProvider.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBBootstrapBuilder;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides debug bar section content for BootstrapBuilder page chrome.
    /// </summary>
    public class DebugBarSectionProvider : IProfileBarSectionProvider
    {
        #region Instance fields and properties

        #region From interface IProfileBarSectionProvider

        /// <summary>
        /// Gets or sets the order value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public int Order => 800;

        #endregion

        #endregion

        #region Instance methods

        #region From interface IProfileBarSectionProvider

        /// <summary>
        /// Builds value for BootstrapBuilder rendering.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="ProfilBarModuleResult"/> value or BootstrapBuilder result.</returns>
        public virtual ProfilBarModuleResult Build(TextWriter writer, IHtmlHelper html)
        {
            ProfilBarModuleResult result = new ProfilBarModuleResult();
            GroupActionItem group = new GroupActionItem("Debug", IconStruct.Bootstrap("bi-bug")).SetVariant(VariantStyle.Danger);
            GroupActionItem debugGroup = new GroupActionItem("Debug", IconStruct.Bootstrap("bi-bug"));
            group.AddItem(debugGroup);
            debugGroup.AddItem(
                new DebugToggleActionItem(html, false)
                    .SetTitle("Show debug")
                    .SetIcon(IconStruct.Bootstrap("bi-eye"))
            );
            debugGroup.AddItem(
                new ModernToggleActionItem(html, false)
                    .SetTitle("Show modern")
                    .SetIcon(IconStruct.Bootstrap("bi-eye"))
            );

            result.ActionList.Add(group);

            return result;
        }

        /// <summary>
        /// Determines whether enabled is active for BootstrapBuilder rendering.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>True when the requested BootstrapBuilder condition is active; otherwise, false.</returns>
        public bool IsEnabled(IHtmlHelper html)
        {
            #if DEBUG
            return true;
            #else
            return false;
            #endif
        }

        #endregion

        #endregion
    }
}