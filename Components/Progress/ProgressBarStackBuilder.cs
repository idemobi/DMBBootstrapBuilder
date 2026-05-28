#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ProgressBarStackBuilder.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Builds and renders the BootstrapBuilder progress bar stack component or page region.
    /// </summary>
    public sealed class ProgressBarStackBuilder :
        HtmlTagBuilder<ProgressBarStackBuilder>,
        ICanUseCustomClasses
    {
        #region Instance fields and properties

        private string _ariaLabel
        {
            get => GetInternal("_ariaLabel", string.Empty);
            set => SetInternal("_ariaLabel", value);
        }

        private readonly List<ProgressBarBuilder> _segments = new();

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressBarStackBuilder"/> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public ProgressBarStackBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "div";
            _classesOfComponent.Add("progress-stacked");
        }

        #endregion

        #region Instance methods

        /// <summary>
        /// Adds progress bar to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="segment">The segment value.</param>
        /// <returns>The configured <see cref="ProgressBarStackBuilder"/> value or BootstrapBuilder result.</returns>
        public ProgressBarStackBuilder AddProgressBar(ProgressBarBuilder segment)
        {
            ArgumentNullException.ThrowIfNull(segment);
            _segments.Add(segment.Clone().WithoutWrapper(true));
            return this;
        }

        /// <summary>
        /// Adds progress bar to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <param name="style">The style value.</param>
        /// <param name="label">The label value.</param>
        /// <param name="showLabel">The show label value.</param>
        /// <param name="striped">The striped value.</param>
        /// <param name="animated">The animated value.</param>
        /// <returns>The configured <see cref="ProgressBarStackBuilder"/> value or BootstrapBuilder result.</returns>
        public ProgressBarStackBuilder AddProgressBar(
            double value,
            VariantStyle style,
            string? label = null,
            bool showLabel = false,
            bool striped = false,
            bool animated = false)
        {
            ProgressBarBuilder segment = new ProgressBarBuilder(_textWriter, _htmlHelper)
                .SetPercentage(value)
                .SetVariant(style)
                .SetLabel(label)
                .SetShowLabel(showLabel)
                .SetStriped(striped)
                .SetAnimated(animated)
                .WithoutWrapper(true);

            _segments.Add(segment);
            return this;
        }

        /// <inheritdoc />
        protected override ProgressBarStackBuilder CreateInstance()
        {
            return new ProgressBarStackBuilder(_textWriter, _htmlHelper);
        }

        /// <inheritdoc />
        protected override void InternalClone(ProgressBarStackBuilder source)
        {
            base.InternalClone(source);

            _ariaLabel = source._ariaLabel;

            _segments.Clear();
            foreach (ProgressBarBuilder segment in source._segments)
            {
                _segments.Add(segment.Clone().WithoutWrapper(true));
            }
        }

        /// <summary>
        /// Removes all progress bar from the current BootstrapBuilder component or composer.
        /// </summary>
        /// <returns>The configured <see cref="ProgressBarStackBuilder"/> value or BootstrapBuilder result.</returns>
        public ProgressBarStackBuilder RemoveAllProgressBar()
        {
            _segments.Clear();
            return this;
        }

        /// <summary>
        /// Configures aria label on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="label">The label value.</param>
        /// <returns>The configured <see cref="ProgressBarStackBuilder"/> value or BootstrapBuilder result.</returns>
        public ProgressBarStackBuilder SetAriaLabel(string? label)
        {
            _ariaLabel = label ?? string.Empty;
            return this;
        }

        /// <summary>
        /// Configures height on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <param name="unit">The unit value.</param>
        /// <returns>The configured <see cref="ProgressBarStackBuilder"/> value or BootstrapBuilder result.</returns>
        public ProgressBarStackBuilder SetHeight(uint size, UnitSize unit)
        {
            return SetStyle("height", $"{size}{unit.GetCss()}");
        }

        /// <summary>
        /// Configures size on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <returns>The configured <see cref="ProgressBarStackBuilder"/> value or BootstrapBuilder result.</returns>
        public ProgressBarStackBuilder SetSize(ProgressBarSize size)
        {
            return SetStyle("height", size.GetSizeAndUnitStyle());
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            string? previousAriaLabel = GetAttributeValue("aria-label");

            try
            {
                if (!string.IsNullOrWhiteSpace(_ariaLabel))
                {
                    SetAria("label", _ariaLabel);
                }

                writer.Write($"<{GetTag()}{BuildAttributes()}>");

                foreach (ProgressBarBuilder segment in _segments)
                {
                    segment.WriteTo(writer, encoder);
                }

                writer.Write($"</{GetTag()}>");
            }
            finally
            {
                RestoreAttribute("aria-label", previousAriaLabel);
            }
        }

        private void RestoreAttribute(string name, string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                RemoveAttribute(name);
            }
            else
            {
                _attributes[name] = value;
            }
        }

        #endregion
    }
}