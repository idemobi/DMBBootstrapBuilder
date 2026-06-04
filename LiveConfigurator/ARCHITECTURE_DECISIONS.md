# DMBBootstrapLiveConfigurator Architecture Decisions

## Purpose

Record durable architecture decisions that AI assistants and maintainers must preserve unless a change request explicitly supersedes them.

## Project-specific section

When copying this file to another PageBuilder ecosystem project, update this section first.

- Project name: `DMBBootstrapLiveConfigurator`
- Project folder: `DMBBootstrapBuilder/LiveConfigurator`
- Project role: Razor package that exposes a live Bootstrap theme configurator, preview pages, static assets, and configuration hooks.
- Main dependencies: `DMBPageBuilder`, `DMBBootstrapBuilder`, `DMBServerWebHelper`, `DMBServerHelper`, and `DMBComponentBuilder`.
- Publication host: `labs_idemobi_com`

## Decisions

### Keep the configurator hostable

The package must remain reusable by MVC/Razor host applications. Do not hard-code repository-specific paths or host-only assumptions into package mechanics.

### Keep routes and asset URLs stable

Controller routes, embedded view locations, global script keys, and static asset URLs may be referenced by consuming hosts and documentation pages.

### Keep theme behavior deterministic

Generated JavaScript, CSS custom properties, preview values, and reset behavior must remain predictable.

### Keep setup in existing configuration hooks

Static asset exposure and global script registration should continue to use `DMBServerWebHelper` and PageBuilder configuration conventions.

### Keep examples outside the package when they are website documentation

The package may contain its own embedded configurator views, but broader tutorials, diagrams, and explanatory pages are published through `labs_idemobi_com` when requested.
