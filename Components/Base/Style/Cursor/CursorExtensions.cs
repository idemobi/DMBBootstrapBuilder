#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj CursorExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring cursor in BootstrapBuilder components.
    /// </summary>
    public static class CursorExtensions
    {
        #region Static methods

        /// <summary>
        /// Stores the important value used by BootstrapBuilder rendering or composition.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The cursor-capable builder to configure.</param>
        /// <param name="value">The cursor style to render as a CSS value.</param>
        /// <param name="important">Whether the style should be emitted with <c>!important</c>.</param>
        /// <returns>The configured builder for fluent chaining.</returns>
        public static TBuilder SetCursor<TBuilder>(this ICursorBuilder<TBuilder> builder, CursorStyle value, bool important = false)
        {
            return builder.SetStyle("cursor", $"{value.ToString().ToLower().Trim('_').Replace('_', '-')}", important);
        }

        #endregion
    }
}
