#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

using System.Collections.Generic;

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Composes Bootstrap CSS classes or page chrome for css grid columns.
    /// </summary>
    public sealed class CssGridColumnsComposer : IIsInlineStyleComposer
    {
        #region Instance fields and properties

        private int? _columns;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="columns">The columns value.</param>
        /// <returns>The configured <see cref="CssGridColumnsComposer" /> value or BootstrapBuilder result.</returns>
        public CssGridColumnsComposer Set(int columns)
        {
            _columns = columns;
            return this;
        }

        #region From interface IIsInlineStyleComposer

        /// <summary>
        ///     Builds styles for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildStyles()
        {
            if (!_columns.HasValue)
            {
                return System.Array.Empty<string>();
            }

            return new[] { $"--bs-columns:{_columns.Value};" };
        }

        #endregion

        #endregion
    }
}