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
    ///     Composes Bootstrap CSS classes or page chrome for col size.
    /// </summary>
    public sealed class ColSizeComposer : IIsCssClassComposer
    {
        #region Static methods

        private static string BuildClass(ColSize size, ResponsiveBreakpoint breakpoint)
        {
            string bp = breakpoint.GetCss();

            if (size == ColSize.Col)
            {
                return string.IsNullOrWhiteSpace(bp) ? "col" : $"col-{bp}";
            }

            if (size == ColSize.Auto)
            {
                return string.IsNullOrWhiteSpace(bp) ? "col-auto" : $"col-{bp}-auto";
            }

            int n = (int)size;

            return string.IsNullOrWhiteSpace(bp)
                ? $"col-{n}"
                : $"col-{bp}-{n}";
        }

        #endregion

        #region Instance fields and properties

        private readonly Dictionary<ResponsiveBreakpoint, ColSize> _rules = new();

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="ColSizeComposer" /> value or BootstrapBuilder result.</returns>
        public ColSizeComposer Set(ColSize size, ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs)
        {
            _rules[breakpoint] = size;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        ///     Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            return _rules
                .Where(x => x.Value != ColSize.None)
                .OrderBy(x => x.Key)
                .Select(x => BuildClass(x.Value, x.Key))
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
            var clone = new ColSizeComposer();
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