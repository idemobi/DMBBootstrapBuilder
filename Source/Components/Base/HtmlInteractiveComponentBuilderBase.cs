#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using System.Collections.Generic;
using System.Linq;
using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Defines the contract for BootstrapBuilder components that can configure interactive.
    /// </summary>
    public interface ICanUseInteractive
    {
    }

    /// <summary>
    ///     Composes Bootstrap CSS classes or page chrome for interactive.
    /// </summary>
    public sealed class InteractiveComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the disabled value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        ///     Gets or sets the no break text value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool NoBreakText { get; set; }

        /// <summary>
        ///     Gets or sets the size value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public BoostrapButtonSize Size { get; set; } = BoostrapButtonSize.Medium;

        /// <summary>
        ///     Gets or sets the style value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public VariantStyle Style { get; set; } = VariantStyle.Normal;

        #endregion

        #region Instance methods

        #region From interface IIsCssClassComposer

        /// <summary>
        ///     Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            List<string> classes = new();

            switch (Size)
            {
                case BoostrapButtonSize.Small:
                    classes.Add("btn-sm");
                break;

                case BoostrapButtonSize.Large:
                    classes.Add("btn-lg");
                break;
            }

            if (NoBreakText)
            {
                classes.Add("text-nowrap");
            }

            if (Disabled)
            {
                classes.Add("disabled");
            }

            return classes
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct(StringComparer.Ordinal)
                .ToList();
        }

        /// <summary>
        ///     Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IIsCssClassComposer" /> value or BootstrapBuilder result.</returns>
        public IIsCssClassComposer Clone()
        {
            return new InteractiveComposer
            {
                Size = Size,
                Style = Style,
                Disabled = Disabled,
                NoBreakText = NoBreakText
            };
        }

        #endregion

        #endregion
    }


    /// <summary>
    ///     Provides extension methods for configuring interactive builder in BootstrapBuilder components.
    /// </summary>
    public static class InteractiveBuilderExtensions
    {
        #region Static methods

        /// <summary>
        ///     Stores the disabled value used by BootstrapBuilder rendering or composition.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The interactive builder to configure.</param>
        /// <param name="disabled">Whether the rendered Bootstrap component should be disabled.</param>
        /// <returns>The configured builder for fluent chaining.</returns>
        public static TBuilder Disabled<TBuilder>(this TBuilder builder, bool disabled = true)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseInteractive
        {
            InteractiveComposer composer = GetInteractiveComposer(builder);
            composer.Disabled = disabled;
            builder.SetDisabled(disabled);
            return builder;
        }

        private static InteractiveComposer GetInteractiveComposer<TBuilder>(TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseInteractive
        {
            return builder.GetOrCreateCssComposer(() => new InteractiveComposer());
        }

        /// <summary>
        ///     Gets interactive disabled for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>True when the requested BootstrapBuilder condition is active; otherwise, false.</returns>
        public static bool GetInteractiveDisabled<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseInteractive
        {
            return GetInteractiveComposer(builder).Disabled;
        }

        /// <summary>
        ///     Gets interactive no break text for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>True when the requested BootstrapBuilder condition is active; otherwise, false.</returns>
        public static bool GetInteractiveNoBreakText<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseInteractive
        {
            return GetInteractiveComposer(builder).NoBreakText;
        }

        /// <summary>
        ///     Gets interactive size for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <see cref="BoostrapButtonSize" /> value or BootstrapBuilder result.</returns>
        public static BoostrapButtonSize GetInteractiveSize<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseInteractive
        {
            return GetInteractiveComposer(builder).Size;
        }

        /// <summary>
        ///     Gets interactive style for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <returns>The configured <see cref="VariantStyle" /> value or BootstrapBuilder result.</returns>
        public static VariantStyle GetInteractiveStyle<TBuilder>(this TBuilder builder)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseInteractive
        {
            return GetInteractiveComposer(builder).Style;
        }

        /// <summary>
        ///     Stores the enabled value used by BootstrapBuilder rendering or composition.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The interactive builder to configure.</param>
        /// <param name="enabled">Whether the rendered text should avoid line breaks.</param>
        /// <returns>The configured builder for fluent chaining.</returns>
        public static TBuilder NoBreakText<TBuilder>(this TBuilder builder, bool enabled = true)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseInteractive
        {
            GetInteractiveComposer(builder).NoBreakText = enabled;
            return builder;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder size operation.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="size">The size value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder Size<TBuilder>(this TBuilder builder, BoostrapButtonSize size)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseInteractive
        {
            GetInteractiveComposer(builder).Size = size;
            return builder;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder style operation.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="style">The style value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder Style<TBuilder>(this TBuilder builder, VariantStyle style)
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseInteractive
        {
            GetInteractiveComposer(builder).Style = style;
            return builder;
        }

        #endregion
    }


    //
    // public abstract class HtmlInteractiveComponentBuilderBase<TBuilder> : HtmlTagBuilder<TBuilder>
    //     where TBuilder : HtmlInteractiveComponentBuilderBase<TBuilder>
    // {
    //     #region Instance fields and properties
    //
    //     protected BoostrapButtonSize ElementSize = BoostrapButtonSize.Medium;
    //     protected VariantStyle ElementStyle = VariantStyle.Normal;
    //     protected bool IsDisabled;
    //     protected bool IsNoBreakText;
    //
    //     #endregion
    //
    //     #region Instance constructors and destructors
    //
    //     protected HtmlInteractiveComponentBuilderBase(TextWriter writer, IHtmlHelper html)
    //         : base(writer, html)
    //     {
    //     }
    //
    //     #endregion
    //
    //     #region Fluent interactive API
    //
    //     public TBuilder Style(VariantStyle style)
    //     {
    //         ElementStyle = style;
    //         return This();
    //     }
    //
    //     public TBuilder Size(BoostrapButtonSize size)
    //     {
    //         ElementSize = size;
    //         return This();
    //     }
    //
    //     public TBuilder Disabled(bool disabled = true)
    //     {
    //         IsDisabled = disabled;
    //         return This();
    //     }
    //
    //     public TBuilder NoBreakText(bool enabled = true)
    //     {
    //         IsNoBreakText = enabled;
    //         return This();
    //     }
    //
    //     #endregion
    //
    //     #region Protected helpers
    //
    //     protected string GetButtonSizeCss()
    //     {
    //         return ElementSize switch
    //         {
    //             BoostrapButtonSize.Small => "btn-sm",
    //             BoostrapButtonSize.Large => "btn-lg",
    //             _ => string.Empty
    //         };
    //     }
    //
    //     protected string GetStyleCss()
    //     {
    //         return ElementStyle.ToString().ToLowerInvariant();
    //     }
    //
    //     protected string GetDisabledAttribute()
    //     {
    //         return IsDisabled ? """ disabled="disabled" """ : string.Empty;
    //     }
    //
    //     protected string GetAriaDisabledAttribute()
    //     {
    //         return IsDisabled ? """ aria-disabled="true" """ : """ aria-disabled="false" """;
    //     }
    //
    //     protected string GetDisabledCss()
    //     {
    //         return IsDisabled ? "disabled" : string.Empty;
    //     }
    //
    //     protected string GetNoBreakCss()
    //     {
    //         return IsNoBreakText ? "text-nowrap" : string.Empty;
    //     }
    //
    //     protected string GetCommonCss(params string[] additionalClasses)
    //     {
    //         return BuildClassAttribute(
    //             GetButtonSizeCss(),
    //             GetNoBreakCss(),
    //             GetDisabledCss(),
    //             additionalClasses == null ? string.Empty : string.Join(" ", additionalClasses));
    //     }
    //
    //     #endregion
    // }
}