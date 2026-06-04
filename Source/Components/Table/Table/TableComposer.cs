#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using System.Collections.Generic;
using System.Linq;
using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Composes Bootstrap CSS classes or page chrome for table.
    /// </summary>
    public sealed class TableComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private bool _bordered;
        private bool _borderless;
        private bool _captionTop;
        private bool _dark;
        private bool _hover;
        private bool _small;
        private bool _sortable;
        private bool _striped;
        private bool _stripedColumns;

        /// <summary>
        ///     Gets or sets a value indicating whether sortable is enabled for BootstrapBuilder rendering.
        /// </summary>
        public bool IsSortable => _sortable;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures bordered on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableComposer" /> value or BootstrapBuilder result.</returns>
        public TableComposer SetBordered(bool value = true)
        {
            _bordered = value;
            if (value)
            {
                _borderless = false;
            }

            return this;
        }

        /// <summary>
        ///     Configures borderless on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableComposer" /> value or BootstrapBuilder result.</returns>
        public TableComposer SetBorderless(bool value = true)
        {
            _borderless = value;
            if (value)
            {
                _bordered = false;
            }

            return this;
        }

        /// <summary>
        ///     Configures caption top on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableComposer" /> value or BootstrapBuilder result.</returns>
        public TableComposer SetCaptionTop(bool value = true)
        {
            _captionTop = value;
            return this;
        }

        /// <summary>
        ///     Configures dark on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableComposer" /> value or BootstrapBuilder result.</returns>
        public TableComposer SetDark(bool value = true)
        {
            _dark = value;
            return this;
        }

        /// <summary>
        ///     Configures hover on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableComposer" /> value or BootstrapBuilder result.</returns>
        public TableComposer SetHover(bool value = true)
        {
            _hover = value;
            return this;
        }

        /// <summary>
        ///     Configures small on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableComposer" /> value or BootstrapBuilder result.</returns>
        public TableComposer SetSmall(bool value = true)
        {
            _small = value;
            return this;
        }

        /// <summary>
        ///     Configures sortable on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableComposer" /> value or BootstrapBuilder result.</returns>
        public TableComposer SetSortable(bool value = true)
        {
            _sortable = value;
            return this;
        }

        /// <summary>
        ///     Configures striped on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableComposer" /> value or BootstrapBuilder result.</returns>
        public TableComposer SetStriped(bool value = true)
        {
            _striped = value;
            return this;
        }

        /// <summary>
        ///     Configures striped columns on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableComposer" /> value or BootstrapBuilder result.</returns>
        public TableComposer SetStripedColumns(bool value = true)
        {
            _stripedColumns = value;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        ///     Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            List<string> result = new()
            {
                "table"
            };

            if (_striped)
            {
                result.Add("table-striped");
            }

            if (_stripedColumns)
            {
                result.Add("table-striped-columns");
            }

            if (_hover)
            {
                result.Add("table-hover");
            }

            if (_bordered)
            {
                result.Add("table-bordered");
            }

            if (_borderless)
            {
                result.Add("table-borderless");
            }

            if (_small)
            {
                result.Add("table-sm");
            }

            if (_dark)
            {
                result.Add("table-dark");
            }

            if (_sortable)
            {
                result.Add("table-sortable");
            }

            if (_captionTop)
            {
                result.Add("caption-top");
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
            var clone = new TableComposer();

            if (_bordered) clone.SetBordered(true);
            if (_borderless) clone.SetBorderless(true);
            if (_dark) clone.SetDark(true);
            if (_hover) clone.SetHover(true);
            if (_small) clone.SetSmall(true);
            if (_sortable) clone.SetSortable(true);
            if (_striped) clone.SetStriped(true);
            if (_stripedColumns) clone.SetStripedColumns(true);

            return clone;
        }

        #endregion

        #endregion
    }
}