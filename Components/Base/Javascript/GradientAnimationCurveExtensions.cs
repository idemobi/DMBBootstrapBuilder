#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj GradientAnimationCurveExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring gradient animation curve in BootstrapBuilder components.
    /// </summary>
    public static class GradientAnimationCurveExtensions
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
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