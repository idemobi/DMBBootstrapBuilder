#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides MVC controller behavior for BootstrapBuilder bootstrap page error pages.
    /// </summary>
    public abstract class BootstrapPageErrorController : RawBootstrapController
    {
        #region Static fields and properties

        /// <summary>
        ///     Stores the error statuses value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public static readonly IReadOnlyDictionary<int, string> ErrorStatuses = new Dictionary<int, string>
        {
            { 400, "Bad Request" },
            { 401, "Unauthorized" },
            { 403, "Forbidden" },
            { 404, "Not Found" },
            { 405, "Method Not Allowed" },
            { 409, "Conflict" },
            { 410, "Gone" },
            { 418, "I am a teapot" },
            { 429, "Too Many Requests" },
            { 500, "Internal Server Error" },
            { 501, "Not Implemented" },
            { 502, "Bad Gateway" },
            { 503, "Service Unavailable" },
            { 504, "Gateway Timeout" }
        };

        /// <summary>
        ///     Stores the information statuses value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public static readonly IReadOnlyDictionary<int, string> InformationStatuses = new Dictionary<int, string>
        {
            { 100, "Continue" },
            { 101, "Switching Protocols" },
            { 102, "Processing" },
            { 103, "Early Hints" }
        };

        /// <summary>
        ///     Stores the redirection statuses value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public static readonly IReadOnlyDictionary<int, string> RedirectionStatuses = new Dictionary<int, string>
        {
            { 300, "Multiple Choices" },
            { 301, "Moved Permanently" },
            { 302, "Found" },
            { 303, "See Other" },
            { 304, "Not Modified" },
            { 307, "Temporary Redirect" },
            { 308, "Permanent Redirect" }
        };

        #endregion

        #region Static methods

        /// <summary>
        ///     Resolves a human-readable HTTP reason phrase for a status code.
        /// </summary>
        /// <param name="statusCode">The HTTP status code to resolve.</param>
        /// <returns>The reason phrase associated with the status code.</returns>
        protected static string GetReasonPhrase(int statusCode)
        {
            if (ErrorStatuses.TryGetValue(statusCode, out string? error))
            {
                return error;
            }

            if (RedirectionStatuses.TryGetValue(statusCode, out string? redirection))
            {
                return redirection;
            }

            if (InformationStatuses.TryGetValue(statusCode, out string? information))
            {
                return information;
            }

            return "Unknown status";
        }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Executes the BootstrapBuilder ajax http error operation.
        /// </summary>
        /// <param name="statusCode">The status code value.</param>
        /// <returns>The configured <see cref="IActionResult" /> value or BootstrapBuilder result.</returns>
        [Route("/ErrorAjax/{statusCode:int}")]
        public virtual IActionResult AjaxHttpError(int statusCode = 404)
        {
            string reasonPhrase = GetReasonPhrase(statusCode);
            Response.Headers["X-Error-Title"] = "HTTP error";
            Response.Headers["X-Error-Icon"] = "bi-exclamation-triangle";
            Response.Headers["X-Error-Code"] = statusCode.ToString();
            Response.Headers["X-Error-Description"] = reasonPhrase;
            Response.Headers["X-Error-Request"] = Request.GetDisplayUrl();

            return StatusCode(statusCode, new
            {
                Code = statusCode,
                Message = reasonPhrase,
                DisplayUrl = Request.GetDisplayUrl()
            });
        }

        /// <summary>
        ///     Configures common page metadata for a Bootstrap error page.
        /// </summary>
        /// <param name="title">The title rendered for the error page.</param>
        protected virtual void ConfigureErrorPage(string title)
        {
            Page.Title = title;
            Page.SetDescription("HTTP error rendered by BootstrapBuilder.");
        }

        /// <summary>
        ///     Executes the BootstrapBuilder exception operation.
        /// </summary>
        /// <returns>The configured <see cref="IActionResult" /> value or BootstrapBuilder result.</returns>
        [Route("/Exception")]
        public virtual IActionResult Exception()
        {
            IExceptionHandlerPathFeature? exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            System.Exception handledException = exceptionFeature?.Error ?? new InvalidOperationException("An exception was handled by BootstrapPageErrorController.");
            List<string> details = new();
            if (!string.IsNullOrWhiteSpace(exceptionFeature?.Path))
            {
                details.Add("Original path: " + exceptionFeature.Path);
            }

            ConfigureErrorPage("Exception alert");
            Response.StatusCode = 500;
            Page.AlertManager.AddException(handledException, details);
            return View(GetErrorViewPath());
        }

        /// <summary>
        ///     Gets the Razor view path used to render the Bootstrap error page.
        /// </summary>
        /// <returns>The absolute Razor view path.</returns>
        protected virtual string GetErrorViewPath()
        {
            return "/Views/BootstrapPageError/Result.cshtml";
        }

        /// <summary>
        ///     Executes the BootstrapBuilder http error operation.
        /// </summary>
        /// <param name="statusCode">The status code value.</param>
        /// <returns>The configured <see cref="IActionResult" /> value or BootstrapBuilder result.</returns>
        [Route("/Error/{statusCode:int}")]
        [Route("/ErrorWithLayout/{statusCode:int}")]
        public virtual IActionResult HttpError(int statusCode = 404)
        {
            string reasonPhrase = GetReasonPhrase(statusCode);
            IStatusCodeReExecuteFeature? reExecuteFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            string? originalUrl = reExecuteFeature?.OriginalPath;

            ConfigureErrorPage($"{statusCode} - {reasonPhrase}");
            Response.StatusCode = statusCode;
            Page.AlertManager.AddHttpError(statusCode, reasonPhrase, originalUrl, Request.GetDisplayUrl());
            return View(GetErrorViewPath());
        }

        #endregion
    }
}