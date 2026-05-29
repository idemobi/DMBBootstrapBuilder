#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBBootstrapBuilder.Resources;
using DMBPageBuilder;
using DMBServerWebHelper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the BootstrapBuilder bootstrap builder configuration component or support type.
    /// </summary>
    [Serializable]
    public class BootstrapBuilderConfiguration : WebGenericConfiguration<BootstrapBuilderConfiguration>, IServerWebConfig
    {
        #region Static constructors and destructors

        static BootstrapBuilderConfiguration()
        {
        }

        #endregion

        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the breadcrumb composer value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public IBreadcrumbComposer BreadcrumbComposer { set; get; } = new BasicBreadcrumbComposer();

        /// <summary>
        ///     Gets or sets the cookie consent composer value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public ICookieConsentComposer CookieConsentComposer { set; get; } = new BasicCookieConsentComposer();

        /// <summary>
        ///     Gets or sets the footer bar composer value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public IFooterBarComposer FooterBarComposer { set; get; } = new BasicFooterBarComposer();

        /// <summary>
        ///     Gets or sets the launch token value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string LaunchToken { set; get; } = DateTime.UtcNow.ToString("yyyyMMddHHmmss");

        /// <summary>
        ///     Gets or sets the navigation bar composer value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public INavigationBarComposer NavigationBarComposer { set; get; } = new BasicNavigationBarComposer();

        #endregion

        #region Instance methods

        #region From interface IServerWebConfig

        /// <summary>
        ///     Executes the BootstrapBuilder after configuration operation.
        /// </summary>
        /// <param name="appBuilder">The app builder value.</param>
        /// <param name="configBuilder">The config builder value.</param>
        /// <param name="configRoot">The config root value.</param>
        public override void AfterConfiguration(IHostApplicationBuilder appBuilder, IConfigurationBuilder configBuilder, IConfigurationRoot configRoot)
        {
            // add services
            appBuilder.Services.ConfigureOptions<BootstrapBuilderConfigureOptions>();
            // addLocalization
            AddAnnotationLocalization(appBuilder,
                typeof(DMBBootstrapBuilderDataAnnotationLocalization),
                typeof(DMBBootstrapBuilderInternalLocalization)
            );
        }

        /// <summary>
        ///     Executes the BootstrapBuilder api description operation.
        /// </summary>
        /// <returns>True when the requested BootstrapBuilder condition is active; otherwise, false.</returns>
        public override bool ApiDescription()
        {
            return false;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder before configuration operation.
        /// </summary>
        /// <param name="appBuilder">The app builder value.</param>
        /// <param name="configBuilder">The config builder value.</param>
        /// <param name="configRoot">The config root value.</param>
        public override void BeforeConfiguration(IHostApplicationBuilder appBuilder, IConfigurationBuilder configBuilder, IConfigurationRoot configRoot)
        {
        }

        /// <summary>
        ///     Executes the BootstrapBuilder needs config file or app settings operation.
        /// </summary>
        /// <returns>True when the requested BootstrapBuilder condition is active; otherwise, false.</returns>
        public override bool NeedsConfigFileOrAppSettings()
        {
            return false;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder random fake operation.
        /// </summary>
        public override void RandomFake()
        {
        }

        #endregion

        #endregion
    }
}