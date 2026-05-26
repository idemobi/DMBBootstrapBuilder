namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Defines BootstrapBuilder values for debug target.
    /// </summary>
    public enum DebugTarget
    {
        /// <summary>
        /// Disables the related BootstrapBuilder option.
        /// </summary>
        None = 0,
        /// <summary>
        /// Represents the data attribute BootstrapBuilder option.
        /// </summary>
        DataAttribute,
        /// <summary>
        /// Represents the css variable BootstrapBuilder option.
        /// </summary>
        CssVariable,
        /// <summary>
        /// Represents the class BootstrapBuilder option.
        /// </summary>
        Class,
        /// <summary>
        /// Represents the style BootstrapBuilder option.
        /// </summary>
        Style
    }
}