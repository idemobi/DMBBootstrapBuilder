# DMBBootstrapLiveConfigurator Examples and Tutorials Rules

## Objective

Define how information pages, instruction pages, concept pages, example pages, demo pages, configurator pages, and tutorials are created for `DMBBootstrapLiveConfigurator`.

These rules apply only when the task explicitly creates or updates example, demo, information, instruction, concept, or tutorial pages.

Do not use this file as the rule source for XML API documentation or reference documentation. Use `DOCUMENTATION_RULES.md` for that work.

## Project-specific section

When copying this file to another PageBuilder ecosystem project, update this section first.

- Project name: `DMBBootstrapLiveConfigurator`
- Default documentation area: `BootstrapLiveConfigurator`
- Publication target: `../labs_idemobi_com`
- Shared UI stack: `DMBBootstrapBuilder`, `DMBComponentBuilder`, `DMBFormBuilder`, and `DMBPageBuilder`
- Default DocumentationViewer package id for this project: `DMBBootstrapLiveConfigurator`
- Default DocumentationViewer namespace for this project: `DMBBootstrapLiveConfigurator`
- Expected page subjects: configurator setup, theme script lifecycle, embedded assets, preview examples, controller routes, and host integration.

## Publication target

Examples and tutorials must be written in `../labs_idemobi_com` unless they are embedded package views required by the live configurator itself.

Use the existing MVC conventions in that project:

- controller actions in `labs_idemobi_com/Controllers`,
- full pages in `labs_idemobi_com/Views/{FeatureOrComponent}/`,
- reusable example partials in `labs_idemobi_com/Views/Shared/Examples/`,
- generated raw-code mirrors in `labs_idemobi_com/Views/Shared/Examples_Raw/`.

AI may create or update source example partials under `Views/Shared/Examples/`. The developer or prebuild step is responsible for regenerating `Views/Shared/Examples_Raw/` when required.

## Shared UI stack

Example, information, concept, and tutorial pages must use the existing PageBuilder ecosystem components instead of ad-hoc layout markup when a suitable component exists.

Prefer:

- `DMBBootstrapBuilder` for layout, titles, cards, rows, columns, alerts, badges, buttons, tables, tabs, and Bootstrap-oriented UI.
- `DMBComponentBuilder` for reusable visual components available in the project.
- `DMBFormBuilder` for controls that preview theme parameters when requested.
- `DMBPageBuilder` for page metadata, raw HTML builders, render lifecycle concepts, and low-level HTML composition.

Do not introduce a new frontend framework or independent demo system for examples.

## Page categories

There are two distinct page formats:

- general information pages,
- configurator or preview pages.

Do not merge the two formats unless the user explicitly asks for a hybrid page.

## Minimum preview coverage

Every new configurator or preview surface must include at least:

- normal state,
- empty state,
- error or fallback state,
- one realistic data example.

Add more examples when the surface has important theme values, JavaScript behavior, persistence behavior, reset behavior, accessibility behavior, or embedded asset behavior.

## Delivery checklist for examples

Before finishing an example or tutorial task, verify:

- the page is in the correct host or embedded package location,
- the page uses existing BootstrapBuilder, ComponentBuilder, FormBuilder, or PageBuilder components where appropriate,
- code examples use `CodeBlockBuilder` or `Html.CodeBlock(...)`,
- action links use `ActionItem` with `ButtonRender` when appropriate,
- Draw.io diagrams follow `DRAWIO_DIAGRAM_RULES.md`,
- DocumentationViewer links target `DMBBootstrapLiveConfigurator`,
- no build/test command was run unless the user explicitly requested it.
