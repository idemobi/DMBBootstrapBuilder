#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

// #region Copyright
//
// // Game-Data-Forge Solution
// // Written by CONTART Jean-François & BOULOGNE Quentin
// // BootstrapBuilder.csproj ModalDismissButtonBuilder.cs create at 2026/03/07 17:03:06
// // ©2024-2026 idéMobi SARL FRANCE
//
// #endregion
//
// using DMBPageBuilder;

// 
// using Microsoft.AspNetCore.Html;
// using Microsoft.AspNetCore.Mvc.Rendering;
//
// namespace BootstrapBuilder
// {
//     public sealed class ModalDismissButtonBuilder : HtmlComponentBuilderBase<ModalDismissButtonBuilder>
//     {
//         private readonly IHtmlHelper _html;
//         private readonly string _title;
//         private readonly IconStruct _icon;
//
//         public ModalDismissButtonBuilder(
//             IHtmlHelper html,
//             string title,
//             VariantStyle style,
//             IconStruct icon)
//             : base(writer, html)
//         {
//             _html = html ?? throw new ArgumentNullException(nameof(html));
//             _title = title ?? throw new ArgumentNullException(nameof(title));
//             _icon = icon;
//             ElementStyle = style;
//         }
//
//         public IHtmlContent Render()
//         {
//             var context = HtmlRenderContextManager.Current(_html);
//
//             if (context == null)
//             {
//                 return HtmlString.Empty;
//             }
//
//             if (!context.Data.TryGetValue("ParentKind", out var parentKindObj) ||
//                 parentKindObj is not HtmlRenderContextKind parentKind ||
//                 parentKind != HtmlRenderContextKind.Modal)
//             {
//                 return HtmlString.Empty;
//             }
//
//             var iconHtml = _icon.IsEmpty
//                 ? string.Empty
//                 : HtmlLayoutExtensions.IconBuilder(_html, _icon, true).ToString();
//
//             string classes = string.Join(
//                 " ",
//                 new[]
//                 {
//                     $"btn btn-{GetStyleCss()}",
//                     GetCommonCss()
//                 }
//                 .Where(x => !string.IsNullOrWhiteSpace(x)));
//
//             return new HtmlString($"""
// <button type="button"
//         class="{classes}"
//         data-bs-dismiss="modal"{GetIdAttribute()}{GetDisabledAttribute()}>
//     {iconHtml}{_title}
// </button>
// """);
//         }
//     }
// }
