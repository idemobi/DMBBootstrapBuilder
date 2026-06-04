#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

// #region Copyright
//
// // Game-Data-Forge Solution
// // Written by CONTART Jean-François & BOULOGNE Quentin
// // DMBBootstrapBuilder.csproj HtmlFlexRegionBuilderBase.cs create at 2026/04/07 21:04:27
// // ©2024-2026 idéMobi SARL FRANCE
//
// #endregion
//
// #region
//
// using DMBPageBuilder;
// using Microsoft.AspNetCore.Mvc.Rendering;
//
// #endregion
//
// namespace DMBBootstrapBuilder
// {
//     public abstract class HtmlFlexRegionBuilderBase<TBuilder> : HtmlConstrainedTagBuilder<TBuilder>
//         where TBuilder : HtmlConstrainedTagBuilder<TBuilder>
//     {
//         #region Instance fields and properties
//
//         private readonly HtmlFlexOptions _flexOptions = new();
//
//         #endregion
//
//         #region Instance constructors and destructors
//
//         protected HtmlFlexRegionBuilderBase(TextWriter writer, IHtmlHelper html)
//             : base(writer, html)
//         {
//         }
//
//         #endregion
//
//         #region Instance methods
//
//         protected string GetFlexCssClasses()
//         {
//             return _flexOptions.BuildCssClasses();
//         }
//
//         protected override string BuildClassValue(params string[] additionalClasses)
//         {
//             List<string> classes = new();
//
//             string flexCss = _flexOptions.BuildCssClasses();
//             if (!string.IsNullOrWhiteSpace(flexCss))
//             {
//                 classes.Add(flexCss);
//             }
//
//             if (additionalClasses is { Length: > 0 })
//             {
//                 classes.AddRange(additionalClasses.Where(x => !string.IsNullOrWhiteSpace(x)));
//             }
//
//             return base.BuildClassValue(classes.ToArray());
//         }
//
//         public TBuilder SetAlignItemsCenter()
//         {
//             _flexOptions.AlignItems = AlignItems.Center;
//             return This();
//         }
//
//         public TBuilder SetAlignItemsEnd()
//         {
//             _flexOptions.AlignItems = AlignItems.End;
//             return This();
//         }
//
//         public TBuilder SetAlignItemsStart()
//         {
//             _flexOptions.AlignItems = AlignItems.Start;
//             return This();
//         }
//
//         public TBuilder SetAlignItemsStretch()
//         {
//             _flexOptions.AlignItems = AlignItems.Stretch;
//             return This();
//         }
//
//         public TBuilder SetJustifyContentAround()
//         {
//             _flexOptions.JustifyContent = JustifyContent.Around;
//             return This();
//         }
//
//         public TBuilder SetJustifyContentBetween()
//         {
//             _flexOptions.JustifyContent = JustifyContent.Between;
//             return This();
//         }
//
//         public TBuilder SetJustifyContentCenter()
//         {
//             _flexOptions.JustifyContent = JustifyContent.Center;
//             return This();
//         }
//
//         public TBuilder SetJustifyContentEnd()
//         {
//             _flexOptions.JustifyContent = JustifyContent.End;
//             return This();
//         }
//
//         public TBuilder SetJustifyContentEvenly()
//         {
//             _flexOptions.JustifyContent = JustifyContent.Evenly;
//             return This();
//         }
//
//         public TBuilder SetJustifyContentStart()
//         {
//             _flexOptions.JustifyContent = JustifyContent.Start;
//             return This();
//         }
//
//         public TBuilder SetNoWrap()
//         {
//             _flexOptions.Wrap = false;
//             return This();
//         }
//
//         public TBuilder WithAdditionalClasses(string classes)
//         {
//             _flexOptions.AdditionalClasses = classes;
//             return This();
//         }
//
//         public TBuilder WithAlignItems(AlignItems alignItems)
//         {
//             _flexOptions.AlignItems = alignItems;
//             return This();
//         }
//
//         public TBuilder WithGap(Old_Gap oldGap = Old_Gap.Default)
//         {
//             _flexOptions.OldGapStyle = oldGap;
//             return This();
//         }
//
//         public TBuilder WithJustifyContent(JustifyContent justifyContent)
//         {
//             _flexOptions.JustifyContent = justifyContent;
//             return This();
//         }
//
//         public TBuilder WithWrap(bool wrap = true)
//         {
//             _flexOptions.Wrap = wrap;
//             return This();
//         }
//
//         #endregion
//     }
// }
