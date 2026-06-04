#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;

#endregion

namespace DMBBootstrapLiveConfigurator.Configuration;

/// <summary>
///     Configures static file options to expose embedded assets from the live configurator package.
/// </summary>
public sealed class BootstrapLiveConfiguratorConfigureOptions : IPostConfigureOptions<StaticFileOptions>
{
    #region Constants

    private const string BasePath = "wwwroot";

    #endregion

    #region Instance fields and properties

    private IWebHostEnvironment Environment { get; }

    #endregion

    #region Instance constructors and destructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="BootstrapLiveConfiguratorConfigureOptions" /> class.
    /// </summary>
    /// <param name="environment">The current web host environment.</param>
    public BootstrapLiveConfiguratorConfigureOptions(IWebHostEnvironment environment)
    {
        Environment = environment;
    }

    #endregion

    #region Instance methods

    #region From interface IPostConfigureOptions<StaticFileOptions>

    /// <summary>
    ///     Post-configures static file options.
    /// </summary>
    /// <param name="name">The options instance name.</param>
    /// <param name="options">The static file options to configure.</param>
    public void PostConfigure(string? name, StaticFileOptions options)
    {
        name = name ?? throw new ArgumentNullException(nameof(name));
        options = options ?? throw new ArgumentNullException(nameof(options));

        options.ContentTypeProvider ??= new FileExtensionContentTypeProvider();
        if (options.FileProvider == null && Environment.WebRootFileProvider == null)
        {
            throw new InvalidOperationException("Missing FileProvider.");
        }

        options.FileProvider ??= Environment.WebRootFileProvider;
        var embeddedProvider = new ManifestEmbeddedFileProvider(GetType().Assembly, BasePath);
        options.FileProvider = new CompositeFileProvider(options.FileProvider, embeddedProvider);
    }

    #endregion

    #endregion
}