#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents border color rule data used by BootstrapBuilder rendering and CSS class composition.
    /// </summary>
    /// <param name="Color">The color value.</param>
    /// <param name="Breakpoint">The breakpoint value.</param>
    public readonly record struct BorderColorRule(
        BorderColor Color,
        ResponsiveBreakpoint Breakpoint
    );
}