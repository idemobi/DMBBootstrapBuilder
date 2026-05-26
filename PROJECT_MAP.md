# DMBBootstrapBuilder Project Map

## Project-specific section

When copying this file to another PageBuilder ecosystem project, update this section first.

- Project name: `DMBBootstrapBuilder`
- Project root folder: `DMBBootstrapBuilder`
- Main role: Bootstrap-oriented visual component, layout, navigation, and page chrome package.
- Important folders: `Components/`, `Bootstrap/`, `BodyBuilder/`, `Composers/`, `HtmlHelpers/`, `Helpers/`, `Managers/`, `Providers/`, `Controllers/`, `Configuration/`, `Constants/`, `Resources/`, `Tools/`, `Views/`, and `wwwroot/`.
- Documentation target: `labs_idemobi_com`

## Folder responsibilities

- `Components/`
  - Bootstrap visual component builders and shared component foundations.
  - Includes accordion, action item, alert, badge, block, body, breadcrumb, button, card, column, container, cookie consent, debug model, diagnostics, footer, footer bar, header, icon, image, logo, modal, navbar, progress, row, section, sidebar, spinner, table, tabs, title, and toast components.
  - `Base/`: abstract component foundations such as `HtmlComponentBuilderBase<TBuilder>`, `HtmlInteractiveComponentBuilderBase<TBuilder>`, panel/block/text bases, wrappers, and void/tag helpers.

- `Bootstrap/`
  - Bootstrap-specific enums, enum extensions, facades, and model types.
  - Includes variant, alignment, spacing, responsive, media, form, card decoration, table, alert, navbar, breadcrumb, and page module contracts.

- `BodyBuilder/`
  - Bootstrap body builder implementation that composes page body regions with PageBuilder infrastructure.

- `Composers/`
  - Default composition helpers for breadcrumb, footer bar, and navigation bar structures.

- `Configuration/`
  - BootstrapBuilder configuration and static-file post-configuration for embedded package assets.

- `Constants/`
  - Shared BootstrapBuilder constants.

- `Controllers/`
  - MVC controller support for Bootstrap-specific package pages and raw Bootstrap output.

- `Helpers/`
  - Extension helpers for cards, tables, modals, title effects, action items, theme toggles, RTL toggles, fluid layout toggles, and sidebar theme actions.

- `HtmlHelpers/`
  - Razor extension methods that expose BootstrapBuilder components and utility output to `.cshtml` files.

- `Managers/`
  - Bootstrap page alert management contracts and implementations.

- `Providers/`
  - Section providers for debug bar, language bar, theme bar, and related page chrome areas.

- `Resources/`
  - Internal and data-annotation localization `.resx` assets for `DMBBootstrapBuilder`.

- `Views/`
  - Embedded Razor views used by BootstrapBuilder package controllers.

- `Tools/`
  - Utility helpers for Bootstrap styles, flex options, responsive display, resource-once rendering, and region state keys.

- `wwwroot/`
  - Embedded static assets (`css`, `js`) served through package static-file configuration.

- `.ai/` and `.aiassistant/`
  - Local AI-assistant support metadata when present. Do not treat generated assistant state as project source.

- `bin/` and `obj/`
  - Build outputs and intermediate files. Do not use these folders as documentation or source-of-truth inputs.

## Documentation-related files

- `README.md`: package overview and usage context.
- `AGENTS.md`: local AI rules and scope for this package.
- `AI_CONTEXT.md`: additional context for AI-assisted maintenance.
- `DOCUMENTATION_RULES.md`: strict documentation policy.
- `DRAWIO_DIAGRAM_RULES.md`: rules for editable Draw.io diagrams used by documentation, concept, instruction, example, and tutorial pages.
- `EXAMPLES_AND_TUTORIALS_RULES.md`: rules for example pages and tutorials only.
- `DELIVERY_CHECKLIST.md`: final quality gate before handoff.
- `ARCHITECTURE_DECISIONS.md`: local architecture decisions and constraints.
- `GLOSSARY.md`: shared vocabulary for this package.
- `LOCAL_DEVELOPMENT_RUNBOOK.md`: local workflow notes and handoff checks.
- `LOCALIZATION_NOMENCLATURE.md`: localization key naming rules for this package.
- `TROUBLESHOOTING.md`: known issues and recovery notes.
