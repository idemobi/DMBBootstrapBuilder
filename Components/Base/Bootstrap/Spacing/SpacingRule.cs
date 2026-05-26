#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj SpacingRule.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents spacing rule data used by BootstrapBuilder rendering and CSS class composition.
    /// </summary>
    /// <param name="Property">The property value.</param>
    /// <param name="Side">The side value.</param>
    /// <param name="Breakpoint">The breakpoint value.</param>
    /// <param name="Size">The size value.</param>
    /// <param name="Negative">True when the spacing class should use Bootstrap negative margin syntax; otherwise, false.</param>
    public readonly record struct SpacingRule(
        SpacingProperty Property,
        SpacingSide Side,
        ResponsiveBreakpoint Breakpoint,
        SpacingSize Size,
        bool Negative = false
    );
}