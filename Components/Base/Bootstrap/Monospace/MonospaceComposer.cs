#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Composes Bootstrap CSS classes or page chrome for monospace.
    /// </summary>
    public sealed class MonospaceComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private Monospace _monospace = Monospace.None;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="monospace">The monospace value.</param>
        /// <returns>The configured <see cref="MonospaceComposer" /> value or BootstrapBuilder result.</returns>
        public MonospaceComposer Set(Monospace monospace)
        {
            _monospace = monospace;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        ///     Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            string css = _monospace.GetCss();

            if (string.IsNullOrWhiteSpace(css))
            {
                return Array.Empty<string>();
            }

            return new[] { css };
        }

        /// <summary>
        ///     Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IIsCssClassComposer" /> value or BootstrapBuilder result.</returns>
        public IIsCssClassComposer Clone()
        {
            var clone = new MonospaceComposer();
            clone.Set(_monospace);
            return clone;
        }

        #endregion

        #endregion
    }
}