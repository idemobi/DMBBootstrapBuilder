#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Adds debug model metadata used by BootstrapBuilder diagnostics or documentation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class DebugModelAttribute : Attribute
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the code pattern value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? CodePattern { get; set; }

        /// <summary>
        ///     Gets or sets the title value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string Title { get; }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="DebugModelAttribute" /> class.
        /// </summary>
        /// <param name="title">The title value.</param>
        public DebugModelAttribute(string title)
        {
            Title = title;
        }

        #endregion
    }
}