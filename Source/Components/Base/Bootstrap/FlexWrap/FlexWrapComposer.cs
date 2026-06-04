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
    ///     Composes Bootstrap CSS classes or page chrome for flex wrap.
    /// </summary>
    public sealed class FlexWrapComposer : IIsCssClassComposer
    {
        #region Static methods

        private static string BuildClass(FlexWrap flexWrap, ResponsiveBreakpoint breakpoint)
        {
            string valueCss = flexWrap.GetCss();
            string breakpointCss = breakpoint.GetCss();

            return string.IsNullOrWhiteSpace(breakpointCss)
                ? $"flex-{valueCss}"
                : $"flex-{breakpointCss}-{valueCss}";
        }

        #endregion

        #region Instance fields and properties

        private readonly Dictionary<ResponsiveBreakpoint, FlexWrap> _rules = new();

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="flexWrap">The flex wrap value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="FlexWrapComposer" /> value or BootstrapBuilder result.</returns>
        public FlexWrapComposer Set(
            FlexWrap flexWrap,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
        {
            _rules[breakpoint] = flexWrap;
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
            var clone = new FlexWrapComposer();
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