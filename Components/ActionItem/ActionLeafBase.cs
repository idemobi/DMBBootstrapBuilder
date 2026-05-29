#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the BootstrapBuilder action leaf base component or support type.
    /// </summary>
    /// <typeparam name="TSelf">The BootstrapBuilder type configured by this member.</typeparam>
    public abstract class ActionLeafBase<TSelf> : ActionItemBase<TSelf>
        where TSelf : ActionLeafBase<TSelf>
    {
    }
}