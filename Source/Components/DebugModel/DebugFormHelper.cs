#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Globalization;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the BootstrapBuilder debug form helper component or support type.
    /// </summary>
    public static class DebugFormHelper
    {
        #region Static methods

        private static void AppendApplyLogic(
            StringBuilder sb,
            PropertyInfo prop,
            DebugPropertyAttribute? attr,
            string propIdJs,
            string sectionIdJs,
            object? initialValue
        )
        {
            string valueJs;
            if (attr?.InputType == DebugInputType.Hidden)
            {
                valueJs = $"'{JavaScriptEncoder.Default.Encode(initialValue?.ToString() ?? "")}'";
            }
            else
            {
                valueJs = $"(document.getElementById('{propIdJs}').value)";
                if (prop.PropertyType == typeof(bool)) valueJs = $"(document.getElementById('{propIdJs}').checked)";
            }

            var targets = new List<(DebugTarget Target, string Name, string? Prefix, string? Suffix)>();

            if (attr?.Target != DebugTarget.None && (attr?.Target == DebugTarget.Class || !string.IsNullOrWhiteSpace(attr?.TargetName)))
            {
                targets.Add((attr!.Target, attr.TargetName ?? string.Empty, attr.ValuePrefix, attr.ValueSuffix));
            }

            var extraTargets = prop.GetCustomAttributes<DebugPropertyTargetAttribute>();
            foreach (var et in extraTargets)
            {
                targets.Add((et.Target, et.Name, et.ValuePrefix, et.ValueSuffix));
            }

            foreach (var t in targets)
            {
                string valExpr = valueJs;
                if (!string.IsNullOrWhiteSpace(t.Prefix) || !string.IsNullOrWhiteSpace(t.Suffix))
                {
                    valExpr = $@"('{t.Prefix ?? ""}' + {valExpr} + '{t.Suffix ?? ""}')";
                }

                switch (t.Target)
                {
                    case DebugTarget.DataAttribute:
                        sb.AppendLine($@"section.setAttribute('{t.Name}', {valExpr});");
                    break;
                    case DebugTarget.CssVariable:
                        sb.AppendLine($@"section.style.setProperty('{t.Name}', {valExpr});");
                    break;
                    case DebugTarget.Style:
                        sb.AppendLine($@"section.style['{t.Name}'] = {valExpr};");
                    break;
                    case DebugTarget.Class:
                        if (prop.PropertyType == typeof(bool))
                        {
                            sb.AppendLine($@"if({valueJs}) section.classList.add('{t.Name}'); else section.classList.remove('{t.Name}');");
                        }
                        else
                        {
                            string storageAttr = $"data-debug-class-{prop.Name.ToLower()}" + (string.IsNullOrWhiteSpace(t.Name) ? "" : "-" + t.Name.ToLower().Replace("-", "").Replace(".", ""));
                            sb.AppendLine($@"var oldClass = section.getAttribute('{storageAttr}'); if(oldClass) section.classList.remove(oldClass);");
                            sb.AppendLine($@"var newClass = {valExpr}; if(newClass) {{ section.classList.add(newClass); section.setAttribute('{storageAttr}', newClass); }} else {{ section.removeAttribute('{storageAttr}'); }}");
                        }

                    break;
                }
            }
        }

        private static void AppendResetLogic(StringBuilder sb, PropertyInfo prop, DebugPropertyAttribute? attr, string propIdJs, object? initialValue)
        {
            string elJs = $@"document.getElementById('{propIdJs}')";
            if (prop.PropertyType == typeof(bool))
            {
                string checkedVal = (initialValue is bool b && b) ? "true" : "false";
                sb.AppendLine($@"if({elJs}) {elJs}.checked = {checkedVal};");
            }
            else
            {
                string val = initialValue?.ToString() ?? "";
                if (initialValue is decimal d) val = d.ToString(CultureInfo.InvariantCulture);

                // Si c'est un enum, il faut peut-être la valeur CSS
                if (prop.PropertyType.IsEnum)
                {
                    var getCssMethod = prop.PropertyType.GetMethod("GetCss") ??
                                       prop.PropertyType.GetMethod("GetVariantCss") ??
                                       typeof(GradientAnimationCurveExtensions).GetMethod("GetCss", new[] { prop.PropertyType }) ??
                                       typeof(VariantStyleInternalExtensions).GetMethod("GetVariantCss", new[] { prop.PropertyType });
                    if (getCssMethod != null)
                    {
                        val = (string)getCssMethod.Invoke(null, new[] { initialValue })!;
                    }
                }

                sb.AppendLine($@"if({elJs}) {elJs}.value = '{JavaScriptEncoder.Default.Encode(val)}';");
            }
        }

        private static string GetFullCodeValueJs(string? pattern, List<string> parts)
        {
            if (string.IsNullOrWhiteSpace(pattern)) return "''";

            // On remplace {0}, {1}... par des concaténations JS
            string jsPattern = $"'{JavaScriptEncoder.Default.Encode(pattern)}'";
            for (int i = 0; i < parts.Count; i++)
            {
                jsPattern = jsPattern.Replace($"{{{i}}}", $"' + {parts[i]} + '");
            }

            return jsPattern;
        }

        private static string GetInitialCodeValue(string? pattern, PropertyInfo[] properties, object model)
        {
            if (string.IsNullOrWhiteSpace(pattern)) return "";

            var values = new List<object>();
            var filteredProps = properties.Where(p =>
            {
                var attr = p.GetCustomAttribute<DebugPropertyAttribute>();
                return attr?.Ignore != true && attr?.InputType != DebugInputType.Hidden && !p.Name.Equals("SectionId", StringComparison.OrdinalIgnoreCase);
            }).ToList();

            foreach (var prop in filteredProps)
            {
                var val = prop.GetValue(model);
                if (val is decimal d)
                    values.Add(d.ToString(CultureInfo.InvariantCulture));
                else if (val is bool b)
                    values.Add(b ? "true" : "false");
                else
                    values.Add(val?.ToString() ?? string.Empty);
            }

            try
            {
                return string.Format(pattern, values.ToArray());
            }
            catch
            {
                return pattern;
            }
        }

        private static string GetPropCodeValue(PropertyInfo prop, string propIdJs)
        {
            string valExpr = $@"document.getElementById('{propIdJs}').value";
            if (prop.PropertyType == typeof(bool))
            {
                return $@"(document.getElementById('{propIdJs}').checked ? 'true' : 'false')";
            }

            if (prop.PropertyType.IsEnum)
            {
                // Mapping JS pour transformer la valeur du select en nom d'enum
                var enumNames = Enum.GetNames(prop.PropertyType);
                var enumValues = Enum.GetValues(prop.PropertyType);
                var mapping = new List<string>();
                for (int i = 0; i < enumNames.Length; i++)
                {
                    var val = enumValues.GetValue(i);
                    string cssVal = val!.ToString()!;
                    var getCssMethod = prop.PropertyType.GetMethod("GetCss") ??
                                       prop.PropertyType.GetMethod("GetVariantCss") ??
                                       typeof(GradientAnimationCurveExtensions).GetMethod("GetCss", new[] { prop.PropertyType }) ??
                                       typeof(VariantStyleInternalExtensions).GetMethod("GetVariantCss", new[] { prop.PropertyType });
                    if (getCssMethod != null) cssVal = (string)getCssMethod.Invoke(null, new[] { val })!;

                    mapping.Add($@"if(v==='{cssVal}') return '{enumNames[i]}';");
                }

                return $@"(function(v){{ {string.Join(" ", mapping)} return v; }})({valExpr})";
            }

            return valExpr;
        }

        /// <summary>
        ///     Renders form for the BootstrapBuilder output.
        /// </summary>
        /// <typeparam name="T">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="model">The model value.</param>
        /// <returns>The rendered HTML content for the BootstrapBuilder component.</returns>
        public static IHtmlContent RenderForm<T>(T model) where T : class
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            Type type = typeof(T);
            var modelAttr = type.GetCustomAttribute<DebugModelAttribute>();
            var properties = type.GetProperties();

            // Résolution du SectionId (crucial pour les IDs et le ciblage JS)
            var sectionIdProp = properties.FirstOrDefault(p => p.Name.Equals("SectionId", StringComparison.OrdinalIgnoreCase));
            string sectionId = sectionIdProp?.GetValue(model)?.ToString() ?? "unknown_section";
            string sectionIdJs = JavaScriptEncoder.Default.Encode(sectionId);

            // Préfixe basé sur le type du modèle pour éviter les collisions d'IDs quand plusieurs effets sont sur la même section
            string effectKey = type.Name
                .Replace("EffectDebugModel", "")
                .Replace("DebugModel", "")
                .ToLowerInvariant();
            string formPrefix = $"{sectionId}_{effectKey}";

            var sb = new StringBuilder();
            var applyLogic = new StringBuilder();
            var resetLogic = new StringBuilder();
            var codeParts = new List<string>();

            foreach (var prop in properties)
            {
                var attr = prop.GetCustomAttribute<DebugPropertyAttribute>();
                if (attr?.Ignore == true || prop.Name.Equals("SectionId", StringComparison.OrdinalIgnoreCase)) continue;

                string propId = $"{formPrefix}_{prop.Name.ToLowerInvariant()}";
                string propIdJs = JavaScriptEncoder.Default.Encode(propId);
                string label = attr?.Label ?? prop.Name;
                object? initialValue = prop.GetValue(model);
                string initialValueStr = initialValue?.ToString() ?? string.Empty;

                // --- Rendu HTML ---
                RenderPropertyHtml(sb, prop, attr, propId, label, initialValue, properties, model);

                // --- Logique JS Apply ---
                AppendApplyLogic(applyLogic, prop, attr, propIdJs, sectionIdJs, initialValue);

                // --- Logique JS Reset ---
                AppendResetLogic(resetLogic, prop, attr, propIdJs, initialValue);

                // --- Code Pattern Part ---
                if (attr?.InputType != DebugInputType.Hidden) codeParts.Add(GetPropCodeValue(prop, propIdJs));
            }

            string formPrefixJs = JavaScriptEncoder.Default.Encode(formPrefix);

            // Script Apply
            string applyScript = $@"
(function(){{
    var section = document.getElementById('{sectionIdJs}');
    if(!section) return;
    {applyLogic}
    var code = document.getElementById('{formPrefixJs}_debug_code');
    if(code) {{
        code.value = {GetFullCodeValueJs(modelAttr?.CodePattern, codeParts)};
    }}
    var _rc = section.getAttribute('data-debug-restart-animation');
    if (_rc) {{
        if (typeof section.getAnimations === 'function') {{
            section.getAnimations({{subtree: true}}).forEach(function(a) {{ a.cancel(); a.play(); }});
        }} else {{
            section.classList.add(_rc + '-paused'); void section.offsetWidth; section.classList.remove(_rc + '-paused');
        }}
    }}
}})();";

            // Script Reset
            string resetScript = $@"
(function(){{
    var section = document.getElementById('{sectionIdJs}');
    if(!section) return;
    {resetLogic}
    {applyScript}
}})();";

            // Script Copy
            string copyScript = @"(function(el){ if(!el) return; el.select(); if(navigator.clipboard) navigator.clipboard.writeText(el.value || ''); })(this);";

            // Boutons et Code
            sb.AppendLine($@"
<div class=""d-flex justify-content-between mb-3 mt-3"">
    <button type=""button"" class=""btn btn-sm btn-outline-warning"" onclick=""{WebUtility.HtmlEncode(applyScript)}"">Apply</button>
    <button type=""button"" class=""btn btn-sm btn-outline-secondary"" onclick=""{WebUtility.HtmlEncode(resetScript)}"">Reset</button>
</div>

<input id=""{formPrefix}_debug_code"" class=""form-control border-top"" readonly value=""{WebUtility.HtmlEncode(GetInitialCodeValue(modelAttr?.CodePattern, properties, model))}"" onclick=""{WebUtility.HtmlEncode(copyScript)}"">");

            return new HtmlString(sb.ToString());
        }

        private static void RenderPropertyHtml(
            StringBuilder sb,
            PropertyInfo prop,
            DebugPropertyAttribute? attr,
            string propId,
            string label,
            object? value,
            PropertyInfo[] allProperties,
            object model
        )
        {
            var inputType = attr?.InputType ?? DebugInputType.Auto;
            if (inputType == DebugInputType.Hidden) return;

            if (inputType == DebugInputType.Auto)
            {
                if (prop.PropertyType == typeof(bool))
                    inputType = DebugInputType.Switch;
                else if (prop.PropertyType.IsEnum)
                    inputType = DebugInputType.Select;
                else if (prop.Name.Contains("Color", StringComparison.OrdinalIgnoreCase))
                    inputType = DebugInputType.Color;
                else if (prop.PropertyType == typeof(decimal) || prop.PropertyType == typeof(double) || prop.PropertyType == typeof(int))
                    inputType = DebugInputType.Number;
                else if (allProperties.Any(p => p.Name == $"Available{prop.Name}s" || p.Name == $"Available{prop.Name}"))
                    inputType = DebugInputType.Select;
                else
                    inputType = DebugInputType.Text;
            }

            sb.AppendLine($@"<div class=""input-group mb-1"">");

            if (inputType == DebugInputType.Switch)
            {
                sb.AppendLine($@"<div class=""input-group-text""><label class=""form-check-label"" for=""{propId}"">{label}</label></div>");
                sb.AppendLine($@"<div class=""form-control""><div class=""form-check form-switch m-auto"">");
                string checkedAttr = (value is bool b && b) ? " checked=\"checked\"" : "";
                sb.AppendLine($@"<input class=""form-check-input"" type=""checkbox"" id=""{propId}""{checkedAttr}>");
                sb.AppendLine(@"</div></div>");
            }
            else
            {
                sb.AppendLine($@"<label class=""input-group-text"" for=""{propId}"">{label}</label>");

                if (inputType == DebugInputType.Select)
                {
                    sb.AppendLine($@"<select id=""{propId}"" class=""form-select form-select-sm"">");

                    // Tentative de trouver une liste d'options
                    var optionsProp = allProperties.FirstOrDefault(p => p.Name == $"Available{prop.Name}s" || p.Name == $"Available{prop.Name}");
                    if (optionsProp != null && typeof(System.Collections.IEnumerable).IsAssignableFrom(optionsProp.PropertyType))
                    {
                        var options = (System.Collections.IEnumerable?)optionsProp.GetValue(model);
                        if (options != null)
                        {
                            foreach (var opt in options)
                            {
                                string optStr = opt?.ToString() ?? "";
                                string selected = string.Equals(optStr, value?.ToString(), StringComparison.OrdinalIgnoreCase) ? " selected" : "";
                                string displayName = optStr;
                                try
                                {
                                    displayName = Path.GetFileName(optStr);
                                }
                                catch
                                {
                                }

                                sb.AppendLine($@"<option value=""{WebUtility.HtmlEncode(optStr)}""{selected}>{WebUtility.HtmlEncode(displayName)}</option>");
                            }
                        }
                    }
                    else if (prop.PropertyType.IsEnum)
                    {
                        foreach (var val in Enum.GetValues(prop.PropertyType))
                        {
                            string selected = Equals(val, value) ? " selected" : "";
                            // Ici, on pourrait vouloir la valeur CSS si l'enum a GetCss()
                            string valStr = val.ToString()!;

                            // Tentative de récupérer GetCss() via réflexion
                            string htmlValue = valStr;
                            var getCssMethod = prop.PropertyType.GetMethod("GetCss") ??
                                               prop.PropertyType.GetMethod("GetVariantCss") ??
                                               typeof(GradientAnimationCurveExtensions).GetMethod("GetCss", new[] { prop.PropertyType }) ??
                                               typeof(VariantStyleInternalExtensions).GetMethod("GetVariantCss", new[] { prop.PropertyType });

                            if (getCssMethod != null)
                            {
                                htmlValue = (string)getCssMethod.Invoke(null, new[] { val })!;
                            }

                            sb.AppendLine($@"<option value=""{WebUtility.HtmlEncode(htmlValue)}""{selected}>{val}</option>");
                        }
                    }

                    sb.AppendLine("</select>");
                }
                else
                {
                    string typeAttr = inputType switch
                    {
                        DebugInputType.Color => "color",
                        DebugInputType.Number => "number",
                        _ => "text"
                    };
                    string classAttr = inputType == DebugInputType.Color ? "form-control-color" : "form-control-sm";
                    string valueStr = value?.ToString() ?? "";
                    if (value is decimal d) valueStr = d.ToString(CultureInfo.InvariantCulture);

                    string minAttr = !string.IsNullOrEmpty(attr?.Min) ? $@" min=""{attr!.Min}""" : "";
                    string maxAttr = !string.IsNullOrEmpty(attr?.Max) ? $@" max=""{attr!.Max}""" : "";
                    string stepAttr = !string.IsNullOrEmpty(attr?.Step) ? $@" step=""{attr!.Step}""" : "";

                    sb.AppendLine($@"<input id=""{propId}"" type=""{typeAttr}"" class=""form-control {classAttr}"" value=""{WebUtility.HtmlEncode(valueStr)}""{minAttr}{maxAttr}{stepAttr}>");
                }
            }

            if (!string.IsNullOrWhiteSpace(attr?.HelpText))
            {
                sb.AppendLine($@"<button type=""button"" class=""btn btn-outline-secondary"" data-bs-container=""body"" data-bs-toggle=""popover"" data-bs-html=""true"" data-bs-placement=""bottom"" data-bs-content=""{WebUtility.HtmlEncode(attr.HelpText)}""><span class=""bi bi-info-circle""></span></button>");
            }

            sb.AppendLine("</div>");
        }

        #endregion
    }
}