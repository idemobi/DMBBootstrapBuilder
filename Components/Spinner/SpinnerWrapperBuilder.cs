using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Builds and renders the BootstrapBuilder spinner wrapper component or page region.
    /// </summary>
    public class SpinnerWrapperBuilder : HtmlTagBuilder<SpinnerWrapperBuilder>, ICanUseCustomClasses
    {
        #region Instance fields and properties

        private string? _inner
        {
            get => GetInternal<string?>("_inner", null);
            set => SetInternal("_inner", value);
        }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SpinnerWrapperBuilder"/> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="tag">The tag value.</param>
        /// <param name="inner">The inner value.</param>
        public SpinnerWrapperBuilder(TextWriter writer, IHtmlHelper html, HtmlTag tag, string? inner = null)
            : base(writer, html)
        {
            _tag = tag.ToString().ToLowerInvariant();
            _inner = inner;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpinnerWrapperBuilder"/> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="tag">The tag value.</param>
        /// <param name="inner">The inner value.</param>
        public SpinnerWrapperBuilder(TextWriter writer, IHtmlHelper html, string tag, string? inner = null)
            : base(writer, html)
        {
            _tag = tag;
            _inner = inner;
        }

        #endregion

        #region Instance methods

        protected override SpinnerWrapperBuilder CreateInstance()
        {
            return new SpinnerWrapperBuilder(_textWriter, _htmlHelper, _tag, _inner);
        }

        protected override void InternalClone(SpinnerWrapperBuilder source)
        {
            base.InternalClone(source);
            _inner = source._inner;
        }

        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write($"<{_tag}{BuildAttributes()}>");

            if (!string.IsNullOrWhiteSpace(_inner))
            {
                writer.Write(_inner);
            }

            writer.Write($"</{_tag}>");
        }

        /// <summary>
        /// Configures inner on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="inner">The inner value.</param>
        /// <returns>The configured <see cref="SpinnerWrapperBuilder"/> value or BootstrapBuilder result.</returns>
        public SpinnerWrapperBuilder SetInner(string? inner)
        {
            _inner = inner;
            return this;
        }

        #endregion
    }
}