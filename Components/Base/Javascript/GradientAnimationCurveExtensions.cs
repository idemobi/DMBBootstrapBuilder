#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring gradient animation curve in BootstrapBuilder components.
    /// </summary>
    public static class GradientAnimationCurveExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="curve">The curve value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this GradientAnimationCurve curve)
        {
            return curve switch
            {
                GradientAnimationCurve.Linear => "linear",
                GradientAnimationCurve.Ease => "ease",
                GradientAnimationCurve.EaseIn => "ease-in",
                GradientAnimationCurve.EaseOut => "ease-out",
                _ => "ease-in-out"
            };
        }

        #endregion
    }
}