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
    ///     Composes Bootstrap CSS classes or page chrome for breadcrumb.
    /// </summary>
    public sealed class BreadcrumbComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private string? _divider = "/";
        private BreadcrumbStyle _style = BreadcrumbStyle.Default;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Gets divider for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <returns>The configured <see cref="string" /> value or BootstrapBuilder result.</returns>
        public string? GetDivider()
        {
            return _divider?.Trim();
        }

        /// <summary>
        ///     Configures divider on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="divider">The divider value.</param>
        /// <returns>The configured <see cref="BreadcrumbComposer" /> value or BootstrapBuilder result.</returns>
        public BreadcrumbComposer SetDivider(string? divider)
        {
            _divider = divider;
            return this;
        }

        /// <summary>
        ///     Configures style on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="style">The style value.</param>
        /// <returns>The configured <see cref="BreadcrumbComposer" /> value or BootstrapBuilder result.</returns>
        public BreadcrumbComposer SetStyle(BreadcrumbStyle style)
        {
            _style = style;
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

            string styleCss = _style.GetCssClass();
            if (!string.IsNullOrWhiteSpace(styleCss))
            {
                result.Add(styleCss);
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
            return new BreadcrumbComposer()
                .SetStyle(_style)
                .SetDivider(_divider);
        }

        #endregion

        #endregion
    }
}