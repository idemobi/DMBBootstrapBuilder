#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj CssGridColumnsComposer.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Composes Bootstrap CSS classes or page chrome for css grid columns.
    /// </summary>
    public sealed class CssGridColumnsComposer : IIsInlineStyleComposer
    {
        #region Instance fields and properties

        private int? _columns;

        #endregion

        #region Instance methods

        /// <summary>
        /// Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="columns">The columns value.</param>
        /// <returns>The configured <see cref="CssGridColumnsComposer"/> value or BootstrapBuilder result.</returns>
        public CssGridColumnsComposer Set(int columns)
        {
            _columns = columns;
            return this;
        }

        #region From interface IIsInlineStyleComposer

        /// <summary>
        /// Builds styles for BootstrapBuilder rendering.
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