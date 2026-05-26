#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj TableRowComposer.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Composes Bootstrap CSS classes or page chrome for table row.
    /// </summary>
    public sealed class TableRowComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private bool _active;
        private VariantStyle _variant = VariantStyle.Normal;

        #endregion

        #region Instance methods

        /// <summary>
        /// Configures active on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TableRowComposer"/> value or BootstrapBuilder result.</returns>
        public TableRowComposer SetActive(bool value = true)
        {
            _active = value;
            return this;
        }

        /// <summary>
        /// Configures variant on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="variant">The variant value.</param>
        /// <returns>The configured <see cref="TableRowComposer"/> value or BootstrapBuilder result.</returns>
        public TableRowComposer SetVariant(VariantStyle variant)
        {
            _variant = variant;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        /// Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            List<string> result = new();

            if (_active)
            {
                result.Add("table-active");
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
        /// Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IIsCssClassComposer"/> value or BootstrapBuilder result.</returns>
        public IIsCssClassComposer Clone()
        {
            return new TableRowComposer()
                .SetActive(_active)
                .SetVariant(_variant);
        }

        #endregion

        #endregion
    }
}