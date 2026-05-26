# DMBBootstrapBuilder Troubleshooting

## Project-specific section

When copying this file to another PageBuilder ecosystem project, update this section first.

- Project name: `DMBBootstrapBuilder`
- Main troubleshooting areas: Bootstrap component rendering, generated CSS classes, accessibility attributes, page chrome composition, action item rendering, Razor helpers, localization resources, and web asset registration.
- Resource folder: `Resources/`
- Documentation target: `labs_idemobi_com`

## Localization key fallback text appears

### Symptoms

- UI displays token-like fallback text instead of translated labels.

### Checks

1. Confirm key exists in `Resources/*.resx`.
2. Confirm key naming follows `LOCALIZATION_NOMENCLATURE.md`.
3. Confirm the expected localizer context is used.

## Bootstrap component markup does not match the expected state

### Checks

1. Confirm the expected fluent configuration method is called before rendering.
2. Confirm variant, size, spacing, and responsive options map to the expected Bootstrap classes.
3. Confirm conditional states such as active, disabled, dismissible, expanded, or selected are set consistently.

## Fluent builder output is missing expected attributes or classes

### Checks

1. Confirm the fluent method sets, replaces, or removes the value as expected.
2. Confirm conditional builder calls are executed before rendering.
3. Confirm custom class composition does not override the expected class.

## Action button renders with an unexpected link or style

### Checks

1. Verify the `ActionItem` implementation and route or URL values.
2. Verify `ButtonRender` receives the expected style, icon, label, and accessibility options.
3. Verify localization keys for action labels and icons follow `LOCALIZATION_NOMENCLATURE.md`.

## Script or stylesheet is missing or duplicated

### Checks

1. Verify the web asset registration key.
2. Verify asset ordering and location rules.
3. Verify the layout renders the corresponding asset region.

## Documentation output quality is weak

### Checks

1. Confirm docs follow `DOCUMENTATION_RULES.md` structure.
2. Confirm examples are self-contained and realistic.
3. Confirm headings are deterministic for extraction.
4. Confirm audience needs (developers + AI) are addressed.
