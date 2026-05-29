#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring align self internal in BootstrapBuilder components.
    /// </summary>
    public static class AlignSelfInternalExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="alignSelf">The align self value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this AlignSelf alignSelf)
        {
            return alignSelf switch
            {
                AlignSelf.Auto => "auto",
                AlignSelf.Start => "start",
                AlignSelf.End => "end",
                AlignSelf.Center => "center",
                AlignSelf.Baseline => "baseline",
                AlignSelf.Stretch => "stretch",
                _ => "auto"
            };
        }

        #endregion
    }
}