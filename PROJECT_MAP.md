# DMBBootstrapBuilder Project Map

## Project-specific section

When copying this file to another PageBuilder ecosystem project, update this section first.

- Project name: `DMBBootstrapBuilder`
- Project root folder: `DMBBootstrapBuilder`
- Main role: Bootstrap-oriented visual component, layout, navigation, and page chrome package.
- Main project folder: `Source/`
- Important source folders: `Source/Components/`, `Source/Bootstrap/`, `Source/BodyBuilder/`, `Source/Composers/`, `Source/HtmlHelpers/`, `Source/Helpers/`, `Source/Managers/`, `Source/Providers/`, `Source/Controllers/`, `Source/Configuration/`, `Source/Constants/`, `Source/Resources/`, `Source/Tools/`, `Source/Views/`, and `Source/wwwroot/`.
- Live configurator project folder: `LiveConfigurator/`
- Labs folder: `Labs/`
- Local website folder: `Website/`
- Unit test folder: `UnitTests/`
- Documentation target: `labs_idemobi_com`

## Folder responsibilities

- `Source/Components/`
  - Bootstrap visual component builders and shared component foundations.
  - Includes accordion, action item, alert, badge, block, body, breadcrumb, button, card, column, container, cookie consent, debug model, diagnostics, footer, footer bar, header, icon, image, logo, modal, navbar, progress, row, section, sidebar, spinner, table, tabs, title, and toast components.
  - `Base/`: abstract component foundations such as `HtmlComponentBuilderBase<TBuilder>`, `HtmlInteractiveComponentBuilderBase<TBuilder>`, panel/block/text bases, wrappers, and void/tag helpers.

- `Source/Bootstrap/`
  - Bootstrap-specific enums, enum extensions, facades, and model types.
  - Includes variant, alignment, spacing, responsive, media, form, card decoration, table, alert, navbar, breadcrumb, and page module contracts.

- `Source/BodyBuilder/`
  - Bootstrap body builder implementation that composes page body regions with PageBuilder infrastructure.

- `Source/Composers/`
  - Default composition helpers for breadcrumb, footer bar, and navigation bar structures.

- `Source/Configuration/`
  - BootstrapBuilder configuration and static-file post-configuration for embedded package assets.

- `Source/Constants/`
  - Shared BootstrapBuilder constants.

- `Source/Controllers/`
  - MVC controller support for Bootstrap-specific package pages and raw Bootstrap output.

- `Source/Helpers/`
  - Extension helpers for cards, tables, modals, title effects, action items, theme toggles, RTL toggles, fluid layout toggles, and sidebar theme actions.

- `Source/HtmlHelpers/`
  - Razor extension methods that expose BootstrapBuilder components and utility output to `.cshtml` files.

- `Source/Managers/`
  - Bootstrap page alert management contracts and implementations.

- `Source/Providers/`
  - Section providers for debug bar, language bar, theme bar, and related page chrome areas.

- `Source/Resources/`
  - Internal and data-annotation localization `.resx` assets for `DMBBootstrapBuilder`.

- `Source/Views/`
  - Embedded Razor views used by BootstrapBuilder package controllers.

- `Source/Tools/`
  - Utility helpers for Bootstrap styles, flex options, responsive display, resource-once rendering, and region state keys.

- `Source/wwwroot/`
  - Embedded static assets (`css`, `js`) served through package static-file configuration.

- `UnitTests/`
  - NUnit test project for `DMBBootstrapBuilder`.
  - References `Source/DMBBootstrapBuilder.csproj` directly and keeps the test assembly name `DMBBootstrapBuilderUnitTest`.

- `Labs/`
  - Razor class library containing BootstrapBuilder presentation pages and examples hosted by `labs_idemobi_com`.
  - References `Source/DMBBootstrapBuilder.csproj` directly and exposes controllers, views, helper extensions, and static assets used by the labs website.
  - `Navigation/`: reusable navigation fragments consumed by local and final host websites.

- `LiveConfigurator/`
  - Razor class library and NuGet package project for `DMBBootstrapLiveConfigurator`.
  - References `Source/DMBBootstrapBuilder.csproj` directly and keeps the public package identity `DMBBootstrapLiveConfigurator`.
  - Exposes the live Bootstrap theme configurator controller, views, configuration hooks, and embedded static assets.

- `Website/`
  - Local ASP.NET Core host website for opening `DMBBootstrapBuilder.slnx` and previewing Labs pages independently from `labs_idemobi_com`.
  - References only local module projects directly (`Labs/`, `Source/`, and `LiveConfigurator/`) and uses package references for external dependencies.
  - Provides the local navbar provider, sidebar filter, PageBuilder-compatible layout, launch settings, favicons, and logo assets.

- `.ai/` and `.aiassistant/`
  - Local AI-assistant support metadata when present. Do not treat generated assistant state as project source.

- `Source/bin/` and `Source/obj/`
  - Build outputs and intermediate files. Do not use these folders as documentation or source-of-truth inputs.

## Documentation-related files

- `Source/README.md`: package overview and usage context packaged with NuGet.
- `Source/LICENSE.md`: package license text packaged with NuGet.
- `LiveConfigurator/README.md`: live configurator package overview packaged with the `DMBBootstrapLiveConfigurator` NuGet package.
- `LiveConfigurator/LICENSE.md`: live configurator package license text packaged with NuGet.
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
