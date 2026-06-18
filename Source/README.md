# DMBBootstrapBuilder

## Purpose

`DMBBootstrapBuilder` is the Bootstrap-oriented visual component and page chrome package for the PageBuilder ecosystem.

It centralizes reusable primitives for:

- composing Bootstrap components through strongly typed fluent builders,
- rendering layout primitives such as containers, rows, columns, blocks, cards, tables, and tabs,
- rendering modal previews for PDFs and responsive PNG or JPEG images,
- rendering page chrome such as body, header, footer, navbar, breadcrumb, sidebar, and footer bar areas,
- rendering action links and buttons through `ActionItem` and `ButtonRender`,
- exposing Bootstrap-oriented Razor helpers for `.cshtml` pages,
- registering embedded BootstrapBuilder scripts and stylesheets.

## Project-specific section

When copying this file to another PageBuilder ecosystem project, update this section first.

- Project name: `DMBBootstrapBuilder`
- Project folder: `DMBBootstrapBuilder`
- Project role: Bootstrap-oriented visual component, layout, navigation, and page chrome package.
- Main consumers: `labs_idemobi_com` and PageBuilder ecosystem packages.
- Documentation target: DocumentationBuilder output rendered in `labs_idemobi_com`.

## Audience

- Primary audience: developers integrating or maintaining the package.
- Secondary audience: AI assistants (Codex, Claude, Junie, and similar tools) that produce technical documentation and code updates.

## Scope

- `Components/`: Bootstrap visual component builders and shared component foundations.
- `Bootstrap/`: Bootstrap enums, model types, facades, and enum extensions.
- `BodyBuilder/`: Bootstrap body builder integration with PageBuilder layouts.
- `Composers/`: default breadcrumb, footer bar, and navigation bar composition helpers.
- `HtmlHelpers/`: Razor helper extensions that expose BootstrapBuilder components and utility output.
- `Helpers/`: extension helpers for cards, tables, modals, action items, theme toggles, and related component integrations.
- `Managers/`: alert and page-level Bootstrap state management.
- `Providers/`: debug, theme, language, menu, profile, and footer bar section providers.
- `Controllers/`: package MVC controllers for Bootstrap-specific pages and raw output.
- `Configuration/`: BootstrapBuilder configuration and static-file post-configuration.
- `Constants/`: BootstrapBuilder constants.
- `Tools/`: utility helpers for Bootstrap styles, flex options, responsive display, resource-once rendering, and region state keys.
- `Resources/`: package localization resources.
- `wwwroot/`: embedded static package assets.

## Technical baseline

- SDK: `Microsoft.NET.Sdk.Razor`
- Target framework: `net10.0`
- Nullable: enabled
- XML documentation output: enabled in `Debug`, `Release`, and `NuGet` configurations

## Navigation rendering

- Dropdown, sidebar, and offcanvas action items render disabled states with Bootstrap-compatible `.disabled`, `disabled`, or `aria-disabled="true"` signals.
- Embedded navigation styles keep disabled items visibly muted across light, dark, primary, and inversed sidebar themes, while preventing pointer activation for disabled links.
- Profile bar `GroupActionItem` entries with the same non-empty `Id` are merged by `BasicNavigationBarComposer`, allowing independent modules to contribute actions to one shared dropdown.

## Documentation strategy

This module follows a **DocumentationBuilder-first** strategy:

- Documentation must be authored for extraction/rendering by DocumentationBuilder.
- Publication target is `labs_idemobi_com`.
- AI prepares content and structure; the developer executes DocumentationBuilder.
- XML documentation must describe the public component, layout, and Bootstrap rendering contract, not only restate member names.
- Examples should use realistic Razor, Bootstrap component, and page composition scenarios when behavior is user-facing.

## Related orientation files

- [AGENTS.md](AGENTS.md)
- [AI_CONTEXT.md](AI_CONTEXT.md)
- [PROJECT_MAP.md](PROJECT_MAP.md)
- [LOCALIZATION_NOMENCLATURE.md](LOCALIZATION_NOMENCLATURE.md)
- [DOCUMENTATION_RULES.md](DOCUMENTATION_RULES.md)
- [DRAWIO_DIAGRAM_RULES.md](DRAWIO_DIAGRAM_RULES.md)
- [EXAMPLES_AND_TUTORIALS_RULES.md](EXAMPLES_AND_TUTORIALS_RULES.md)
- [LOCAL_DEVELOPMENT_RUNBOOK.md](LOCAL_DEVELOPMENT_RUNBOOK.md)
- [DELIVERY_CHECKLIST.md](DELIVERY_CHECKLIST.md)
- [TROUBLESHOOTING.md](TROUBLESHOOTING.md)
- [GLOSSARY.md](GLOSSARY.md)
- [ARCHITECTURE_DECISIONS.md](ARCHITECTURE_DECISIONS.md)
