# DMBBootstrapLiveConfigurator Local Development Runbook

## Purpose

Provide a lightweight workflow for local work in `DMBBootstrapLiveConfigurator`.

## Project-specific section

When copying this file to another PageBuilder ecosystem project, update this section first.

- Project name: `DMBBootstrapLiveConfigurator`
- Project folder: `DMBBootstrapBuilder/LiveConfigurator`
- Project role: Razor package that exposes a live Bootstrap theme configurator, preview pages, static assets, and configuration hooks.
- Publication host: `labs_idemobi_com`

## Orientation

Start by reading:

- [README.md](README.md)
- [PROJECT_MAP.md](PROJECT_MAP.md)
- [DOCUMENTATION_RULES.md](DOCUMENTATION_RULES.md)
- [DELIVERY_CHECKLIST.md](DELIVERY_CHECKLIST.md)

For example or tutorial page work, also read:

- [EXAMPLES_AND_TUTORIALS_RULES.md](EXAMPLES_AND_TUTORIALS_RULES.md)
- [DRAWIO_DIAGRAM_RULES.md](DRAWIO_DIAGRAM_RULES.md)

## Work loop

1. Identify the affected feature family:
   - controller routes,
   - embedded configurator views,
   - CSS assets,
   - JavaScript assets,
   - global theme script registration,
   - static file configuration,
   - dependency injection setup,
   - documentation pages.
2. Read the relevant code and local rules before editing.
3. Keep edits local to the smallest useful area.
4. Update XML documentation for touched public APIs.
5. Update README or guidance files when behavior changes.
6. Run only checks that the user explicitly permits.

## Build and test policy

Do not run these commands unless explicitly requested:

```text
dotnet build
dotnet test
dotnet restore
dotnet format
```

## Safe inspection commands

Useful read-only commands:

```text
rg "BootstrapLiveConfigurator" DMBBootstrapBuilder/LiveConfigurator
rg "RegisterGlobalScriptAsset" DMBBootstrapBuilder/LiveConfigurator
find DMBBootstrapBuilder/LiveConfigurator -maxdepth 3 -type f | sort
git diff -- DMBBootstrapBuilder/LiveConfigurator
```

Prefer `rg` for searches.
