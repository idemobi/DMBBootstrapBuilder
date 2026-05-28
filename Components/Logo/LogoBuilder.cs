#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj LogoBuilder.cs create at 2026/05/12
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using System.Net;
using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Builds and renders the BootstrapBuilder logo component or page region.
    /// </summary>
    public sealed class LogoBuilder :
        HtmlBuilderBase<LogoBuilder>,
        ICanUseCustomClasses
    {
        private string _source = "/logo/logo.svg";
        private string _alt = string.Empty;
        private int _size = 40;
        private string? _badgeText;
        private VariantStyle _badgeVariant = VariantStyle.Info;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogoBuilder"/> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public LogoBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "div";
        }

        /// <summary>
        /// Configures source on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="source">The source value.</param>
        /// <returns>The configured <see cref="LogoBuilder"/> value or BootstrapBuilder result.</returns>
        public LogoBuilder SetSource(string? source)
        {
            _source = string.IsNullOrWhiteSpace(source) ? "/logo/logo.svg" : source;
            return this;
        }

        /// <summary>
        /// Configures alt on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="alt">The alt value.</param>
        /// <returns>The configured <see cref="LogoBuilder"/> value or BootstrapBuilder result.</returns>
        public LogoBuilder SetAlt(string? alt)
        {
            _alt = alt ?? string.Empty;
            return this;
        }

        /// <summary>
        /// Configures size on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <returns>The configured <see cref="LogoBuilder"/> value or BootstrapBuilder result.</returns>
        public LogoBuilder SetSize(int size)
        {
            _size = Math.Max(1, size);
            return this;
        }

        /// <summary>
        /// Configures badge on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <param name="variant">The variant value.</param>
        /// <returns>The configured <see cref="LogoBuilder"/> value or BootstrapBuilder result.</returns>
        public LogoBuilder WithBadge(string? text, VariantStyle variant = VariantStyle.Info)
        {
            _badgeText = text;
            _badgeVariant = variant;
            return this;
        }

        /// <inheritdoc />
        protected override LogoBuilder CreateInstance()
        {
            return new LogoBuilder(_textWriter, _htmlHelper)
                .SetSource(_source)
                .SetAlt(_alt)
                .SetSize(_size)
                .WithBadge(_badgeText, _badgeVariant);
        }

        /// <inheritdoc />
        protected override void InternalClone(LogoBuilder source)
        {
            base.InternalClone(source);

            _source = source._source;
            _alt = source._alt;
            _size = source._size;
            _badgeText = source._badgeText;
            _badgeVariant = source._badgeVariant;
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write($"<{GetTag()}{BuildAttributes()}>");
            writer.Write($"""<img class="logo" src="{WebUtility.HtmlEncode(_source)}" alt="{WebUtility.HtmlEncode(_alt)}" width="{_size}" height="{_size}">""");

            if (!string.IsNullOrWhiteSpace(_badgeText))
            {
                string variant = _badgeVariant.GetVariantCss();
                if (string.IsNullOrWhiteSpace(variant))
                {
                    variant = "secondary";
                }

                writer.Write($"""<span class="top-0 ms-3 translate-middle badge rounded-pill bg-{WebUtility.HtmlEncode(variant)}">{WebUtility.HtmlEncode(_badgeText)}</span>""");
            }

            writer.Write($"</{GetTag()}>");
        }
    }
}
