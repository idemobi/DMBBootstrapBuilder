#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj HtmlRegionStateKeys.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    internal static class HtmlRegionStateKeys
    {
        #region Constants

        /// <summary>
        /// Provides the body closed by footer constant used by BootstrapBuilder rendering or asset registration.
        /// </summary>
        public const string BodyClosedByFooter = "__BODY_CLOSED_BY_FOOTER__";
        /// <summary>
        /// Provides the body open constant used by BootstrapBuilder rendering or asset registration.
        /// </summary>
        public const string BodyOpen = "__BODY_OPEN__";
        /// <summary>
        /// Provides the footer open constant used by BootstrapBuilder rendering or asset registration.
        /// </summary>
        public const string FooterOpen = "__FOOTER_OPEN__";

        #endregion
    }
}