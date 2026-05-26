# DMBBootstrapBuilder AI Context

## What this module is

`DMBBootstrapBuilder` is the Bootstrap-oriented visual component package used by PageBuilder ecosystem packages and web modules.

It should be treated as infrastructure-level UI composition code with cross-module impact.

## Project-specific section

When copying this file to another PageBuilder ecosystem project, update this section first.

- Project name: `DMBBootstrapBuilder`
- Project role: Bootstrap visual components, page chrome, layout builders, action buttons, and Bootstrap helper APIs.
- Primary consumers: `labs_idemobi_com` and ecosystem packages such as `DMBComponentBuilder`, `DMBFormBuilder`, and documentation/example pages.
- Main documentation target: DocumentationBuilder output rendered in `labs_idemobi_com`.

## What this module is not

- Not a product-specific feature package.
- Not the low-level page metadata foundation.
- Not a place for business-flow logic.
- Not a replacement for specialized form or domain component packages.

## Main responsibilities

- Bootstrap component builders such as titles, alerts, toasts, cards, modals, tables, tabs, rows, columns, badges, spinners, images, navbars, sidebars, headers, footers, and progress elements.
- Bootstrap enums, style helpers, spacing helpers, and responsive display helpers.
- Action item rendering and button composition.
- Page chrome builders for body, header, footer, footer bar, navbar, breadcrumb, sidebar, and debug/theme/language bars.
- Razor helper extensions for BootstrapBuilder components and utility output.
- Embedded BootstrapBuilder static assets.

## Change strategy for AI

1. Identify whether change affects public component contracts, Razor helpers, fluent builders, action items, Bootstrap class output, or page chrome behavior.
2. Evaluate downstream impact before changing signatures, rendered HTML, Bootstrap classes, accessibility attributes, ordering, or default behavior.
3. Prefer extension points over behavior replacement.
4. Update documentation in the same change set.

## Documentation strategy for AI

- Produce extraction-ready docs for DocumentationBuilder.
- Keep sectioning explicit and deterministic.
- Prefer examples that are realistic and directly mappable to package capabilities.
