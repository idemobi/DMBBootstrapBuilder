#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj FlexGrowComposer.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Composes Bootstrap CSS classes or page chrome for flex grow.
    /// </summary>
    public sealed class FlexGrowComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private FlexGrow _value = FlexGrow.None;

        #endregion

        #region Instance methods

        /// <summary>
        /// Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="FlexGrowComposer"/> value or BootstrapBuilder result.</returns>
        public FlexGrowComposer Set(FlexGrow value)
        {
            _value = value;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        /// Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            string css = _value.GetCss();
            return string.IsNullOrWhiteSpace(css)
                ? Array.Empty<string>()
                : new[] { css };
        }

        /// <summary>
        /// Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IIsCssClassComposer"/> value or BootstrapBuilder result.</returns>
        public IIsCssClassComposer Clone()
        {
            var clone = new FlexGrowComposer();
            clone.Set(_value);
            return clone;
        }

        #endregion

        #endregion
    }
}