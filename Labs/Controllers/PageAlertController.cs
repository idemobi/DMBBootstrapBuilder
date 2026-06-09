#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBBootstrapBuilder;
using DMBBootstrapBuilderLabs.Models;
using DMBPageBuilder;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace DMBBootstrapBuilderLabs.Controllers
{
    /// <summary>
    ///     Provides live examples for the PageBuilder alert management system.
    /// </summary>
    public class PageAlertController : RawBootstrapController
    {
        #region Instance methods

        /// <summary>
        ///     Returns a 500 JSON error response with custom X-Error-* headers for AJAX error handling demos.
        /// </summary>
        /// <returns>A 500 status code result with error details.</returns>
        public IActionResult AjaxException()
        {
            Response.Headers["X-Error-Title"] = "Exception";
            Response.Headers["X-Error-Icon"] = "bi-bug";
            Response.Headers["X-Error-Code"] = "500";
            Response.Headers["X-Error-Description"] = "Simulated exception";
            Response.Headers["X-Error-Request"] = Request.GetDisplayUrl();

            return StatusCode(500, new
            {
                Code = 500,
                Message = "Simulated exception",
                DisplayUrl = Request.GetDisplayUrl()
            });
        }

        /// <summary>
        ///     Sets the page title, description, and breadcrumb for a page alert demo action.
        /// </summary>
        private void ConfigurePage(string title)
        {
            Page.Title = title;
            Page.SetDescription("PageBuilder alert, error and exception examples.");
            AddBreadcrumb(
                new AspRouteActionItem("Home", IconStruct.BootstrapEnum(BootStrapEnum.bi_house), "Index", "Home"),
                new AspRouteActionItem("Page alerts", IconStruct.BootstrapEnum(BootStrapEnum.bi_exclamation_triangle), "Index", "PageAlert")
            );
        }

        /// <summary>
        ///     Renders a simulated exception alert with status 500.
        /// </summary>
        /// <returns>The result view with an exception alert.</returns>
        public IActionResult Exception()
        {
            ConfigurePage("Exception alert");
            Response.StatusCode = 500;
            Page.AlertManager.AddException(new InvalidOperationException("This is a simulated exception rendered by PageBuilder."), new[] { "No exception was thrown by this demo action.", "The alert is produced by Page.AlertManager.AddException(...)." });
            return View("Result");
        }

        /// <summary>
        ///     Processes a GET-only action and renders a success alert.
        /// </summary>
        /// <returns>The result view with a success alert.</returns>
        [HttpGet]
        public IActionResult GetOnly()
        {
            ConfigurePage("GET only action");
            Page.AlertManager.AddAlert(PageAlertLayout.Alert, PageAlertStyle.Success, "GET accepted", "The controller method exists and accepts GET.");
            return View("Result");
        }

        /// <summary>
        ///     Renders the page alert overview with an info alert.
        /// </summary>
        /// <returns>The page alert overview view.</returns>
        public IActionResult Index()
        {
            ConfigurePage("Page alerts");
            Page.AlertManager.AddAlert(PageAlertLayout.Alert, PageAlertStyle.Info, "PageBuilder alert manager", "This page exercises alerts, exceptions and HTTP status messages through Page.AlertManager.");
            return View();
        }

        /// <summary>
        ///     Renders a simulated HTTP 500 internal error alert.
        /// </summary>
        /// <returns>The result view with an error alert.</returns>
        public IActionResult InternalError()
        {
            ConfigurePage("Internal error alert");
            Response.StatusCode = 500;
            Page.AlertManager.AddHttpError(500, "Voluntary internal error", Request.GetDisplayUrl(), Request.GetDisplayUrl());
            Page.AlertManager.AddAlert(new PageAlertModel
            {
                Style = PageAlertStyle.Danger,
                Title = "Debug context",
                Message = "The legacy GDF error card has been replaced by PageBuilder alert composition.",
                Details = new List<string> { "Code: 999", "Debug: No context" }
            });
            return View("Result");
        }

        /// <summary>
        ///     Processes a form submission and renders an invalid-fields validation alert.
        /// </summary>
        /// <param name="model">The submitted form model.</param>
        /// <returns>The result view with a validation alert.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InvalidFields(PageAlertFormExample model)
        {
            ConfigurePage("Invalid fields");
            if (!ModelState.IsValid)
            {
                Page.AlertManager.AddInvalidModel("Invalid fields", "The submitted form contains values that do not match validation rules.", ModelState);
                return View("Result");
            }

            Page.AlertManager.AddAlert(PageAlertLayout.Alert, PageAlertStyle.Success, "Form accepted", "All field values were valid.");
            return View("Result");
        }

        /// <summary>
        ///     Processes a form submission and renders a missing-fields validation alert.
        /// </summary>
        /// <param name="model">The submitted form model.</param>
        /// <returns>The result view with a validation alert.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MissingFields(PageAlertFormExample model)
        {
            ConfigurePage("Missing fields");
            if (!ModelState.IsValid)
            {
                Page.AlertManager.AddInvalidModel("Missing fields", "The submitted form has required fields missing.", ModelState);
                return View("Result");
            }

            Page.AlertManager.AddAlert(PageAlertLayout.Alert, PageAlertStyle.Success, "Form accepted", "All required fields were present.");
            return View("Result");
        }

        /// <summary>
        ///     Processes a POST-only action and renders a success alert.
        /// </summary>
        /// <returns>The result view with a success alert.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostOnly()
        {
            ConfigurePage("POST only action");
            Page.AlertManager.AddAlert(PageAlertLayout.Alert, PageAlertStyle.Success, "POST accepted", "The controller method exists and accepts POST.");
            return View("Result");
        }

        /// <summary>
        ///     Returns a 200 JSON response to reset the AJAX demo state.
        /// </summary>
        /// <returns>An OK result with a ready status payload.</returns>
        public IActionResult ResetAjax()
        {
            return Ok(new
            {
                Code = 200,
                Message = "Ready",
                DisplayUrl = Request.GetDisplayUrl()
            });
        }

        /// <summary>
        ///     Intentionally throws an exception to exercise the global error handler.
        /// </summary>
        /// <returns>Never returns — always throws.</returns>
        public IActionResult ThrowException()
        {
            throw new InvalidOperationException("This exception was intentionally thrown by PageAlertController.ThrowException().");
        }

        #endregion
    }
}