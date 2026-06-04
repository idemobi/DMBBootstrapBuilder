#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System.Collections.Generic;
using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Composes Bootstrap CSS classes or page chrome for visibility.
    /// </summary>
    public sealed class VisibilityComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private Visibility _visibility = Visibility.Normal;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="visibility">The visibility value.</param>
        /// <returns>The configured <see cref="VisibilityComposer" /> value or BootstrapBuilder result.</returns>
        public VisibilityComposer Set(Visibility visibility)
        {
            _visibility = visibility;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        ///     Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            string css = _visibility.GetCss();

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
            var clone = new VisibilityComposer();
            clone.Set(_visibility);
            return clone;
        }

        #endregion

        #endregion
    }
}