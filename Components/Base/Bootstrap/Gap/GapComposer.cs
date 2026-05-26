#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj GapComposer.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Composes Bootstrap CSS classes or page chrome for gap.
    /// </summary>
    public sealed class GapComposer : IIsCssClassComposer
    {
        #region Static methods

        private static string BuildClass(string prefix, Gap gap, ResponsiveBreakpoint breakpoint)
        {
            string value = gap.GetCss();
            string bp = breakpoint.GetCss();

            return string.IsNullOrWhiteSpace(bp)
                ? $"{prefix}-{value}"
                : $"{prefix}-{bp}-{value}";
        }

        #endregion

        #region Instance fields and properties

        private readonly Dictionary<ResponsiveBreakpoint, Gap> _gapRules = new();
        private readonly Dictionary<ResponsiveBreakpoint, Gap> _gapXRules = new();
        private readonly Dictionary<ResponsiveBreakpoint, Gap> _gapYRules = new();

        #endregion

        #region Instance methods

        /// <summary>
        /// Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="gap">The gap value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="GapComposer"/> value or BootstrapBuilder result.</returns>
        public GapComposer Set(Gap gap, ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs)
        {
            _gapRules[breakpoint] = gap;
            return this;
        }

        /// <summary>
        /// Configures x on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="gap">The gap value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="GapComposer"/> value or BootstrapBuilder result.</returns>
        public GapComposer SetX(Gap gap, ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs)
        {
            _gapXRules[breakpoint] = gap;
            return this;
        }

        /// <summary>
        /// Configures y on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="gap">The gap value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="GapComposer"/> value or BootstrapBuilder result.</returns>
        public GapComposer SetY(Gap gap, ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs)
        {
            _gapYRules[breakpoint] = gap;
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

            result.AddRange(_gapRules.OrderBy(x => x.Key).Select(x => BuildClass("g", x.Value, x.Key)));
            result.AddRange(_gapXRules.OrderBy(x => x.Key).Select(x => BuildClass("gx", x.Value, x.Key)));
            result.AddRange(_gapYRules.OrderBy(x => x.Key).Select(x => BuildClass("gy", x.Value, x.Key)));

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
            var clone = new GapComposer();
            foreach (var rule in _gapRules)
            {
                clone.Set(rule.Value, rule.Key);
            }

            foreach (var rule in _gapXRules)
            {
                clone.SetX(rule.Value, rule.Key);
            }

            foreach (var rule in _gapYRules)
            {
                clone.SetY(rule.Value, rule.Key);
            }

            return clone;
        }

        #endregion

        #endregion
    }
}