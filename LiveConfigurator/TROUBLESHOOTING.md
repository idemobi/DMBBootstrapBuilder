# DMBBootstrapLiveConfigurator Troubleshooting

## Purpose

Collect common issues and investigation paths for `DMBBootstrapLiveConfigurator`.

## Project-specific section

When copying this file to another PageBuilder ecosystem project, update this section first.

- Project name: `DMBBootstrapLiveConfigurator`
- Project folder: `DMBBootstrapBuilder/LiveConfigurator`
- Project role: Razor package that exposes a live Bootstrap theme configurator, preview pages, static assets, and configuration hooks.
- Publication host: `labs_idemobi_com`

## Configurator page does not render

Check:

- the consuming host references the package or project,
- MVC discovers `BootstrapLiveConfiguratorController`,
- embedded views are included in the package,
- required PageBuilder and BootstrapBuilder services are registered.

## Static assets are missing

Check:

- `BootstrapLiveConfiguratorConfigureOptions` is registered,
- embedded file provider configuration includes package assets,
- URLs under `/css` and `/js` match the generated asset paths,
- the host static file middleware is configured.

## Global theme script does not run early enough

Check:

- `BootstrapLiveConfiguratorConfiguration` is loaded by the host,
- the script key is `DMBBootstrapLiveConfigurator.GlobalTheme`,
- the script URL is `/js/BootstrapLiveConfigurator.GlobalTheme.js`,
- the script location and order still match the intended head loading behavior.

## Theme values do not persist or reset correctly

Check:

- JavaScript storage keys,
- reset button behavior,
- CSS custom property names,
- browser storage availability,
- conflicts with host theme scripts.

## Documentation page issues

When pages in `labs_idemobi_com` are wrong or inconsistent:

- read `EXAMPLES_AND_TUTORIALS_RULES.md`,
- use `CodeBlockBuilder` or `Html.CodeBlock(...)` for code examples,
- use `ActionItem` with `ButtonRender` for action links,
- use `DRAWIO_DIAGRAM_RULES.md` for editable diagrams,
- keep DocumentationViewer links targeting `DMBBootstrapLiveConfigurator`.
