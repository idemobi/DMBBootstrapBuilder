#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Globalization;
using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Builds and renders the BootstrapBuilder table row component or page region.
    /// </summary>
    public sealed class TableRowBuilder :
        HtmlTagBuilder<TableRowBuilder>,
        ICursorBuilder<TableRowBuilder>,
        ICanUseTableRow,
        ICanUseTextAlign,
        ICanUseVerticalAlign,
        ICanUseHeight,
        IDisposable
    {
        #region Instance fields and properties

        private HtmlRenderContext? _renderContext;

        private new bool _started
        {
            get => GetInternal("_started", false);
            set => SetInternal("_started", value);
        }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="TableRowBuilder" /> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public TableRowBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "tr";
            SetData("table-row", "true");
        }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Executes the BootstrapBuilder begin operation.
        /// </summary>
        /// <returns>The configured <see cref="TableRowBuilder" /> value or BootstrapBuilder result.</returns>
        public override TableRowBuilder Begin()
        {
            if (_started)
            {
                return this;
            }

            HtmlRenderContext? currentContext = HtmlRenderContextManager.Current(_htmlHelper);

            if (currentContext == null ||
                currentContext.Kind == HtmlRenderContextKind.TableRow ||
                (currentContext.Kind != HtmlRenderContextKind.Table &&
                 currentContext.Kind != HtmlRenderContextKind.TableHead &&
                 currentContext.Kind != HtmlRenderContextKind.TableBody &&
                 currentContext.Kind != HtmlRenderContextKind.TableFoot))
            {
                throw new InvalidOperationException(
                    $"TableRow must be opened within a Table, Thead, Tbody or Tfoot context (current context is {currentContext?.Kind.ToString() ?? "null"}).");
            }

            OnRenderDebug();

            _renderContext = new HtmlRenderContext
            {
                Kind = HtmlRenderContextKind.TableRow,
                Owner = this
            };

            HtmlRenderContextManager.Push(_htmlHelper, _renderContext);

            _textWriter.Write($"<{GetTag()}{BuildAttributes()}>");
            _started = true;
            return this;
        }

        /// <inheritdoc />
        protected override TableRowBuilder CreateInstance()
        {
            return new TableRowBuilder(_textWriter, _htmlHelper);
        }

        /// <inheritdoc />
        protected override void InternalClone(TableRowBuilder source)
        {
            base.InternalClone(source);
            _started = false;
            _renderContext = null;
        }

        /// <summary>
        ///     Configures active on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableRowBuilder" /> value or BootstrapBuilder result.</returns>
        public TableRowBuilder SetActive(bool value = true)
        {
            return this.SetTableRowActive(value);
        }

        /// <summary>
        ///     Configures sort value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="key">The key value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableRowBuilder" /> value or BootstrapBuilder result.</returns>
        public TableRowBuilder SetSortValue(string key, string? value)
        {
            PageInformation page = PageRegistry.GetOrCreatePageInformation(_htmlHelper.ViewContext.HttpContext);
            page.SetScriptFile("/js/TableSortable.js");

            key = key.Trim().ToLowerInvariant();

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Sort key cannot be null or empty.", nameof(key));
            }

            SetData($"sort-{key}", value ?? string.Empty);
            return this;
        }

        /// <summary>
        ///     Configures sort value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="key">The key value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableRowBuilder" /> value or BootstrapBuilder result.</returns>
        public TableRowBuilder SetSortValue(string key, int value)
        {
            return SetSortValue(key, value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        ///     Configures sort value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="key">The key value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableRowBuilder" /> value or BootstrapBuilder result.</returns>
        public TableRowBuilder SetSortValue(string key, long value)
        {
            return SetSortValue(key, value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        ///     Configures sort value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="key">The key value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableRowBuilder" /> value or BootstrapBuilder result.</returns>
        public TableRowBuilder SetSortValue(string key, decimal value)
        {
            return SetSortValue(key, value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        ///     Configures sort value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="key">The key value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableRowBuilder" /> value or BootstrapBuilder result.</returns>
        public TableRowBuilder SetSortValue(string key, double value)
        {
            return SetSortValue(key, value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        ///     Configures sort value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="key">The key value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableRowBuilder" /> value or BootstrapBuilder result.</returns>
        public TableRowBuilder SetSortValue(string key, DateTime value)
        {
            return SetSortValue(key, value.ToString("O", CultureInfo.InvariantCulture));
        }

        /// <summary>
        ///     Configures variant on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="style">The style value.</param>
        /// <returns>The configured <see cref="TableRowBuilder" /> value or BootstrapBuilder result.</returns>
        public TableRowBuilder SetVariant(VariantStyle style)
        {
            return this.SetTableRowVariant(style);
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write($"<{GetTag()}{BuildAttributes()}></{GetTag()}>");
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

            _textWriter.Write($"</{GetTag()}>");
            _renderContext = null;
            _started = false;
        }

        #endregion

        #endregion
    }
}