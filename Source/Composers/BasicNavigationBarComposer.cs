#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Collections.Generic;
using System.IO;
using System.Linq;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Composes Bootstrap CSS classes or page chrome for basic navigation bar.
    /// </summary>
    public class BasicNavigationBarComposer : INavigationBarComposer
    {
        #region Instance methods

        /// <summary>
        ///     Gets menu bar module result for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public virtual List<MenuBarModuleResult> GetMenuBarModuleResult(TextWriter writer, IHtmlHelper html)
        {
            List<MenuBarModuleResult> result = new List<MenuBarModuleResult>();
            IEnumerable<IMenuBarSectionProvider> providers = html.ViewContext.HttpContext
                .RequestServices
                .GetServices<IMenuBarSectionProvider>();
            foreach (IMenuBarSectionProvider provider in providers.OrderBy(x => x.Order))
            {
                if (provider == null)
                {
                    continue;
                }

                if (!provider.IsEnabled(html))
                {
                    continue;
                }

                MenuBarModuleResult moduleResult = provider.Build(writer, html);
                if (moduleResult == null)
                {
                    continue;
                }

                result.Add(moduleResult);
            }

            return result;
        }

        /// <summary>
        ///     Gets nav bar offcanvas icon for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <returns>The configured <see cref="IconStruct" /> value or BootstrapBuilder result.</returns>
        public virtual IconStruct GetNavBarOffcanvasIcon()
        {
            return IconStruct.Bootstrap("bi-list");
        }

        /// <summary>
        ///     Gets nav bar offcanvas title for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public virtual string GetNavBarOffcanvasTitle()
        {
            return string.Empty;
        }

        /// <summary>
        ///     Gets profil bar module result for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public virtual List<ProfilBarModuleResult> GetProfilBarModuleResult(TextWriter writer, IHtmlHelper html)
        {
            List<ProfilBarModuleResult> result = new List<ProfilBarModuleResult>();
            IEnumerable<IProfileBarSectionProvider> providers = html.ViewContext.HttpContext
                .RequestServices
                .GetServices<IProfileBarSectionProvider>();
            foreach (IProfileBarSectionProvider provider in providers.OrderBy(x => x.Order))
            {
                if (provider == null)
                {
                    continue;
                }

                if (!provider.IsEnabled(html))
                {
                    continue;
                }

                ProfilBarModuleResult moduleResult = provider.Build(writer, html);
                if (moduleResult == null)
                {
                    continue;
                }

                result.Add(moduleResult);
            }

            return result;
        }

        /// <summary>
        ///     Gets side bar offcanvas icon for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <returns>The configured <see cref="IconStruct" /> value or BootstrapBuilder result.</returns>
        public virtual IconStruct GetSideBarOffcanvasIcon()
        {
            return IconStruct.Bootstrap("bi-layout-sidebar");
        }

        /// <summary>
        ///     Gets side bar offcanvas title for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public virtual string GetSideBarOffcanvasTitle()
        {
            return string.Empty;
        }

        #region From interface INavigationBarComposer

        /// <summary>
        ///     Gets desktop navbar for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="NavbarBuilder" /> value or BootstrapBuilder result.</returns>
        public virtual NavbarBuilder GetDesktopNavbar(TextWriter writer, IHtmlHelper html)
        {
            // prepare
            NavbarBuilder _desktopNavbar = new NavbarBuilder(writer, html);
            NavbarContainerComponent _desktopBrandContainer = new NavbarContainerComponent();
            //NavBrandComponent _desktopBrand = new NavBrandComponent("Game-Data-Forge", "/", IconStruct.Bootstrap("bi-controller"));
            NavBrandLogoComponent _desktopBrand = new NavBrandLogoComponent("/");
            NavbarContainerComponent _desktopMenuContainer = new NavbarContainerComponent();
            NavLinksComponent _desktopMenuActionsContainer = new NavLinksComponent().WithDropdownAlign(NavbarDropdownAlign.Start);
            NavbarContainerComponent _desktopProfilContainer = new NavbarContainerComponent();
            NavLinksComponent _desktopProfilActionsContainer = new NavLinksComponent().WithDropdownAlign(NavbarDropdownAlign.End);

            // get actions
            foreach (MenuBarModuleResult menuBar in GetMenuBarModuleResult(writer, html))
            {
                foreach (IActionItem action in menuBar.ActionList)
                {
                    _desktopMenuActionsContainer.Add(action);
                }

                foreach (INavbarComponent component in menuBar.NavbarComponents)
                {
                    _desktopMenuContainer.Add(component);
                }
            }

            foreach (ProfilBarModuleResult menuBar in GetProfilBarModuleResult(writer, html))
            {
                foreach (INavbarComponent component in menuBar.NavbarComponents)
                {
                    _desktopProfilContainer.Add(component);
                }

                foreach (IActionItem action in menuBar.ActionList)
                {
                    _desktopProfilActionsContainer.Add(action);
                }
            }

            // assembly
            _desktopNavbar
                .Id("navbar_desktop")
                .Variant(VariantStyle.Dark)
                .Justify(JustifyContent.Between)
                .WithAlignItems(AlignItems.Stretch)
                .Placement(NavbarPlacement.StickyTop)
                .WithGap(Old_Gap.Gap3)
                .Expand(NavbarExpand.Xl)
                .ShowFrom(ResponsiveBreakpoint.Xl);
            _desktopNavbar.Add(_desktopBrandContainer);
            // _desktopNavbar.Add(new NavbarDividerComponent());
            _desktopNavbar.Add(_desktopMenuContainer);
            _desktopNavbar.Add(new NavbarSpacerComponent());
            _desktopNavbar.Add(_desktopProfilContainer);
            _desktopBrandContainer.WithAlignItems(AlignItems.End).WithJustify(JustifyContent.Start).Add(_desktopBrand);
            _desktopProfilActionsContainer.IconOnly = true;
            _desktopMenuContainer.WithAlignItems(AlignItems.End).WithJustify(JustifyContent.Start).WithGap(Old_Gap.Gap3).Add(_desktopMenuActionsContainer);
            _desktopProfilContainer.WithAlignItems(AlignItems.End).WithJustify(JustifyContent.End).WithGap(Old_Gap.Gap3).Add(_desktopProfilActionsContainer);

            return _desktopNavbar;
        }

        /// <summary>
        ///     Gets mobile navbar for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="sideBar">The side bar value.</param>
        /// <returns>The configured <see cref="NavbarBuilder" /> value or BootstrapBuilder result.</returns>
        public virtual NavbarBuilder GetMobileNavbar(TextWriter writer, IHtmlHelper html, SideBarComponent? sideBar)
        {
            NavbarBuilder _mobileNavbar = new NavbarBuilder(writer, html);
            NavbarContainerComponent _mobileBrandContainer = new NavbarContainerComponent();
            NavBrandLogoComponent _mobileBrand = new NavBrandLogoComponent("/");
            NavbarContainerComponent _mobileSideBarContainer = new NavbarContainerComponent();
            NavbarContainerComponent _mobileNavBarContainer = new NavbarContainerComponent();
            NavOffcanvasComponent _sideBarOffcanvasComponent = new NavOffcanvasComponent("sidebar_off_canvas_mobile", GetSideBarOffcanvasTitle()).WithPlacement(OffcanvasPlacement.Start);
            _sideBarOffcanvasComponent.ToggleIcon = GetSideBarOffcanvasIcon();
            NavOffcanvasComponent _navBarOffcanvasComponent = new NavOffcanvasComponent("menu_and_profile_mobile", GetNavBarOffcanvasTitle());
            _navBarOffcanvasComponent.ToggleIcon = GetNavBarOffcanvasIcon();

            // get actions
            foreach (MenuBarModuleResult menuBar in GetMenuBarModuleResult(writer, html))
            {
                foreach (IActionItem action in menuBar.ActionList)
                {
                    _navBarOffcanvasComponent.Add(action);
                }

                foreach (INavbarComponent component in menuBar.NavbarComponents)
                {
                    _mobileNavBarContainer.Add(component);
                }
            }

            // add divider
            _navBarOffcanvasComponent.Add(new DividerActionItem());

            foreach (ProfilBarModuleResult menuBar in GetProfilBarModuleResult(writer, html))
            {
                foreach (INavbarComponent component in menuBar.NavbarComponents)
                {
                    _navBarOffcanvasComponent.Add(component);
                }

                foreach (IActionItem action in menuBar.ActionList)
                {
                    _navBarOffcanvasComponent.Add(action);
                }
            }

            if (_navBarOffcanvasComponent.HasActions() == false)
            {
                _navBarOffcanvasComponent.Hide();
            }

            // add sidebar
            if (sideBar != null)
            {
                _sideBarOffcanvasComponent.Title = GetSideBarOffcanvasTitle();
                _sideBarOffcanvasComponent.ToggleIcon = GetSideBarOffcanvasIcon();
                _sideBarOffcanvasComponent.AddSidebar(sideBar.Clone().WithId("mobile_sidebar"));
            }
            else
            {
                _sideBarOffcanvasComponent.Hide();
            }

            // assembly
            _mobileNavbar
                .Id("navbar_mobile")
                .Variant(VariantStyle.Dark)
                .Justify(JustifyContent.Between)
                .WithAlignItems(AlignItems.Center)
                .Placement(NavbarPlacement.StickyTop)
                .WithGap(Old_Gap.Gap2)
                .Expand(NavbarExpand.Never)
                .ShowUntil(ResponsiveBreakpoint.Xl);
            _mobileBrandContainer.Add(_mobileBrand);
            _mobileNavbar.Add(_mobileSideBarContainer);
            _mobileNavbar.Add(_mobileBrandContainer);
            _mobileNavbar.Add(_mobileNavBarContainer);
            _mobileSideBarContainer.Add(_sideBarOffcanvasComponent);
            _mobileNavBarContainer.Add(_navBarOffcanvasComponent);

            return _mobileNavbar;
        }

        #endregion

        #endregion
    }
}