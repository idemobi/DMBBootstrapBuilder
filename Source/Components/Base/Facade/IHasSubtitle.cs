#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Defines a BootstrapBuilder contract for has subtitle.
    /// </summary>
    public interface IHasSubtitle
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the subtitle rendered by the component.
        /// </summary>
        string? Subtitle { get; set; }

        #endregion
    }
}