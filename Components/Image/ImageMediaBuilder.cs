#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ImageMediaBuilder.cs create at 2026/04/09 14:04:31
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Builds and renders the BootstrapBuilder image media component or page region.
    /// </summary>
    public sealed class ImageMediaBuilder : HtmlTagBuilder<ImageMediaBuilder>,
        ICanUseMargin,
        ICanUsePadding,
        ICanUseShadow,
        ICanUseBorder,
        ICanUseBorderRadius,
        ICanUseHeight,
        ICanUseWidth, ICanUseCustomClasses
    {
        #region Instance fields and properties

        private string _alt
        {
            get => GetInternal("_alt", string.Empty);
            set => SetInternal("_alt", value);
        }

        private ImageRenderMode _mode
        {
            get => GetInternal("_mode", ImageRenderMode.Auto);
            set => SetInternal("_mode", value);
        }

        private string _src
        {
            get => GetInternal("_src", string.Empty);
            set => SetInternal("_src", value);
        }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageMediaBuilder"/> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="src">The src value.</param>
        /// <param name="alt">The alt value.</param>
        public ImageMediaBuilder(TextWriter writer, IHtmlHelper html, string src, string alt = "")
            : base(writer, html)
        {
            _tag = "img";
            _src = src ?? string.Empty;
            _alt = alt ?? string.Empty;
        }

        #endregion

        #region Instance methods

        protected override ImageMediaBuilder CreateInstance()
        {
            return new ImageMediaBuilder(_textWriter, _htmlHelper, _src, _alt)
                .SetMode(_mode);
        }

        protected override void InternalClone(ImageMediaBuilder source)
        {
            base.InternalClone(source);
            _src = source._src;
            _alt = source._alt;
            _mode = source._mode;
        }

        /// <summary>
        /// Gets alternate for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public string GetAlternate()
        {
            return _alt;
        }

        /// <summary>
        /// Gets source for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public string GetSource()
        {
            return _src;
        }

        /// <summary>
        /// Executes the BootstrapBuilder resolve mode operation.
        /// </summary>
        /// <returns>The configured <see cref="ImageRenderMode"/> value or BootstrapBuilder result.</returns>
        public ImageRenderMode ResolveMode()
        {
            if (_mode != ImageRenderMode.Auto)
            {
                return _mode;
            }

            return _src.EndsWith(".svg", StringComparison.OrdinalIgnoreCase)
                ? ImageRenderMode.InlineSvg
                : ImageRenderMode.ImageTag;
        }

        /// <summary>
        /// Configures alt on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="alt">The alt value.</param>
        /// <returns>The configured <see cref="ImageMediaBuilder"/> value or BootstrapBuilder result.</returns>
        public ImageMediaBuilder SetAlt(string alt)
        {
            _alt = alt ?? string.Empty;
            return this;
        }

        /// <summary>
        /// Configures file on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="src">The src value.</param>
        /// <returns>The configured <see cref="ImageMediaBuilder"/> value or BootstrapBuilder result.</returns>
        public ImageMediaBuilder SetFile(string src)
        {
            _src = src ?? string.Empty;
            return this;
        }

        /// <summary>
        /// Configures mode on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="mode">The mode value.</param>
        /// <returns>The configured <see cref="ImageMediaBuilder"/> value or BootstrapBuilder result.</returns>
        public ImageMediaBuilder SetMode(ImageRenderMode mode)
        {
            _mode = mode;
            return this;
        }

        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            string? previousSrc = GetAttributeValue("src");
            string? previousAlt = GetAttributeValue("alt");
            string? previousAriaLabel = GetAttributeValue("aria-label");
            string? previousInlineSvg = GetAttributeValue("data-image-render-inline-svg");

            try
            {
                SetAttribute("src", _src);
                SetAttribute("alt", _alt);
                SetAria("label", _alt);

                if (ResolveMode() == ImageRenderMode.InlineSvg)
                {
                    SetData("image-render-inline-svg", true);
                    writer.Write($"<div{BuildAttributes()}></div>");
                    return;
                }

                RemoveAttribute("data-image-render-inline-svg");
                writer.Write($"<{_tag}{BuildAttributes()}>");
            }
            finally
            {
                RestoreAttribute("src", previousSrc);
                RestoreAttribute("alt", previousAlt);
                RestoreAttribute("aria-label", previousAriaLabel);
                RestoreAttribute("data-image-render-inline-svg", previousInlineSvg);
            }
        }

        private void RestoreAttribute(string name, string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                RemoveAttribute(name);
            }
            else
            {
                _attributes[name] = value;
            }
        }

        #endregion
    }
}