#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using DMBPageBuilder;
using DMBServerHelper;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Renders Bootstrap debug hints for the qualification state of Razor pages.
    /// </summary>
    public sealed class PageQualificationDebugBuilder :
        HtmlTagBuilder<PageQualificationDebugBuilder>,
        ICanUseCustomClasses
    {
        #region Constants

        private const string DebugCssPath = "/css/DebugMode.css";

        #endregion

        #region Static methods

        private static void WriteMarker(TextWriter writer, HtmlEncoder encoder, string relativeViewPath, IReadOnlyCollection<QualificationBadge> badges)
        {
            writer.Write("""
                         <div class="bootstrap-page-qualification-marker theme-debug-only alert alert-secondary border-secondary-subtle d-flex flex-wrap align-items-center justify-content-end gap-2 py-2 px-3 small my-2">
                             <code class="bootstrap-page-qualification-path me-auto">
                         """);
            encoder.Encode(writer, relativeViewPath);
            writer.Write("""
                             </code>
                         """);

            foreach (QualificationBadge badge in badges)
            {
                writer.Write($"""
                                  <span class="badge rounded-pill text-bg-{badge.Variant}">
                                      <i class="bi {badge.Icon} me-1" aria-hidden="true"></i>
                              """);
                encoder.Encode(writer, badge.Label);
                writer.Write("""
                                 </span>
                             """);
            }

            writer.Write("""
                         </div>
                         """);
        }

        #endregion

        #region Instance fields and properties

        private string _relativeViewPath = string.Empty;
        private bool _renderedStartComment;

        private string _sourcePath = string.Empty;
        private PageQualificationStatus _status = PageQualificationStatus.Validated;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PageQualificationDebugBuilder" /> class.
        /// </summary>
        /// <param name="writer">The writer used by the current rendering context.</param>
        /// <param name="html">The HTML helper associated with the current Razor view.</param>
        public PageQualificationDebugBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "div";
            InternalAddClass("bootstrap-page-qualification");
            SetData("page-qualification", "true");
        }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Begins a diagnostic page wrapper.
        /// </summary>
        /// <returns>The current builder instance.</returns>
        public override PageQualificationDebugBuilder Begin()
        {
            if (_started)
            {
                return this;
            }

            _started = true;
            _relativeViewPath = GetRelativeViewPath();

            if (!CanRenderDebugHint() || string.IsNullOrWhiteSpace(_relativeViewPath))
            {
                return this;
            }

            EnsureAssets();
            _textWriter.Write($"<!-- {_relativeViewPath} start -->");
            _renderedStartComment = true;

            IHtmlContent marker = RenderMarker();
            marker.WriteTo(_textWriter, HtmlEncoder.Default);

            return this;
        }

        private IEnumerable<QualificationBadge> BuildBadges()
        {
            if (_status.HasFlag(PageQualificationStatus.InProgress))
            {
                yield return new QualificationBadge("warning", "bi-exclamation-circle", "Page in progress");
            }

            if (_status.HasFlag(PageQualificationStatus.NotValidated))
            {
                yield return new QualificationBadge("danger", "bi-x-circle", "Invalid page");
            }

            if (_status.HasFlag(PageQualificationStatus.Danger))
            {
                yield return new QualificationBadge("danger", "bi-exclamation-octagon", "Dangerous page");
            }

            if (_status.HasFlag(PageQualificationStatus.NeedLayout))
            {
                yield return new QualificationBadge("info", "bi-layout-text-window", "Page needs layout");
            }
        }

        private bool CanRenderDebugHint()
        {
            return ServerHelperConfiguration.IsDebug();
        }

        /// <inheritdoc />
        protected override PageQualificationDebugBuilder CreateInstance()
        {
            return new PageQualificationDebugBuilder(_textWriter, _htmlHelper);
        }

        /// <summary>
        ///     Ends a diagnostic page wrapper.
        /// </summary>
        public override void End()
        {
            if (!_started)
            {
                return;
            }

            if (_renderedStartComment)
            {
                _textWriter.Write($"<!-- {_relativeViewPath} end -->");
            }

            _started = false;
            _renderedStartComment = false;
            _relativeViewPath = string.Empty;
        }

        private void EnsureAssets()
        {
            PageInformation page = PageRegistry.GetOrCreatePageInformation(_htmlHelper.ViewContext.HttpContext);
            page.SetStylesheet(DebugCssPath);
        }

        private string GetRelativeViewPath()
        {
            if (string.IsNullOrWhiteSpace(_sourcePath))
            {
                return string.Empty;
            }

            string normalized = _sourcePath.Replace('\\', '/');
            const string marker = "/Views/";
            int index = normalized.IndexOf(marker, StringComparison.OrdinalIgnoreCase);
            if (index < 0)
            {
                return string.Empty;
            }

            return normalized[(index + marker.Length)..];
        }

        /// <inheritdoc />
        protected override void InternalClone(PageQualificationDebugBuilder source)
        {
            base.InternalClone(source);
            _sourcePath = source._sourcePath;
            _status = source._status;
            _relativeViewPath = string.Empty;
            _renderedStartComment = false;
        }

        /// <summary>
        ///     Renders only the visible qualification marker.
        /// </summary>
        /// <returns>The generated marker content.</returns>
        public IHtmlContent RenderMarker()
        {
            if (!CanRenderDebugHint())
            {
                return HtmlString.Empty;
            }

            EnsureAssets();

            string relativeViewPath = string.IsNullOrWhiteSpace(_relativeViewPath)
                ? GetRelativeViewPath()
                : _relativeViewPath;

            if (string.IsNullOrWhiteSpace(relativeViewPath))
            {
                return HtmlString.Empty;
            }

            List<QualificationBadge> badges = BuildBadges().ToList();
            if (badges.Count == 0)
            {
                return HtmlString.Empty;
            }

            using StringWriter writer = new();
            WriteMarker(writer, HtmlEncoder.Default, relativeViewPath, badges);
            return new HtmlString(writer.ToString());
        }

        /// <summary>
        ///     Sets the Razor source path used by diagnostics.
        /// </summary>
        /// <param name="sourcePath">The Razor source path.</param>
        /// <returns>The current builder instance.</returns>
        public PageQualificationDebugBuilder SetSourcePath(string? sourcePath)
        {
            _sourcePath = sourcePath ?? string.Empty;
            return this;
        }

        /// <summary>
        ///     Sets the page qualification status.
        /// </summary>
        /// <param name="status">The qualification status.</param>
        /// <returns>The current builder instance.</returns>
        public PageQualificationDebugBuilder SetStatus(PageQualificationStatus status)
        {
            _status = status;
            return this;
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            IHtmlContent marker = RenderMarker();
            marker.WriteTo(writer, encoder);
        }

        #endregion

        #region Nested type: QualificationBadge

        private readonly record struct QualificationBadge(string Variant, string Icon, string Label);

        #endregion
    }
}