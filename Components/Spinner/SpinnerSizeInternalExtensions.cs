#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj SpinnerSizeInternalExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring spinner size internal in BootstrapBuilder components.
    /// </summary>
    public static class SpinnerSizeInternalExtensions
    {
        #region Static methods

        /// <summary>
        /// Executes the BootstrapBuilder class to clean operation.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public static string[] ClassToClean(this SpinnerSize size)
        {
            return new string[] { "spinner-grow-sm", "spinner-border-sm" };
        }

        /// <summary>
        /// Gets css class for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <param name="type">The type value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCssClass(this SpinnerSize size, SpinnerType type)
        {
            return size switch
            {
                SpinnerSize.Small => type == SpinnerType.Grow ? "spinner-grow-sm" : "spinner-border-sm",
                _ => string.Empty
            };
        }

        #endregion
    }
}