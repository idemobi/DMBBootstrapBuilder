# DMBBootstrapLiveConfigurator Project Map

## Purpose

Map the structure of `DMBBootstrapLiveConfigurator` so AI assistants can find the right files quickly.

## Project-specific section

When copying this file to another PageBuilder ecosystem project, update this section first.

- Project name: `DMBBootstrapLiveConfigurator`
- Project folder: `DMBBootstrapBuilder/LiveConfigurator`
- Project role: Razor package that exposes a live Bootstrap theme configurator, preview pages, static assets, and configuration hooks.
- Publication host: `labs_idemobi_com`

## Root files

- `DMBBootstrapLiveConfigurator.csproj`: project file and package metadata.
- `README.md`: package overview and documentation entry point.
- `AGENTS.md`: local AI instructions.
- `AI_CONTEXT.md`: project context for AI assistants.
- `DOCUMENTATION_RULES.md`: XML and reference documentation rules.
- `EXAMPLES_AND_TUTORIALS_RULES.md`: website page, example, and tutorial rules.
- `DRAWIO_DIAGRAM_RULES.md`: editable Draw.io diagram rules.
- `DELIVERY_CHECKLIST.md`: pre-delivery checklist.
- `ARCHITECTURE_DECISIONS.md`: durable architecture decisions.
- `LOCALIZATION_NOMENCLATURE.md`: localization key rules.
- `LOCAL_DEVELOPMENT_RUNBOOK.md`: local workflow guide.
- `TROUBLESHOOTING.md`: common issue guide.
- `GLOSSARY.md`: common term definitions.

## Configuration

- `BootstrapLiveConfiguratorConfigureOptions.cs`: static file options configuration for embedded configurator assets.
- `BootstrapLiveConfiguratorOptions.cs`: package options.
- `DMBBootstrapLiveConfiguratorConfiguration.cs`: server configuration hook for static assets and global theme script registration.

## Controllers

- `BootstrapLiveConfiguratorController.cs`: controller actions for the configurator and examples pages.

## Extensions

- `ServiceCollectionExtensions.cs`: dependency injection extension methods.

## Views

- `Views/BootstrapLiveConfigurator/Index.cshtml`: live configurator page.
- `Views/BootstrapLiveConfigurator/Examples.cshtml`: preview examples page.

## Static assets

- `wwwroot/css/BootstrapLiveConfigurator.css`: configurator styling.
- `wwwroot/js/BootstrapLiveConfigurator.js`: configurator behavior.
- `wwwroot/js/BootstrapLiveConfigurator.GlobalTheme.js`: global theme bootstrap script.

## Related projects

- `DMBBootstrapBuilder`: Bootstrap-oriented visual builder package.
- `DMBPageBuilder`: low-level page and HTML builder package.
- `DMBComponentBuilder`: reusable component package used in preview surfaces.
- `DMBServerWebHelper`: static file and global script registration helpers.
- `DMBServerHelper`: server-side helper package.
- `labs_idemobi_com`: publication host for examples, tutorials, information pages, and diagrams.
