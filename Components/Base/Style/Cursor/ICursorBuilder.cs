#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Defines a BootstrapBuilder contract for cursor builder.
    /// </summary>
    /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
    public interface ICursorBuilder<TBuilder> : IHasStyleBuilder<TBuilder>
    {
    }
}