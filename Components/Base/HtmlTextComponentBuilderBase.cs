// #region Copyright
//
// // Game-Data-Forge Solution
// // Written by CONTART Jean-François & BOULOGNE Quentin
// // DMBBootstrapBuilder.csproj HtmlTextComponentBuilderBase.cs create at 2026/04/07 21:04:27
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
//     public abstract class HtmlTextComponentBuilderBase<TBuilder> :
//         HtmlBuilderBase<TBuilder>,
//         ICanUseCustomClasses
//         where TBuilder : HtmlBuilderBase<TBuilder>
//     {
//         #region Instance fields and properties
//
//         private FontItalic _fontItalic
//         {
//             get => GetInternal("_fontItalic", FontItalic.Normal);
//             set => SetInternal("_fontItalic", value);
//         }
//
//         private FontSize _fontSize
//         {
//             get => GetInternal("_fontSize", FontSize.Normal);
//             set => SetInternal("_fontSize", value);
//         }
//
//         private FontWeight _fontWeight
//         {
//             get => GetInternal("_fontWeight", FontWeight.None);
//             set => SetInternal("_fontWeight", value);
//         }
//
//         private LineHeight _lineHeight
//         {
//             get => GetInternal("_lineHeight", LineHeight.Normal);
//             set => SetInternal("_lineHeight", value);
//         }
//
//         private Monospace _monospace
//         {
//             get => GetInternal("_monospace", Monospace.None);
//             set => SetInternal("_monospace", value);
//         }
//
//         private ResetTextColor _resetTextColor
//         {
//             get => GetInternal("_resetTextColor", ResetTextColor.Normal);
//             set => SetInternal("_resetTextColor", value);
//         }
//
//         private TextAlign _textAlign
//         {
//             get => GetInternal("_textAlign", TextAlign.Default);
//             set => SetInternal("_textAlign", value);
//         }
//
//         private TextDecoration _textDecoration
//         {
//             get => GetInternal("_textDecoration", TextDecoration.None);
//             set => SetInternal("_textDecoration", value);
//         }
//
//         private TextMuted _textMuted
//         {
//             get => GetInternal("_textMuted", TextMuted.None);
//             set => SetInternal("_textMuted", value);
//         }
//
//         private TextTransform _textTransform
//         {
//             get => GetInternal("_textTransform", TextTransform.Normal);
//             set => SetInternal("_textTransform", value);
//         }
//
//         private WordBreak _wordBreak
//         {
//             get => GetInternal("_wordBreak", WordBreak.None);
//             set => SetInternal("_wordBreak", value);
//         }
//
//         private TextWrapping _wrapping
//         {
//             get => GetInternal("_wrapping", TextWrapping.Normal);
//             set => SetInternal("_wrapping", value);
//         }
//
//         #endregion
//
//         #region Instance constructors and destructors
//
//         protected HtmlTextComponentBuilderBase(TextWriter writer, IHtmlHelper html)
//             : base(writer, html)
//         {
//         }
//
//         #endregion
//
//         #region Instance methods
//
//         protected override string BuildClassValue(params string[] additionalClasses)
//         {
//             List<string> computedClasses = new();
//
//             if (_textDecoration != TextDecoration.None)
//             {
//                 computedClasses.Add(_textDecoration.GetCss());
//             }
//
//             if (_resetTextColor != ResetTextColor.Normal)
//             {
//                 computedClasses.Add(_resetTextColor.GetCss());
//             }
//
//             if (_monospace != Monospace.None)
//             {
//                 computedClasses.Add(_monospace.GetCss());
//             }
//
//             if (_lineHeight != LineHeight.Normal)
//             {
//                 computedClasses.Add(_lineHeight.GetCss());
//             }
//
//             if (_fontItalic != FontItalic.Normal)
//             {
//                 computedClasses.Add(_fontItalic.GetCss());
//             }
//
//             if (_fontWeight != FontWeight.None)
//             {
//                 computedClasses.Add(_fontWeight.GetCss());
//             }
//
//             if (_fontSize != FontSize.Normal)
//             {
//                 computedClasses.Add(_fontSize.GetCss());
//             }
//
//             if (_textTransform != TextTransform.Normal)
//             {
//                 computedClasses.Add(_textTransform.GetCss());
//             }
//
//             if (_textMuted != TextMuted.None)
//             {
//                 computedClasses.Add(_textMuted.GetCss());
//             }
//
//             if (_textAlign != TextAlign.Default)
//             {
//                 computedClasses.Add(_textAlign.GetTextCss());
//             }
//
//             if (_wrapping != TextWrapping.Normal)
//             {
//                 computedClasses.Add(_wrapping.GetCss());
//             }
//
//             if (_wordBreak != WordBreak.None)
//             {
//                 computedClasses.Add(_wordBreak.GetCss());
//             }
//
//             if (additionalClasses is { Length: > 0 })
//             {
//                 computedClasses.AddRange(additionalClasses);
//             }
//
//             return base.BuildClassValue(computedClasses.ToArray());
//         }
//
//         public TBuilder SetFontItalic(FontItalic fontItalic)
//         {
//             _fontItalic = fontItalic;
//             return This();
//         }
//
//         public TBuilder SetFontSize(FontSize fontSize)
//         {
//             _fontSize = fontSize;
//             return This();
//         }
//
//         public TBuilder SetFontWeight(FontWeight fontWeight)
//         {
//             _fontWeight = fontWeight;
//             return This();
//         }
//
//         public TBuilder SetLineHeight(LineHeight lineHeight)
//         {
//             _lineHeight = lineHeight;
//             return This();
//         }
//
//         public TBuilder SetMonospace(Monospace monospace)
//         {
//             _monospace = monospace;
//             return This();
//         }
//
//         public TBuilder SetResetTextColor(ResetTextColor resetTextColor)
//         {
//             _resetTextColor = resetTextColor;
//             return This();
//         }
//
//         public TBuilder SetTextAlignement(TextAlign align)
//         {
//             _textAlign = align;
//             return This();
//         }
//
//         public TBuilder SetTextAlignment(TextAlign align)
//         {
//             return SetTextAlignement(align);
//         }
//
//         public TBuilder SetTextDecoration(TextDecoration textDecoration)
//         {
//             _textDecoration = textDecoration;
//             return This();
//         }
//
//         public TBuilder SetTextMuted(TextMuted value = TextMuted.Muted)
//         {
//             _textMuted = value;
//             return This();
//         }
//
//         public TBuilder SetTextTransform(TextTransform textTransform)
//         {
//             _textTransform = textTransform;
//             return This();
//         }
//
//         public TBuilder SetTextWrapping(TextWrapping wrapping)
//         {
//             _wrapping = wrapping;
//             return This();
//         }
//
//         public TBuilder SetWordBreak(WordBreak wordBreak)
//         {
//             _wordBreak = wordBreak;
//             return This();
//         }
//
//         #endregion
//     }
// }