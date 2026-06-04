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
    ///     Composes Bootstrap CSS classes or page chrome for table section.
    /// </summary>
    public sealed class TableSectionComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private bool _groupDivider;
        private VariantStyle _variant = VariantStyle.Normal;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures divider on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableSectionComposer" /> value or BootstrapBuilder result.</returns>
        public TableSectionComposer SetDivider(bool value = true)
        {
            _groupDivider = value;
            return this;
        }

        /// <summary>
        ///     Configures variant on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="variant">The variant value.</param>
        /// <returns>The configured <see cref="TableSectionComposer" /> value or BootstrapBuilder result.</returns>
        public TableSectionComposer SetVariant(VariantStyle variant)
        {
            _variant = variant;
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

            if (_groupDivider)
            {
                result.Add("table-group-divider");
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
            return new TableSectionComposer()
                .SetDivider(_groupDivider)
                .SetVariant(_variant);
        }

        #endregion

        #endregion
    }
}