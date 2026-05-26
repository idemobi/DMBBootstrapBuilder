#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj DisplayComposer.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Composes Bootstrap CSS classes or page chrome for display.
    /// </summary>
    public sealed class DisplayComposer : IIsCssClassComposer
    {
        #region Static methods

        private static string BuildPrintClass(Display display)
        {
            return $"d-print-{display.GetCss()}";
        }

        private static string BuildResponsiveClass(Display display, ResponsiveBreakpoint breakpoint)
        {
            string displayCss = display.GetCss();
            string breakpointCss = breakpoint.GetCss();

            if (string.IsNullOrWhiteSpace(breakpointCss))
            {
                return $"d-{displayCss}";
            }

            return $"d-{breakpointCss}-{displayCss}";
        }

        #endregion

        #region Instance fields and properties

        private Display? _printDisplay;
        private readonly Dictionary<ResponsiveBreakpoint, Display> _responsiveRules = new();

        #endregion

        #region Instance methods

        /// <summary>
        /// Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="display">The display value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="DisplayComposer"/> value or BootstrapBuilder result.</returns>
        public DisplayComposer Set(Display display, ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs)
        {
            _responsiveRules[breakpoint] = display;
            return this;
        }

        /// <summary>
        /// Configures print on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="display">The display value.</param>
        /// <returns>The configured <see cref="DisplayComposer"/> value or BootstrapBuilder result.</returns>
        public DisplayComposer SetPrint(Display display)
        {
            _printDisplay = display;
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

            foreach (KeyValuePair<ResponsiveBreakpoint, Display> rule in _responsiveRules.OrderBy(x => x.Key))
            {
                result.Add(BuildResponsiveClass(rule.Value, rule.Key));
            }

            if (_printDisplay.HasValue)
            {
                result.Add(BuildPrintClass(_printDisplay.Value));
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
            var clone = new DisplayComposer();
            foreach (var rule in _responsiveRules)
            {
                clone.Set(rule.Value, rule.Key);
            }

            if (_printDisplay.HasValue)
            {
                clone.SetPrint(_printDisplay.Value);
            }

            return clone;
        }

        #endregion

        #endregion
    }
}