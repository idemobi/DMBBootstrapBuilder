#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj FlexDirectionComposer.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Composes Bootstrap CSS classes or page chrome for flex direction.
    /// </summary>
    public sealed class FlexDirectionComposer : IIsCssClassComposer
    {
        #region Static methods

        private static string BuildClass(FlexDirection flexDirection, ResponsiveBreakpoint breakpoint)
        {
            string valueCss = flexDirection.GetCss();
            string breakpointCss = breakpoint.GetCss();

            return string.IsNullOrWhiteSpace(breakpointCss)
                ? $"flex-{valueCss}"
                : $"flex-{breakpointCss}-{valueCss}";
        }

        #endregion

        #region Instance fields and properties

        private readonly Dictionary<ResponsiveBreakpoint, FlexDirection> _rules = new();

        #endregion

        #region Instance methods

        /// <summary>
        /// Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="flexDirection">The flex direction value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="FlexDirectionComposer"/> value or BootstrapBuilder result.</returns>
        public FlexDirectionComposer Set(
            FlexDirection flexDirection,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
        {
            _rules[breakpoint] = flexDirection;
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
            var clone = new FlexDirectionComposer();
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