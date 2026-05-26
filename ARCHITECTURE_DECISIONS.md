# DMBBootstrapBuilder Architecture Decisions

## Project-specific section

When copying this file to another PageBuilder ecosystem project, update this section first.

- Project name: `DMBBootstrapBuilder`
- Architectural role: Bootstrap-oriented component, layout, and page chrome layer built on PageBuilder foundations.
- Main stability concerns: public component builders, Razor helpers, action items, Bootstrap class output, accessibility attributes, page chrome composition, and embedded static assets.
- Documentation target: DocumentationBuilder output rendered in `labs_idemobi_com`.

## ADR-001: Bootstrap component stability

- Date: 2026-05-14
- Context: The package is consumed by multiple modules; component, helper, layout, or Bootstrap markup regressions propagate quickly.
- Decision: Prefer backward-compatible additive changes for public component contracts, fluent builders, Razor helpers, and Bootstrap rendering behavior.
- Consequences: Refactors may be slower, but consumer safety is improved.
- Status: Accepted

## ADR-002: DocumentationBuilder-first documentation

- Date: 2026-05-14
- Context: Documentation is expected to be extracted/generated into `labs_idemobi_com`.
- Decision: Author docs in extraction-friendly structure and metadata style.
- Consequences: More disciplined writing format, better automation quality.
- Status: Accepted

## ADR-003: Project-autonomous AI rules

- Date: 2026-05-14
- Context: Different projects need explicit and independent AI guidance.
- Decision: Keep local rules complete in module docs, without implicit inheritance.
- Consequences: Some duplication, but clearer execution for AI tools.
- Status: Accepted
