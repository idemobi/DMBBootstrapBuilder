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
    ///     Composes Bootstrap CSS classes or page chrome for badge.
    /// </summary>
    public sealed class BadgeComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private bool _asNotification = false;
        private bool _pill;
        private VariantStyle _variant = VariantStyle.Secondary;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures as notification on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="BadgeComposer" /> value or BootstrapBuilder result.</returns>
        public BadgeComposer SetAsNotification(bool value = true)
        {
            _asNotification = value;
            return this;
        }

        /// <summary>
        ///     Configures pill on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="BadgeComposer" /> value or BootstrapBuilder result.</returns>
        public BadgeComposer SetPill(bool value = true)
        {
            _pill = value;
            return this;
        }

        /// <summary>
        ///     Configures variant on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="variant">The variant value.</param>
        /// <returns>The configured <see cref="BadgeComposer" /> value or BootstrapBuilder result.</returns>
        public BadgeComposer SetVariant(VariantStyle variant)
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
            List<string> result = new()
            {
                "badge"
            };
            string variantCss = _variant.GetVariantCss();
            if (_asNotification)
            {
                result.Add($"position-absolute top-0 start-100 translate-middle p-2 rounded-circle border border-light");
                if (!string.IsNullOrWhiteSpace(variantCss))
                {
                    result.Add($"bg-{variantCss}");
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(variantCss))
                {
                    result.Add($"text-bg-{variantCss}");
                }

                if (_pill)
                {
                    result.Add("rounded-pill");
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
            return new BadgeComposer()
                .SetVariant(_variant)
                .SetPill(_pill)
                .SetAsNotification(_asNotification);
        }

        #endregion

        #endregion
    }
}