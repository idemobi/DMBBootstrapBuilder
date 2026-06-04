#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the BootstrapBuilder side bar section component component or support type.
    /// </summary>
    public sealed class SideBarSectionComponent
    {
        #region Instance fields and properties

        private readonly List<IActionItem> _items = new();

        /// <summary>
        ///     Gets or sets the additional classes value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string AdditionalClasses { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets a value indicating whether content is enabled for BootstrapBuilder rendering.
        /// </summary>
        public bool HasContent => _items.Count > 0;

        internal IReadOnlyList<IActionItem> Items => _items;

        /// <summary>
        ///     Gets or sets the title value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? Title { get; set; }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SideBarSectionComponent" /> class.
        /// </summary>
        /// <param name="title">The title value.</param>
        public SideBarSectionComponent(string? title = null)
        {
            Title = title;
        }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Adds value to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="item">The item value.</param>
        /// <returns>The configured <see cref="SideBarSectionComponent" /> value or BootstrapBuilder result.</returns>
        public SideBarSectionComponent Add(IActionItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _items.Add(item);
            return this;
        }

        /// <summary>
        ///     Adds value to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="items">The items value.</param>
        /// <returns>The configured <see cref="SideBarSectionComponent" /> value or BootstrapBuilder result.</returns>
        public SideBarSectionComponent Add(params IActionItem[] items)
        {
            if (items == null)
            {
                return this;
            }

            foreach (var item in items.Where(x => x != null))
            {
                Add(item);
            }

            return this;
        }

        /// <summary>
        ///     Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="SideBarSectionComponent" /> value or BootstrapBuilder result.</returns>
        public SideBarSectionComponent Clone()
        {
            var clone = new SideBarSectionComponent(Title)
            {
                AdditionalClasses = AdditionalClasses
            };

            foreach (var item in _items)
            {
                clone.Add(item.Clone());
            }

            return clone;
        }

        internal string RenderHeader()
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                return string.Empty;
            }

            string css = string.Join(
                " ",
                new[]
                {
                    "d-flex",
                    "align-items-center",
                    "gap-2",
                    "mt-3",
                    "mb-2",
                    AdditionalClasses
                }.Where(x => !string.IsNullOrWhiteSpace(x)));

            return $"""
                    <div class="{WebUtility.HtmlEncode(css)}">
                        <div class="fw-semibold fs-5 dmb-sidebar-section-title" title="{WebUtility.HtmlEncode(Title)}">{WebUtility.HtmlEncode(Title)}</div>
                        <div class="flex-grow-1 border-top opacity-50"></div>
                    </div>
                    """;
        }

        #endregion
    }
}