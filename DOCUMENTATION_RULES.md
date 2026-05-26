# DMBBootstrapBuilder Documentation Rules

## Language

- Documentation must be written in English.
- XML documentation comments must be written in English.

## Target audience

- Primary: developers maintaining or integrating `DMBBootstrapBuilder`.
- Secondary: developers building Razor pages with the PageBuilder ecosystem.
- Tertiary: AI assistants consuming structured project rules and technical context.

Documentation must be useful without private chat context. A reader should understand what the API renders, which Bootstrap structures and classes it produces, how it participates in page composition, and what constraints apply before reading the implementation.

## Project-specific section

When copying this file to another PageBuilder ecosystem project, update this section first.

- Project name: `DMBBootstrapBuilder`
- Primary API families: Bootstrap component builders, layout builders, page chrome builders, action items, Bootstrap enums, style helpers, Razor helpers, and embedded static assets.
- Important types to reference when relevant: `TitleBuilder`, `AlertBuilder`, `ToastBuilder`, `CardBuilder`, `ButtonRender`, `ActionItem`, `HtmlComponentBuilderBase<TBuilder>`, `IHtmlHelper`, Bootstrap enums, and related builder interfaces.
- Publication host: `labs_idemobi_com`
- Documentation generation strategy: DocumentationBuilder-first; AI prepares content, the developer executes generation.

## Strict C# XML documentation policy

- Always write XML HeaderDoc for:
  - public classes,
  - public interfaces,
  - public structs,
  - public methods,
  - public constructors,
  - public properties,
  - public fields,
  - public constants,
  - public events,
  - public delegates,
  - public enums,
  - public enum values,
  - public extension methods.
- Also write XML HeaderDoc for protected members when they are part of the inheritance contract or are expected to be overridden by derived builders.
- Internal and private members do not require XML HeaderDoc unless they explain complex rendering behavior that would otherwise be difficult to maintain.
- XML documentation must use valid C# XML syntax.
- Prefer these tags:
  - `<summary>`
  - `<param>`
  - `<typeparam>`
  - `<returns>`
  - `<value>`
  - `<remarks>`
  - `<exception>`
  - `<see cref="..."/>`
  - `<seealso cref="..."/>`
- Use `<inheritdoc/>` only when the inherited documentation is accurate for the current member. Do not hide different behavior behind inherited text.

## XML documentation quality standard

XML documentation must explain the public contract, not repeat the member name.

For classes and interfaces, document:

- the component's role in Bootstrap UI composition,
- the rendered HTML element, Bootstrap component, or page chrome artifact when applicable,
- the relationship with important types such as `TitleBuilder`, `AlertBuilder`, `ToastBuilder`, `CardBuilder`, `ButtonRender`, `ActionItem`, `HtmlComponentBuilderBase<TBuilder>`, `IHtmlHelper`, or related builder interfaces,
- lifecycle expectations, including whether the type is used directly, through Razor helpers, or by MVC infrastructure.

For methods and constructors, document:

- what the member changes in the generated output, Bootstrap component state, or page composition model,
- every parameter and the expected format when relevant,
- the returned fluent builder instance when the method supports chaining,
- side effects such as registering scripts, stylesheets, Bootstrap classes, attributes, action items, accessibility attributes, or render regions,
- validation rules and exceptions,
- whether `null`, empty strings, duplicate keys, or repeated calls have special behavior.

For properties, fields, and constants, document:

- the meaning of the value,
- the default value when meaningful,
- whether consumers may set it directly,
- how it affects rendering, Bootstrap class output, ordering, deduplication, localization, accessibility, or page composition.

For enums and enum values, document:

- where the enum is used,
- how each value maps to rendered HTML, Bootstrap classes, component behavior, metadata, or ordering,
- default or fallback behavior when applicable.

For extension methods, document:

- the receiver type,
- the builder or artifact returned,
- the intended Razor or BootstrapBuilder usage pattern,
- how it connects to the underlying component class.

## Project API documentation requirements

- Bootstrap component builders must identify the Bootstrap component, HTML element structure, CSS classes, and accessibility attributes they render.
- Fluent builder methods must state that they return the same builder type for chaining.
- Style, variant, spacing, and responsive helpers must describe the Bootstrap classes they generate.
- Attribute helpers must describe whether they set, replace, remove, encode, or serialize an attribute.
- Action item APIs must explain how actions are configured and how `ButtonRender` or related renderers output them.
- Page chrome APIs must explain how headers, footers, navbars, breadcrumbs, sidebars, and body builders compose with the PageBuilder layout.
- Asset APIs must document deduplication keys, ordering, script location, loading mode, integrity, and crossorigin behavior.
- Rendering APIs must identify whether they write immediately to a `TextWriter`, return `IHtmlContent`, or defer output until the page layout renders.
- Razor helpers must include enough context for a developer to discover the helper from IntelliSense and use it in a `.cshtml` file.
- Documentation must distinguish raw HTML rendering from encoded content where relevant.
- Security-sensitive APIs must mention HTML injection, URL, script, or style risks when consumer-provided values are rendered.

## Examples in XML documentation

Use `<example>` when it materially improves understanding of:

- Razor helper entry points,
- non-obvious fluent chains,
- component composition,
- action item rendering,
- Bootstrap variant, layout, responsive, or accessibility behavior,
- script/style registration,
- context-constrained builders such as rows, columns, tables, tabs, navbars, modal content, and footer/header regions.

Examples must be short, realistic, and compile-oriented. Prefer Razor examples for Razor helpers and C# examples for component, action item, style helper, or page chrome APIs.

## Markdown documentation policy

- Follow PageBuilder markdown conventions in:
  - `../MARKDOWN_GUIDELINES.md`
- Keep this structure where applicable:
  1. Context
  2. Explanation
  3. Example
  4. Notes / constraints

## Draw.io diagrams for conceptual documentation

Information pages, instruction pages, concept pages, architecture pages, and rendering pipeline pages may use Draw.io diagrams when they clarify a real model or flow.

Draw.io diagrams must follow:

- `DRAWIO_DIAGRAM_RULES.md`

Required baseline:

- save diagrams as enriched `.drawio.svg` files that remain editable in Draw.io,
- store diagrams under `labs_idemobi_com/wwwroot/drawio/{Area}/{diagram-name}.drawio.svg`,
- align shapes and connectors to the Draw.io grid,
- keep diagrams compatible with both light and dark page themes,
- include meaningful alternative text and surrounding explanatory text when rendered in a page,
- start from `labs_idemobi_com/wwwroot/drawio/_templates/concept-flow-template.drawio.svg` when a simple concept-flow template is appropriate.

Do not use Draw.io diagrams in XML documentation comments. XML documentation may reference concepts that are diagrammed on pages, but the diagram artifact belongs to the website documentation layer.

## DocumentationBuilder-first rule

Documentation in this module must be authored with a **DocumentationBuilder-first** objective.

- Write docs so they can be extracted and rendered without manual rewrite.
- Keep headings deterministic and stable.
- Keep examples self-contained and realistically useful.
- Avoid implicit references to chat history or hidden context.
- Prefer stable type and member names that DocumentationBuilder can cross-reference.
- Use `<see cref="..."/>` and `<seealso cref="..."/>` for related PageBuilder types whenever it improves navigation.

## Separation from examples and tutorials

`EXAMPLES_AND_TUTORIALS_RULES.md` is not a general documentation rule source.

- Use this file for API documentation, XML HeaderDoc, README updates, reference pages, and DocumentationBuilder-ready documentation.
- Use `../MARKDOWN_GUIDELINES.md` for general Markdown formatting rules.
- Use `EXAMPLES_AND_TUTORIALS_RULES.md` only when the task explicitly creates or updates example pages, demo pages, tutorials, or tutorial-like walkthroughs.
- Do not import example-page requirements into XML documentation or reference documentation unless the task also changes examples or tutorials.

### Target publication project

- `../labs_idemobi_com` (from PageBuilder root)

### Execution responsibility

- AI prepares documentation content, structure, and metadata.
- The developer executes DocumentationBuilder.
- AI must not claim DocumentationBuilder execution unless it was actually run.

### Personalization policy

When DocumentationBuilder offers customization hooks, use them only to improve:

- clarity,
- discoverability (keywords/meta),
- structure quality,
- examples/tutorial quality.

Customizations must remain:

- technically accurate,
- aligned with current code behavior,
- consistent with naming and localization conventions.

## Minimum update policy

If public component rendering behavior, Bootstrap class output, page chrome behavior, action item behavior, or a Razor helper changes, update in the same change set:

- local `README.md`,
- relevant XML docs,
- impacted guidance/examples.

If a new visual or user-facing rendering component is added, update or add a demo/example page as a separate examples task and then apply `EXAMPLES_AND_TUTORIALS_RULES.md` to that examples work.

## Review checklist for documentation changes

- The documentation names the real BootstrapBuilder concept, not a copied source project concept.
- All public and protected-contract API members touched by the change have valid XML documentation.
- Summaries are specific enough to help IntelliSense users choose the right API.
- Parameters, return values, generic parameters, exceptions, and side effects are documented where applicable.
- Examples reflect current code behavior and realistic BootstrapBuilder usage.
- Draw.io diagrams, when added, follow `DRAWIO_DIAGRAM_RULES.md`.
- DocumentationBuilder can extract the content without needing hidden context or manual rewrite.
