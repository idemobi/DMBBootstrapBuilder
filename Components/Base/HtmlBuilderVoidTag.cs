#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

// #region Copyright
//
// // Game-Data-Forge Solution
// // Written by CONTART Jean-François & BOULOGNE Quentin
// // DMBBootstrapBuilder.csproj HtmlBuilderVoidTag.cs create at 2026/04/07 21:04:27
// // ©2024-2026 idéMobi SARL FRANCE
//
// #endregion
//
// #region
//
// using Microsoft.AspNetCore.Html;
// using Microsoft.AspNetCore.Mvc.Rendering;
//
// #endregion
//
// namespace DMBBootstrapBuilder
// {
//     public class HtmlBuilderVoidTag : HtmlComponentBuilderBase<HtmlBuilderVoidTag>
//     {
//         #region Instance constructors and destructors
//
//         public HtmlBuilderVoidTag(TextWriter writer, IHtmlHelper html, HtmlVoidTag tag)
//             : base(writer, html)
//         {
//             _tag = tag.ToString().ToLowerInvariant();
//         }
//
//         public HtmlBuilderVoidTag(TextWriter writer, IHtmlHelper html, string tag)
//             : base(writer, html)
//         {
//             _tag = tag;
//         }
//
//         #endregion
//
//         #region Instance methods
//
//         public HtmlBuilderVoidTag Clone()
//         {
//             HtmlBuilderVoidTag result = new HtmlBuilderVoidTag(_textWriter, _htmlHelper, _tag);
//             foreach (KeyValuePair<string, string> attribute in _attributes)
//             {
//                 result._attributes.TryAdd(attribute.Key, attribute.Value);
//             }
//
//             foreach (KeyValuePair<string, object> inter in _internals)
//             {
//                 result._internals.TryAdd(inter.Key, inter.Value);
//             }
//
//             foreach (KeyValuePair<string, string> style in _styles)
//             {
//                 result._styles.TryAdd(style.Key, style.Value);
//             }
//
//             return result;
//         }
//
//         public override IHtmlContent Render()
//         {
//             return new HtmlString($"<{_tag}{BuiltAttributes()}>");
//         }
//
//         #endregion
//     }
// }
