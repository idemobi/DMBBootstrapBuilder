#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj PositionComposer.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Composes Bootstrap CSS classes or page chrome for position.
    /// </summary>
    public sealed class PositionComposer : IIsCssClassComposer
    {
        #region Static methods

        private static void AddValueClass(List<string> classes, string prefix, PositionValue value)
        {
            string css = value.GetCss();
            if (!string.IsNullOrWhiteSpace(css))
            {
                classes.Add($"{prefix}-{css}");
            }
        }

        #endregion

        #region Instance fields and properties

        private PositionValue _bottom = PositionValue.None;
        private PositionValue _end = PositionValue.None;
        private Position _position = Position.Normal;
        private PositionValue _start = PositionValue.None;
        private PositionValue _top = PositionValue.None;
        private TranslateMode _translate = TranslateMode.None;

        #endregion

        #region Instance methods

        /// <summary>
        /// Configures bottom on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="PositionComposer"/> value or BootstrapBuilder result.</returns>
        public PositionComposer SetBottom(PositionValue value)
        {
            _bottom = value;
            return this;
        }

        /// <summary>
        /// Configures end on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="PositionComposer"/> value or BootstrapBuilder result.</returns>
        public PositionComposer SetEnd(PositionValue value)
        {
            _end = value;
            return this;
        }

        /// <summary>
        /// Configures position on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="position">The position value.</param>
        /// <returns>The configured <see cref="PositionComposer"/> value or BootstrapBuilder result.</returns>
        public PositionComposer SetPosition(Position position)
        {
            _position = position;
            return this;
        }

        /// <summary>
        /// Configures start on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="PositionComposer"/> value or BootstrapBuilder result.</returns>
        public PositionComposer SetStart(PositionValue value)
        {
            _start = value;
            return this;
        }

        /// <summary>
        /// Configures top on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="PositionComposer"/> value or BootstrapBuilder result.</returns>
        public PositionComposer SetTop(PositionValue value)
        {
            _top = value;
            return this;
        }

        /// <summary>
        /// Configures translate on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="mode">The mode value.</param>
        /// <returns>The configured <see cref="PositionComposer"/> value or BootstrapBuilder result.</returns>
        public PositionComposer SetTranslate(TranslateMode mode)
        {
            _translate = mode;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        /// Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            List<string> classes = new();

            string positionCss = _position.GetCss();
            if (!string.IsNullOrWhiteSpace(positionCss))
            {
                classes.Add(positionCss);
            }

            AddValueClass(classes, "top", _top);
            AddValueClass(classes, "bottom", _bottom);
            AddValueClass(classes, "start", _start);
            AddValueClass(classes, "end", _end);

            string translateCss = _translate.GetCss();
            if (!string.IsNullOrWhiteSpace(translateCss))
            {
                classes.Add(translateCss);
            }

            return classes;
        }

        /// <summary>
        /// Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IIsCssClassComposer"/> value or BootstrapBuilder result.</returns>
        public IIsCssClassComposer Clone()
        {
            var clone = new PositionComposer();
            clone.SetPosition(_position);
            clone.SetTop(_top);
            clone.SetBottom(_bottom);
            clone.SetStart(_start);
            clone.SetEnd(_end);
            clone.SetTranslate(_translate);
            return clone;
        }

        #endregion

        #endregion
    }
}