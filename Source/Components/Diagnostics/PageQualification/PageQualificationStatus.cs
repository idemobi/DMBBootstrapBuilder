#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

using System;

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Describes the diagnostic qualification state of a Razor page or partial view.
    /// </summary>
    [Flags]
    public enum PageQualificationStatus
    {
        /// <summary>
        ///     Disables the related BootstrapBuilder option.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Represents the validated BootstrapBuilder option.
        /// </summary>
        Validated = 1,

        /// <summary>
        ///     Represents the in progress BootstrapBuilder option.
        /// </summary>
        InProgress = 2,

        /// <summary>
        ///     Represents the not validated BootstrapBuilder option.
        /// </summary>
        NotValidated = 4,

        /// <summary>
        ///     Represents the danger BootstrapBuilder option.
        /// </summary>
        Danger = 8,

        /// <summary>
        ///     Represents the need layout BootstrapBuilder option.
        /// </summary>
        NeedLayout = 16
    }
}