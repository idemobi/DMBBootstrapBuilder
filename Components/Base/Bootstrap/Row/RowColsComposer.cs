#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj RowColsComposer.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Composes Bootstrap CSS classes or page chrome for row cols.
    /// </summary>
    public sealed class RowColsComposer : IIsCssClassComposer
    {
        #region Static methods

        private static string BuildClass(RowColsSize size, ResponsiveBreakpoint breakpoint)
        {
            string bp = breakpoint.GetCss();

            if (size == RowColsSize.Auto)
            {
                return string.IsNullOrWhiteSpace(bp)
                    ? "row-cols-auto"
                    : $"row-cols-{bp}-auto";
            }

            int n = (int)size;

            return string.IsNullOrWhiteSpace(bp)
                ? $"row-cols-{n}"
                : $"row-cols-{bp}-{n}";
        }

        #endregion

        #region Instance fields and properties

        private readonly Dictionary<ResponsiveBreakpoint, RowColsSize> _rules = new();

        #endregion

        #region Instance methods

        /// <summary>
        /// Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="RowColsComposer"/> value or BootstrapBuilder result.</returns>
        public RowColsComposer Set(RowColsSize size, ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs)
        {
            _rules[breakpoint] = size;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        /// Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            return _rules
                .Where(x => x.Value != RowColsSize.None)
                .OrderBy(x => x.Key)
                .Select(x => BuildClass(x.Value, x.Key))
                .Distinct(StringComparer.Ordinal)
                .ToList();
        }

        /// <summary>
        /// Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IIsCssClassComposer"/> value or BootstrapBuilder result.</returns>
        public IIsCssClassComposer Clone()
        {
            var clone = new RowColsComposer();
            foreach (var rule in _rules)
            {
                clone.Set(rule.Value, rule.Key);
            }

            return clone;
        }

        #endregion

        #endregion
    }
}