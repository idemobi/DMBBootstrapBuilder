#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using DMBBootstrapLiveConfigurator.Configuration;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace DMBBootstrapLiveConfigurator.Extensions;

/// <summary>
///     Provides dependency injection extensions for the Bootstrap live configurator package.
/// </summary>
public static class ServiceCollectionExtensions
{
    #region Static methods

    /// <summary>
    ///     Registers services used by the Bootstrap live configurator package.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <returns>The same <see cref="IServiceCollection" /> instance for chaining.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="services" /> is <see langword="null" />.</exception>
    public static IServiceCollection AddDmbBootstrapLiveConfigurator(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddOptions<BootstrapLiveConfiguratorOptions>();
        return services;
    }

    #endregion
}