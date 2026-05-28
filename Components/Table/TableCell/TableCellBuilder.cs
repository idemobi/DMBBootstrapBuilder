#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj TableCellBuilder.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using System.Globalization;
using System.Net;
using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Builds and renders the BootstrapBuilder table cell component or page region.
    /// </summary>
    public sealed class TableCellBuilder :
        HtmlTagBuilder<TableCellBuilder>,
        ICursorBuilder<TableCellBuilder>,
        ICanUseTableCell,
        ICanUseVerticalAlign,
        ICanUseTextAlign,
        ICanUseBorder,
        ICanUseFontItalic,
        ICanUseFontSize,
        ICanUseFontWeight,
        ICanUseTextDecoration,
        ICanUseTextTransform,
        ICanUseTextMuted,
        ICanUsePadding,
        ICanUseOpacity,
        ICanUseWordBreak,
        ICanUseHeight,
        ICanUseWidth,
        IDisposable,
        ICanUseTextWrapping
    {
        #region Instance fields and properties

        private int _colspan
        {
            get => GetInternal("_colspan", 0);
            set => SetInternal("_colspan", value);
        }

        private bool _isHeader
        {
            get => GetInternal("_isHeader", false);
            set => SetInternal("_isHeader", value);
        }

        private int _rowspan
        {
            get => GetInternal("_rowspan", 0);
            set => SetInternal("_rowspan", value);
        }

        private string _scope
        {
            get => GetInternal("_scope", string.Empty);
            set => SetInternal("_scope", value);
        }

        private string _sortKey
        {
            get => GetInternal("_sortKey", string.Empty);
            set => SetInternal("_sortKey", value);
        }

        private new bool _started
        {
            get => GetInternal("_started", false);
            set => SetInternal("_started", value);
        }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TableCellBuilder"/> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public TableCellBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "td";
            SetData("table-cell", "true");
        }

        #endregion

        #region Instance methods

        /// <summary>
        /// Executes the BootstrapBuilder begin operation.
        /// </summary>
        /// <returns>The configured <see cref="TableCellBuilder"/> value or BootstrapBuilder result.</returns>
        public override TableCellBuilder Begin()
        {
            if (_started)
            {
                return this;
            }

            string exceptionMessage = string.Empty;
            HtmlRenderContext? currentContext = HtmlRenderContextManager.Current(_htmlHelper);

            if (currentContext == null || currentContext.Kind != HtmlRenderContextKind.TableRow)
            {
                exceptionMessage =
                    $"<span class=\"text-danger bi bi-exclamation-triangle-fill\"></span> <!-- TableCellBuilder must be opened within a TableRow context (current context is {currentContext?.Kind.ToString() ?? "null"}). -->";
            }

            OnRenderDebug();

            if (!string.IsNullOrWhiteSpace(_sortKey))
            {
                this.SetSortable(true);
                SetData("sortable", "true");
                SetData("sort-key", _sortKey);
                SetData("sort-direction", string.Empty);
            }

            if (!string.IsNullOrWhiteSpace(_scope))
            {
                SetAttribute("scope", _scope);
            }

            if (_colspan > 1)
            {
                SetAttribute("colspan", _colspan.ToString(CultureInfo.InvariantCulture));
            }

            if (_rowspan > 1)
            {
                SetAttribute("rowspan", _rowspan.ToString(CultureInfo.InvariantCulture));
            }

            _textWriter.Write($"<{GetTag()}{BuildAttributes()}>{exceptionMessage}");

            if (!string.IsNullOrWhiteSpace(_sortKey))
            {
                _textWriter.Write("""<span class="table-sort-header">""");
            }

            _started = true;
            return this;
        }

       /// <inheritdoc />
       protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
{
    string? previousScope = GetAttributeValue("scope");
    string? previousColspan = GetAttributeValue("colspan");
    string? previousRowspan = GetAttributeValue("rowspan");
    string? previousSortable = GetAttributeValue("data-sortable");
    string? previousSortKey = GetAttributeValue("data-sort-key");
    string? previousSortDirection = GetAttributeValue("data-sort-direction");

    try
    {
        if (!string.IsNullOrWhiteSpace(_sortKey))
        {
            this.SetSortable(true);
            SetData("sortable", "true");
            SetData("sort-key", _sortKey);
            SetData("sort-direction", string.Empty);
        }

        if (!string.IsNullOrWhiteSpace(_scope))
        {
            SetAttribute("scope", _scope);
        }

        if (_colspan > 1)
        {
            SetAttribute("colspan", _colspan.ToString(CultureInfo.InvariantCulture));
        }

        if (_rowspan > 1)
        {
            SetAttribute("rowspan", _rowspan.ToString(CultureInfo.InvariantCulture));
        }

        writer.Write($"<{GetTag()}{BuildAttributes()}>");

        if (!string.IsNullOrWhiteSpace(_sortKey))
        {
            writer.Write("""
                         <span class="table-sort-header">
                             <span class="table-sort-icons" aria-hidden="true">
                                 <i class="bi bi-caret-up-fill sort-icon sort-icon-asc"></i>
                                 <i class="bi bi-caret-down-fill sort-icon sort-icon-desc"></i>
                             </span>
                         </span>
                         """);
        }

        writer.Write($"</{GetTag()}>");
    }
    finally
    {
        RestoreAttribute("scope", previousScope);
        RestoreAttribute("colspan", previousColspan);
        RestoreAttribute("rowspan", previousRowspan);
        RestoreAttribute("data-sortable", previousSortable);
        RestoreAttribute("data-sort-key", previousSortKey);
        RestoreAttribute("data-sort-direction", previousSortDirection);
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

        /// <inheritdoc />
        protected override TableCellBuilder CreateInstance()
        {
            return new TableCellBuilder(_textWriter, _htmlHelper);
        }

        /// <inheritdoc />
        protected override void InternalClone(TableCellBuilder source)
        {
            base.InternalClone(source);

            _colspan = source._colspan;
            _rowspan = source._rowspan;
            _isHeader = source._isHeader;
            _scope = source._scope;
            _sortKey = source._sortKey;
            _started = false;

            _tag = source._tag;
        }

        /// <summary>
        /// Renders value for the BootstrapBuilder output.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableCellBuilder"/> value or BootstrapBuilder result.</returns>
        public TableCellBuilder Render(int value) => Render(value.ToString(CultureInfo.CurrentCulture));

        /// <summary>
        /// Renders value for the BootstrapBuilder output.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableCellBuilder"/> value or BootstrapBuilder result.</returns>
        public TableCellBuilder Render(long value) => Render(value.ToString(CultureInfo.CurrentCulture));

        /// <summary>
        /// Renders value for the BootstrapBuilder output.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableCellBuilder"/> value or BootstrapBuilder result.</returns>
        public TableCellBuilder Render(float value) => Render(value.ToString("N2", CultureInfo.CurrentCulture));

        /// <summary>
        /// Renders value for the BootstrapBuilder output.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableCellBuilder"/> value or BootstrapBuilder result.</returns>
        public TableCellBuilder Render(double value) => Render(value.ToString("N2", CultureInfo.CurrentCulture));

        /// <summary>
        /// Renders value for the BootstrapBuilder output.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableCellBuilder"/> value or BootstrapBuilder result.</returns>
        public TableCellBuilder Render(decimal value) => Render(value.ToString("N2", CultureInfo.CurrentCulture));

        /// <summary>
        /// Renders value for the BootstrapBuilder output.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <returns>The configured <see cref="TableCellBuilder"/> value or BootstrapBuilder result.</returns>
        public TableCellBuilder Render(string? text)
        {
            Begin();

            if (!string.IsNullOrEmpty(text))
            {
                _textWriter.Write(WebUtility.HtmlEncode(text));
            }

            Dispose();
            return this;
        }

        /// <summary>
        /// Renders value for the BootstrapBuilder output.
        /// </summary>
        /// <param name="content">The content value.</param>
        /// <returns>The configured <see cref="TableCellBuilder"/> value or BootstrapBuilder result.</returns>
        public TableCellBuilder Render(IHtmlContent? content)
        {
            Begin();

            if (content != null)
            {
                content.WriteTo(_textWriter, HtmlEncoder.Default);
            }

            Dispose();
            return this;
        }

        /// <summary>
        /// Renders value for the BootstrapBuilder output.
        /// </summary>
        /// <param name="icon">The icon value.</param>
        /// <returns>The configured <see cref="TableCellBuilder"/> value or BootstrapBuilder result.</returns>
        public TableCellBuilder Render(IconStruct icon)
        {
            Begin();

            HtmlLayoutExtensions
                .IconBuilder(_htmlHelper, icon, null, null)
                .WriteTo(_textWriter, HtmlEncoder.Default);

            Dispose();
            return this;
        }

        /// <summary>
        /// Renders value for the BootstrapBuilder output.
        /// </summary>
        /// <param name="action">The action value.</param>
        /// <returns>The configured <see cref="TableCellBuilder"/> value or BootstrapBuilder result.</returns>
        public TableCellBuilder Render(IActionItem action)
        {
            ArgumentNullException.ThrowIfNull(action);
            return Render(_htmlHelper.Button(action));
        }

        /// <summary>
        /// Renders value for the BootstrapBuilder output.
        /// </summary>
        /// <param name="oldGap">The old gap value.</param>
        /// <param name="justify">The justify value.</param>
        /// <param name="actions">The actions value.</param>
        /// <returns>The configured <see cref="TableCellBuilder"/> value or BootstrapBuilder result.</returns>
        public TableCellBuilder Render(
            Old_Gap oldGap = Old_Gap.Gap1,
            JustifyContent justify = JustifyContent.Start,
            params IActionItem[] actions)
        {
            Begin();

            if (actions != null && actions.Length > 0)
            {
                string justifyClass = justify.GetJustifyCss();
                string gapClass = oldGap.GetGapCss();

                _textWriter.Write($"""<div class="d-flex {justifyClass} {gapClass}">""");

                foreach (IActionItem action in actions.Where(x => x != null))
                {
                    _htmlHelper.Button(action).WriteTo(_textWriter, HtmlEncoder.Default);
                }

                _textWriter.Write("</div>");
            }

            Dispose();
            return this;
        }

        /// <summary>
        /// Renders group for the BootstrapBuilder output.
        /// </summary>
        /// <param name="actions">The actions value.</param>
        /// <returns>The configured <see cref="TableCellBuilder"/> value or BootstrapBuilder result.</returns>
        public TableCellBuilder RenderGroup(params IActionItem[] actions)
        {
            Begin();

            List<IActionItem>? validActions = actions?.Where(x => x != null).ToList();
            if (validActions != null && validActions.Count > 0)
            {
                _textWriter.Write("""<div class="btn-group" role="group">""");

                foreach (IActionItem action in validActions)
                {
                    _htmlHelper.Button(action).WriteTo(_textWriter, HtmlEncoder.Default);
                }

                _textWriter.Write("""</div>""");
            }

            Dispose();
            return this;
        }

        /// <summary>
        /// Renders html for the BootstrapBuilder output.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="TableCellBuilder"/> value or BootstrapBuilder result.</returns>
        public TableCellBuilder RenderHtml(string? html)
        {
            Begin();

            if (!string.IsNullOrEmpty(html))
            {
                _textWriter.Write(html);
            }

            Dispose();
            return this;
        }

        /// <summary>
        /// Configures colspan on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="colspan">The colspan value.</param>
        /// <returns>The configured <see cref="TableCellBuilder"/> value or BootstrapBuilder result.</returns>
        public TableCellBuilder SetColspan(int colspan)
        {
            if (colspan <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(colspan));
            }

            _colspan = colspan;
            return this;
        }

        /// <summary>
        /// Configures is header on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="header">The header value.</param>
        /// <returns>The configured <see cref="TableCellBuilder"/> value or BootstrapBuilder result.</returns>
        public TableCellBuilder SetIsHeader(bool header = true)
        {
            if (!_started)
            {
                _isHeader = header;
                _tag = header ? "th" : "td";
            }

            return this;
        }

        /// <summary>
        /// Configures rowspan on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="rowspan">The rowspan value.</param>
        /// <returns>The configured <see cref="TableCellBuilder"/> value or BootstrapBuilder result.</returns>
        public TableCellBuilder SetRowspan(int rowspan)
        {
            if (rowspan <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rowspan));
            }

            _rowspan = rowspan;
            return this;
        }

        /// <summary>
        /// Configures scope on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="scope">The scope value.</param>
        /// <returns>The configured <see cref="TableCellBuilder"/> value or BootstrapBuilder result.</returns>
        public TableCellBuilder SetScope(string scope)
        {
            _scope = scope ?? string.Empty;
            return this;
        }

        /// <summary>
        /// Configures sortable on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="key">The key value.</param>
        /// <returns>The configured <see cref="TableCellBuilder"/> value or BootstrapBuilder result.</returns>
        public TableCellBuilder SetSortable(string key)
        {
            if (!_isHeader)
            {
                throw new InvalidOperationException("Sortable(...) is only valid on table header cells.");
            }

            key = key.Trim().ToLowerInvariant();

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Sort key cannot be null or empty.", nameof(key));
            }

            _sortKey = key;
            return this;
        }

        #region From interface IDisposable

        /// <summary>
        /// Executes the BootstrapBuilder dispose operation.
        /// </summary>
        public new void Dispose()
        {
            if (!_started)
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(_sortKey))
            {
                _textWriter.Write("""
                                  <span class="table-sort-icons" aria-hidden="true">
                                      <i class="bi bi-caret-up-fill sort-icon sort-icon-asc"></i>
                                      <i class="bi bi-caret-down-fill sort-icon sort-icon-desc"></i>
                                  </span>
                                  </span>
                                  """);
            }

            _textWriter.Write($"</{GetTag()}>");
            _started = false;
        }

        #endregion

        #endregion
    }
}
