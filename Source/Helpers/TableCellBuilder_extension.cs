#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBPageBuilder;
using DMBServerHelper;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring table cell builder in BootstrapBuilder components.
    /// </summary>
    public static class TableCellBuilderExtension
    {
        #region Static methods

        /// <summary>
        ///     Renders icon bootstrap localized for the BootstrapBuilder output.
        /// </summary>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="iconKey">The icon key value.</param>
        /// <returns>The configured <see cref="TableCellBuilder" /> value or BootstrapBuilder result.</returns>
        public static TableCellBuilder RenderIconBootstrapLocalized(this TableCellBuilder builder, string iconKey)
        {
            #if DEBUG
            builder.SetData("render-icon-localized", true);
            builder.SetData("render-icon-key", iconKey);
            #endif
            return builder.Render(IconStruct.Bootstrap(WebLocalizer.GetInternal(iconKey)));
        }

        /// <summary>
        ///     Renders localized for the BootstrapBuilder output.
        /// </summary>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="titleKey">The title key value.</param>
        /// <param name="args">The args value.</param>
        /// <returns>The configured <see cref="TableCellBuilder" /> value or BootstrapBuilder result.</returns>
        public static TableCellBuilder RenderLocalized(this TableCellBuilder builder, string titleKey, params object[] args)
        {
            #if DEBUG
            builder.SetData("render-localized", true);
            builder.SetData("render-key", titleKey);
            #endif
            return builder.Render(WebLocalizer.GetInternal(titleKey, args));
        }

        #endregion
    }
}