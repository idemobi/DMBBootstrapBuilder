#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Composes Bootstrap CSS classes or page chrome for overflow.
    /// </summary>
    public sealed class OverflowComposer : IIsCssClassComposer
    {
        #region Instance fields and properties

        private OverflowValue _overflow = OverflowValue.None;
        private OverflowValue _overflowX = OverflowValue.None;
        private OverflowValue _overflowY = OverflowValue.None;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="overflow">The overflow value.</param>
        /// <returns>The configured <see cref="OverflowComposer" /> value or BootstrapBuilder result.</returns>
        public OverflowComposer Set(OverflowValue overflow)
        {
            _overflow = overflow;
            return this;
        }

        /// <summary>
        ///     Configures x on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="overflow">The overflow value.</param>
        /// <returns>The configured <see cref="OverflowComposer" /> value or BootstrapBuilder result.</returns>
        public OverflowComposer SetX(OverflowValue overflow)
        {
            _overflowX = overflow;
            return this;
        }

        /// <summary>
        ///     Configures y on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="overflow">The overflow value.</param>
        /// <returns>The configured <see cref="OverflowComposer" /> value or BootstrapBuilder result.</returns>
        public OverflowComposer SetY(OverflowValue overflow)
        {
            _overflowY = overflow;
            return this;
        }

        #region From interface IIsCssClassComposer

        /// <summary>
        ///     Builds classes for BootstrapBuilder rendering.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<string> BuildClasses()
        {
            List<string> classes = new();

            string overflowCss = _overflow.GetCss();
            if (!string.IsNullOrWhiteSpace(overflowCss))
            {
                classes.Add($"overflow-{overflowCss}");
            }

            string overflowXCss = _overflowX.GetCss();
            if (!string.IsNullOrWhiteSpace(overflowXCss))
            {
                classes.Add($"overflow-x-{overflowXCss}");
            }

            string overflowYCss = _overflowY.GetCss();
            if (!string.IsNullOrWhiteSpace(overflowYCss))
            {
                classes.Add($"overflow-y-{overflowYCss}");
            }

            return classes;
        }

        /// <summary>
        ///     Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IIsCssClassComposer" /> value or BootstrapBuilder result.</returns>
        public IIsCssClassComposer Clone()
        {
            var clone = new OverflowComposer();
            clone.Set(_overflow);
            clone.SetX(_overflowX);
            clone.SetY(_overflowY);
            return clone;
        }

        #endregion

        #endregion
    }
}