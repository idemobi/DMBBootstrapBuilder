# DMBBootstrapBuilder Delivery Checklist

## Project-specific section

When copying this file to another PageBuilder ecosystem project, update this section first.

- Project name: `DMBBootstrapBuilder`
- Main delivery risk: accidental changes to rendered Bootstrap markup, CSS classes, accessibility attributes, fluent component behavior, Razor helper behavior, action item rendering, or web asset registration.
- Publication target: `labs_idemobi_com`
- Documentation generation: developer-run DocumentationBuilder; AI must not claim generation unless it was actually run.

## 1. Code scope

- Change is minimal and focused.
- Public component, layout, action item, Razor helper, and Bootstrap markup behavior is backward compatible, or breakage is explicit.

## 2. Localization

- Added keys follow `LOCALIZATION_NOMENCLATURE.md`.
- Resource entries are consistent across required locales.

## 3. Documentation quality

- `README.md` and relevant docs updated for behavior changes.
- Public API XML HeaderDoc exists for new/updated public items.
- XML tags are valid and useful (`summary`, `param`, `returns`, etc.).
- Documentation is understandable by both developers and AI assistants.

## 4. DocumentationBuilder readiness

- Structure is explicit (Context, Explanation, Example, Notes/Constraints).
- Headings are deterministic.
- Examples are self-contained.
- Publication target is `labs_idemobi_com`.
- Developer will run DocumentationBuilder (AI does not claim execution).

## 5. Final reporting

- Changed files are listed.
- Untested areas are clearly stated.
