#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Composes Bootstrap CSS classes or page chrome for table cell.
    /// </summary>
    public sealed class TableCellComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private bool _sortableHeader;
        private VariantStyle _variant = VariantStyle.Normal;
        private VerticalTitleDirection _verticalTitleDirection = VerticalTitleDirection.None;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures sortable header on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableCellComposer" /> value or BootstrapBuilder result.</returns>
        public TableCellComposer SetSortableHeader(bool value = true)
        {
            _sortableHeader = value;
            return this;
        }

        /// <summary>
        ///     Configures variant on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="variant">The variant value.</param>
        /// <returns>The configured <see cref="TableCellComposer" /> value or BootstrapBuilder result.</returns>
        public TableCellComposer SetVariant(VariantStyle variant)
        {
            _variant = variant;
            return this;
        }

        /// <summary>
        ///     Configures vertical title on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="direction">The direction value.</param>
        /// <returns>The configured <see cref="TableCellComposer" /> value or BootstrapBuilder result.</returns>
        public TableCellComposer SetVerticalTitle(VerticalTitleDirection direction)
        {
            _verticalTitleDirection = direction;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        ///     Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            List<string> result = new();

            if (_sortableHeader)
            {
                result.Add("table-sortable-header");
            }

            if (_verticalTitleDirection != VerticalTitleDirection.None)
            {
                string verticalCss = _verticalTitleDirection.GetCss();
                if (!string.IsNullOrWhiteSpace(verticalCss))
                {
                    result.Add(verticalCss);
                }
            }

            if (_variant != VariantStyle.Normal)
            {
                string variant = _variant.GetVariantCss();
                if (string.IsNullOrWhiteSpace(variant) == false)
                {
                    result.Add($"table-{variant}");
                }
            }

            return result
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct(StringComparer.Ordinal)
                .ToList();
        }

        /// <summary>
        ///     Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IIsCssClassComposer" /> value or BootstrapBuilder result.</returns>
        public IIsCssClassComposer Clone()
        {
            return new TableCellComposer()
                .SetVariant(_variant)
                .SetVerticalTitle(_verticalTitleDirection)
                .SetSortableHeader(_sortableHeader);
        }

        #endregion

        #endregion
    }
}