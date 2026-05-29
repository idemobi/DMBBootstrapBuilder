#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Defines a BootstrapBuilder contract for has title.
    /// </summary>
    public interface IHasTitle
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the title rendered by the component.
        /// </summary>
        string? Title { get; set; }

        #endregion
    }
}