# DMBBootstrapLiveConfigurator AI Context

## Purpose

This file gives AI assistants the minimum project context required to work safely in `DMBBootstrapLiveConfigurator`.

## Project-specific section

When copying this file to another PageBuilder ecosystem project, update this section first.

- Project name: `DMBBootstrapLiveConfigurator`
- Project folder: `DMBBootstrapBuilder/LiveConfigurator`
- Project role: Razor package that exposes a live Bootstrap theme configurator, preview pages, static assets, and configuration hooks.
- Main dependencies: `DMBPageBuilder`, `DMBBootstrapBuilder`, `DMBServerWebHelper`, `DMBServerHelper`, and `DMBComponentBuilder`.
- Publication host: `labs_idemobi_com`
- Primary documentation audience: developers integrating the live configurator into MVC/Razor hosts.

## What this project is

`DMBBootstrapLiveConfigurator` is a live configuration and preview package.

It provides:

- MVC controller actions for the configurator and examples,
- embedded Razor views for live previews,
- CSS and JavaScript assets for configurator behavior,
- a global theme script registered through PageBuilder services,
- configuration hooks for embedded static files,
- dependency injection extensions for package setup.

## What this project is not

This project is not:

- a general Bootstrap builder package,
- a reusable component package,
- a form builder package,
- a low-level HTML builder package,
- an ASP.NET host application,
- a documentation website.

## Main concepts

- `BootstrapLiveConfiguratorController` serves the live configurator pages.
- `BootstrapLiveConfiguratorOptions` stores package options.
- `BootstrapLiveConfiguratorConfigureOptions` exposes embedded static files.
- `DMBBootstrapLiveConfiguratorConfiguration` registers static file options and the global theme script asset.
- `AddDmbBootstrapLiveConfigurator(...)` registers the options surface with dependency injection.

## Change strategy

- Keep changes localized to the relevant controller, view, asset, option, or configuration family.
- Preserve public API names, routes, and asset URLs unless the request explicitly asks for a breaking change.
- Keep generated script keys and CSS class/custom-property behavior deterministic.
- Document public API behavior in XML comments when the code is touched.
- Update README and local rule files when project behavior or documentation strategy changes.

## Documentation strategy

- Use `DOCUMENTATION_RULES.md` for XML docs, README/reference docs, and DocumentationBuilder-ready documentation.
- Use `EXAMPLES_AND_TUTORIALS_RULES.md` only for pages, examples, tutorials, and walkthroughs.
- Use `DRAWIO_DIAGRAM_RULES.md` when diagrams clarify configurator lifecycle, asset registration, theme script flow, or host integration.
- Keep all generated documentation in English unless the user explicitly requests another language for user-facing website content.
