#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Text.Encodings.Web;
using DMBPageBuilder;
using DMBServerHelper;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Renders Bootstrap debug hints for Razor views that can be overridden by host applications.
    /// </summary>
    public sealed class OverridableViewDebugBuilder :
        HtmlTagBuilder<OverridableViewDebugBuilder>,
        ICanUseCustomClasses
    {
        #region Constants

        private const string DebugCssPath = "/css/DebugMode.css";

        #endregion

        #region Static methods

        private static void WritePath(TextWriter writer, HtmlEncoder encoder, string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return;
            }

            writer.Write("<li><code>");
            encoder.Encode(writer, path);
            writer.Write("</code></li>");
        }

        #endregion

        #region Instance fields and properties

        private bool _isOverride;
        private bool _renderedWrapper;

        private string _sourcePath = string.Empty;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="OverridableViewDebugBuilder" /> class.
        /// </summary>
        /// <param name="writer">The writer used by the current rendering context.</param>
        /// <param name="html">The HTML helper associated with the current Razor view.</param>
        public OverridableViewDebugBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "div";
            InternalAddClass("bootstrap-overridable-area");
            SetData("overridable-view", "true");
        }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Begins a debug wrapper around overridable content.
        /// </summary>
        /// <returns>The current builder instance.</returns>
        public override OverridableViewDebugBuilder Begin()
        {
            if (_started)
            {
                return this;
            }

            if (!CanRenderDebugHint())
            {
                _started = true;
                return this;
            }

            EnsureAssets();
            OverridableViewPaths paths = BuildPaths();
            if (!paths.HasPath)
            {
                _started = true;
                return this;
            }

            _started = true;
            _renderedWrapper = true;
            _textWriter.Write($"<{GetTag()}{BuildAttributes()}>");
            WriteMarker(_textWriter, HtmlEncoder.Default, paths, false);

            return this;
        }

        private OverridableViewPaths BuildPaths()
        {
            return OverridableViewPaths.FromSourcePath(_sourcePath, GetCultureName());
        }

        private bool CanRenderDebugHint()
        {
            return ServerHelperConfiguration.IsDebug();
        }

        /// <inheritdoc />
        protected override OverridableViewDebugBuilder CreateInstance()
        {
            return new OverridableViewDebugBuilder(_textWriter, _htmlHelper);
        }

        /// <summary>
        ///     Ends the debug wrapper around overridable content.
        /// </summary>
        public override void End()
        {
            if (!_started)
            {
                return;
            }

            if (_renderedWrapper)
            {
                _textWriter.Write($"</{GetTag()}>");
            }

            _started = false;
            _renderedWrapper = false;
        }

        private void EnsureAssets()
        {
            PageInformation page = PageRegistry.GetOrCreatePageInformation(_htmlHelper.ViewContext.HttpContext);
            page.SetStylesheet(DebugCssPath);
        }

        private string GetCultureName()
        {
            return _htmlHelper.ViewContext.HttpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture.UICulture.Name
                   ?? string.Empty;
        }

        /// <inheritdoc />
        protected override void InternalClone(OverridableViewDebugBuilder source)
        {
            base.InternalClone(source);
            _sourcePath = source._sourcePath;
            _isOverride = source._isOverride;
            _renderedWrapper = false;
        }

        /// <summary>
        ///     Renders only the debug marker for the current view.
        /// </summary>
        /// <returns>The generated HTML content.</returns>
        public IHtmlContent RenderMarker()
        {
            if (!CanRenderDebugHint())
            {
                return HtmlString.Empty;
            }

            EnsureAssets();
            OverridableViewPaths paths = BuildPaths();
            if (!paths.HasPath)
            {
                return HtmlString.Empty;
            }

            using StringWriter writer = new();
            WriteMarker(writer, HtmlEncoder.Default, paths, true);
            return new HtmlString(writer.ToString());
        }

        /// <summary>
        ///     Marks the current view as an application override.
        /// </summary>
        /// <param name="value">A value indicating whether the marker should describe an override.</param>
        /// <returns>The current builder instance.</returns>
        public OverridableViewDebugBuilder SetOverride(bool value = true)
        {
            _isOverride = value;
            return this;
        }

        /// <summary>
        ///     Sets the physical Razor source path used to compute the overridable view paths.
        /// </summary>
        /// <param name="sourcePath">The source file path.</param>
        /// <returns>The current builder instance.</returns>
        public OverridableViewDebugBuilder SetSourcePath(string? sourcePath)
        {
            _sourcePath = sourcePath ?? string.Empty;
            return this;
        }

        private void WriteMarker(TextWriter writer, HtmlEncoder encoder, OverridableViewPaths paths, bool standalone)
        {
            string stateClass = _isOverride ? "bootstrap-overridable-marker-override" : "bootstrap-overridable-marker-available";
            string icon = _isOverride ? "bi-arrow-down-right-square" : "bi-pencil-square";
            string title = _isOverride ? "This view overrides BootstrapBuilder content" : "Overridable Razor view";

            writer.Write($"""
                          <div class="bootstrap-overridable-marker {stateClass} theme-debug-only alert alert-warning border-warning-subtle d-flex align-items-start gap-2 py-2 px-3 small{(standalone ? " my-2" : " mb-2")}">
                              <i class="bi {icon} flex-shrink-0" aria-hidden="true"></i>
                              <div class="min-w-0">
                                  <div class="fw-semibold">{encoder.Encode(title)}</div>
                                  <ul class="bootstrap-overridable-paths mb-0 ps-3">
                          """);

            WritePath(writer, encoder, paths.DefaultPath);
            WritePath(writer, encoder, paths.LocalizedPath);

            writer.Write("""
                                 </ul>
                             </div>
                         </div>
                         """);
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            if (!CanRenderDebugHint())
            {
                return;
            }

            EnsureAssets();
            OverridableViewPaths paths = BuildPaths();
            if (!paths.HasPath)
            {
                return;
            }

            WriteMarker(writer, encoder, paths, true);
        }

        #endregion

        #region Nested type: OverridableViewPaths

        private readonly record struct OverridableViewPaths(string DefaultPath, string LocalizedPath)
        {
            #region Static methods

            private static string BuildLocalizedPath(string defaultRelative, string cultureName)
            {
                if (string.IsNullOrWhiteSpace(defaultRelative) || string.IsNullOrWhiteSpace(cultureName))
                {
                    return string.Empty;
                }

                return defaultRelative.EndsWith(".cshtml", StringComparison.OrdinalIgnoreCase)
                    ? $"~/Views/{defaultRelative[..^".cshtml".Length]}.{cultureName}.cshtml"
                    : string.Empty;
            }

            /// <summary>
            ///     Executes the BootstrapBuilder from source path operation.
            /// </summary>
            /// <param name="sourcePath">The source path value.</param>
            /// <param name="cultureName">The culture name value.</param>
            /// <returns>The configured <see cref="OverridableViewPaths" /> value or BootstrapBuilder result.</returns>
            public static OverridableViewPaths FromSourcePath(string sourcePath, string cultureName)
            {
                if (string.IsNullOrWhiteSpace(sourcePath))
                {
                    return new OverridableViewPaths(string.Empty, string.Empty);
                }

                string normalized = sourcePath.Replace('\\', '/');
                const string marker = "/Views/";
                int index = normalized.IndexOf(marker, StringComparison.OrdinalIgnoreCase);
                if (index < 0)
                {
                    return new OverridableViewPaths(string.Empty, string.Empty);
                }

                string relative = normalized[(index + marker.Length)..];
                string defaultRelative = RemoveCultureSuffix(relative, cultureName);
                string defaultPath = $"~/Views/{defaultRelative}";
                string localizedPath = BuildLocalizedPath(defaultRelative, cultureName);

                return new OverridableViewPaths(defaultPath, localizedPath);
            }

            private static string RemoveCultureSuffix(string relativePath, string cultureName)
            {
                if (string.IsNullOrWhiteSpace(cultureName))
                {
                    return relativePath;
                }

                return relativePath.Replace($".{cultureName}.cshtml", ".cshtml", StringComparison.OrdinalIgnoreCase);
            }

            #endregion

            #region Instance fields and properties

            /// <summary>
            ///     Gets or sets a value indicating whether path is enabled for BootstrapBuilder rendering.
            /// </summary>
            public bool HasPath => !string.IsNullOrWhiteSpace(DefaultPath);

            #endregion
        }

        #endregion
    }
}