#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents border radius rule data used by BootstrapBuilder rendering and CSS class composition.
    /// </summary>
    /// <param name="Side">The side value.</param>
    /// <param name="Size">The size value.</param>
    /// <param name="Breakpoint">The breakpoint value.</param>
    public readonly record struct BorderRadiusRule(
        BorderRadiusSide Side,
        BorderRadiusSize Size,
        ResponsiveBreakpoint Breakpoint
    );
}