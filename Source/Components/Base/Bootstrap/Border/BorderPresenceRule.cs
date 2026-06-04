#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents border presence rule data used by BootstrapBuilder rendering and CSS class composition.
    /// </summary>
    /// <param name="Side">The side value.</param>
    /// <param name="Presence">The presence value.</param>
    /// <param name="Breakpoint">The breakpoint value.</param>
    public readonly record struct BorderPresenceRule(
        BorderSide Side,
        BorderPresence Presence,
        ResponsiveBreakpoint Breakpoint
    );
}