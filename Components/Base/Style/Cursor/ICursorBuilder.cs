#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ICursorBuilder.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Defines a BootstrapBuilder contract for cursor builder.
    /// </summary>
    /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
    public interface ICursorBuilder<TBuilder> : IHasStyleBuilder<TBuilder>
    {
    }
}