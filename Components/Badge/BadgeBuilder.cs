#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj BadgeBuilder.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using System.Net;
using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Builds and renders the BootstrapBuilder badge component or page region.
    /// </summary>
    public sealed class BadgeBuilder :
        HtmlBuilderBase<BadgeBuilder>,
        ICanUseBadge,
        ICanUseZIndex,
        ICanUseMargin,
        ICanUseDebugOnly,
        ICanUseOpacity
    {
        #region Instance fields and properties

        private string? _text
        {
            get => GetInternal<string?>("_text", null);
            set => SetInternal("_text", value);
        }

        private string? _visuallyHiddenText
        {
            get => GetInternal<string?>("_visuallyHiddenText", null);
            set => SetInternal("_visuallyHiddenText", value);
        }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BadgeBuilder"/> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public BadgeBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "span";
            SetData("badge", "true");
            this.SetBadgeVariant(VariantStyle.Danger);
        }

        #endregion

        #region Instance methods

        /// <summary>
        /// Configures hidden text on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <returns>The configured <see cref="BadgeBuilder"/> value or BootstrapBuilder result.</returns>
        public BadgeBuilder SetHiddenText(string? text)
        {
            _visuallyHiddenText = text;
            return this;
        }

        /// <summary>
        /// Configures text on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <returns>The configured <see cref="BadgeBuilder"/> value or BootstrapBuilder result.</returns>
        public BadgeBuilder SetText(string? text)
        {
            _text = text;
            return this;
        }

        #endregion

        #region Protected methods

        protected override BadgeBuilder CreateInstance()
        {
            return new BadgeBuilder(_textWriter, _htmlHelper);
        }

        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write($"<{GetTag()}{BuildAttributes()}>");

            if (!string.IsNullOrWhiteSpace(_text))
            {
                writer.Write(WebUtility.HtmlEncode(_text));
            }

            if (!string.IsNullOrWhiteSpace(_visuallyHiddenText))
            {
                writer.Write("<span class=\"visually-hidden\">");
                writer.Write(WebUtility.HtmlEncode(_visuallyHiddenText));
                writer.Write("</span>");
            }

            writer.Write($"</{GetTag()}>");
        }

        #endregion

        // public BadgeBuilder AsNotification(bool pill = true, bool withBorder = false)
        // {
        //     this.SetPosition(Position.Absolute)
        //         .SetTop(PositionValue.Zero)
        //         .SetStart(PositionValue.Hundred)
        //         .SetTranslate(TranslateMode.Middle);
        //
        //     if (pill)
        //     {
        //         this.SetPill();
        //     }
        //
        //     if (withBorder)
        //     {
        //         AddClass("border");
        //         AddClass("border-light");
        //     }
        //
        //     return this;
        // }
    }
}