#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj TableBuilder.cs create at 2026/04/07 21:04:27
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
    /// Builds and renders the BootstrapBuilder table component or page region.
    /// </summary>
    public sealed class TableBuilder :
        HtmlBuilderBase<TableBuilder>,
        IDisposable,
        ICanUseTable
    {
        #region Instance fields and properties

        private string? _caption
        {
            get => GetInternal<string?>("_caption", null);
            set => SetInternal("_caption", value);
        }

        private HtmlBuilderWrapper _captionComponent;
        private HtmlRenderContext? _renderContext;

        private bool _started
        {
            get => GetInternal("_started", false);
            set => SetInternal("_started", value);
        }

        private TableWrapperComponent _wrapperComponent;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TableBuilder"/> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public TableBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "table";
            _classesOfComponent.Add("table");
            _wrapperComponent = new TableWrapperComponent(writer, html);
            _captionComponent = new HtmlBuilderWrapper(writer, html, "caption");
            SetData("table", "true");
        }

        #endregion

        #region Instance methods

        /// <summary>
        /// Executes the BootstrapBuilder begin operation.
        /// </summary>
        /// <returns>The configured <see cref="TableBuilder"/> value or BootstrapBuilder result.</returns>
        public TableBuilder Begin()
        {
            if (_started)
            {
                return this;
            }

            HtmlRenderContext? currentContext = HtmlRenderContextManager.Current(_htmlHelper);

            if (currentContext != null &&
                (currentContext.Kind == HtmlRenderContextKind.Table ||
                 currentContext.Kind == HtmlRenderContextKind.TableHead ||
                 currentContext.Kind == HtmlRenderContextKind.TableBody ||
                 currentContext.Kind == HtmlRenderContextKind.TableFoot ||
                 currentContext.Kind == HtmlRenderContextKind.TableRow))
            {
                throw new InvalidOperationException(
                    $"Table must be opened within a neutral context (current context is {currentContext.Kind}).");
            }

            OnRenderDebug();

            TableComposer? tableComposer = GetCssComposer<TableComposer>();
            if (tableComposer?.IsSortable == true)
            {
                SetData("sortable", "true");
            }

            _renderContext = new HtmlRenderContext
            {
                Kind = HtmlRenderContextKind.Table,
                Owner = this
            };

            HtmlRenderContextManager.Push(_htmlHelper, _renderContext);

            _textWriter.Write($"<{_wrapperComponent.GetTag()}{_wrapperComponent.BuildAttributes()}>");
            _textWriter.Write($"<{GetTag()}{BuildAttributes()}>");

            if (!string.IsNullOrWhiteSpace(_caption))
            {
                _captionComponent.SetData("table-caption", "true");
                _textWriter.Write(
                    $"<{_captionComponent.GetTag()}{_captionComponent.BuildAttributes()}>{WebUtility.HtmlEncode(_caption)}</{_captionComponent.GetTag()}>");
            }

            _started = true;
            return this;
        }

        protected override TableBuilder CreateInstance()
        {
            return new TableBuilder(_textWriter, _htmlHelper);
        }

        protected override void InternalClone(TableBuilder source)
        {
            base.InternalClone(source);

            _started = false;
            _renderContext = null;
            _caption = source._caption;
            _captionComponent = source._captionComponent.Clone();
            _wrapperComponent = source._wrapperComponent.Clone();
        }

        /// <summary>
        /// Executes the BootstrapBuilder in caption component operation.
        /// </summary>
        /// <param name="configure">The configure value.</param>
        /// <returns>The configured <see cref="TableBuilder"/> value or BootstrapBuilder result.</returns>
        public TableBuilder InCaptionComponent(Func<HtmlBuilderWrapper, HtmlBuilderWrapper> configure)
        {
            ArgumentNullException.ThrowIfNull(configure);
            _captionComponent = configure(_captionComponent);
            return This();
        }

        /// <summary>
        /// Executes the BootstrapBuilder in wrapper component operation.
        /// </summary>
        /// <param name="configure">The configure value.</param>
        /// <returns>The configured <see cref="TableBuilder"/> value or BootstrapBuilder result.</returns>
        public TableBuilder InWrapperComponent(Func<TableWrapperComponent, TableWrapperComponent> configure)
        {
            ArgumentNullException.ThrowIfNull(configure);
            _wrapperComponent = configure(_wrapperComponent);
            return This();
        }

        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            TableComposer? tableComposer = GetCssComposer<TableComposer>();
            bool hadSortable = HasAttribute("data-sortable");
            string? previousSortable = GetAttributeValue("data-sortable");

            try
            {
                if (tableComposer?.IsSortable == true)
                {
                    SetData("sortable", "true");
                }

                writer.Write($"<{_wrapperComponent.GetTag()}{_wrapperComponent.BuildAttributes()}>");
                writer.Write($"<{GetTag()}{BuildAttributes()}>");

                if (!string.IsNullOrWhiteSpace(_caption))
                {
                    HtmlBuilderWrapper captionComponent = _captionComponent.Clone();
                    captionComponent.SetData("table-caption", "true");
                    writer.Write(
                        $"<{captionComponent.GetTag()}{captionComponent.BuildAttributes()}>{WebUtility.HtmlEncode(_caption)}</{captionComponent.GetTag()}>");
                }

                writer.Write($"</{GetTag()}>");
                writer.Write($"</{_wrapperComponent.GetTag()}>");
            }
            finally
            {
                if (hadSortable)
                {
                    _attributes["data-sortable"] = previousSortable!;
                }
                else
                {
                    RemoveAttribute("data-sortable");
                }
            }
        }

        /// <summary>
        /// Configures bordered on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableBuilder"/> value or BootstrapBuilder result.</returns>
        public TableBuilder SetBordered(bool value = true)
        {
            return this.SetTableBordered(value);
        }

        /// <summary>
        /// Configures borderless on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableBuilder"/> value or BootstrapBuilder result.</returns>
        public TableBuilder SetBorderless(bool value = true)
        {
            return this.SetTableBorderless(value);
        }

        /// <summary>
        /// Configures caption on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="caption">The caption value.</param>
        /// <returns>The configured <see cref="TableBuilder"/> value or BootstrapBuilder result.</returns>
        public TableBuilder SetCaption(string? caption)
        {
            _caption = caption;
            return This();
        }

        /// <summary>
        /// Configures dark on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableBuilder"/> value or BootstrapBuilder result.</returns>
        public TableBuilder SetDark(bool value = true)
        {
            return this.SetTableDark(value);
        }

        /// <summary>
        /// Configures hover on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableBuilder"/> value or BootstrapBuilder result.</returns>
        public TableBuilder SetHover(bool value = true)
        {
            return this.SetTableHover(value);
        }

        /// <summary>
        /// Configures responsive on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="responsive">The responsive value.</param>
        /// <returns>The configured <see cref="TableBuilder"/> value or BootstrapBuilder result.</returns>
        public TableBuilder SetResponsive(TableResponsiveBreakpoint responsive)
        {
            _wrapperComponent.SetResponsiveTable(responsive);
            return This();
        }

        /// <summary>
        /// Configures responsive always on the current BootstrapBuilder instance.
        /// </summary>
        /// <returns>The configured <see cref="TableBuilder"/> value or BootstrapBuilder result.</returns>
        public TableBuilder SetResponsiveAlways()
        {
            _wrapperComponent.SetResponsiveTable(TableResponsiveBreakpoint.Always);
            return This();
        }

        /// <summary>
        /// Configures responsive lg on the current BootstrapBuilder instance.
        /// </summary>
        /// <returns>The configured <see cref="TableBuilder"/> value or BootstrapBuilder result.</returns>
        public TableBuilder SetResponsiveLg()
        {
            _wrapperComponent.SetResponsiveTable(TableResponsiveBreakpoint.Lg);
            return This();
        }

        /// <summary>
        /// Configures responsive md on the current BootstrapBuilder instance.
        /// </summary>
        /// <returns>The configured <see cref="TableBuilder"/> value or BootstrapBuilder result.</returns>
        public TableBuilder SetResponsiveMd()
        {
            _wrapperComponent.SetResponsiveTable(TableResponsiveBreakpoint.Md);
            return This();
        }

        /// <summary>
        /// Configures responsive sm on the current BootstrapBuilder instance.
        /// </summary>
        /// <returns>The configured <see cref="TableBuilder"/> value or BootstrapBuilder result.</returns>
        public TableBuilder SetResponsiveSm()
        {
            _wrapperComponent.SetResponsiveTable(TableResponsiveBreakpoint.Sm);
            return This();
        }

        /// <summary>
        /// Configures responsive xl on the current BootstrapBuilder instance.
        /// </summary>
        /// <returns>The configured <see cref="TableBuilder"/> value or BootstrapBuilder result.</returns>
        public TableBuilder SetResponsiveXl()
        {
            _wrapperComponent.SetResponsiveTable(TableResponsiveBreakpoint.Xl);
            return This();
        }

        /// <summary>
        /// Configures responsive xxl on the current BootstrapBuilder instance.
        /// </summary>
        /// <returns>The configured <see cref="TableBuilder"/> value or BootstrapBuilder result.</returns>
        public TableBuilder SetResponsiveXxl()
        {
            _wrapperComponent.SetResponsiveTable(TableResponsiveBreakpoint.Xxl);
            return This();
        }

        /// <summary>
        /// Configures small on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableBuilder"/> value or BootstrapBuilder result.</returns>
        public TableBuilder SetSmall(bool value = true)
        {
            return this.SetTableSmall(value);
        }

        /// <summary>
        /// Configures sortable on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableBuilder"/> value or BootstrapBuilder result.</returns>
        public TableBuilder SetSortable(bool value = true)
        {
            return this.SetTableSortable(value);
        }

        /// <summary>
        /// Configures striped on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableBuilder"/> value or BootstrapBuilder result.</returns>
        public TableBuilder SetStriped(bool value = true)
        {
            return this.SetTableStriped(value);
        }

        /// <summary>
        /// Configures striped columns on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableBuilder"/> value or BootstrapBuilder result.</returns>
        public TableBuilder SetStripedColumns(bool value = true)
        {
            return this.SetTableStripedColumns(value);
        }

        #region From interface IDisposable

        /// <summary>
        /// Executes the BootstrapBuilder dispose operation.
        /// </summary>
        public void Dispose()
        {
            if (!_started)
            {
                return;
            }

            HtmlRenderContext? current = HtmlRenderContextManager.Current(_htmlHelper);
            if (ReferenceEquals(current, _renderContext))
            {
                HtmlRenderContextManager.Pop(_htmlHelper);
            }

            _textWriter.Write($"</{GetTag()}>");
            _textWriter.Write($"</{_wrapperComponent.GetTag()}>");

            _renderContext = null;
            _started = false;
        }

        #endregion

        #endregion
    }
}