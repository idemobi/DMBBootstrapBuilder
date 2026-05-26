namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Adds debug property target metadata used by BootstrapBuilder diagnostics or documentation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public sealed class DebugPropertyTargetAttribute : Attribute
    {
        #region Instance fields and properties

        /// <summary>
        /// Gets or sets the name value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Gets or sets the target value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public DebugTarget Target { get; }
        /// <summary>
        /// Gets or sets the value prefix value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? ValuePrefix { get; set; }
        /// <summary>
        /// Gets or sets the value suffix value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? ValueSuffix { get; set; }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DebugPropertyTargetAttribute"/> class.
        /// </summary>
        /// <param name="target">The target value.</param>
        /// <param name="name">The name value.</param>
        public DebugPropertyTargetAttribute(DebugTarget target, string name)
        {
            Target = target;
            Name = name;
        }

        #endregion
    }
}