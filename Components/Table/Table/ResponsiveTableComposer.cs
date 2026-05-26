#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ResponsiveTableComposer.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Composes Bootstrap CSS classes or page chrome for responsive table.
    /// </summary>
    public sealed class ResponsiveTableComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private TableResponsiveBreakpoint _breakpoint = TableResponsiveBreakpoint.None;

        #endregion

        #region Instance methods

        /// <summary>
        /// Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="ResponsiveTableComposer"/> value or BootstrapBuilder result.</returns>
        public ResponsiveTableComposer Set(TableResponsiveBreakpoint breakpoint)
        {
            _breakpoint = breakpoint;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        /// Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            string css = _breakpoint.GetCssClass();

            if (string.IsNullOrWhiteSpace(css))
            {
                return Array.Empty<string>();
            }

            return new[] { css };
        }

        /// <summary>
        /// Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IIsCssClassComposer"/> value or BootstrapBuilder result.</returns>
        public IIsCssClassComposer Clone()
        {
            var clone = new ResponsiveTableComposer();

            if (_breakpoint != TableResponsiveBreakpoint.None)
            {
                clone.Set(_breakpoint);
            }

            return clone;
        }

        #endregion

        #endregion
    }
}