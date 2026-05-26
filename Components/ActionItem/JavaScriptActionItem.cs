#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj JavaScriptActionItem.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder java script action item component or support type.
    /// </summary>
    public class JavaScriptActionItem : ActionLeafBase<JavaScriptActionItem>
    {
        #region Instance fields and properties

        /// <summary>
        /// Gets or sets the java script value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? JavaScript { get; set; }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="JavaScriptActionItem"/> class.
        /// </summary>
        /// <param name="script">The script value.</param>
        public JavaScriptActionItem(string script)
        {
            JavaScript = script;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JavaScriptActionItem"/> class.
        /// </summary>
        public JavaScriptActionItem()
        {
        }

        #endregion

        #region Instance methods

        /// <summary>
        /// Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IActionItem"/> value or BootstrapBuilder result.</returns>
        public override IActionItem Clone()
        {
            var clone = new JavaScriptActionItem
            {
                Id = Id,
                Title = Title,
                Subtitle = Subtitle,
                Icon = Icon,
                DebugOnly = DebugOnly,
                Outline = Outline,
                Variant = Variant,
                Size = Size,
                AdditionalClasses = AdditionalClasses,
                JavaScript = JavaScript,
                Disabled = Disabled,
                Active = Active,
                BadgeText = BadgeText,
                BadgeStyle = BadgeStyle
            };

            return clone;
        }

        #endregion
    }
}