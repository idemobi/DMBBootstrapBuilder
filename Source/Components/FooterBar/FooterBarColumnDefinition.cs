#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

using System.Collections.Generic;

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the BootstrapBuilder footer bar column definition component or support type.
    /// </summary>
    public sealed class FooterBarColumnDefinition
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the groups value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public List<GroupActionItem> Groups { get; } = new();

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="FooterBarColumnDefinition" /> class.
        /// </summary>
        public FooterBarColumnDefinition()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FooterBarColumnDefinition" /> class.
        /// </summary>
        /// <param name="groups">The groups value.</param>
        public FooterBarColumnDefinition(params GroupActionItem[] groups)
        {
            AddGroups(groups);
        }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Adds groups to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="groups">The groups value.</param>
        /// <returns>The configured <see cref="FooterBarColumnDefinition" /> value or BootstrapBuilder result.</returns>
        public FooterBarColumnDefinition AddGroups(params GroupActionItem[] groups)
        {
            if (groups == null)
            {
                return this;
            }

            foreach (GroupActionItem group in groups)
            {
                if (group != null)
                {
                    Groups.Add(group);
                }
            }

            return this;
        }

        #endregion
    }
}