#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring z index internal in BootstrapBuilder components.
    /// </summary>
    public static class ZIndexInternalExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="zIndex">The z index value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this ZIndex zIndex)
        {
            return zIndex switch
            {
                ZIndex.Normal => string.Empty,
                ZIndex.N1 => "z-n1",
                ZIndex.Z0 => "z-0",
                ZIndex.Z1 => "z-1",
                ZIndex.Z2 => "z-2",
                ZIndex.Z3 => "z-3",
                _ => string.Empty
            };
        }

        #endregion
    }
}