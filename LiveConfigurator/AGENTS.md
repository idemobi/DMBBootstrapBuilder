# AI Rules - DMBBootstrapLiveConfigurator

## Scope

- Applies to the `DMBBootstrapLiveConfigurator` folder and descendants.
- This project is autonomous: required rules are defined in local documentation files.

## Project-specific section

When copying this file to another PageBuilder ecosystem project, update this section first.

- Project name: `DMBBootstrapLiveConfigurator`
- Project folder: `DMBBootstrapBuilder/LiveConfigurator`
- Project role: Razor package that exposes a live Bootstrap theme configurator, preview pages, static assets, and configuration hooks.
- Primary consumers: MVC/Razor host applications such as `labs_idemobi_com`.
- Main dependencies: `DMBPageBuilder`, `DMBBootstrapBuilder`, `DMBServerWebHelper`, `DMBServerHelper`, and `DMBComponentBuilder`.
- Publication host: `labs_idemobi_com`
- Documentation generation strategy: DocumentationBuilder-first; AI prepares content, the developer executes generation.

## Module intent

- Provide a live configurator UI for Bootstrap-oriented theme variables and previews.
- Register configurator static assets and global theme script hooks through existing PageBuilder ecosystem services.
- Keep controller routes, embedded views, static asset paths, and option names stable for consuming hosts.
- Avoid moving general Bootstrap rendering, reusable component rendering, form behavior, or server infrastructure responsibilities into this package.

## Key constraints

- Keep public APIs backward compatible unless a change request explicitly allows breakage.
- Prefer additive options over rewiring controller routes or asset paths.
- Every new visual preview or configurator surface must include a manual preview route/page.
- Cover normal state, empty state, error state, and one realistic data example for new preview surfaces.
- Treat generated JavaScript, CSS custom properties, static asset URLs, and user-provided theme values as behavior-sensitive areas.
- Do not run `dotnet build`, `dotnet test`, `dotnet restore`, or `dotnet format` unless explicitly requested.

## Documentation objective

- Documentation must be authored so it can be extracted and rendered by DocumentationBuilder.
- Publication target is `labs_idemobi_com`.
- Documentation output must serve both developers and AI assistants.
- AI prepares documentation content and structure; the developer runs DocumentationBuilder.
- XML documentation comments must be written in English.
- Public classes, public methods, public constructors, public properties, public fields, public constants, public enums, public enum values, public records, and extension methods must have useful XML documentation.

## Local rule sources

- Use [AI_CONTEXT.md](AI_CONTEXT.md) for the project summary and safe-change strategy.
- Use [DOCUMENTATION_RULES.md](DOCUMENTATION_RULES.md) for XML HeaderDoc, README/reference documentation, and DocumentationBuilder-ready documentation.
- Use [EXAMPLES_AND_TUTORIALS_RULES.md](EXAMPLES_AND_TUTORIALS_RULES.md) only when creating or updating example, demo, information, instruction, concept, or tutorial pages.
- Use [DRAWIO_DIAGRAM_RULES.md](DRAWIO_DIAGRAM_RULES.md) when adding editable Draw.io diagrams to information, instruction, concept, architecture, configurator lifecycle, or tutorial pages.
- Use `CodeBlockBuilder` or the local `Html.CodeBlock(...)` helper for code examples when available.
- Use `ActionItem` with `ButtonRender` for page action links when the target publication project exposes those helpers.
- Store editable Draw.io diagrams as enriched `.drawio.svg` files under `labs_idemobi_com/wwwroot/drawio/{Area}/`.

## Localization

- Follow local [LOCALIZATION_NOMENCLATURE.md](LOCALIZATION_NOMENCLATURE.md).
- Do not assume external localization rules unless duplicated here.

## Before delivery

- Update local docs when behavior changes.
- State untested areas explicitly.
- Do not claim build/test or DocumentationBuilder execution when they were not run.
