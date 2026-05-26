#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj TitleEffectsComposer.cs create at 2026/04/30
// ©2024-2026 idéMobi SARL FRANCE

#endregion

using System.Globalization;
using System.Text;
using System.Text.Encodings.Web;
using DMBPageBuilder;

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Composes Bootstrap CSS classes or page chrome for title effects.
    /// </summary>
    public sealed class TitleEffectsComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private bool _twisted;
        private decimal _twistAngle = -3m;
        private bool _gradient;
        private string _gradientStart = "#ff6ecf";
        private string _gradientEnd = "#efff5c";
        private decimal _gradientAngle = 90m;
        private bool _typewriter;
        private decimal _typewriterDuration = 2m;
        private string _typewriterGuid = string.Empty;
        private bool _letterCollapse;
        private decimal _letterCollapseDuration = 1m;
        private bool _wave;
        private decimal _waveDuration = 1m;
        private bool _scramble;
        private decimal _scrambleDuration = 2m;
        private bool _neonGlow;
        private string _neonColor = "#ff6ecf";
        private decimal _neonSpeed = 2m;
        private bool _glitchText;
        private string _glitchColor1 = "#ff005c";
        private string _glitchColor2 = "#00f5d4";
        private decimal _glitchSpeed = 3m;
        private bool _shake;
        private decimal _shakeSpeed = 4m;
        private bool _splitColor;
        private string _splitTop = "var(--bs-body-color, #212529)";
        private string _splitBottom = "#ff6ecf";
        private bool _stamp;
        private decimal _stampDuration = 0.6m;
        private bool _blurReveal;
        private decimal _blurStart = 12m;
        private decimal _blurDuration = 1.5m;
        private bool _slideUp;
        private decimal _slideDuration = 0.6m;
        private bool _colorCycle;
        private decimal _colorCycleSpeed = 4m;
        private string _colorCycleBase = "#ff6ecf";
        private bool _outline;
        private string _outlineColor = "var(--bs-primary, #0d6efd)";
        private decimal _outlineWidth = 1m;
        private decimal _outlineSpeed = 2m;

        /// <summary>
        /// Gets or sets the needs script value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool NeedsScript => _typewriter || _scramble;

        #endregion

        #region Instance methods

        /// <summary>
        /// Configures twisted on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="angle">The angle value.</param>
        /// <returns>The configured <see cref="TitleEffectsComposer"/> value or BootstrapBuilder result.</returns>
        public TitleEffectsComposer SetTwisted(decimal angle = -3m)
        {
            _twisted = true;
            _twistAngle = angle;
            return this;
        }

        /// <summary>
        /// Configures gradient on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="colorStart">The color start value.</param>
        /// <param name="colorEnd">The color end value.</param>
        /// <param name="angle">The angle value.</param>
        /// <returns>The configured <see cref="TitleEffectsComposer"/> value or BootstrapBuilder result.</returns>
        public TitleEffectsComposer SetGradient(string colorStart = "#ff6ecf", string colorEnd = "#efff5c", decimal angle = 90m)
        {
            _gradient = true;
            _gradientStart = colorStart;
            _gradientEnd = colorEnd;
            _gradientAngle = angle;
            return this;
        }

        /// <summary>
        /// Configures typewriter on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="durationSeconds">The duration seconds value.</param>
        /// <returns>The configured <see cref="TitleEffectsComposer"/> value or BootstrapBuilder result.</returns>
        public TitleEffectsComposer SetTypewriter(decimal durationSeconds = 2m)
        {
            _typewriter = true;
            _typewriterDuration = durationSeconds;
            _typewriterGuid = Guid.NewGuid().ToString("N");
            return this;
        }

        /// <summary>
        /// Configures letter collapse on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="durationSeconds">The duration seconds value.</param>
        /// <returns>The configured <see cref="TitleEffectsComposer"/> value or BootstrapBuilder result.</returns>
        public TitleEffectsComposer SetLetterCollapse(decimal durationSeconds = 1m)
        {
            _letterCollapse = true;
            _letterCollapseDuration = durationSeconds;
            return this;
        }

        /// <summary>
        /// Configures wave on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="durationSeconds">The duration seconds value.</param>
        /// <returns>The configured <see cref="TitleEffectsComposer"/> value or BootstrapBuilder result.</returns>
        public TitleEffectsComposer SetWave(decimal durationSeconds = 1m)
        {
            _wave = true;
            _waveDuration = durationSeconds;
            return this;
        }

        /// <summary>
        /// Configures scramble on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="durationSeconds">The duration seconds value.</param>
        /// <returns>The configured <see cref="TitleEffectsComposer"/> value or BootstrapBuilder result.</returns>
        public TitleEffectsComposer SetScramble(decimal durationSeconds = 2m)
        {
            _scramble = true;
            _scrambleDuration = durationSeconds;
            return this;
        }

        /// <summary>
        /// Configures neon glow on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="color">The color value.</param>
        /// <param name="speedSeconds">The speed seconds value.</param>
        /// <returns>The configured <see cref="TitleEffectsComposer"/> value or BootstrapBuilder result.</returns>
        public TitleEffectsComposer SetNeonGlow(string color = "#ff6ecf", decimal speedSeconds = 2m)
        {
            _neonGlow = true;
            _neonColor = color;
            _neonSpeed = speedSeconds;
            return this;
        }

        /// <summary>
        /// Configures glitch text on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="color1">The color1 value.</param>
        /// <param name="color2">The color2 value.</param>
        /// <param name="speedSeconds">The speed seconds value.</param>
        /// <returns>The configured <see cref="TitleEffectsComposer"/> value or BootstrapBuilder result.</returns>
        public TitleEffectsComposer SetGlitchText(string color1 = "#ff005c", string color2 = "#00f5d4", decimal speedSeconds = 3m)
        {
            _glitchText = true;
            _glitchColor1 = color1;
            _glitchColor2 = color2;
            _glitchSpeed = speedSeconds;
            return this;
        }

        /// <summary>
        /// Configures shake on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="speedSeconds">The speed seconds value.</param>
        /// <returns>The configured <see cref="TitleEffectsComposer"/> value or BootstrapBuilder result.</returns>
        public TitleEffectsComposer SetShake(decimal speedSeconds = 4m)
        {
            _shake = true;
            _shakeSpeed = speedSeconds;
            return this;
        }

        /// <summary>
        /// Configures split color on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="topColor">The top color value.</param>
        /// <param name="bottomColor">The bottom color value.</param>
        /// <returns>The configured <see cref="TitleEffectsComposer"/> value or BootstrapBuilder result.</returns>
        public TitleEffectsComposer SetSplitColor(string topColor = "#ffffff", string bottomColor = "#ff6ecf")
        {
            _splitColor = true;
            _splitTop = topColor;
            _splitBottom = bottomColor;
            return this;
        }

        /// <summary>
        /// Configures stamp on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="durationSeconds">The duration seconds value.</param>
        /// <returns>The configured <see cref="TitleEffectsComposer"/> value or BootstrapBuilder result.</returns>
        public TitleEffectsComposer SetStamp(decimal durationSeconds = 0.6m)
        {
            _stamp = true;
            _stampDuration = durationSeconds;
            return this;
        }

        /// <summary>
        /// Configures blur reveal on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="startBlurPx">The start blur px value.</param>
        /// <param name="durationSeconds">The duration seconds value.</param>
        /// <returns>The configured <see cref="TitleEffectsComposer"/> value or BootstrapBuilder result.</returns>
        public TitleEffectsComposer SetBlurReveal(decimal startBlurPx = 12m, decimal durationSeconds = 1.5m)
        {
            _blurReveal = true;
            _blurStart = startBlurPx;
            _blurDuration = durationSeconds;
            return this;
        }

        /// <summary>
        /// Configures slide up on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="durationSeconds">The duration seconds value.</param>
        /// <returns>The configured <see cref="TitleEffectsComposer"/> value or BootstrapBuilder result.</returns>
        public TitleEffectsComposer SetSlideUp(decimal durationSeconds = 0.6m)
        {
            _slideUp = true;
            _slideDuration = durationSeconds;
            return this;
        }

        /// <summary>
        /// Configures color cycle on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="baseColor">The base color value.</param>
        /// <param name="speedSeconds">The speed seconds value.</param>
        /// <returns>The configured <see cref="TitleEffectsComposer"/> value or BootstrapBuilder result.</returns>
        public TitleEffectsComposer SetColorCycle(string baseColor = "#ff6ecf", decimal speedSeconds = 4m)
        {
            _colorCycle = true;
            _colorCycleBase = baseColor;
            _colorCycleSpeed = speedSeconds;
            return this;
        }

        /// <summary>
        /// Configures outline on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="color">The color value.</param>
        /// <param name="widthPx">The width px value.</param>
        /// <param name="speedSeconds">The speed seconds value.</param>
        /// <returns>The configured <see cref="TitleEffectsComposer"/> value or BootstrapBuilder result.</returns>
        public TitleEffectsComposer SetOutline(string color = "#ffffff", decimal widthPx = 1m, decimal speedSeconds = 2m)
        {
            _outline = true;
            _outlineColor = color;
            _outlineWidth = widthPx;
            _outlineSpeed = speedSeconds;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder validate effects operation.
        /// </summary>
        public void ValidateEffects()
        {
            if (_typewriter && _letterCollapse)
                throw new InvalidOperationException("SetTypewriterEffect and SetLetterCollapseEffect cannot be used together.");
            if (_wave && _typewriter)
                throw new InvalidOperationException("SetWaveEffect and SetTypewriterEffect cannot be used together.");
            if (_wave && _letterCollapse)
                throw new InvalidOperationException("SetWaveEffect and SetLetterCollapseEffect cannot be used together.");
            if (_scramble && _typewriter)
                throw new InvalidOperationException("SetScrambleEffect and SetTypewriterEffect cannot be used together.");
            if (_neonGlow && _gradient)
                throw new InvalidOperationException("SetNeonGlowEffect and SetGradientEffect cannot be used together.");
            if (_outline && _gradient)
                throw new InvalidOperationException("SetOutlineEffect and SetGradientEffect cannot be used together.");
            if (_slideUp && _wave)
                throw new InvalidOperationException("SetSlideUpEffect and SetWaveEffect cannot be used together.");
            if (_blurReveal && _colorCycle)
                throw new InvalidOperationException("SetBlurRevealEffect and SetColorCycleEffect cannot be used together.");
        }

        /// <summary>
        /// Builds style value for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public string BuildStyleValue()
        {
            var ci = CultureInfo.InvariantCulture;
            var sb = new StringBuilder();

            if (_twisted)
                sb.Append($"transform:rotate({_twistAngle.ToString(ci)}deg);");

            if (_gradient)
            {
                sb.Append($"background:linear-gradient({_gradientAngle.ToString(ci)}deg,{_gradientStart},{_gradientEnd});");
                sb.Append("-webkit-background-clip:text;");
                sb.Append("-webkit-text-fill-color:transparent;");
                sb.Append("background-clip:text;");
            }

            if (_typewriter)
                sb.Append("overflow:hidden;white-space:nowrap;border-right:3px solid;width:0;");

            if (_letterCollapse)
                sb.Append($"animation:bb-letter-collapse {_letterCollapseDuration.ToString(ci)}s ease-out forwards;");

            if (_neonGlow)
            {
                sb.Append($"--bb-neon-color:{_neonColor};");
                sb.Append($"--bb-neon-speed:{_neonSpeed.ToString(ci)}s;");
            }

            if (_blurReveal)
            {
                sb.Append($"--bb-blur-start:{_blurStart.ToString(ci)}px;");
                sb.Append($"--bb-blur-duration:{_blurDuration.ToString(ci)}s;");
            }

            if (_colorCycle)
            {
                sb.Append($"--bb-color-cycle-base:{_colorCycleBase};");
                sb.Append($"--bb-color-cycle-speed:{_colorCycleSpeed.ToString(ci)}s;");
            }

            if (_outline)
            {
                sb.Append($"--bb-outline-color:{_outlineColor};");
                sb.Append($"--bb-outline-width:{_outlineWidth.ToString(ci)}px;");
                sb.Append($"--bb-outline-speed:{_outlineSpeed.ToString(ci)}s;");
            }

            if (_shake)
                sb.Append($"--bb-shake-speed:{_shakeSpeed.ToString(ci)}s;");

            if (_splitColor)
            {
                sb.Append($"--bb-split-top:{_splitTop};");
                sb.Append($"--bb-split-bottom:{_splitBottom};");
            }

            if (_stamp)
                sb.Append($"--bb-stamp-duration:{_stampDuration.ToString(ci)}s;");

            if (_glitchText)
            {
                sb.Append($"--bb-glitch-color1:{_glitchColor1};");
                sb.Append($"--bb-glitch-color2:{_glitchColor2};");
                sb.Append($"--bb-glitch-speed:{_glitchSpeed.ToString(ci)}s;");
            }

            sb.Append("display:inline-block;");

            return sb.ToString();
        }

        /// <summary>
        /// Builds extra attributes for BootstrapBuilder rendering.
        /// </summary>
        /// <param name="encodedTitle">The encoded title value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public string BuildExtraAttributes(string encodedTitle)
        {
            var ci = CultureInfo.InvariantCulture;
            var sb = new StringBuilder();

            if (_typewriter)
                sb.Append($" data-typewriter-chars=\"{encodedTitle.Length}\" data-typewriter-duration=\"{_typewriterDuration.ToString(ci)}\"");

            if (_scramble)
                sb.Append($" data-scramble-text=\"{encodedTitle}\" data-scramble-duration=\"{_scrambleDuration.ToString(ci)}\"");

            if (_glitchText)
                sb.Append($" data-text=\"{encodedTitle}\"");

            if (_splitColor && !_glitchText)
                sb.Append($" data-text=\"{encodedTitle}\"");

            return sb.ToString();
        }

        /// <summary>
        /// Builds title content for BootstrapBuilder rendering.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public string BuildTitleContent(string title)
        {
            var ci = CultureInfo.InvariantCulture;

            if (_wave)
            {
                var letters = new StringBuilder();
                decimal delay = 0m;
                foreach (char c in title)
                {
                    string encoded = c == ' ' ? "&nbsp;" : HtmlEncoder.Default.Encode(c.ToString());
                    letters.Append($"<span class=\"bb-wave-letter\" style=\"--wave-duration:{_waveDuration.ToString(ci)}s;animation-delay:{delay.ToString(ci)}s;\">{encoded}</span>");
                    delay += 0.08m;
                }
                return letters.ToString();
            }

            if (_slideUp)
            {
                var letters = new StringBuilder();
                decimal delay = 0m;
                foreach (char c in title)
                {
                    string encoded = c == ' ' ? "&nbsp;" : HtmlEncoder.Default.Encode(c.ToString());
                    letters.Append($"<span class=\"bb-slide-letter\" style=\"--bb-slide-duration:{_slideDuration.ToString(ci)}s;animation-delay:{delay.ToString(ci)}s;\">{encoded}</span>");
                    delay += 0.05m;
                }
                return letters.ToString();
            }

            return HtmlEncoder.Default.Encode(title);
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        /// Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            var result = new List<string>();

            if (_typewriter)
            {
                result.Add("bb-typewriter");
                result.Add($"bb-tw-{_typewriterGuid}");
            }

            if (_scramble)
                result.Add("bb-scramble");

            if (_neonGlow)
                result.Add("bb-title-neon");

            if (_glitchText)
                result.Add("bb-title-glitch");

            if (_blurReveal)
                result.Add("bb-title-blur-reveal");

            if (_colorCycle)
                result.Add("bb-title-color-cycle");

            if (_outline)
                result.Add("bb-title-outline");

            if (_shake)
                result.Add("bb-title-shake");

            if (_splitColor)
                result.Add("bb-title-split-color");

            if (_stamp)
                result.Add("bb-title-stamp");

            return result;
        }

        /// <summary>
        /// Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IIsCssClassComposer"/> value or BootstrapBuilder result.</returns>
        public IIsCssClassComposer Clone()
        {
            var clone = new TitleEffectsComposer();
            if (_twisted) clone.SetTwisted(_twistAngle);
            if (_gradient) clone.SetGradient(_gradientStart, _gradientEnd, _gradientAngle);
            if (_typewriter) clone.SetTypewriter(_typewriterDuration);
            if (_letterCollapse) clone.SetLetterCollapse(_letterCollapseDuration);
            if (_wave) clone.SetWave(_waveDuration);
            if (_scramble) clone.SetScramble(_scrambleDuration);
            if (_neonGlow) clone.SetNeonGlow(_neonColor, _neonSpeed);
            if (_glitchText) clone.SetGlitchText(_glitchColor1, _glitchColor2, _glitchSpeed);
            if (_shake) clone.SetShake(_shakeSpeed);
            if (_splitColor) clone.SetSplitColor(_splitTop, _splitBottom);
            if (_stamp) clone.SetStamp(_stampDuration);
            if (_blurReveal) clone.SetBlurReveal(_blurStart, _blurDuration);
            if (_slideUp) clone.SetSlideUp(_slideDuration);
            if (_colorCycle) clone.SetColorCycle(_colorCycleBase, _colorCycleSpeed);
            if (_outline) clone.SetOutline(_outlineColor, _outlineWidth, _outlineSpeed);
            return clone;
        }

        #endregion

        #endregion
    }
}
