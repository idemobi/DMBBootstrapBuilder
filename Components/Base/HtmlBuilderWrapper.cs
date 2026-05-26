#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj HtmlBuilderWrapper.cs create at 2026/04/07 21:04:27
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
    /// Represents the BootstrapBuilder html builder wrapper component or support type.
    /// </summary>
    public class HtmlBuilderWrapper : HtmlTagBuilder<HtmlBuilderWrapper>
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
        /// Initializes a new instance of the <see cref="HtmlBuilderWrapper"/> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="tag">The tag value.</param>
        /// <param name="inner">The inner value.</param>
        public HtmlBuilderWrapper(TextWriter writer, IHtmlHelper html, HtmlTag tag, string? inner = null)
            : base(writer, html)
        {
            _tag = tag.ToString().ToLowerInvariant();
            _inner = inner;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlBuilderWrapper"/> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="tag">The tag value.</param>
        /// <param name="classes">The classes value.</param>
        /// <param name="inner">The inner value.</param>
        public HtmlBuilderWrapper(TextWriter writer, IHtmlHelper html, string tag, string classes = "", string? inner = null)
            : base(writer, html)
        {
            _tag = tag;
            _inner = inner;
            if (string.IsNullOrWhiteSpace(classes) == false)
            {
            _classesOfComponent.Add(classes);
        }
    }

        #endregion

        #region Instance methods

        /// <summary>
        /// Configures inner on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="inner">The inner value.</param>
        /// <returns>The configured <see cref="HtmlBuilderWrapper"/> value or BootstrapBuilder result.</returns>
        public HtmlBuilderWrapper SetInner(string? inner)
        {
            _inner = inner;
            return this;
        }

        protected override HtmlBuilderWrapper CreateInstance()
        {
            return new HtmlBuilderWrapper(_textWriter, _htmlHelper, _tag, _inner);
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

        protected override void InternalClone(HtmlBuilderWrapper source)
        {
            base.InternalClone(source);
            _inner = source._inner;
        }

        #endregion
    }
}