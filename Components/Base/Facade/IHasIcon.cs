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
    ///     Defines a BootstrapBuilder contract for has icon.
    /// </summary>
    public interface IHasIcon
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the icon rendered by the component.
        /// </summary>
        IconStruct Icon { get; set; }

        #endregion
    }
}