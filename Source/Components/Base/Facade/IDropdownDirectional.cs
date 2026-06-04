#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Defines a BootstrapBuilder contract for dropdown directional.
    /// </summary>
    public interface IDropdownDirectional
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the dropdown direction used by Bootstrap dropdown rendering.
        /// </summary>
        DropdownDirection DropdownDirection { get; set; }

        #endregion
    }
}