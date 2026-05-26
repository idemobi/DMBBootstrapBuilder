#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj AlertFactory.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder alert factory component or support type.
    /// </summary>
    public static class AlertFactory
    {
        #region Static methods

        /// <summary>
        /// Executes the BootstrapBuilder danger operation.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <param name="message">The message value.</param>
        /// <returns>The configured <see cref="AlertModel"/> value or BootstrapBuilder result.</returns>
        public static AlertModel Danger(string title, string message)
        {
            return new AlertModel(IconStruct.BootstrapEnum(BootStrapEnum.bi_exclamation_octagon), title, message).SetVariant(VariantStyle.Danger);
        }

        /// <summary>
        /// Executes the BootstrapBuilder exception operation.
        /// </summary>
        /// <param name="exception">The exception value.</param>
        /// <returns>The configured <see cref="AlertModel"/> value or BootstrapBuilder result.</returns>
        public static AlertModel Exception(Exception exception)
        {
            return new AlertModel(IconStruct.BootstrapEnum(BootStrapEnum.bi_exclamation_triangle), "Exception", exception.Message).SetVariant(VariantStyle.Danger);
        }

        /// <summary>
        /// Executes the BootstrapBuilder failed operation.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <param name="message">The message value.</param>
        /// <returns>The configured <see cref="AlertModel"/> value or BootstrapBuilder result.</returns>
        public static AlertModel Failed(string title, string message)
        {
            return new AlertModel(IconStruct.BootstrapEnum(BootStrapEnum.bi_exclamation_triangle), title, message).SetVariant(VariantStyle.Danger);
        }

        /// <summary>
        /// Executes the BootstrapBuilder information operation.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <param name="message">The message value.</param>
        /// <returns>The configured <see cref="AlertModel"/> value or BootstrapBuilder result.</returns>
        public static AlertModel Information(string title, string message)
        {
            return new AlertModel(IconStruct.BootstrapEnum(BootStrapEnum.bi_info_circle), title, message).SetVariant(VariantStyle.Info).SetDismissible();
        }

        /// <summary>
        /// Executes the BootstrapBuilder success operation.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <param name="message">The message value.</param>
        /// <returns>The configured <see cref="AlertModel"/> value or BootstrapBuilder result.</returns>
        public static AlertModel Success(string title, string message)
        {
            return new AlertModel(IconStruct.BootstrapEnum(BootStrapEnum.bi_info_circle), title, message).SetVariant(VariantStyle.Success).SetDismissible();
        }

        /// <summary>
        /// Executes the BootstrapBuilder warning operation.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <param name="message">The message value.</param>
        /// <returns>The configured <see cref="AlertModel"/> value or BootstrapBuilder result.</returns>
        public static AlertModel Warning(string title, string message)
        {
            return new AlertModel(IconStruct.BootstrapEnum(BootStrapEnum.bi_exclamation_triangle), title, message).SetVariant(VariantStyle.Warning);
        }

        #endregion
    }
}