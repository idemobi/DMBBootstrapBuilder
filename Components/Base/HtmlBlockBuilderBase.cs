#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

// #region Copyright
//
// // Game-Data-Forge Solution
// // Written by CONTART Jean-François & BOULOGNE Quentin
// // DMBBootstrapBuilder.csproj HtmlBlockBuilderBase.cs create at 2026/04/07 21:04:27
// // ©2024-2026 idéMobi SARL FRANCE
//
// #endregion
//
// #region
//
// using System.Diagnostics;
// using System.Text.Encodings.Web;
// using DMBPageBuilder;
// using Microsoft.AspNetCore.Mvc.Rendering;
//
// #endregion
//
// namespace DMBBootstrapBuilder
// {
//     public abstract class HtmlBlockBuilderBase<TBuilder> :
//         HtmlTextComponentBuilderBase<TBuilder>,
//         IDisposable, ICanUseCustomClasses
//         where TBuilder : HtmlBuilderBase<TBuilder>
//     {
//         #region Instance fields and properties
//
//         protected bool _started;
//         protected HtmlRenderContext? _renderContext;
//
//         internal IHtmlHelper HtmlHelper => _htmlHelper;
//
//         #endregion
//
//         #region Instance constructors and destructors
//
//         protected HtmlBlockBuilderBase(TextWriter writer, IHtmlHelper html)
//             : base(writer, html)
//         {
//             _tag = "div";
//         }
//
//         #endregion
//
//         #region Instance methods
//
//         public TBuilder WithAutoId(out string id, string prefix = "tag")
//         {
//             string? existingId = GetAttributeValue("id");
//
//             if (string.IsNullOrWhiteSpace(existingId))
//             {
//                 id = _htmlHelper.GenerateUniqueId(prefix);
//                 SetAttribute("id", id);
//             }
//             else
//             {
//                 id = existingId;
//             }
//
//             return This();
//         }
//
//         public virtual TBuilder Begin()
//         {
//             if (_started)
//             {
//                 return This();
//             }
//
//             DebugStart();
//             _started = true;
//
//             OnRenderDebug();
//             OnBeginRendering();
//
//             if (_renderContext != null)
//             {
//                 HtmlRenderContextManager.Push(HtmlHelper, _renderContext);
//             }
//
//             _textWriter.Write($"<{_tag}{BuildAttributes()}>");
//
//             return This();
//         }
//
//         public virtual void End()
//         {
//             if (!_started)
//             {
//                 return;
//             }
//
//             _textWriter.Write($"</{_tag}>");
//
//             try
//             {
//                 OnEndRendering();
//             }
//             finally
//             {
//                 if (_renderContext != null)
//                 {
//                     HtmlRenderContext? current = HtmlRenderContextManager.Current(HtmlHelper);
//
//                     if (ReferenceEquals(current, _renderContext))
//                     {
//                         HtmlRenderContextManager.Pop(HtmlHelper);
//                     }
//
//                     _renderContext = null;
//                 }
//
//                 _started = false;
//                 DebugEnd();
//             }
//         }
//
//         public void Dispose()
//         {
//             End();
//         }
//
//         protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
//         {
//             OnRenderDebug();
//             OnBeginRendering();
//
//             HtmlRenderContext? localContext = _renderContext;
//
//             if (localContext != null)
//             {
//                 HtmlRenderContextManager.Push(HtmlHelper, localContext);
//             }
//
//             try
//             {
//                 writer.Write($"<{_tag}{BuildAttributes()}>");
//                 writer.Write($"</{_tag}>");
//             }
//             finally
//             {
//                 try
//                 {
//                     OnEndRendering();
//                 }
//                 finally
//                 {
//                     if (localContext != null)
//                     {
//                         HtmlRenderContext? current = HtmlRenderContextManager.Current(HtmlHelper);
//
//                         if (ReferenceEquals(current, localContext))
//                         {
//                             HtmlRenderContextManager.Pop(HtmlHelper);
//                         }
//                     }
//
//                     if (ReferenceEquals(_renderContext, localContext))
//                     {
//                         _renderContext = null;
//                     }
//                 }
//             }
//         }
//
//         protected virtual void OnBeginRendering()
//         {
//         }
//
//         protected virtual void OnEndRendering()
//         {
//         }
//
//         [Conditional("DEBUG")]
//         protected void DebugStart()
//         {
//             #if DEBUG
//             string name = GetType().Name.Replace("Builder", "", StringComparison.Ordinal);
//             _textWriter.Write($"<!-- Debug : {name} start -->");
//             #endif
//         }
//
//         [Conditional("DEBUG")]
//         protected void DebugEnd()
//         {
//             #if DEBUG
//             string name = GetType().Name.Replace("Builder", "", StringComparison.Ordinal);
//             _textWriter.Write($"<!-- Debug : {name} end -->");
//             #endif
//         }
//
//         #endregion
//     }
// }
