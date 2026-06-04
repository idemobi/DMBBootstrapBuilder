#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBBootstrapBuilder;
using DMBBootstrapBuilderLabs.Navigation;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Filters;

#endregion

namespace DMBBootstrapBuilderWebsite;

internal sealed class DMBBootstrapBuilderWebsiteSidebarActionFilter : IActionFilter
{
    #region Instance methods

    #region From interface IActionFilter

    /// <summary>
    ///     Completes the action filter lifecycle after the action has executed.
    /// </summary>
    /// <param name="context">The current action executed context.</param>
    public void OnActionExecuted(ActionExecutedContext context)
    {
    }

    /// <summary>
    ///     Injects the local DMBBootstrapBuilder sidebar and breadcrumb for labs controllers.
    /// </summary>
    /// <param name="context">The current action execution context.</param>
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.Controller is not RawBootstrapController controller)
        {
            return;
        }

        string? currentController = context.RouteData.Values["controller"]?.ToString();
        string? currentAction = context.RouteData.Values["action"]?.ToString();

        if (!DMBBootstrapBuilderLabsNavigationAgent.IsModuleController(currentController))
        {
            return;
        }

        string actionName = string.IsNullOrWhiteSpace(currentAction)
            ? DMBBootstrapBuilderLabsNavigationAgent.ResolveModuleDefaultAction(currentController)
            : currentAction;

        controller.SetSidebar(DMBBootstrapBuilderLabsNavigationAgent.CreateSidebar(currentController, currentAction));
        controller.AddBreadcrumb(
            ActionItemFactory.Url("Home", "/", IconStruct.Bootstrap("bi-house")),
            ActionItemFactory.AspRoute(
                    DMBBootstrapBuilderLabsNavigationAgent.ResolveModuleController(currentController),
                    DMBBootstrapBuilderLabsNavigationAgent.ResolveModuleDefaultAction(currentController))
                .SetTitle(DMBBootstrapBuilderLabsNavigationAgent.ResolveModuleTitle(currentController))
                .SetIcon(DMBBootstrapBuilderLabsNavigationAgent.ResolveModuleIcon(currentController)),
            ActionItemFactory.AspRoute(currentController ?? "BootstrapBuilder", actionName)
                .SetTitle(DMBBootstrapBuilderLabsNavigationAgent.ResolveActionTitle(currentController, actionName))
                .SetIcon(DMBBootstrapBuilderLabsNavigationAgent.ResolveActionIcon(currentController, actionName))
        );
    }

    #endregion

    #endregion
}
