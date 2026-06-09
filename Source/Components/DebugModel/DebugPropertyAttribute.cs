#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Adds debug property metadata used by BootstrapBuilder diagnostics or documentation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class DebugPropertyAttribute : Attribute
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the help text value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? HelpText { get; set; }

        /// <summary>
        ///     Gets or sets the ignore value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool Ignore { get; set; }

        /// <summary>
        ///     Gets or sets the input type value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public DebugInputType InputType { get; set; } = DebugInputType.Auto;

        /// <summary>
        ///     Gets or sets the label value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? Label { get; set; }

        /// <summary>
        ///     Gets or sets the max value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? Max { get; set; }

        /// <summary>
        ///     Gets or sets the min value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? Min { get; set; }

        /// <summary>
        ///     Gets or sets the step value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? Step { get; set; }

        /// <summary>
        ///     Gets or sets the target value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public DebugTarget Target { get; set; } = DebugTarget.None;

        /// <summary>
        ///     Gets or sets the target name value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? TargetName { get; set; }

        /// <summary>
        ///     Gets or sets the value prefix value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? ValuePrefix { get; set; }

        /// <summary>
        ///     Gets or sets the value suffix value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? ValueSuffix { get; set; }

        #endregion
    }
}