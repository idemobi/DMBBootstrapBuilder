#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ActionContainerBase.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder action container base component or support type.
    /// </summary>
    /// <typeparam name="TSelf">The BootstrapBuilder type configured by this member.</typeparam>
    public abstract class ActionContainerBase<TSelf> : ActionItemBase<TSelf>, IActionContainerItem
        where TSelf : ActionContainerBase<TSelf>
    {
        #region Instance fields and properties

        #region From interface IActionContainerItem

        /// <summary>
        /// Gets or sets a value indicating whether children is enabled for BootstrapBuilder rendering.
        /// </summary>
        public bool HasChildren => Items.Count > 0;
        /// <summary>
        /// Gets or sets the items value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public List<IActionItem> Items { get; } = new();

        #endregion

        #endregion

        #region Instance methods

        /// <summary>
        /// Adds item to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="item">The item value.</param>
        /// <returns>The configured <typeparamref name="TSelf"/> value or BootstrapBuilder result.</returns>
        public TSelf AddItem(IActionItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            Items.Add(item);
            return This();
        }

        /// <summary>
        /// Adds items to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="items">The items value.</param>
        /// <returns>The configured <typeparamref name="TSelf"/> value or BootstrapBuilder result.</returns>
        public TSelf AddItems(params IActionItem[] items)
        {
            foreach (var item in items)
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }

                Items.Add(item);
            }

            return This();
        }

        #endregion
    }
}