#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj BootstrapBuilderConfigureOptions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     The DMBWebDevelopmentConfigureOptions class implements the IPostConfigureOptions interface.
    ///     It is used to configure the StaticFileOptions for DMBWebDevelopment.
    /// </summary>
    public class BootstrapBuilderConfigureOptions : IPostConfigureOptions<StaticFileOptions>
    {
        #region Constants

        /// <summary>
        ///     The base path used for serving static files.
        /// </summary>
        const string K_BasePath = "wwwroot";

        #endregion

        #region Instance fields and properties

        /// *Environment Property Documentation**
        private IWebHostEnvironment Environment { get; }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Configuration options for DMBWebDevelopment.
        /// </summary>
        /// <param name="sEnvironment">The web host environment used to locate embedded static assets.</param>
        public BootstrapBuilderConfigureOptions(IWebHostEnvironment sEnvironment)
        {
            Environment = sEnvironment;
        }

        #endregion

        #region Instance methods

        #region From interface IPostConfigureOptions<StaticFileOptions>

        /// <summary>
        ///     Configures options for serving static files.
        /// </summary>
        /// <param name="sName">The name of the options to post configure.</param>
        /// <param name="sOptions">The <see cref="StaticFileOptions" /> to configure.</param>
        public void PostConfigure(string? sName, StaticFileOptions sOptions)
        {
            sName = sName ?? throw new ArgumentNullException(nameof(sName));
            sOptions = sOptions ?? throw new ArgumentNullException(nameof(sOptions));

            sOptions.ContentTypeProvider = sOptions.ContentTypeProvider ?? new FileExtensionContentTypeProvider();
            if (sOptions.FileProvider == null && Environment.WebRootFileProvider == null)
            {
                throw new InvalidOperationException("Missing FileProvider.");
            }

            sOptions.FileProvider = sOptions.FileProvider ?? Environment.WebRootFileProvider;
            var tFilesProvider = new ManifestEmbeddedFileProvider(GetType().Assembly, K_BasePath);
            sOptions.FileProvider = new CompositeFileProvider(sOptions.FileProvider, tFilesProvider);
        }

        #endregion

        #endregion
    }
}
