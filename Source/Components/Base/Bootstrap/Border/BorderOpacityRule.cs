#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents border opacity rule data used by BootstrapBuilder rendering and CSS class composition.
    /// </summary>
    /// <param name="Opacity">The opacity value.</param>
    /// <param name="Breakpoint">The breakpoint value.</param>
    public readonly record struct BorderOpacityRule(
        BorderOpacity Opacity,
        ResponsiveBreakpoint Breakpoint
    );
}