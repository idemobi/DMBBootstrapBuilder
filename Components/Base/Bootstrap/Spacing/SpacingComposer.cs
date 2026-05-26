#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj SpacingComposer.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Composes Bootstrap CSS classes or page chrome for spacing.
    /// </summary>
    public sealed class SpacingComposer : IIsCssClassComposer
    {
        #region Static methods

        private static string BuildClass(SpacingRule rule)
        {
            string property = rule.Property == SpacingProperty.Margin ? "m" : "p";
            string side = rule.Side switch
            {
                SpacingSide.All => "",
                SpacingSide.Top => "t",
                SpacingSide.Bottom => "b",
                SpacingSide.Start => "s",
                SpacingSide.End => "e",
                SpacingSide.X => "x",
                SpacingSide.Y => "y",
                _ => throw new ArgumentOutOfRangeException()
            };

            string breakpoint = rule.Breakpoint switch
            {
                ResponsiveBreakpoint.Xs => "",
                ResponsiveBreakpoint.Sm => "sm",
                ResponsiveBreakpoint.Md => "md",
                ResponsiveBreakpoint.Lg => "lg",
                ResponsiveBreakpoint.Xl => "xl",
                ResponsiveBreakpoint.Xxl => "xxl",
                _ => throw new ArgumentOutOfRangeException()
            };

            string size = rule.Size switch
            {
                SpacingSize.Zero => "0",
                SpacingSize.One => "1",
                SpacingSize.Two => "2",
                SpacingSize.Three => "3",
                SpacingSize.Four => "4",
                SpacingSize.Five => "5",
                SpacingSize.Auto => "auto",
                _ => throw new ArgumentOutOfRangeException()
            };

            string negative = rule.Negative ? "n" : "";

            return string.IsNullOrWhiteSpace(breakpoint)
                ? $"{property}{side}-{negative}{size}"
                : $"{property}{side}-{breakpoint}-{negative}{size}";
        }

        private static void Validate(SpacingProperty property, SpacingSize size, bool negative)
        {
            if (property == SpacingProperty.Padding && size == SpacingSize.Auto)
            {
                throw new InvalidOperationException("Padding cannot use auto.");
            }

            if (property == SpacingProperty.Padding && negative)
            {
                throw new InvalidOperationException("Padding cannot be negative.");
            }

            if (negative && size == SpacingSize.Auto)
            {
                throw new InvalidOperationException("Negative margin cannot use auto.");
            }
        }

        #endregion

        #region Instance fields and properties

        private readonly Dictionary<(SpacingProperty Property, SpacingSide Side, ResponsiveBreakpoint Breakpoint), SpacingRule> _rules = new();

        #endregion

        #region Instance methods

        /// <summary>
        /// Builds class string for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public string BuildClassString()
        {
            return string.Join(" ", BuildClasses());
        }

        /// <summary>
        /// Executes the BootstrapBuilder margin operation.
        /// </summary>
        /// <param name="side">The side value.</param>
        /// <param name="size">The size value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <param name="negative">The negative value.</param>
        /// <returns>The configured <see cref="SpacingComposer"/> value or BootstrapBuilder result.</returns>
        public SpacingComposer Margin(SpacingSide side, SpacingSize size, ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs, bool negative = false)
        {
            Validate(SpacingProperty.Margin, size, negative);
            SetRule(new SpacingRule(SpacingProperty.Margin, side, breakpoint, size, negative));
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder padding operation.
        /// </summary>
        /// <param name="side">The side value.</param>
        /// <param name="size">The size value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="SpacingComposer"/> value or BootstrapBuilder result.</returns>
        public SpacingComposer Padding(SpacingSide side, SpacingSize size, ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs)
        {
            Validate(SpacingProperty.Padding, size, negative: false);
            SetRule(new SpacingRule(SpacingProperty.Padding, side, breakpoint, size, false));
            return this;
        }

        /// <summary>
        /// Removes value from the current BootstrapBuilder component or composer.
        /// </summary>
        /// <param name="property">The property value.</param>
        /// <param name="side">The side value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="SpacingComposer"/> value or BootstrapBuilder result.</returns>
        public SpacingComposer Remove(SpacingProperty property, SpacingSide side, ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs)
        {
            _rules.Remove((property, side, breakpoint));
            return this;
        }

        private void SetRule(SpacingRule rule)
        {
            _rules[(rule.Property, rule.Side, rule.Breakpoint)] = rule;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        /// Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            return _rules.Values
                .Select(BuildClass)
                .Distinct(StringComparer.Ordinal)
                .ToList();
        }

        /// <summary>
        /// Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IIsCssClassComposer"/> value or BootstrapBuilder result.</returns>
        public IIsCssClassComposer Clone()
        {
            var clone = new SpacingComposer();
            foreach (var rule in _rules.Values)
            {
                if (rule.Property == SpacingProperty.Margin)
                {
                    clone.Margin(rule.Side, rule.Size, rule.Breakpoint, rule.Negative);
                }
                else
                {
                    clone.Padding(rule.Side, rule.Size, rule.Breakpoint);
                }
            }

            return clone;
        }

        #endregion

        #endregion
    }
}