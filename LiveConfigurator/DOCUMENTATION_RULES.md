# DMBBootstrapLiveConfigurator Documentation Rules

## Language

- Documentation must be written in English.
- XML documentation comments must be written in English.

## Target audience

- Primary: developers maintaining or integrating `DMBBootstrapLiveConfigurator`.
- Secondary: developers embedding the live configurator in MVC/Razor hosts.
- Tertiary: AI assistants consuming structured project rules and technical context.

Documentation must be useful without private chat context. A reader should understand which controller, views, assets, options, and configuration hooks are required before reading the implementation.

## Project-specific section

When copying this file to another PageBuilder ecosystem project, update this section first.

- Project name: `DMBBootstrapLiveConfigurator`
- Primary API families: controller actions, configuration classes, options, dependency injection extensions, embedded views, JavaScript assets, and CSS assets.
- Important types to reference when relevant: `BootstrapLiveConfiguratorController`, `BootstrapLiveConfiguratorOptions`, `BootstrapLiveConfiguratorConfigureOptions`, `BootstrapLiveConfiguratorConfiguration`, and `ServiceCollectionExtensions`.
- Publication host: `labs_idemobi_com`
- Documentation generation strategy: DocumentationBuilder-first; AI prepares content, the developer executes generation.

## Strict C# XML documentation policy

- Always write XML HeaderDoc for public classes, public interfaces, public structs, public records, public methods, public constructors, public properties, public fields, public constants, public events, public delegates, public enums, public enum values, and public extension methods.
- Also write XML HeaderDoc for protected members when they are part of an inheritance contract or expected host integration point.
- Internal and private members do not require XML HeaderDoc unless they explain complex routing, static asset registration, JavaScript behavior, theme persistence, localization, or security behavior that would otherwise be difficult to maintain.
- XML documentation must use valid C# XML syntax.
- Prefer `<summary>`, `<param>`, `<typeparam>`, `<returns>`, `<value>`, `<remarks>`, `<exception>`, `<see cref="..."/>`, and `<seealso cref="..."/>`.
- Use `<inheritdoc/>` only when the inherited documentation is accurate for the current member.

## XML documentation quality standard

XML documentation must explain the public contract, not repeat the member name.

For controllers and actions, document:

- the rendered page or preview surface,
- the route or action purpose,
- the relationship with embedded views and assets,
- host assumptions and side effects when relevant.

For configuration and options types, document:

- what services or static assets are registered,
- required host services,
- default behavior,
- whether values can be overridden by consumers.

For extension methods, document:

- the receiver type,
- the services registered,
- the returned service collection for chaining,
- null handling and exceptions.

## Project API documentation requirements

- Controller APIs must identify whether they render configurator pages or examples.
- Static asset configuration must document embedded asset exposure and consuming application requirements.
- Global script registration must document the script key, URL, loading location, and order when changed.
- JavaScript-facing options must document persistence, reset behavior, and CSS custom property effects.

## Markdown documentation policy

- Follow PageBuilder markdown conventions in `../MARKDOWN_GUIDELINES.md`.
- Keep this structure where applicable:
  1. Context
  2. Explanation
  3. Example
  4. Notes / constraints

## DocumentationBuilder-first rule

Documentation in this module must be authored with a DocumentationBuilder-first objective.

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
- Use `EXAMPLES_AND_TUTORIALS_RULES.md` only when the task explicitly creates or updates example pages, demo pages, information pages, instruction pages, concept pages, tutorials, or tutorial-like walkthroughs.

## Minimum update policy

If public route behavior, configurator UI behavior, static asset behavior, script registration, or host integration behavior changes, update in the same change set:

- local `README.md`,
- relevant XML docs,
- impacted guidance/examples when the task includes pages.
