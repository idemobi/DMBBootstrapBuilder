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
    ///     Defines the contract for BootstrapBuilder components that can configure align self.
    /// </summary>
    public interface ICanUseAlignSelf
    {
    }

    /// <summary>
    ///     Defines BootstrapBuilder values for align self.
    /// </summary>
    public enum AlignSelf
    {
        /// <summary>
        ///     Represents the auto BootstrapBuilder option.
        /// </summary>
        Auto,

        /// <summary>
        ///     Represents the start BootstrapBuilder option.
        /// </summary>
        Start,

        /// <summary>
        ///     Represents the end BootstrapBuilder option.
        /// </summary>
        End,

        /// <summary>
        ///     Represents the center BootstrapBuilder option.
        /// </summary>
        Center,

        /// <summary>
        ///     Represents the baseline BootstrapBuilder option.
        /// </summary>
        Baseline,

        /// <summary>
        ///     Represents the stretch BootstrapBuilder option.
        /// </summary>
        Stretch
    }

    /// <summary>
    ///     Composes Bootstrap CSS classes or page chrome for align self.
    /// </summary>
    public sealed class AlignSelfComposer : IIsCssClassComposer
    {
        #region Static methods

        private static string BuildClass(AlignSelf alignSelf, ResponsiveBreakpoint breakpoint)
        {
            string valueCss = alignSelf.GetCss();
            string bpCss = breakpoint.GetCss();

            return string.IsNullOrWhiteSpace(bpCss)
                ? $"align-self-{valueCss}"
                : $"align-self-{bpCss}-{valueCss}";
        }

        #endregion

        #region Instance fields and properties

        private readonly Dictionary<ResponsiveBreakpoint, AlignSelf> _rules = new();

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="alignSelf">The align self value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="AlignSelfComposer" /> value or BootstrapBuilder result.</returns>
        public AlignSelfComposer Set(
            AlignSelf alignSelf,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
        {
            _rules[breakpoint] = alignSelf;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        ///     Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            return _rules
                .OrderBy(x => x.Key)
                .Select(x => BuildClass(x.Value, x.Key))
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
            var clone = new AlignSelfComposer();
            foreach (var rule in _rules)
            {
                clone.Set(rule.Value, rule.Key);
            }

            return clone;
        }

        #endregion

        #endregion
    }

    /// <summary>
    ///     Provides extension methods for configuring align self in BootstrapBuilder components.
    /// </summary>
    public static class AlignSelfExtensions
    {
        #region Static methods

        /// <summary>
        ///     Configures align self on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="alignSelf">The align self value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetAlignSelf<TBuilder>(
            this TBuilder builder,
            AlignSelf alignSelf,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseAlignSelf
        {
            AlignSelfComposer composer =
                builder.GetOrCreateCssComposer(() => new AlignSelfComposer());

            composer.Set(alignSelf, breakpoint);

            return builder;
        }

        /// <summary>
        ///     Configures align self auto on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetAlignSelfAuto<TBuilder>(
            this TBuilder builder,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseAlignSelf
        {
            return builder.SetAlignSelf(AlignSelf.Auto, breakpoint);
        }

        /// <summary>
        ///     Configures align self baseline on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetAlignSelfBaseline<TBuilder>(
            this TBuilder builder,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseAlignSelf
        {
            return builder.SetAlignSelf(AlignSelf.Baseline, breakpoint);
        }

        /// <summary>
        ///     Configures align self center on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetAlignSelfCenter<TBuilder>(
            this TBuilder builder,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseAlignSelf
        {
            return builder.SetAlignSelf(AlignSelf.Center, breakpoint);
        }

        /// <summary>
        ///     Configures align self end on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetAlignSelfEnd<TBuilder>(
            this TBuilder builder,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseAlignSelf
        {
            return builder.SetAlignSelf(AlignSelf.End, breakpoint);
        }

        /// <summary>
        ///     Configures align self start on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetAlignSelfStart<TBuilder>(
            this TBuilder builder,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseAlignSelf
        {
            return builder.SetAlignSelf(AlignSelf.Start, breakpoint);
        }

        /// <summary>
        ///     Configures align self stretch on the current BootstrapBuilder instance.
        /// </summary>
        /// <typeparam name="TBuilder">The BootstrapBuilder type configured by this member.</typeparam>
        /// <param name="builder">The BootstrapBuilder instance to configure.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <typeparamref name="TBuilder" /> value or BootstrapBuilder result.</returns>
        public static TBuilder SetAlignSelfStretch<TBuilder>(
            this TBuilder builder,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xs
        )
            where TBuilder : HtmlBuilderBase<TBuilder>, ICanUseAlignSelf
        {
            return builder.SetAlignSelf(AlignSelf.Stretch, breakpoint);
        }

        #endregion
    }
}