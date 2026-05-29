#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

// #region Copyright
//
// // Game-Data-Forge Solution
// // Written by CONTART Jean-François & BOULOGNE Quentin
// // BootstrapBuilder.csproj HtmlActionItemExtensions.cs create at 2026/03/07 11:03:12
// // ©2024-2026 idéMobi SARL FRANCE
//
// #endregion
//
// using DMBPageBuilder;

// 
// using Microsoft.AspNetCore.Html;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.AspNetCore.Mvc.Routing;
//
// namespace BootstrapBuilder
// {
//     public static class HtmlActionItemExtensions
//     {
//         public static IHtmlContent ActionItem(this IHtmlHelper htmlHelper, ActionItem item)
//         {
//             if (htmlHelper == null)
//             {
//                 throw new ArgumentNullException(nameof(htmlHelper));
//             }
//
//             if (item == null)
//             {
//                 throw new ArgumentNullException(nameof(item));
//             }
//
//             var context = HtmlRenderContextManager.Current(htmlHelper);
//
//             return context?.Kind switch
//             {
//                 HtmlRenderContextKind.Navbar => new HtmlString(RenderNavbarItem(htmlHelper, item)),
//                 HtmlRenderContextKind.DropdownMenu => new HtmlString(RenderDropdownItem(htmlHelper, item)),
//                 HtmlRenderContextKind.Menu => new HtmlString(RenderMenuItem(htmlHelper, item)),
//                 HtmlRenderContextKind.Toolbar => htmlHelper.ActionButton(item),
//                 _ => htmlHelper.ActionButton(item)
//             };
//         }
//
//         public static IHtmlContent ActionButton(this IHtmlHelper htmlHelper, ActionItem item)
//         {
//             if (htmlHelper == null)
//             {
//                 throw new ArgumentNullException(nameof(htmlHelper));
//             }
//
//             if (item == null)
//             {
//                 throw new ArgumentNullException(nameof(item));
//             }
//
//             return new ButtonBuilder(htmlHelper, item).Render();
//         }
//
//         public static IHtmlContent ActionLink(this IHtmlHelper htmlHelper, ActionItem item)
//         {
//             return new HtmlString(RenderLink(htmlHelper, item));
//         }
//
//         public static IHtmlContent ActionNavbarItem(this IHtmlHelper htmlHelper, ActionItem item)
//         {
//             return new HtmlString(RenderNavbarItem(htmlHelper, item));
//         }
//
//         public static IHtmlContent ActionDropdownItem(this IHtmlHelper htmlHelper, ActionItem item)
//         {
//             return new HtmlString(RenderDropdownItem(htmlHelper, item));
//         }
//
//         public static IHtmlContent ActionMenuItem(this IHtmlHelper htmlHelper, ActionItem item)
//         {
//             return new HtmlString(RenderMenuItem(htmlHelper, item));
//         }
//
//         #region Link rendering
//
//         private static string RenderLink(IHtmlHelper htmlHelper, ActionItem item)
//         {
//             if (item.IsSwitch)
//             {
//                 return RenderSwitchAsLinkLike(htmlHelper, item);
//             }
//
//             var active = item.Active ? " active" : string.Empty;
//             var disabled = item.Disabled ? " disabled" : string.Empty;
//             var css = $"link-body-emphasis {item.AdditionalClasses}{active}{disabled}";
//             var id = RenderId(item);
//             var content = RenderContent(htmlHelper, item);
//
//             return item.Kind switch
//             {
//                 ActionItemKind.Url => $@"<a{id} href=""{HtmlEncode(item.Url)}"" class=""{css}{GetDebugOnlyCss(item)}""{RenderTarget(item)}{RenderRel(item)}>{content}</a>",
//                 ActionItemKind.JavaScript => $@"<a{id} href=""#"" class=""{css}{GetDebugOnlyCss(item)}"" onclick=""{HtmlEncode(item.JavaScript)}"">{content}</a>",
//                 ActionItemKind.Modal => $@"<a{id} href=""#"" class=""{css}{GetDebugOnlyCss(item)}"" data-bs-toggle=""modal"" data-bs-target=""#{HtmlEncode(item.ModalTargetId)}"">{content}</a>",
//                 ActionItemKind.AspRoute => $@"<a{id} href=""{HtmlEncode(BuildAspRouteUrl(htmlHelper, item))}"" class=""{css}{GetDebugOnlyCss(item)}"">{content}</a>",
//                 _ => $@"<span{id} class=""{css}{GetDebugOnlyCss(item)}"">{content}</span>"
//             };
//         }
//
//         #endregion
//
//         #region Navbar rendering
//
//         private static string RenderNavbarItem(IHtmlHelper htmlHelper, ActionItem item)
//         {
//             if (item.IsDivider)
//             {
//                 return string.Empty;
//             }
//
//             if (item.IsGroup)
//             {
//                 return RenderNavbarGroup(htmlHelper, item);
//             }
//
//             if (item.HasChildren)
//             {
//                 return RenderNavbarDropdown(htmlHelper, item);
//             }
//
//             if (item.IsSwitch)
//             {
//                 return RenderNavbarSwitch(htmlHelper, item);
//             }
//
//             var active = item.Active ? " active" : string.Empty;
//             var disabled = item.Disabled ? " disabled" : string.Empty;
//             var css = $"nav-link {item.AdditionalClasses}{active}{disabled}";
//             var id = RenderId(item);
//             var content = RenderContent(htmlHelper, item);
//
//             return item.Kind switch
//             {
//                 ActionItemKind.Url => $@"<li class=""nav-item""><a{id} href=""{HtmlEncode(item.Url)}"" class=""{css}{GetDebugOnlyCss(item)}""{RenderTarget(item)}{RenderRel(item)}>{content}</a></li>",
//                 ActionItemKind.JavaScript => $@"<li class=""nav-item""><a{id} href=""#"" class=""{css}{GetDebugOnlyCss(item)}"" onclick=""{HtmlEncode(item.JavaScript)}"">{content}</a></li>",
//                 ActionItemKind.Modal => $@"<li class=""nav-item""><a{id} href=""#"" class=""{css}{GetDebugOnlyCss(item)}"" data-bs-toggle=""modal"" data-bs-target=""#{HtmlEncode(item.ModalTargetId)}"">{content}</a></li>",
//                 ActionItemKind.AspRoute => $@"<li class=""nav-item""><a{id} href=""{HtmlEncode(BuildAspRouteUrl(htmlHelper, item))}"" class=""{css}{GetDebugOnlyCss(item)}"">{content}</a></li>",
//                 _ => $@"<li class=""nav-item""><span{id} class=""{css}{GetDebugOnlyCss(item)}"">{content}</span></li>"
//             };
//         }
//
//         private static string RenderNavbarDropdown(IHtmlHelper htmlHelper, ActionItem item)
//         {
//             var sb = new StringBuilder();
//             var id = string.IsNullOrWhiteSpace(item.Id) ? htmlHelper.GenerateUniqueId("dropdown") : item.Id;
//             var content = RenderContent(htmlHelper, item);
//             var active = item.Active ? " active" : string.Empty;
//
//             sb.Append($@"<li class=""nav-item dropdown"">");
//             sb.Append($@"<a id=""{HtmlEncode(id)}"" class=""nav-link dropdown-toggle {item.AdditionalClasses}{active}{GetDebugOnlyCss(item)}"" href=""#"" role=""button"" data-bs-toggle=""dropdown"" aria-expanded=""false"">{content}</a>");
//             sb.Append("""<ul class="dropdown-menu">""");
//
//             foreach (var child in item.Items)
//             {
//                 sb.Append(RenderDropdownItem(htmlHelper, child));
//             }
//
//             sb.Append("</ul></li>");
//             return sb.ToString();
//         }
//
//         private static string RenderNavbarGroup(IHtmlHelper htmlHelper, ActionItem item)
//         {
//             var sb = new StringBuilder();
//
//             foreach (var child in item.Items)
//             {
//                 sb.Append(RenderNavbarItem(htmlHelper, child));
//             }
//
//             return sb.ToString();
//         }
//
//         private static string RenderNavbarSwitch(IHtmlHelper htmlHelper, ActionItem item)
//         {
//             var id = string.IsNullOrWhiteSpace(item.Id) ? htmlHelper.GenerateUniqueId("switch") : item.Id;
//             var content = RenderContent(htmlHelper, item);
//             var checkedText = item.SwitchValue ? @" checked=""checked""" : string.Empty;
//             var onchange = string.IsNullOrWhiteSpace(item.SwitchJavaScript) ? string.Empty : $@" onchange=""{HtmlEncode(item.SwitchJavaScript)}""";
//
//             return $@"
// <li class=""nav-item d-flex align-items-center {item.AdditionalClasses}{GetDebugOnlyCss(item)}"">
//     <div class=""form-check form-switch m-0"">
//         <input id=""{HtmlEncode(id)}"" class=""form-check-input"" type=""checkbox""{checkedText}{onchange}>
//     </div>
//     <label class=""nav-link mb-0"" for=""{HtmlEncode(id)}"">{content}</label>
// </li>";
//         }
//
//         #endregion
//
//         #region Dropdown rendering
//
//         private static string RenderDropdownItem(IHtmlHelper htmlHelper, ActionItem item)
//         {
//             return RenderDropdownItem(htmlHelper, item, false);
//         }
//
//         private static string RenderDropdownItem(IHtmlHelper htmlHelper, ActionItem item, bool indented)
//         {
//             if (item.IsDivider)
//             {
//                 return RenderDropdownDivider(indented);
//             }
//
//             if (item.IsGroup)
//             {
//                 return RenderDropdownGroup(htmlHelper, item);
//             }
//
//             if (item.HasChildren)
//             {
//                 return RenderDropdownNested(htmlHelper, item, indented);
//             }
//
//             if (item.IsSwitch)
//             {
//                 return RenderDropdownSwitch(htmlHelper, item, indented);
//             }
//
//             var active = item.Active ? " active" : string.Empty;
//             var disabled = item.Disabled ? " disabled" : string.Empty;
//             var indentCss = indented ? " ps-4" : string.Empty;
//             var textStyleCss = GetDropdownTextStyleCss(item);
//             var css = $"dropdown-item {item.AdditionalClasses}{active}{disabled}{indentCss}";
//             if (!string.IsNullOrWhiteSpace(textStyleCss))
//             {
//                 css += $" {textStyleCss}";
//             }
//
//             var id = RenderId(item);
//             var content = RenderContent(htmlHelper, item);
//
//             return item.Kind switch
//             {
//                 ActionItemKind.Url => $@"<li><a{id} href=""{HtmlEncode(item.Url)}"" class=""{css}{GetDebugOnlyCss(item)}""{RenderTarget(item)}{RenderRel(item)}>{content}</a></li>",
//                 ActionItemKind.JavaScript => $@"<li><a{id} href=""#"" class=""{css}{GetDebugOnlyCss(item)}"" onclick=""{HtmlEncode(item.JavaScript)}"">{content}</a></li>",
//                 ActionItemKind.Modal => $@"<li><a{id} href=""#"" class=""{css}{GetDebugOnlyCss(item)}"" data-bs-toggle=""modal"" data-bs-target=""#{HtmlEncode(item.ModalTargetId)}"">{content}</a></li>",
//                 ActionItemKind.AspRoute => $@"<li><a{id} href=""{HtmlEncode(BuildAspRouteUrl(htmlHelper, item))}"" class=""{css}{GetDebugOnlyCss(item)}"">{content}</a></li>",
//                 _ => $@"<li><span{id} class=""{css}{GetDebugOnlyCss(item)}"">{content}</span></li>"
//             };
//         }
//
//         private static string RenderDropdownNested(IHtmlHelper htmlHelper, ActionItem item, bool indented)
//         {
//             var sb = new StringBuilder();
//             var id = string.IsNullOrWhiteSpace(item.Id) ? htmlHelper.GenerateUniqueId("dropdown") : item.Id;
//             var content = RenderContent(htmlHelper, item);
//             var indentCss = indented ? " ps-4" : string.Empty;
//
//             sb.Append($@"<li class=""dropdown-submenu{GetDebugOnlyCss(item)}"">");
//             sb.Append($@"<a id=""{HtmlEncode(id)}"" class=""dropdown-item dropdown-toggle {item.AdditionalClasses}{indentCss}"" href=""#"" data-bs-toggle=""dropdown"">{content}</a>");
//             sb.Append("""<ul class="dropdown-menu">""");
//
//             foreach (var child in item.Items)
//             {
//                 sb.Append(RenderDropdownItem(htmlHelper, child));
//             }
//
//             sb.Append("</ul></li>");
//             return sb.ToString();
//         }
//
//         private static string RenderDropdownGroup(IHtmlHelper htmlHelper, ActionItem item)
//         {
//             var sb = new StringBuilder();
//             
//             var iconHtml = item.Icon.IsEmpty
//                 ? string.Empty
//                 : HtmlLayoutExtensions.IconBuilder(htmlHelper, item.Icon).ToString();
//
//             var titleHtml = HtmlEncode(item.Title);
//             var subtitleHtml = string.IsNullOrWhiteSpace(item.Subtitle)
//                 ? string.Empty
//                 : $@"<div class=""small text-body-secondary"">{HtmlEncode(item.Subtitle)}</div>";
//
//             sb.Append("""
// <li>
//     <div class="dropdown-item-text py-2">
//         <div class="d-flex align-items-start gap-2">
// """);
//             if (!string.IsNullOrWhiteSpace(iconHtml))
//             {
//                 sb.Append($@"<div class=""flex-shrink-0"">{iconHtml}</div>");
//             }
//
//             sb.Append($"""
//             <div class="flex-grow-1">
//                 <div class="fw-semibold">{titleHtml}</div>
//                 {subtitleHtml}
//             </div>
//         </div>
//     </div>
// </li>
// """);
//
//             foreach (var child in item.Items)
//             {
//                 sb.Append(RenderDropdownItem(htmlHelper, child, true));
//             }
//
//             return sb.ToString();
//         }
//
//         private static string RenderDropdownDivider(bool indented)
//         {
//             var indentCss = indented ? " ms-4" : string.Empty;
//             return $@"<li><hr class=""dropdown-divider{indentCss}""></li>";
//         }
//
//         private static string RenderDropdownSwitch(IHtmlHelper htmlHelper, ActionItem item, bool indented)
//         {
//             var id = string.IsNullOrWhiteSpace(item.Id) ? htmlHelper.GenerateUniqueId("switch") : item.Id;
//             var checkedText = item.SwitchValue ? @" checked=""checked""" : string.Empty;
//             var onchange = string.IsNullOrWhiteSpace(item.SwitchJavaScript) ? string.Empty : $@" onchange=""{HtmlEncode(item.SwitchJavaScript)}""";
//             var indentCss = indented ? " ps-4" : string.Empty;
//             var textStyleCss = GetDropdownTextStyleCss(item);
//             var content = RenderContent(htmlHelper, item);
//
//             return $@"
// <li class=""{GetDebugOnlyCss(item)}"">
//     <div class=""dropdown-item-text d-flex justify-content-between align-items-center {item.AdditionalClasses}{indentCss} {textStyleCss}"">
//         <label class=""mb-0 flex-grow-1"" for=""{HtmlEncode(id)}"">{content}</label>
//         <div class=""form-check form-switch m-0"">
//             <input id=""{HtmlEncode(id)}"" class=""form-check-input"" type=""checkbox""{checkedText}{onchange}>
//         </div>
//     </div>
// </li>";
//         }
//
//         #endregion
//
//         #region Menu rendering
//
//         private static string RenderMenuItem(IHtmlHelper htmlHelper, ActionItem item)
//         {
//             if (item.IsDivider)
//             {
//                 return """<hr class="menu-divider" />""";
//             }
//
//             if (item.IsGroup)
//             {
//                 var sb = new StringBuilder();
//
//                 if (!string.IsNullOrWhiteSpace(item.Title))
//                 {
//                     sb.Append($"""<div class="menu-group-title fw-semibold">{HtmlEncode(item.Title)}</div>""");
//                 }
//
//                 if (!string.IsNullOrWhiteSpace(item.Subtitle))
//                 {
//                     sb.Append($"""<div class="menu-group-subtitle small text-body-secondary">{HtmlEncode(item.Subtitle)}</div>""");
//                 }
//
//                 foreach (var child in item.Items)
//                 {
//                     sb.Append(RenderMenuItem(htmlHelper, child));
//                 }
//
//                 return sb.ToString();
//             }
//
//             if (item.IsSwitch)
//             {
//                 return RenderMenuSwitch(htmlHelper, item);
//             }
//
//             return RenderLink(htmlHelper, item);
//         }
//
//         private static string RenderMenuSwitch(IHtmlHelper htmlHelper, ActionItem item)
//         {
//             var id = string.IsNullOrWhiteSpace(item.Id) ? htmlHelper.GenerateUniqueId("switch") : item.Id;
//             var checkedText = item.SwitchValue ? @" checked=""checked""" : string.Empty;
//             var onchange = string.IsNullOrWhiteSpace(item.SwitchJavaScript) ? string.Empty : $@" onchange=""{HtmlEncode(item.SwitchJavaScript)}""";
//             var content = RenderContent(htmlHelper, item);
//
//             return $@"
// <div class=""menu-item d-flex justify-content-between align-items-center {item.AdditionalClasses}{GetDebugOnlyCss(item)}"">
//     <label class=""mb-0 flex-grow-1"" for=""{HtmlEncode(id)}"">{content}</label>
//     <div class=""form-check form-switch m-0"">
//         <input id=""{HtmlEncode(id)}"" class=""form-check-input"" type=""checkbox""{checkedText}{onchange}>
//     </div>
// </div>";
//         }
//
//         #endregion
//
//         #region Switch in button/link contexts
//
//         private static string RenderSwitchAsLinkLike(IHtmlHelper htmlHelper, ActionItem item)
//         {
//             var id = string.IsNullOrWhiteSpace(item.Id) ? htmlHelper.GenerateUniqueId("switch") : item.Id;
//             var checkedText = item.SwitchValue ? @" checked=""checked""" : string.Empty;
//             var onchange = string.IsNullOrWhiteSpace(item.SwitchJavaScript) ? string.Empty : $@" onchange=""{HtmlEncode(item.SwitchJavaScript)}""";
//             var content = RenderContent(htmlHelper, item);
//
//             return $@"
// <span class=""d-inline-flex align-items-center gap-2 {item.AdditionalClasses}{GetDebugOnlyCss(item)}"">
//     <label class=""mb-0"" for=""{HtmlEncode(id)}"">{content}</label>
//     <div class=""form-check form-switch m-0"">
//         <input id=""{HtmlEncode(id)}"" class=""form-check-input"" type=""checkbox""{checkedText}{onchange}>
//     </div>
// </span>";
//         }
//
//         #endregion
//
//         #region Helpers
//
//         private static string RenderContent(IHtmlHelper htmlHelper, ActionItem item)
//         {
//             var iconHtml = item.Icon.IsEmpty
//                 ? string.Empty
//                 : HtmlLayoutExtensions.IconBuilder(htmlHelper, item.Icon).ToString();
//             return $"{iconHtml}{HtmlEncode(item.Title)}";
//         }
//
//         private static string BuildAspRouteUrl(IHtmlHelper htmlHelper, ActionItem item)
//         {
//             var urlHelper = new UrlHelper(htmlHelper.ViewContext);
//
//             var routeValues = new Dictionary<string, object?>();
//
//             if (!string.IsNullOrWhiteSpace(item.AspArea))
//             {
//                 routeValues["area"] = item.AspArea;
//             }
//
//             foreach (var kvp in item.RouteValues)
//             {
//                 routeValues[kvp.Key] = kvp.Value;
//             }
//
//             var context = new UrlActionContext
//             {
//                 Action = item.AspAction,
//                 Controller = item.AspController,
//                 Values = routeValues
//             };
//
//             return urlHelper.Action(context) ?? "#";
//         }
//
//         private static string RenderId(ActionItem item)
//         {
//             return string.IsNullOrWhiteSpace(item.Id) ? string.Empty : $@" id=""{HtmlEncode(item.Id)}""";
//         }
//
//         private static string RenderTarget(ActionItem item)
//         {
//             return string.IsNullOrWhiteSpace(item.Target) ? string.Empty : $@" target=""{HtmlEncode(item.Target)}""";
//         }
//
//         private static string RenderRel(ActionItem item)
//         {
//             return string.IsNullOrWhiteSpace(item.Rel) ? string.Empty : $@" rel=""{HtmlEncode(item.Rel)}""";
//         }
//
//         private static string HtmlEncode(string? value)
//         {
//             return System.Net.WebUtility.HtmlEncode(value ?? string.Empty);
//         }
//
//         private static string GetDebugOnlyCss(ActionItem item)
//         {
//             return item.DebugOnly ? " theme-debug-only" : string.Empty;
//         }
//
//         private static string GetDropdownTextStyleCss(ActionItem item)
//         {
//             if (item.Active)
//             {
//                 return string.Empty;
//             }
//
//             return item.Variant switch
//             {
//                 VariantStyle.Primary => "text-primary",
//                 VariantStyle.Secondary => "text-secondary",
//                 VariantStyle.Success => "text-success",
//                 VariantStyle.Warning => "text-warning",
//                 VariantStyle.Danger => "text-danger",
//                 VariantStyle.Info => "text-info",
//                 VariantStyle.Light => "text-light",
//                 VariantStyle.Dark => "text-dark",
//                 VariantStyle.Tertiary => "text-body",
//                 _ => string.Empty
//             };
//         }
//
//         #endregion
//     }
// }
