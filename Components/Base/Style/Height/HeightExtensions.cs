#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj HeightExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring height in BootstrapBuilder components.
    /// </summary>
    public static class HeightExtensions
    {
        #region Static methods

        /// <summary>
        /// Stores the unit value used by BootstrapBuilder rendering or composition.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        public static TBuilder SetHeight<TBuilder>(this TBuilder builder, uint size, UnitSize unit = UnitSize.percent, bool important = false) where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseHeight
        {
            return builder.SetStyle("height", $"{size}{unit.GetCss()}", important);
        }

        /// <summary>
        /// Stores the unit value used by BootstrapBuilder rendering or composition.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        public static TBuilder SetMaxHeight<TBuilder>(this TBuilder builder, uint size, UnitSize unit = UnitSize.percent, bool important = false) where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseHeight
        {
            return builder.SetStyle("max-height", $"{size}{unit.GetCss()}", important);
        }

        /// <summary>
        /// Stores the unit value used by BootstrapBuilder rendering or composition.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        public static TBuilder SetMinHeight<TBuilder>(this TBuilder builder, uint size, UnitSize unit = UnitSize.percent, bool important = false) where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseHeight
        {
            return builder.SetStyle("min-height", $"{size}{unit.GetCss()}", important);
        }

        #endregion
    }
}