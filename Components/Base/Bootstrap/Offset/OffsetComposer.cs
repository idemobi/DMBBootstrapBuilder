#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj OffsetComposer.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Composes Bootstrap CSS classes or page chrome for offset.
    /// </summary>
    public sealed class OffsetComposer : IIsCssClassComposer
    {
        #region Static methods

        private static string BuildClass(Offset offset, ResponsiveBreakpoint breakpoint)
        {
            string value = ((int)offset).ToString();
            string bp = breakpoint.GetCss();

            return string.IsNullOrWhiteSpace(bp)
                ? $"offset-{value}"
                : $"offset-{bp}-{value}";
        }

        #endregion

        #region Instance fields and properties

        private readonly Dictionary<ResponsiveBreakpoint, Offset> _rules = new();

        #endregion

        #region Instance methods

        /// <summary>
        /// Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="offset">The offset value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="OffsetComposer"/> value or BootstrapBuilder result.</returns>
        public OffsetComposer Set(Offset offset, ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs)
        {
            _rules[breakpoint] = offset;
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
                .Where(x => x.Value != Offset.None)
                .OrderBy(x => x.Key)
                .Select(x => BuildClass(x.Value, x.Key))
                .ToList();
        }

        /// <summary>
        /// Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IIsCssClassComposer"/> value or BootstrapBuilder result.</returns>
        public IIsCssClassComposer Clone()
        {
            var clone = new OffsetComposer();
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