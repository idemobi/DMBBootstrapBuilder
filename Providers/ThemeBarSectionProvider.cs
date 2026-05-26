#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ThemeBarSectionProvider.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBBootstrapBuilder.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides theme bar section content for BootstrapBuilder page chrome.
    /// </summary>
    public class ThemeBarSectionProvider : IProfileBarSectionProvider
    {
        #region Instance fields and properties

        #region From interface IProfileBarSectionProvider

        /// <summary>
        /// Gets or sets the order value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public int Order => 1;

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
        public ProfilBarModuleResult Build(TextWriter writer, IHtmlHelper html)
        {
            HttpContext context = html.ViewContext.HttpContext;

            ProfilBarModuleResult result = new ProfilBarModuleResult();
            GroupActionItem group = new GroupActionItem()
                .SetLocalizedTitle(nameof(DMBBootstrapBuilderInternalLocalization.ACTIONITEM_GROUP_Customize_TITLE))
                .SetLocalizedIconBootstrap(nameof(DMBBootstrapBuilderInternalLocalization.ACTIONITEM_GROUP_Customize_ICON))
                .SetAttribut("group-customize", true);
            result.ActionList.Add(group);

            GroupActionItem groupTheme = new GroupActionItem()
                .SetLocalizedTitle(nameof(DMBBootstrapBuilderInternalLocalization.ACTIONITEM_GROUP_Customize_Theme_TITLE))
                .SetLocalizedIconBootstrap(nameof(DMBBootstrapBuilderInternalLocalization.ACTIONITEM_GROUP_Customize_Theme_ICON));
            group.AddItem(groupTheme);
            groupTheme.AddItem(new ThemeModeActionItem(html, ThemeMode.Automatic)
                .SetLocalizedTitle(nameof(DMBBootstrapBuilderInternalLocalization.COMMON_ThemeAutomatic_TITLE))
                .SetLocalizedIconBootstrap(nameof(DMBBootstrapBuilderInternalLocalization.COMMON_ThemeAutomatic_ICON)));
            groupTheme.AddItem(new ThemeModeActionItem(html, ThemeMode.Light)
                .SetLocalizedTitle(nameof(DMBBootstrapBuilderInternalLocalization.COMMON_ThemeLight_TITLE))
                .SetLocalizedIconBootstrap(nameof(DMBBootstrapBuilderInternalLocalization.COMMON_ThemeLight_ICON)));
            groupTheme.AddItem(new ThemeModeActionItem(html, ThemeMode.Dark)
                .SetLocalizedTitle(nameof(DMBBootstrapBuilderInternalLocalization.COMMON_ThemeDark_TITLE))
                .SetLocalizedIconBootstrap(nameof(DMBBootstrapBuilderInternalLocalization.COMMON_ThemeDark_ICON)));

            group.AddItem(new DividerActionItem());

            GroupActionItem groupSideBar = new GroupActionItem()
                .SetLocalizedTitle(nameof(DMBBootstrapBuilderInternalLocalization.ACTIONITEM_GROUP_Customize_SideBar_TITLE))
                .SetLocalizedIconBootstrap(nameof(DMBBootstrapBuilderInternalLocalization.ACTIONITEM_GROUP_Customize_SideBar_ICON));
            group.AddItem(groupSideBar);
            foreach (SideBarTheme mode in Enum.GetValues(typeof(SideBarTheme)))
            {
                if (mode == SideBarTheme.Colored)
                {
                    continue;
                }

                groupSideBar.AddItem(new SideBarThemeActionItem(html, mode)
                    .SetLocalizedTitle($"COMMON_SideBarTheme{mode.ToString()}_TITLE")
                    .SetLocalizedIconBootstrap($"COMMON_SideBarTheme{mode.ToString()}_ICON")
                );
            }

            group.AddItem(new DividerActionItem());

            GroupActionItem groupOptions = new GroupActionItem()
                .SetLocalizedTitle(nameof(DMBBootstrapBuilderInternalLocalization.ACTIONITEM_GROUP_Customize_Options_TITLE))
                .SetLocalizedIconBootstrap(nameof(DMBBootstrapBuilderInternalLocalization.ACTIONITEM_GROUP_Customize_Options_ICON));
            group.AddItem(groupOptions);
            groupOptions.AddItem(new RTLToggleActionItem(html, false)
                .SetLocalizedTitle(nameof(DMBBootstrapBuilderInternalLocalization.COMMON_OptionThemeRTL_TITLE))
                .SetLocalizedIconBootstrap(nameof(DMBBootstrapBuilderInternalLocalization.COMMON_OptionThemeRTL_ICON)));
            groupOptions.AddItem(new FluidToggleActionItem(html, true)
                .SetLocalizedTitle(nameof(DMBBootstrapBuilderInternalLocalization.COMMON_OptionThemeFluid_TITLE))
                .SetLocalizedIconBootstrap(nameof(DMBBootstrapBuilderInternalLocalization.COMMON_OptionThemeFluid_ICON)));
            groupOptions.AddItem(new BreadcrumbToggleActionItem(html, true)
                .SetLocalizedTitle(nameof(DMBBootstrapBuilderInternalLocalization.COMMON_OptionThemeBreadcrumb_TITLE))
                .SetLocalizedIconBootstrap(nameof(DMBBootstrapBuilderInternalLocalization.COMMON_OptionThemeBreadcrumb_ICON)));

            return result;
        }

        /// <summary>
        /// Determines whether enabled is active for BootstrapBuilder rendering.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>True when the requested BootstrapBuilder condition is active; otherwise, false.</returns>
        public bool IsEnabled(IHtmlHelper html)
        {
            return true;
        }

        #endregion

        #endregion
    }
}
