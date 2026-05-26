#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ActionLeafBase.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder action leaf base component or support type.
    /// </summary>
    /// <typeparam name="TSelf">The BootstrapBuilder type configured by this member.</typeparam>
    public abstract class ActionLeafBase<TSelf> : ActionItemBase<TSelf>
        where TSelf : ActionLeafBase<TSelf>
    {
    }
}