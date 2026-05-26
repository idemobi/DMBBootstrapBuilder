#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj CssGridSpanComposer.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Composes Bootstrap CSS classes or page chrome for css grid span.
    /// </summary>
    public sealed class CssGridSpanComposer : IIsCssClassComposer
    {
        #region Static methods

        private static string BuildClass(CssGridSpan span, ResponsiveBreakpoint breakpoint)
        {
            string bp = breakpoint.GetCss();
            int value = (int)span;

            return string.IsNullOrWhiteSpace(bp)
                ? $"g-col-{value}"
                : $"g-col-{bp}-{value}";
        }

        #endregion

        #region Instance fields and properties

        private readonly Dictionary<ResponsiveBreakpoint, CssGridSpan> _rules = new();

        #endregion

        #region Instance methods

        /// <summary>
        /// Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="span">The span value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="CssGridSpanComposer"/> value or BootstrapBuilder result.</returns>
        public CssGridSpanComposer Set(CssGridSpan span, ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs)
        {
            _rules[breakpoint] = span;
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
                .Where(x => x.Value != CssGridSpan.None)
                .OrderBy(x => x.Key)
                .Select(x => BuildClass(x.Value, x.Key))
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
            var clone = new CssGridSpanComposer();
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