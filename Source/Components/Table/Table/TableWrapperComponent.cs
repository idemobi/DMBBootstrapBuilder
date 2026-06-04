#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.IO;
using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the BootstrapBuilder table wrapper component component or support type.
    /// </summary>
    public sealed class TableWrapperComponent :
        HtmlTagBuilder<TableWrapperComponent>,
        ICanUseResponsiveTable
    {
        #region Instance fields and properties

        private string _inner
        {
            get => GetInternal("_inner", string.Empty);
            set => SetInternal("_inner", value);
        }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="TableWrapperComponent" /> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public TableWrapperComponent(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "div";
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override TableWrapperComponent CreateInstance()
        {
            return new TableWrapperComponent(_textWriter, _htmlHelper);
        }

        /// <inheritdoc />
        protected override void InternalClone(TableWrapperComponent source)
        {
            base.InternalClone(source);
            _inner = source._inner;
        }

        /// <summary>
        ///     Configures inner on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The configured <see cref="TableWrapperComponent" /> value or BootstrapBuilder result.</returns>
        public TableWrapperComponent SetInner(string html)
        {
            _inner = html ?? string.Empty;
            return this;
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write($"<{_tag}{BuildAttributes()}>");

            if (!string.IsNullOrEmpty(_inner))
            {
                writer.Write(_inner);
            }

            writer.Write($"</{_tag}>");
        }

        #endregion
    }
}