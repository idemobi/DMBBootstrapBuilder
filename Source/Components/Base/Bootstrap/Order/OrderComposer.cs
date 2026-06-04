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
    ///     Composes Bootstrap CSS classes or page chrome for order.
    /// </summary>
    public sealed class OrderComposer : IIsCssClassComposer
    {
        #region Static methods

        private static string BuildClass(Order order, ResponsiveBreakpoint breakpoint)
        {
            string valueCss = order.GetCss();
            string bpCss = breakpoint.GetCss();

            if (string.IsNullOrWhiteSpace(valueCss))
            {
                return string.Empty;
            }

            return string.IsNullOrWhiteSpace(bpCss)
                ? $"order-{valueCss}"
                : $"order-{bpCss}-{valueCss}";
        }

        #endregion

        #region Instance fields and properties

        private readonly Dictionary<ResponsiveBreakpoint, Order> _rules = new();

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="order">The order value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="OrderComposer" /> value or BootstrapBuilder result.</returns>
        public OrderComposer Set(
            Order order,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
        {
            _rules[breakpoint] = order;
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
            var clone = new OrderComposer();
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