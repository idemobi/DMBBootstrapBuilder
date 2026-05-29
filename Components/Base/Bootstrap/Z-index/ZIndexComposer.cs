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
    ///     Composes Bootstrap CSS classes or page chrome for z index.
    /// </summary>
    public sealed class ZIndexComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private ZIndex _zIndex = ZIndex.Normal;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="zIndex">The z index value.</param>
        /// <returns>The configured <see cref="ZIndexComposer" /> value or BootstrapBuilder result.</returns>
        public ZIndexComposer Set(ZIndex zIndex)
        {
            _zIndex = zIndex;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        ///     Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            string css = _zIndex.GetCss();

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
            var clone = new ZIndexComposer();
            clone.Set(_zIndex);
            return clone;
        }

        #endregion

        #endregion
    }
}