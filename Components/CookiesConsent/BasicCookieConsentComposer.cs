#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj BasicCookieConsentComposer.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using System.Net;
using DMBPageBuilder;
using DMBServerHelper;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Composes Bootstrap CSS classes or page chrome for basic cookie consent.
    /// </summary>
    public class BasicCookieConsentComposer : ICookieConsentComposer
    {
        #region Instance methods

        /// <summary>
        /// Renders cookie consent for the BootstrapBuilder output.
        /// </summary>
        /// <param name="htmlHelper">The Razor HTML helper used to access view context and services.</param>
        /// <param name="page">The page information used during BootstrapBuilder rendering.</param>
        /// <param name="cookieConsent">The cookie consent value.</param>
        /// <param name="context">The context value.</param>
        /// <returns>The rendered HTML content for the BootstrapBuilder component.</returns>
        public IHtmlContent RenderCookieConsent(IHtmlHelper htmlHelper, PageInformation page, CookieDefinition cookieConsent, HttpContext context)
        {
            if (cookieConsent is CookieBool cookieBool)
            {
                string onClick = cookieBool.GenerateOnClick(true) + "this.closest('.alert').style.display='none'; window.location.reload();";
                string title = WebUtility.HtmlEncode(cookieBool.Title);
                string explication = WebUtility.HtmlEncode(cookieBool.Explication);

                return new HtmlString($@"
<div class=""alert alert-light border shadow-sm alert-dismissible fade show fixed-bottom m-3"" role=""alert"" style=""z-index: 1050;"">
    <div class=""container-fluid d-flex justify-content-between align-items-center flex-wrap"">
        <div class=""me-3"">
            <i class=""bi bi-info-circle me-2""></i>
            <strong>{title}</strong> : {explication}
        </div>
        <div>
            <button type=""button"" class=""btn btn-primary btn-sm"" onclick=""{onClick}"">
                Accepter
            </button>
        </div>
    </div>
</div>
");
            }

            return new HtmlString(string.Empty);
        }

        #endregion
    }
}