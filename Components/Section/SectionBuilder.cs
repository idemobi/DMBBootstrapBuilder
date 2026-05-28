#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj SectionBuilder.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Builds and renders the BootstrapBuilder section component or page region.
    /// </summary>
    public sealed class SectionBuilder : HtmlConstrainedTagBuilder<SectionBuilder>,
        ICanUseHeight,
        ICanUseWidth,
        ICanUseCustomClasses
    {
        #region Instance fields and properties

        private readonly List<IHtmlContent> _afterBeginContents = new();
        private readonly List<IHtmlContent> _afterEndContents = new();
        #if DEBUG
        private readonly List<(string Title, string RenderedContent)> _debugEntries = new();
        #endif

        private bool _sectionDisposed
        {
            get => GetInternal("_sectionDisposed", false);
            set => SetInternal("_sectionDisposed", value);
        }

        private bool _sectionStarted
        {
            get => GetInternal("_sectionStarted", false);
            set => SetInternal("_sectionStarted", value);
        }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SectionBuilder"/> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public SectionBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "section";
        }

        #endregion

        #region Protected accessors

        /// <inheritdoc />
        protected override HtmlRenderContextKind ContextKind => HtmlRenderContextKind.Section;

        #endregion

        #region Instance methods

        /// <summary>
        /// Adds debug panel to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <param name="content">The content value.</param>
        /// <param name="panelId">The panel id value.</param>
        /// <returns>The configured <see cref="SectionBuilder"/> value or BootstrapBuilder result.</returns>
        public SectionBuilder AddDebugPanel(string title, IHtmlContent? content, string? panelId = null)
        {
            #if DEBUG
            EnsureId("section");
            this.AddClass("section-debug-host");

            string renderedContent = RenderHtmlContentToString(content);
            if (string.IsNullOrWhiteSpace(renderedContent))
                renderedContent = """<div class="section-debug-empty text-muted fst-italic">No debug option.</div>""";

            _debugEntries.Add((title ?? "Debug", renderedContent));
            #endif

            return this;
        }

        /// <summary>
        /// Adds debug panel to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <typeparam name="T">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="model">The model value.</param>
        /// <returns>The configured <see cref="SectionBuilder"/> value or BootstrapBuilder result.</returns>
        public SectionBuilder AddDebugPanel<T>(T model) where T : class
        {
            #if DEBUG
            DebugModelAttribute? attr = typeof(T).GetCustomAttribute<DebugModelAttribute>();
            string title = attr?.Title ?? "Debug";
            return AddDebugPanel(title, DebugFormHelper.RenderForm(model));
            #else
            return this;
            #endif
        }

        /// <summary>
        /// Executes the BootstrapBuilder attribute value operation.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <returns>The configured <see cref="string"/> value or BootstrapBuilder result.</returns>
        public string? AttributeValue(string name)
        {
            return GetAttributeValue(name);
        }

        /// <summary>
        /// Executes the BootstrapBuilder begin operation.
        /// </summary>
        /// <returns>The configured <see cref="SectionBuilder"/> value or BootstrapBuilder result.</returns>
        public new SectionBuilder Begin()
        {
            if (_sectionStarted)
            {
                return this;
            }

            #if DEBUG
            if (_debugEntries.Count > 0)
            {
                string sectionId = GetAttributeValue("id") ?? "unknown_section";
                string panelId = $"{sectionId}_debug_panel";

                var html = new StringBuilder();
                html.AppendLine($@"<div class=""section-debug theme-debug-only text-end"">");
                html.AppendLine($@"    <button type=""button"" class=""btn btn-sm btn-outline-warning"" data-bs-toggle=""collapse"" data-bs-target=""#{System.Net.WebUtility.HtmlEncode(panelId)}"" aria-expanded=""false"" aria-controls=""{System.Net.WebUtility.HtmlEncode(panelId)}""><span class=""bi bi-sliders""></span></button>");
                html.AppendLine($@"    <div id=""{System.Net.WebUtility.HtmlEncode(panelId)}"" class=""section-debug-panel collapse"">");

                bool first = true;
                foreach (var (title, renderedContent) in _debugEntries)
                {
                    if (!first) html.AppendLine(@"<hr class=""my-3"">");
                    html.AppendLine($@"<h5 class=""mb-2"">{System.Net.WebUtility.HtmlEncode(title)}</h5>");
                    html.AppendLine(@"<hr class=""my-2"">");
                    html.AppendLine(renderedContent);
                    first = false;
                }

                html.AppendLine("    </div>");
                html.AppendLine("</div>");

                _afterBeginContents.Insert(0, new HtmlString(html.ToString()));
            }
            #endif

            base.Begin();
            _sectionStarted = true;

            foreach (IHtmlContent content in _afterBeginContents)
            {
                content.WriteTo(_textWriter, HtmlEncoder.Default);
            }

            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder change tag operation.
        /// </summary>
        /// <param name="tag">The tag value.</param>
        /// <returns>The configured <see cref="SectionBuilder"/> value or BootstrapBuilder result.</returns>
        public SectionBuilder ChangeTag(string tag)
        {
            _tag = tag.Trim().ToLowerInvariant();
            return this;
        }

        /// <inheritdoc />
        protected override SectionBuilder CreateInstance()
        {
            return new SectionBuilder(_textWriter, _htmlHelper);
        }

        /// <inheritdoc />
        protected override void InternalClone(SectionBuilder source)
        {
            base.InternalClone(source);

            _afterBeginContents.Clear();
            _afterBeginContents.AddRange(source._afterBeginContents);

            _afterEndContents.Clear();
            _afterEndContents.AddRange(source._afterEndContents);

            #if DEBUG
            _debugEntries.Clear();
            _debugEntries.AddRange(source._debugEntries);
            #endif

            _sectionStarted = false;
            _sectionDisposed = false;
        }

        /// <summary>
        /// Executes the BootstrapBuilder dispose operation.
        /// </summary>
        public new void Dispose()
        {
            if (_sectionDisposed)
            {
                return;
            }

            if (!_sectionStarted)
            {
                return;
            }

            foreach (IHtmlContent content in _afterEndContents)
            {
                content.WriteTo(_textWriter, HtmlEncoder.Default);
            }

            base.Dispose();
            _sectionDisposed = true;
            _sectionStarted = false;
        }

        /// <summary>
        /// Executes the BootstrapBuilder ensure id operation.
        /// </summary>
        /// <param name="prefix">The prefix value.</param>
        /// <returns>The configured <see cref="SectionBuilder"/> value or BootstrapBuilder result.</returns>
        public SectionBuilder EnsureId(string prefix = "section")
        {
            if (string.IsNullOrWhiteSpace(GetAttributeValue("id")))
            {
                SetId(HtmlHelper.GenerateUniqueId(prefix));
            }

            return this;
        }

        private string RenderHtmlContentToString(IHtmlContent? content)
        {
            if (content == null)
            {
                return string.Empty;
            }

            using StringWriter writer = new();
            content.WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        }

        /// <summary>
        /// Executes the BootstrapBuilder write operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="SectionBuilder"/> value or BootstrapBuilder result.</returns>
        public SectionBuilder Write(string html)
        {
            if (!string.IsNullOrEmpty(html))
            {
                _textWriter.Write(html);
            }

            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder write operation.
        /// </summary>
        /// <param name="content">The content value.</param>
        /// <returns>The configured <see cref="SectionBuilder"/> value or BootstrapBuilder result.</returns>
        public SectionBuilder Write(IHtmlContent content)
        {
            if (content != null)
            {
                content.WriteTo(_textWriter, HtmlEncoder.Default);
            }

            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder write after begin operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="SectionBuilder"/> value or BootstrapBuilder result.</returns>
        public SectionBuilder WriteAfterBegin(string html)
        {
            if (!string.IsNullOrEmpty(html))
            {
                _afterBeginContents.Add(new HtmlString(html));
            }

            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder write after begin operation.
        /// </summary>
        /// <param name="content">The content value.</param>
        /// <returns>The configured <see cref="SectionBuilder"/> value or BootstrapBuilder result.</returns>
        public SectionBuilder WriteAfterBegin(IHtmlContent content)
        {
            if (content != null)
            {
                _afterBeginContents.Add(content);
            }

            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder write after end operation.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="SectionBuilder"/> value or BootstrapBuilder result.</returns>
        public SectionBuilder WriteAfterEnd(string html)
        {
            if (!string.IsNullOrEmpty(html))
            {
                _afterEndContents.Add(new HtmlString(html));
            }

            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder write after end operation.
        /// </summary>
        /// <param name="content">The content value.</param>
        /// <returns>The configured <see cref="SectionBuilder"/> value or BootstrapBuilder result.</returns>
        public SectionBuilder WriteAfterEnd(IHtmlContent content)
        {
            if (content != null)
            {
                _afterEndContents.Add(content);
            }

            return this;
        }

        #endregion
    }
}