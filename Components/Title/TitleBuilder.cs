#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Builds and renders the BootstrapBuilder title component or page region.
    /// </summary>
    [Documented]
    public sealed class TitleBuilder : HtmlTagBuilder<TitleBuilder>,
        ICanUseTextVariant,
        ICanUseMargin,
        ICanUseTextTransform,
        ICanUseTextShadow,
        ICanUseCustomClasses
    {
        #region Instance fields and properties

        private IconStruct Icon
        {
            get => GetInternal("_icon", IconStruct.Empty);
            set => SetInternal("_icon", value);
        }

        private TitleLevel Level
        {
            get => GetInternal("_level", TitleLevel.Three);
            set => SetInternal("_level", value);
        }

        private string Text
        {
            get => GetInternal("_text", string.Empty);
            set => SetInternal("_text", value);
        }

        #endregion

        #region Instance constructors and destructors

        #region Instance constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="TitleBuilder" /> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        [Documented]
        public TitleBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "h3";
            _classesOfComponent.Add("title w-100");
        }

        #endregion

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override TitleBuilder CreateInstance()
        {
            return new TitleBuilder(_textWriter, _htmlHelper);
        }

        /// <summary>
        ///     Configures icon on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="icon">The icon value.</param>
        /// <returns>The configured <see cref="TitleBuilder" /> value or BootstrapBuilder result.</returns>
        [Documented]
        public TitleBuilder SetIcon(IconStruct icon)
        {
            if (!icon.IsEmpty)
            {
                Icon = icon;
            }

            return this;
        }

        /// <summary>
        ///     Configures icon bootstrap on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="icon">The icon value.</param>
        /// <returns>The configured <see cref="TitleBuilder" /> value or BootstrapBuilder result.</returns>
        [Documented]
        public TitleBuilder SetIconBootstrap(string icon)
        {
            Icon = IconStruct.Bootstrap(icon);
            return this;
        }

        /// <summary>
        ///     Configures title on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <param name="level">The level value.</param>
        /// <returns>The configured <see cref="TitleBuilder" /> value or BootstrapBuilder result.</returns>
        [Documented]
        public TitleBuilder SetTitle(string text, TitleLevel level = TitleLevel.Three)
        {
            Text = text?.Trim() ?? string.Empty;
            Level = level;
            _tag = level.Tag();
            return this;
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            string originalTag = _tag;
            _tag = Level.Tag();

            try
            {
                if (!Icon.IsEmpty)
                {
                    string gap = Level.Gap();

                    using (PushInternalClasses("d-inline-flex", "align-items-center", gap))
                    {
                        writer.Write($"<{_tag}{BuildAttributes()}>");
                        HtmlLayoutExtensions.IconBuilder(_htmlHelper, Icon).WriteTo(writer, encoder);
                        writer.Write("<span>");
                        writer.Write(encoder.Encode(Text));
                        writer.Write("</span>");
                        writer.Write($"</{_tag}>");
                    }
                }
                else
                {
                    writer.Write($"<{_tag}{BuildAttributes()}>");
                    writer.Write("<span>");
                    writer.Write(encoder.Encode(Text));
                    writer.Write("</span>");
                    writer.Write($"</{_tag}>");
                }
            }
            finally
            {
                _tag = originalTag;
            }
        }

        #endregion
    }
}