#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBBootstrapBuilder;
using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilderLabs.Navigation;

/// <summary>
///     Provides reusable navigation fragments for DMBBootstrapBuilder labs hosts.
/// </summary>
/// <remarks>
///     The agent only builds DMBBootstrapBuilder-specific menu and sidebar fragments. Host websites remain
///     responsible for assembling these fragments into their own navbar providers, sidebar filters, and
///     global navigation structures.
/// </remarks>
public static class DMBBootstrapBuilderLabsNavigationAgent
{
    #region Static fields and properties

    private static readonly HashSet<string> ModuleControllers = new(StringComparer.OrdinalIgnoreCase)
    {
        "BootstrapBuilder",
        "Theme",
        "SideBar",
        "Fluid",
        "RTL",
        "NavBar",
        "FooterBar",
        "Breadcrumb",
        "Pagination",
        "Block",
        "BlockTitle",
        "RowAndCol",
        "Section",
        "Table",
        "Tabs",
        "Accordion",
        "Modal",
        "Card",
        "Title",
        "Alert",
        "PageAlert",
        "Toast",
        "Button",
        "Image",
        "Badge",
        "Progress",
        "Spinner",
        "OverridableViewDebug",
        "PageQualificationDebug",
        "BootstrapLiveConfigurator"
    };

    #endregion

    #region Static methods

    /// <summary>
    ///     Creates an action item for a DMBBootstrapBuilder labs page.
    /// </summary>
    /// <param name="controller">The MVC controller name.</param>
    /// <param name="action">The MVC action name.</param>
    /// <param name="title">The action title shown in navigation UI.</param>
    /// <param name="icon">The Bootstrap Icons CSS class used by the action.</param>
    /// <param name="currentController">The current MVC controller name used to mark the action active.</param>
    /// <param name="currentAction">The current MVC action name used to mark the action active.</param>
    /// <returns>The configured <see cref="AspRouteActionItem" />.</returns>
    public static AspRouteActionItem CreateAction(
        string controller,
        string action,
        string title,
        string icon,
        string? currentController = null,
        string? currentAction = null
    )
    {
        bool active =
            string.Equals(currentController, controller, StringComparison.OrdinalIgnoreCase) &&
            string.Equals(currentAction, action, StringComparison.OrdinalIgnoreCase);

        return ActionItemFactory.AspRoute(controller, action)
            .SetTitle(title)
            .SetIcon(IconStruct.Bootstrap(icon))
            .SetActive(active);
    }

    /// <summary>
    ///     Creates the DMBBootstrapBuilder navbar menu group.
    /// </summary>
    /// <returns>The configured <see cref="GroupActionItem" /> containing DMBBootstrapBuilder labs page links.</returns>
    public static GroupActionItem CreateMenuGroup()
    {
        return ActionItemFactory.Group("DMBBootstrapBuilder", IconStruct.Bootstrap("bi-bootstrap"))
            .AddItems(
                ActionItemFactory.Group("General", IconStruct.Bootstrap("bi-info-circle"))
                    .AddItems(
                        CreateAction("BootstrapBuilder", "Introduction", "Introduction", "bi-info-circle"),
                        CreateAction("BootstrapBuilder", "GettingStarted", "Getting Started", "bi-play-circle"),
                        CreateAction("BootstrapBuilder", "Architecture", "Architecture", "bi-diagram-3"),
                        CreateAction("BootstrapBuilder", "RenderingPipeline", "Rendering Pipeline", "bi-bezier2")
                    ),
                ActionItemFactory.Group("Customization", IconStruct.Bootstrap("bi-sliders"))
                    .AddItems(
                        CreateAction("Theme", "Index", "Theme", "bi-palette"),
                        CreateAction("SideBar", "Index", "SideBar", "bi-layout-sidebar"),
                        CreateAction("Fluid", "Index", "Fluid", "bi-arrows-angle-expand"),
                        CreateAction("RTL", "Index", "RTL", "bi-text-right")
                    ),
                ActionItemFactory.Group("Navigation", IconStruct.Bootstrap("bi-compass"))
                    .AddItems(
                        CreateAction("NavBar", "Index", "NavBar", "bi-menu-button-wide"),
                        CreateAction("FooterBar", "Index", "FooterBar", "bi-window-dock"),
                        CreateAction("Breadcrumb", "Index", "Breadcrumb", "bi-signpost-split"),
                        CreateAction("Pagination", "Index", "Pagination", "bi-list-ol")
                    ),
                ActionItemFactory.Group("Blocks", IconStruct.Bootstrap("bi-grid-3x3-gap"))
                    .AddItems(
                        CreateAction("Block", "Index", "Block", "bi-square"),
                        CreateAction("RowAndCol", "Index", "Row and Col", "bi-columns-gap"),
                        CreateAction("Section", "Index", "Section", "bi-layout-text-window"),
                        CreateAction("BlockTitle", "Index", "BlockTitle", "bi-type-h1"),
                        CreateAction("Table", "Index", "Table", "bi-table"),
                        CreateAction("Tabs", "Index", "Tabs", "bi-segmented-nav"),
                        CreateAction("Accordion", "Index", "Accordion", "bi-view-stacked"),
                        CreateAction("Modal", "Index", "Modal", "bi-window"),
                        CreateAction("Card", "Index", "Card", "bi-card-text")
                    ),
                ActionItemFactory.Group("Components", IconStruct.Bootstrap("bi-ui-checks-grid"))
                    .AddItems(
                        CreateAction("Title", "Index", "Title", "bi-type-h1"),
                        CreateAction("Alert", "Index", "Alert", "bi-exclamation-circle"),
                        CreateAction("PageAlert", "Index", "Page alerts", "bi-exclamation-triangle"),
                        CreateAction("Toast", "Index", "Toast", "bi-chat-square-text"),
                        CreateAction("Button", "Index", "Button", "bi-cursor"),
                        CreateAction("Image", "Index", "Image", "bi-image"),
                        CreateAction("Badge", "Index", "Badge", "bi-patch-check"),
                        CreateAction("Progress", "Index", "Progress", "bi-bar-chart-steps"),
                        CreateAction("Spinner", "Index", "Spinner", "bi-arrow-repeat")
                    ),
                ActionItemFactory.Group("Diagnostics", IconStruct.Bootstrap("bi-bug"))
                    .AddItems(
                        CreateAction("OverridableViewDebug", "Index", "Overridable views", "bi-pencil-square"),
                        CreateAction("PageQualificationDebug", "Index", "Page qualification", "bi-patch-check")
                    ),
                ActionItemFactory.Group("Live Configurator", IconStruct.Bootstrap("bi-sliders2"))
                    .AddItems(
                        CreateAction("BootstrapLiveConfigurator", "Index", "Live Configurator", "bi-sliders2"),
                        CreateAction("BootstrapLiveConfigurator", "Examples", "Live Examples", "bi-window-stack")
                    )
            );
    }

    /// <summary>
    ///     Creates the DMBBootstrapBuilder sidebar component.
    /// </summary>
    /// <param name="currentController">The current MVC controller name used to mark the active item.</param>
    /// <param name="currentAction">The current MVC action name used to mark the active item.</param>
    /// <param name="sidebarId">The HTML identifier applied to the sidebar component.</param>
    /// <param name="localStorageKey">The browser local-storage key used for sidebar state.</param>
    /// <returns>The configured <see cref="SideBarComponent" />.</returns>
    public static SideBarComponent CreateSidebar(
        string? currentController,
        string? currentAction,
        string sidebarId = "bootstrap_builder_sidebar",
        string localStorageKey = "dmbbootstrapbuilder.labs.sidebar"
    )
    {
        SideBarComponent sidebar = new SideBarComponent()
            .WithId(sidebarId)
            .WithLocalStorageKey(localStorageKey)
            .WithAutoExpandActivePath()
            .WithRememberExpandedState();

        sidebar.AddSection(CreateSidebarSection(currentController, currentAction));

        return sidebar;
    }

    /// <summary>
    ///     Creates the DMBBootstrapBuilder sidebar section.
    /// </summary>
    /// <param name="currentController">The current MVC controller name used to mark the active item.</param>
    /// <param name="currentAction">The current MVC action name used to mark the active item.</param>
    /// <returns>The configured <see cref="SideBarSectionComponent" />.</returns>
    public static SideBarSectionComponent CreateSidebarSection(string? currentController, string? currentAction)
    {
        return new SideBarSectionComponent("DMBBootstrapBuilder")
            .Add(
                ActionItemFactory.Group("General", IconStruct.Bootstrap("bi-info-circle"))
                    .AddItems(
                        CreateAction("BootstrapBuilder", "Introduction", "Introduction", "bi-info-circle", currentController, currentAction),
                        CreateAction("BootstrapBuilder", "GettingStarted", "Getting Started", "bi-play-circle", currentController, currentAction),
                        CreateAction("BootstrapBuilder", "Architecture", "Architecture", "bi-diagram-3", currentController, currentAction),
                        CreateAction("BootstrapBuilder", "RenderingPipeline", "Rendering Pipeline", "bi-bezier2", currentController, currentAction)
                    ),
                ActionItemFactory.Group("Customization", IconStruct.Bootstrap("bi-sliders"))
                    .AddItems(
                        CreateAction("Theme", "Index", "Theme", "bi-palette", currentController, currentAction),
                        CreateAction("SideBar", "Index", "SideBar", "bi-layout-sidebar", currentController, currentAction),
                        CreateAction("Fluid", "Index", "Fluid", "bi-arrows-angle-expand", currentController, currentAction),
                        CreateAction("RTL", "Index", "RTL", "bi-text-right", currentController, currentAction)
                    ),
                ActionItemFactory.Group("Navigation", IconStruct.Bootstrap("bi-compass"))
                    .AddItems(
                        CreateAction("NavBar", "Index", "NavBar", "bi-menu-button-wide", currentController, currentAction),
                        CreateAction("FooterBar", "Index", "FooterBar", "bi-window-dock", currentController, currentAction),
                        CreateAction("Breadcrumb", "Index", "Breadcrumb", "bi-signpost-split", currentController, currentAction),
                        CreateAction("Pagination", "Index", "Pagination", "bi-list-ol", currentController, currentAction)
                    ),
                ActionItemFactory.Group("Blocks", IconStruct.Bootstrap("bi-grid-3x3-gap"))
                    .AddItems(
                        CreateAction("Block", "Index", "Block", "bi-square", currentController, currentAction),
                        CreateAction("RowAndCol", "Index", "Row and Col", "bi-columns-gap", currentController, currentAction),
                        CreateAction("Section", "Index", "Section", "bi-layout-text-window", currentController, currentAction),
                        CreateAction("BlockTitle", "Index", "BlockTitle", "bi-type-h1", currentController, currentAction),
                        CreateAction("Table", "Index", "Table", "bi-table", currentController, currentAction),
                        CreateAction("Tabs", "Index", "Tabs", "bi-segmented-nav", currentController, currentAction),
                        CreateAction("Accordion", "Index", "Accordion", "bi-view-stacked", currentController, currentAction),
                        CreateAction("Modal", "Index", "Modal", "bi-window", currentController, currentAction),
                        CreateAction("Card", "Index", "Card", "bi-card-text", currentController, currentAction)
                    ),
                ActionItemFactory.Group("Components", IconStruct.Bootstrap("bi-ui-checks-grid"))
                    .AddItems(
                        CreateAction("Title", "Index", "Title", "bi-type-h1", currentController, currentAction),
                        CreateAction("Alert", "Index", "Alert", "bi-exclamation-circle", currentController, currentAction),
                        CreateAction("PageAlert", "Index", "Page alerts", "bi-exclamation-triangle", currentController, currentAction),
                        CreateAction("Toast", "Index", "Toast", "bi-chat-square-text", currentController, currentAction),
                        CreateAction("Button", "Index", "Button", "bi-cursor", currentController, currentAction),
                        CreateAction("Image", "Index", "Image", "bi-image", currentController, currentAction),
                        CreateAction("Badge", "Index", "Badge", "bi-patch-check", currentController, currentAction),
                        CreateAction("Progress", "Index", "Progress", "bi-bar-chart-steps", currentController, currentAction),
                        CreateAction("Spinner", "Index", "Spinner", "bi-arrow-repeat", currentController, currentAction)
                    ),
                ActionItemFactory.Group("Diagnostics", IconStruct.Bootstrap("bi-bug"))
                    .AddItems(
                        CreateAction("OverridableViewDebug", "Index", "Overridable views", "bi-pencil-square", currentController, currentAction),
                        CreateAction("PageQualificationDebug", "Index", "Page qualification", "bi-patch-check", currentController, currentAction)
                    ),
                ActionItemFactory.Group("Live Configurator", IconStruct.Bootstrap("bi-sliders2"))
                    .AddItems(
                        CreateAction("BootstrapLiveConfigurator", "Index", "Live Configurator", "bi-sliders2", currentController, currentAction),
                        CreateAction("BootstrapLiveConfigurator", "Examples", "Live Examples", "bi-window-stack", currentController, currentAction)
                    )
            );
    }

    /// <summary>
    ///     Determines whether a controller belongs to the DMBBootstrapBuilder labs module.
    /// </summary>
    /// <param name="controllerName">The MVC controller name to inspect.</param>
    /// <returns><see langword="true" /> when the controller is part of this labs module; otherwise, <see langword="false" />.</returns>
    public static bool IsModuleController(string? controllerName)
    {
        return !string.IsNullOrWhiteSpace(controllerName) && ModuleControllers.Contains(controllerName);
    }

    /// <summary>
    ///     Resolves the Bootstrap icon for a DMBBootstrapBuilder labs action.
    /// </summary>
    /// <param name="currentController">The MVC controller name to resolve.</param>
    /// <param name="actionName">The MVC action name to resolve.</param>
    /// <returns>The icon value represented as an <see cref="IconStruct" />.</returns>
    public static IconStruct ResolveActionIcon(string? currentController, string? actionName)
    {
        return actionName switch
        {
            "GettingStarted" => IconStruct.Bootstrap("bi-play-circle"),
            "Architecture" => IconStruct.Bootstrap("bi-diagram-3"),
            "RenderingPipeline" => IconStruct.Bootstrap("bi-bezier2"),
            "Examples" => IconStruct.Bootstrap("bi-window-stack"),
            _ => ResolveIndexIcon(currentController)
        };
    }

    /// <summary>
    ///     Resolves the display title for a DMBBootstrapBuilder labs action.
    /// </summary>
    /// <param name="currentController">The MVC controller name to resolve.</param>
    /// <param name="actionName">The MVC action name to resolve.</param>
    /// <returns>The display title for the action.</returns>
    public static string ResolveActionTitle(string? currentController, string? actionName)
    {
        return actionName switch
        {
            "GettingStarted" => "Getting Started",
            "Architecture" => "Architecture",
            "RenderingPipeline" => "Rendering Pipeline",
            "Examples" => "Live Examples",
            "Index" => ResolveIndexTitle(currentController),
            _ => string.Equals(currentController, "BootstrapBuilder", StringComparison.OrdinalIgnoreCase)
                ? "Introduction"
                : ResolveIndexTitle(currentController)
        };
    }

    private static IconStruct ResolveIndexIcon(string? currentController)
    {
        return currentController switch
        {
            "Theme" => IconStruct.Bootstrap("bi-palette"),
            "SideBar" => IconStruct.Bootstrap("bi-layout-sidebar"),
            "Fluid" => IconStruct.Bootstrap("bi-arrows-angle-expand"),
            "RTL" => IconStruct.Bootstrap("bi-text-right"),
            "NavBar" => IconStruct.Bootstrap("bi-menu-button-wide"),
            "FooterBar" => IconStruct.Bootstrap("bi-window-dock"),
            "Breadcrumb" => IconStruct.Bootstrap("bi-signpost-split"),
            "Pagination" => IconStruct.Bootstrap("bi-list-ol"),
            "Block" => IconStruct.Bootstrap("bi-square"),
            "RowAndCol" => IconStruct.Bootstrap("bi-columns-gap"),
            "Section" => IconStruct.Bootstrap("bi-layout-text-window"),
            "BlockTitle" => IconStruct.Bootstrap("bi-type-h1"),
            "Table" => IconStruct.Bootstrap("bi-table"),
            "Tabs" => IconStruct.Bootstrap("bi-segmented-nav"),
            "Accordion" => IconStruct.Bootstrap("bi-view-stacked"),
            "Modal" => IconStruct.Bootstrap("bi-window"),
            "Card" => IconStruct.Bootstrap("bi-card-text"),
            "Title" => IconStruct.Bootstrap("bi-type-h1"),
            "Alert" => IconStruct.Bootstrap("bi-exclamation-circle"),
            "PageAlert" => IconStruct.Bootstrap("bi-exclamation-triangle"),
            "Toast" => IconStruct.Bootstrap("bi-chat-square-text"),
            "Button" => IconStruct.Bootstrap("bi-cursor"),
            "Image" => IconStruct.Bootstrap("bi-image"),
            "Badge" => IconStruct.Bootstrap("bi-patch-check"),
            "Progress" => IconStruct.Bootstrap("bi-bar-chart-steps"),
            "Spinner" => IconStruct.Bootstrap("bi-arrow-repeat"),
            "OverridableViewDebug" => IconStruct.Bootstrap("bi-pencil-square"),
            "PageQualificationDebug" => IconStruct.Bootstrap("bi-patch-check"),
            "BootstrapLiveConfigurator" => IconStruct.Bootstrap("bi-sliders2"),
            _ => IconStruct.Bootstrap("bi-info-circle")
        };
    }

    private static string ResolveIndexTitle(string? currentController)
    {
        return currentController switch
        {
            "RowAndCol" => "Row and Col",
            "PageAlert" => "Page alerts",
            "OverridableViewDebug" => "Overridable views",
            "PageQualificationDebug" => "Page qualification",
            "BootstrapLiveConfigurator" => "Live Configurator",
            null or "" => "Introduction",
            _ => currentController
        };
    }

    /// <summary>
    ///     Resolves the module root controller for a DMBBootstrapBuilder labs controller.
    /// </summary>
    /// <param name="currentController">The MVC controller name to resolve.</param>
    /// <returns>The module root controller name.</returns>
    public static string ResolveModuleController(string? currentController)
    {
        return string.Equals(currentController, "BootstrapLiveConfigurator", StringComparison.OrdinalIgnoreCase)
            ? "BootstrapLiveConfigurator"
            : "BootstrapBuilder";
    }

    /// <summary>
    ///     Resolves the default action for a DMBBootstrapBuilder labs module root controller.
    /// </summary>
    /// <param name="currentController">The MVC controller name to resolve.</param>
    /// <returns>The module default action name.</returns>
    public static string ResolveModuleDefaultAction(string? currentController)
    {
        return string.Equals(currentController, "BootstrapLiveConfigurator", StringComparison.OrdinalIgnoreCase)
            ? "Index"
            : "Introduction";
    }

    /// <summary>
    ///     Resolves the Bootstrap icon for a DMBBootstrapBuilder labs module.
    /// </summary>
    /// <param name="currentController">The MVC controller name to resolve.</param>
    /// <returns>The module icon value represented as an <see cref="IconStruct" />.</returns>
    public static IconStruct ResolveModuleIcon(string? currentController)
    {
        return string.Equals(currentController, "BootstrapLiveConfigurator", StringComparison.OrdinalIgnoreCase)
            ? IconStruct.Bootstrap("bi-sliders2")
            : IconStruct.Bootstrap("bi-bootstrap");
    }

    /// <summary>
    ///     Resolves the display title for a DMBBootstrapBuilder labs module.
    /// </summary>
    /// <param name="currentController">The MVC controller name to resolve.</param>
    /// <returns>The module display title.</returns>
    public static string ResolveModuleTitle(string? currentController)
    {
        return string.Equals(currentController, "BootstrapLiveConfigurator", StringComparison.OrdinalIgnoreCase)
            ? "DMBBootstrapLiveConfigurator"
            : "DMBBootstrapBuilder";
    }

    #endregion
}
