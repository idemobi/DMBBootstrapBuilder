#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj BorderColorRule.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents border color rule data used by BootstrapBuilder rendering and CSS class composition.
    /// </summary>
    /// <param name="Color">The color value.</param>
    /// <param name="Breakpoint">The breakpoint value.</param>
    public readonly record struct BorderColorRule(
        BorderColor Color,
        ResponsiveBreakpoint Breakpoint
    );
}