#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj BorderComposer.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Composes Bootstrap CSS classes or page chrome for border.
    /// </summary>
    public sealed class BorderComposer : IIsCssClassComposer
    {
        #region Static methods

        private static string ApplyBreakpoint(string css, ResponsiveBreakpoint breakpoint)
        {
            if (breakpoint == ResponsiveBreakpoint.Xs)
            {
                return css;
            }

            return InsertResponsiveBreakpoint(css, breakpoint);
        }

        private static string BuildColorClass(BorderColorRule rule)
        {
            if (rule.Color == global::DMBBootstrapBuilder.BorderColor.None)
            {
                return string.Empty;
            }

            return ApplyBreakpoint($"border-{GetColorCss(rule.Color)}", rule.Breakpoint);
        }

        private static string BuildOpacityClass(BorderOpacityRule rule)
        {
            if (rule.Opacity == global::DMBBootstrapBuilder.BorderOpacity.None)
            {
                return string.Empty;
            }

            return ApplyBreakpoint($"border-opacity-{GetOpacityCss(rule.Opacity)}", rule.Breakpoint);
        }

        private static string BuildPresenceClass(BorderPresenceRule rule)
        {
            string prefix = rule.Presence == BorderPresence.Visible ? "border" : "border-0";

            if (rule.Side != BorderSide.All)
            {
                prefix = rule.Presence == BorderPresence.Visible
                    ? $"border-{GetSideCss(rule.Side)}"
                    : $"border-{GetSideCss(rule.Side)}-0";
            }

            return ApplyBreakpoint(prefix, rule.Breakpoint);
        }

        private static string BuildRadiusClass(BorderRadiusRule rule)
        {
            string css = rule.Size switch
            {
                BorderRadiusSize.None => "rounded-0",
                BorderRadiusSize.Small => "rounded-1",
                BorderRadiusSize.Normal => "rounded",
                BorderRadiusSize.Large => "rounded-3",
                BorderRadiusSize.ExtraLarge => "rounded-4",
                BorderRadiusSize.ExtraExtraLarge => "rounded-5",
                BorderRadiusSize.Circle => "rounded-circle",
                BorderRadiusSize.Pill => "rounded-pill",
                _ => "rounded"
            };

            if (rule.Side != BorderRadiusSide.All &&
                rule.Size != BorderRadiusSize.Circle &&
                rule.Size != BorderRadiusSize.Pill)
            {
                css = rule.Size switch
                {
                    BorderRadiusSize.None => $"rounded-{GetRadiusSideCss(rule.Side)}-0",
                    BorderRadiusSize.Small => $"rounded-{GetRadiusSideCss(rule.Side)}-1",
                    BorderRadiusSize.Normal => $"rounded-{GetRadiusSideCss(rule.Side)}",
                    BorderRadiusSize.Large => $"rounded-{GetRadiusSideCss(rule.Side)}-3",
                    BorderRadiusSize.ExtraLarge => $"rounded-{GetRadiusSideCss(rule.Side)}-4",
                    BorderRadiusSize.ExtraExtraLarge => $"rounded-{GetRadiusSideCss(rule.Side)}-5",
                    _ => $"rounded-{GetRadiusSideCss(rule.Side)}"
                };
            }

            return ApplyBreakpoint(css, rule.Breakpoint);
        }

        private static string GetColorCss(BorderColor color) => color switch
        {
            global::DMBBootstrapBuilder.BorderColor.Primary => "primary",
            global::DMBBootstrapBuilder.BorderColor.Secondary => "secondary",
            global::DMBBootstrapBuilder.BorderColor.Success => "success",
            global::DMBBootstrapBuilder.BorderColor.Danger => "danger",
            global::DMBBootstrapBuilder.BorderColor.Warning => "warning",
            global::DMBBootstrapBuilder.BorderColor.Info => "info",
            global::DMBBootstrapBuilder.BorderColor.Light => "light",
            global::DMBBootstrapBuilder.BorderColor.Dark => "dark",
            global::DMBBootstrapBuilder.BorderColor.White => "white",
            global::DMBBootstrapBuilder.BorderColor.Black => "black",
            global::DMBBootstrapBuilder.BorderColor.Body => "body",
            global::DMBBootstrapBuilder.BorderColor.Transparent => "transparent",
            _ => ""
        };

        private static string GetOpacityCss(BorderOpacity opacity) => opacity switch
        {
            global::DMBBootstrapBuilder.BorderOpacity.Opacity10 => "10",
            global::DMBBootstrapBuilder.BorderOpacity.Opacity25 => "25",
            global::DMBBootstrapBuilder.BorderOpacity.Opacity50 => "50",
            global::DMBBootstrapBuilder.BorderOpacity.Opacity75 => "75",
            global::DMBBootstrapBuilder.BorderOpacity.Opacity100 => "100",
            _ => ""
        };

        private static string GetRadiusSideCss(BorderRadiusSide side) => side switch
        {
            BorderRadiusSide.Top => "top",
            BorderRadiusSide.Bottom => "bottom",
            BorderRadiusSide.Start => "start",
            BorderRadiusSide.End => "end",
            _ => ""
        };

        private static string GetSideCss(BorderSide side) => side switch
        {
            BorderSide.Top => "top",
            BorderSide.Bottom => "bottom",
            BorderSide.Start => "start",
            BorderSide.End => "end",
            _ => ""
        };

        private static string InsertResponsiveBreakpoint(string css, ResponsiveBreakpoint breakpoint)
        {
            string bp = breakpoint.ToString().ToLowerInvariant();

            int firstDash = css.IndexOf('-');
            if (firstDash < 0)
            {
                return $"{css}-{bp}";
            }

            return css.Insert(firstDash, $"-{bp}");
        }

        #endregion

        #region Instance fields and properties

        private readonly Dictionary<ResponsiveBreakpoint, BorderColorRule> _colorRules = new();
        private readonly Dictionary<ResponsiveBreakpoint, BorderOpacityRule> _opacityRules = new();
        private readonly Dictionary<(BorderSide, ResponsiveBreakpoint), BorderPresenceRule> _presenceRules = new();
        private readonly Dictionary<(BorderRadiusSide, ResponsiveBreakpoint), BorderRadiusRule> _radiusRules = new();

        #endregion

        #region Instance methods

        /// <summary>
        /// Executes the BootstrapBuilder border operation.
        /// </summary>
        /// <param name="side">The side value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="BorderComposer"/> value or BootstrapBuilder result.</returns>
        public BorderComposer Border(BorderSide side = BorderSide.All, ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs)
        {
            _presenceRules[(side, breakpoint)] = new BorderPresenceRule(side, BorderPresence.Visible, breakpoint);
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder border color operation.
        /// </summary>
        /// <param name="color">The color value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="BorderComposer"/> value or BootstrapBuilder result.</returns>
        public BorderComposer BorderColor(BorderColor color, ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs)
        {
            _colorRules[breakpoint] = new BorderColorRule(color, breakpoint);
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder border opacity operation.
        /// </summary>
        /// <param name="opacity">The opacity value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="BorderComposer"/> value or BootstrapBuilder result.</returns>
        public BorderComposer BorderOpacity(BorderOpacity opacity, ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs)
        {
            _opacityRules[breakpoint] = new BorderOpacityRule(opacity, breakpoint);
            return this;
        }

        /// <summary>
        /// Builds class string for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public string BuildClassString()
        {
            return string.Join(" ", BuildClasses());
        }

        /// <summary>
        /// Executes the BootstrapBuilder no border operation.
        /// </summary>
        /// <param name="side">The side value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="BorderComposer"/> value or BootstrapBuilder result.</returns>
        public BorderComposer NoBorder(BorderSide side = BorderSide.All, ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs)
        {
            _presenceRules[(side, breakpoint)] = new BorderPresenceRule(side, BorderPresence.None, breakpoint);
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder rounded operation.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <param name="side">The side value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="BorderComposer"/> value or BootstrapBuilder result.</returns>
        public BorderComposer Rounded(BorderRadiusSize size = BorderRadiusSize.Normal, BorderRadiusSide side = BorderRadiusSide.All, ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs)
        {
            _radiusRules[(side, breakpoint)] = new BorderRadiusRule(side, size, breakpoint);
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        /// Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            var result = new List<string>();

            result.AddRange(_presenceRules.Values.Select(BuildPresenceClass));
            result.AddRange(_colorRules.Values.Select(BuildColorClass));
            result.AddRange(_opacityRules.Values.Select(BuildOpacityClass));
            result.AddRange(_radiusRules.Values.Select(BuildRadiusClass));

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
            var clone = new BorderComposer();

            foreach (var rule in _colorRules)
            {
                clone.BorderColor(rule.Value.Color, rule.Value.Breakpoint);
            }

            foreach (var rule in _opacityRules)
            {
                clone.BorderOpacity(rule.Value.Opacity, rule.Value.Breakpoint);
            }

            foreach (var rule in _presenceRules)
            {
                if (rule.Value.Presence == BorderPresence.Visible)
                {
                    clone.Border(rule.Value.Side, rule.Value.Breakpoint);
                }
                else
                {
                    clone.NoBorder(rule.Value.Side, rule.Value.Breakpoint);
                }
            }

            foreach (var rule in _radiusRules)
            {
                clone.Rounded(rule.Value.Size, rule.Value.Side, rule.Value.Breakpoint);
            }

            return clone;
        }

        #endregion

        #endregion
    }
}