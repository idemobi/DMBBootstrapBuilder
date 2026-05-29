#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the BootstrapBuilder modal render context component or support type.
    /// </summary>
    public sealed class ModalRenderContext
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets a value indicating whether custom footer is enabled for BootstrapBuilder rendering.
        /// </summary>
        public bool HasCustomFooter { get; set; } = false;

        /// <summary>
        ///     Gets or sets the modal id value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string ModalId { get; set; } = string.Empty;

        #endregion
    }
}