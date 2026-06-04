#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using System.IO;
using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Builds and renders the BootstrapBuilder table section component or page region.
    /// </summary>
    public sealed class TableSectionBuilder :
        HtmlTagBuilder<TableSectionBuilder>,
        IDisposable,
        ICanUseTableSection
    {
        #region Static methods

        private static HtmlRenderContextKind GetRenderContextKind(TableSectionKind kind)
        {
            return kind switch
            {
                TableSectionKind.Header => HtmlRenderContextKind.TableHead,
                TableSectionKind.Body => HtmlRenderContextKind.TableBody,
                TableSectionKind.Footer => HtmlRenderContextKind.TableFoot,
                _ => HtmlRenderContextKind.TableBody
            };
        }

        #endregion

        #region Instance fields and properties

        private TableSectionKind _kind
        {
            get => GetInternal("_kind", TableSectionKind.Body);
            set => SetInternal("_kind", value);
        }

        private HtmlRenderContext? _renderContext;

        private new bool _started
        {
            get => GetInternal("_started", false);
            set => SetInternal("_started", value);
        }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="TableSectionBuilder" /> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public TableSectionBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _kind = TableSectionKind.Body;
            _tag = _kind.GetTag();
            SetData("table-section", "true");
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TableSectionBuilder" /> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <param name="kind">The kind value.</param>
        public TableSectionBuilder(TextWriter writer, IHtmlHelper html, TableSectionKind kind = TableSectionKind.Body)
            : base(writer, html)
        {
            _kind = kind;
            _tag = _kind.GetTag();
            SetData("table-section", "true");
        }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Executes the BootstrapBuilder begin operation.
        /// </summary>
        /// <returns>The configured <see cref="TableSectionBuilder" /> value or BootstrapBuilder result.</returns>
        public override TableSectionBuilder Begin()
        {
            if (_started)
            {
                return this;
            }

            HtmlRenderContext? currentContext = HtmlRenderContextManager.Current(_htmlHelper);

            if (currentContext == null || currentContext.Kind != HtmlRenderContextKind.Table)
            {
                throw new InvalidOperationException(
                    $"TableSection must be opened within a Table context (current context is {currentContext?.Kind.ToString() ?? "null"}).");
            }

            OnRenderDebug();

            _renderContext = new HtmlRenderContext
            {
                Kind = GetRenderContextKind(_kind),
                Owner = this
            };

            HtmlRenderContextManager.Push(_htmlHelper, _renderContext);

            _textWriter.Write($"""<{_kind.GetTag()}{BuildAttributes()}>""");
            _started = true;
            return this;
        }

        /// <inheritdoc />
        protected override TableSectionBuilder CreateInstance()
        {
            return new TableSectionBuilder(_textWriter, _htmlHelper, _kind);
        }

        /// <inheritdoc />
        protected override void InternalClone(TableSectionBuilder source)
        {
            base.InternalClone(source);
            _kind = source._kind;
            _tag = source._tag;
            _started = false;
            _renderContext = null;
        }

        /// <summary>
        ///     Configures divider on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="divider">The divider value.</param>
        /// <returns>The configured <see cref="TableSectionBuilder" /> value or BootstrapBuilder result.</returns>
        public TableSectionBuilder SetDivider(bool divider = true)
        {
            return this.SetTableSectionDivider(divider);
        }

        /// <summary>
        ///     Configures section on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="kind">The kind value.</param>
        /// <returns>The configured <see cref="TableSectionBuilder" /> value or BootstrapBuilder result.</returns>
        public TableSectionBuilder SetSection(TableSectionKind kind)
        {
            _kind = kind;
            _tag = _kind.GetTag();
            return this;
        }

        /// <summary>
        ///     Configures variant on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="style">The style value.</param>
        /// <returns>The configured <see cref="TableSectionBuilder" /> value or BootstrapBuilder result.</returns>
        public TableSectionBuilder SetVariant(VariantStyle style)
        {
            return this.SetTableSectionVariant(style);
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write($"""<{_kind.GetTag()}{BuildAttributes()}></{_kind.GetTag()}>""");
        }

        #region From interface IDisposable

        /// <summary>
        ///     Executes the BootstrapBuilder dispose operation.
        /// </summary>
        public new void Dispose()
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

            _textWriter.Write($"""</{_kind.GetTag()}>""");
            _renderContext = null;
            _started = false;
        }

        #endregion

        #endregion
    }
}