#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj TitleLevel.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Defines BootstrapBuilder values for title level.
    /// </summary>
    [Serializable]
    public enum TitleLevel : int
    {
        /// <summary>
        /// Represents the one BootstrapBuilder option.
        /// </summary>
        One = 1,
        /// <summary>
        /// Represents the two BootstrapBuilder option.
        /// </summary>
        Two = 2,
        /// <summary>
        /// Represents the three BootstrapBuilder option.
        /// </summary>
        Three = 3,
        /// <summary>
        /// Represents the four BootstrapBuilder option.
        /// </summary>
        Four = 4,
        /// <summary>
        /// Represents the five BootstrapBuilder option.
        /// </summary>
        Five = 5,
        /// <summary>
        /// Represents the six BootstrapBuilder option.
        /// </summary>
        Six = 6,
    }

    /// <summary>
    /// Provides extension methods for configuring title level in BootstrapBuilder components.
    /// </summary>
    public static class TitleLevelExtension
    {
        #region Static methods

        /// <summary>
        /// Executes the BootstrapBuilder gap operation.
        /// </summary>
        /// <param name="level">The level value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string Gap(this TitleLevel level)
        {
            return level switch
            {
                TitleLevel.One => "gap-3",
                TitleLevel.Two => "gap-3",
                TitleLevel.Three => "gap-2",
                TitleLevel.Four => "gap-2",
                TitleLevel.Five => "gap-2",
                TitleLevel.Six => "gap-1",
                _ => "gap-2"
            };
        }

        /// <summary>
        /// Executes the BootstrapBuilder tag operation.
        /// </summary>
        /// <param name="level">The level value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string Tag(this TitleLevel level)
        {
            return level switch
            {
                TitleLevel.One => "h1",
                TitleLevel.Two => "h2",
                TitleLevel.Three => "h3",
                TitleLevel.Four => "h4",
                TitleLevel.Five => "h5",
                TitleLevel.Six => "h6",
                _ => "h3"
            };
        }

        #endregion
    }
}