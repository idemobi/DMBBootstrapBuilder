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
    ///     Composes Bootstrap CSS classes or page chrome for clearfix.
    /// </summary>
    public sealed class ClearfixComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private Clearfix _clearfix = Clearfix.Normal;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="clearfix">The clearfix value.</param>
        /// <returns>The configured <see cref="ClearfixComposer" /> value or BootstrapBuilder result.</returns>
        public ClearfixComposer Set(Clearfix clearfix)
        {
            _clearfix = clearfix;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        ///     Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            string css = _clearfix.GetCss();

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
            var clone = new ClearfixComposer();
            clone.Set(_clearfix);
            return clone;
        }

        #endregion

        #endregion
    }
}