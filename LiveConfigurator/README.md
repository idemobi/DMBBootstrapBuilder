# DMBBootstrapLiveConfigurator

## Context

`DMBBootstrapLiveConfigurator` is a Razor package for the PageBuilder ecosystem. It exposes a live Bootstrap theme configurator, preview pages, and static assets that can be hosted by MVC/Razor applications such as `labs_idemobi_com`.

## Explanation

The package provides:

- `BootstrapLiveConfiguratorController` for configurator and example pages,
- embedded Razor views under `Views/BootstrapLiveConfigurator`,
- JavaScript and CSS assets under `wwwroot`,
- `BootstrapLiveConfiguratorConfiguration` for registering static assets and global theme scripts,
- `AddDmbBootstrapLiveConfigurator(...)` for dependency injection setup,
- options and static file configuration classes for host integration.

The package depends on the existing PageBuilder ecosystem rather than introducing a separate frontend framework.

## Example

```csharp
builder.Services.AddDmbBootstrapLiveConfigurator();
```

Host applications also need the package configuration registered through the existing `DMBServerWebHelper` configuration flow so embedded static assets and global scripts are available.

## Notes / constraints

- Keep controller routes and asset URLs stable because consuming hosts may link to them directly.
- Keep generated JavaScript and CSS behavior deterministic.
- Do not run `dotnet build`, `dotnet test`, `dotnet restore`, or `dotnet format` unless explicitly requested.
