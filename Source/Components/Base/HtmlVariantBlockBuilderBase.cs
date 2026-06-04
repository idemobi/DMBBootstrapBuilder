#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

// #region Copyright
//
// // Game-Data-Forge Solution
// // Written by CONTART Jean-François & BOULOGNE Quentin
// // DMBBootstrapBuilder.csproj HtmlVariantBlockBuilderBase.cs create at 2026/04/07 21:04:27
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
//     public abstract class HtmlVariantBlockBuilderBase<TBuilder> : HtmlTextComponentBuilderBase<TBuilder>
//         where TBuilder : HtmlVariantBlockBuilderBase<TBuilder>
//     {
//         #region Instance fields and properties
//
//         private VariantStyle _backgroundVariant
//         {
//             get => GetInternal("_backgroundVariant", VariantStyle.Normal);
//             set => SetInternal("_backgroundVariant", value);
//         }
//
//         private VariantStyle _textVariant
//         {
//             get => GetInternal("_textVariant", VariantStyle.Normal);
//             set => SetInternal("_textVariant", value);
//         }
//
//         #endregion
//
//         #region Instance constructors and destructors
//
//         protected HtmlVariantBlockBuilderBase(TextWriter writer, IHtmlHelper html)
//             : base(writer, html)
//         {
//         }
//
//         #endregion
//
//         #region Visual API
//
//         public TBuilder WithBackgroundVariant(VariantStyle backgroundVariant, bool autoTextVariant = true)
//         {
//             _backgroundVariant = backgroundVariant;
//             if (autoTextVariant)
//             {
//                 switch (backgroundVariant)
//                 {
//                     case VariantStyle.Primary:
//                         _textVariant = VariantStyle.Light;
//                     break;
//                     case VariantStyle.Secondary:
//                         _textVariant = VariantStyle.Light;
//                     break;
//                     case VariantStyle.Success:
//                         _textVariant = VariantStyle.Light;
//                     break;
//                     case VariantStyle.Warning:
//                         _textVariant = VariantStyle.Dark;
//                     break;
//                     case VariantStyle.Danger:
//                         _textVariant = VariantStyle.Light;
//                     break;
//                     case VariantStyle.Info:
//                         _textVariant = VariantStyle.Dark;
//                     break;
//                     case VariantStyle.Light:
//                         _textVariant = VariantStyle.Dark;
//                     break;
//                     case VariantStyle.Dark:
//                         _textVariant = VariantStyle.Light;
//                     break;
//                 }
//             }
//
//             return This();
//         }
//
//         public TBuilder WithTextVariant(VariantStyle style)
//         {
//             _textVariant = style;
//             return This();
//         }
//
//         #endregion
//     }
// }
