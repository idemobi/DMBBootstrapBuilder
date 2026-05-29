#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

// #region Copyright
//
// // Game-Data-Forge Solution
// // Written by CONTART Jean-François & BOULOGNE Quentin
// // DMBBootstrapBuilder.csproj HtmlBuilderTag.cs create at 2026/04/07 21:04:27
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
//     public class HtmlBuilderTag : HtmlComponentBuilderBase<HtmlBuilderTag>, ICanUseCustomClasses
//     {
//         #region Instance fields and properties
//
//         private string _inner;
//
//         #endregion
//
//         #region Instance constructors and destructors
//
//         public HtmlBuilderTag(TextWriter writer, IHtmlHelper html, HtmlTag tag, string? inner = null)
//             : base(writer, html)
//         {
//             _tag = tag.ToString().ToLowerInvariant();
//             _inner = inner;
//         }
//
//         public HtmlBuilderTag(TextWriter writer, IHtmlHelper html, string tag, string? inner = null)
//             : base(writer, html)
//         {
//             _tag = tag;
//             _inner = inner;
//         }
//
//         #endregion
//
//         #region Instance methods
//
//         public HtmlBuilderTag Clone()
//         {
//             HtmlBuilderTag result = new HtmlBuilderTag(_textWriter, _htmlHelper, _tag, _inner);
//             result._tag = _tag;
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
//             if (string.IsNullOrWhiteSpace(_inner))
//             {
//                 return new HtmlString($"<{_tag}{BuiltAttributes()}></{_tag}>");
//             }
//
//             return new HtmlString($"<{_tag}{BuiltAttributes()}>{_inner}</{_tag}>");
//         }
//
//         public HtmlBuilderTag SetInner(string inner)
//         {
//             _inner = inner;
//             return this;
//         }
//
//         #endregion
//     }
// }
