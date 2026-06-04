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
    ///     Composes Bootstrap CSS classes or page chrome for tab block.
    /// </summary>
    public sealed class TabBlockComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private bool _active;
        private bool _disabled;
        private bool _fade = true;

        /// <summary>
        ///     Gets or sets a value indicating whether active is enabled for BootstrapBuilder rendering.
        /// </summary>
        public bool IsActive => _active;

        /// <summary>
        ///     Gets or sets a value indicating whether disabled is enabled for BootstrapBuilder rendering.
        /// </summary>
        public bool IsDisabled => _disabled;

        /// <summary>
        ///     Gets or sets a value indicating whether fade is enabled for BootstrapBuilder rendering.
        /// </summary>
        public bool IsFade => _fade;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures active on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TabBlockComposer" /> value or BootstrapBuilder result.</returns>
        public TabBlockComposer SetActive(bool value = true)
        {
            _active = value;
            return this;
        }

        /// <summary>
        ///     Configures disabled on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TabBlockComposer" /> value or BootstrapBuilder result.</returns>
        public TabBlockComposer SetDisabled(bool value = true)
        {
            _disabled = value;
            return this;
        }

        /// <summary>
        ///     Configures fade on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TabBlockComposer" /> value or BootstrapBuilder result.</returns>
        public TabBlockComposer SetFade(bool value = true)
        {
            _fade = value;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        ///     Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            return Array.Empty<string>();
        }

        /// <summary>
        ///     Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IIsCssClassComposer" /> value or BootstrapBuilder result.</returns>
        public IIsCssClassComposer Clone()
        {
            return new TabBlockComposer()
                .SetActive(_active)
                .SetDisabled(_disabled)
                .SetFade(_fade);
        }

        #endregion

        #endregion
    }
}