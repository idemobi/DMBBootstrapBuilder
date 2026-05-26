#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ModalRenderContext.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder modal render context component or support type.
    /// </summary>
    public sealed class ModalRenderContext
    {
        #region Instance fields and properties

        /// <summary>
        /// Gets or sets a value indicating whether custom footer is enabled for BootstrapBuilder rendering.
        /// </summary>
        public bool HasCustomFooter { get; set; } = false;
        /// <summary>
        /// Gets or sets the modal id value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string ModalId { get; set; } = string.Empty;

        #endregion
    }
}