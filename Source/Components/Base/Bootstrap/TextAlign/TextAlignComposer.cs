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
    ///     Composes Bootstrap CSS classes or page chrome for text align.
    /// </summary>
    public sealed class TextAlignComposer : IIsCssClassComposer
    {
        #region Static methods

        private static string BuildClass(TextAlign textAlign, ResponsiveBreakpoint breakpoint)
        {
            string alignCss = textAlign.GetCss();
            string breakpointCss = breakpoint.GetCss();

            if (string.IsNullOrWhiteSpace(breakpointCss))
            {
                return $"text-{alignCss}";
            }

            return $"text-{breakpointCss}-{alignCss}";
        }

        #endregion

        #region Instance fields and properties

        private readonly Dictionary<ResponsiveBreakpoint, TextAlign> _rules = new();

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="textAlign">The text align value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="TextAlignComposer" /> value or BootstrapBuilder result.</returns>
        public TextAlignComposer Set(TextAlign textAlign, ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs)
        {
            _rules[breakpoint] = textAlign;
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
            var clone = new TextAlignComposer();
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