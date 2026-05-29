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
    ///     Composes Bootstrap CSS classes or page chrome for debug only.
    /// </summary>
    public sealed class DebugOnlyComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private bool _enabled;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="enabled">True to enable enabled; otherwise, false.</param>
        /// <returns>The configured <see cref="DebugOnlyComposer" /> value or BootstrapBuilder result.</returns>
        public DebugOnlyComposer Set(bool enabled)
        {
            _enabled = enabled;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        ///     Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            if (_enabled)
            {
                return new[] { "theme-debug-only" };
            }

            return Array.Empty<string>();
        }

        /// <summary>
        ///     Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IIsCssClassComposer" /> value or BootstrapBuilder result.</returns>
        public IIsCssClassComposer Clone()
        {
            var clone = new DebugOnlyComposer();
            clone.Set(_enabled);
            return clone;
        }

        #endregion

        #endregion
    }
}