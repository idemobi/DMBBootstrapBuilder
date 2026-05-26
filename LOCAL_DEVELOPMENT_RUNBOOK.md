# DMBBootstrapBuilder Local Development Runbook

## Purpose

Guide local development for `DMBBootstrapBuilder` changes.

## Project-specific section

When copying this file to another PageBuilder ecosystem project, update this section first.

- Project name: `DMBBootstrapBuilder`
- Main code areas: `Components/`, `Bootstrap/`, `BodyBuilder/`, `Composers/`, `HtmlHelpers/`, `Helpers/`, `Managers/`, `Providers/`, `Controllers/`, `Configuration/`, `Resources/`, `Tools/`, and `wwwroot/`.
- Main risk areas: rendered Bootstrap markup, generated CSS classes, accessibility attributes, action item rendering, page chrome composition, asset registration, Razor helper contracts, and fluent builder behavior.
- Documentation target: `labs_idemobi_com`

## Typical workflow

1. Update component, layout, action item, helper, page chrome, or related resource code.
2. Update XML HeaderDoc for changed public API surface.
3. Update local markdown docs (`README`, rules, checklists) if behavior changed.
4. Validate downstream usage in nearest consumers.
5. Hand off for developer-run DocumentationBuilder generation.

## Common checks

- Resource key consistency in `Resources/*.resx`.
- Namespace and public contract consistency.
- Null/argument validation behavior.
- Rendered HTML, Bootstrap classes, accessibility attributes, and asset ordering expectations.
- Razor helper discoverability and usage consistency.

## Documentation handoff checks

- Documentation structure is extraction-ready.
- Examples are self-contained.
- Audience (developers + AI) is respected.
