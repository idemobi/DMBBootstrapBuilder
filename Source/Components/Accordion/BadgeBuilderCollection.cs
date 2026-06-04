#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the BootstrapBuilder badge builder collection component or support type.
    /// </summary>
    public sealed class BadgeBuilderCollection
    {
        #region Instance fields and properties

        private readonly List<BadgeBuilder> _badges = new();

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets a value indicating whether badges is enabled for BootstrapBuilder rendering.
        /// </summary>
        public bool HasBadges => _badges.Count > 0;

        /// <summary>
        ///     Gets or sets the count value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public int Count => _badges.Count;

        #endregion

        #region Public API

        /// <summary>
        ///     Executes the BootstrapBuilder clear operation.
        /// </summary>
        public void Clear()
        {
            _badges.Clear();
        }

        /// <summary>
        ///     Configures value on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="badge">The badge value.</param>
        public void Set(BadgeBuilder badge)
        {
            ArgumentNullException.ThrowIfNull(badge);

            _badges.Clear();
            _badges.Add(badge.Clone());
        }

        /// <summary>
        ///     Adds value to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="badge">The badge value.</param>
        /// <param name="others">The others value.</param>
        public void Add(BadgeBuilder badge, params BadgeBuilder[] others)
        {
            ArgumentNullException.ThrowIfNull(badge);

            _badges.Add(badge.Clone());

            if (others == null || others.Length == 0)
            {
                return;
            }

            foreach (BadgeBuilder other in others)
            {
                if (other != null)
                {
                    _badges.Add(other.Clone());
                }
            }
        }

        /// <summary>
        ///     Gets all for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public IReadOnlyList<BadgeBuilder> GetAll()
        {
            return _badges;
        }

        #endregion

        #region Rendering

        /// <summary>
        ///     Renders html for the BootstrapBuilder output.
        /// </summary>
        /// <param name="encoder">The encoder value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public string RenderHtml(HtmlEncoder encoder)
        {
            return RenderHtml(encoder, null);
        }

        /// <summary>
        ///     Renders html for the BootstrapBuilder output.
        /// </summary>
        /// <param name="encoder">The encoder value.</param>
        /// <param name="wrapperCssClass">The wrapper css class value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public string RenderHtml(HtmlEncoder encoder, string? wrapperCssClass)
        {
            ArgumentNullException.ThrowIfNull(encoder);

            if (_badges.Count == 0)
            {
                return string.Empty;
            }

            using StringWriter writer = new();

            if (!string.IsNullOrWhiteSpace(wrapperCssClass))
            {
                writer.Write($"""<span class="{encoder.Encode(wrapperCssClass)}">""");
            }

            foreach (BadgeBuilder badge in _badges)
            {
                badge.WriteTo(writer, encoder);
            }

            if (!string.IsNullOrWhiteSpace(wrapperCssClass))
            {
                writer.Write("</span>");
            }

            return writer.ToString();
        }

        #endregion

        #region Clone

        /// <summary>
        ///     Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="BadgeBuilderCollection" /> value or BootstrapBuilder result.</returns>
        public BadgeBuilderCollection Clone()
        {
            BadgeBuilderCollection clone = new();

            foreach (BadgeBuilder badge in _badges)
            {
                clone._badges.Add(badge.Clone());
            }

            return clone;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder to cloned list operation.
        /// </summary>
        /// <returns>The generated Bootstrap CSS classes or composed output items.</returns>
        public List<BadgeBuilder> ToClonedList()
        {
            List<BadgeBuilder> result = new();

            foreach (BadgeBuilder badge in _badges)
            {
                result.Add(badge.Clone());
            }

            return result;
        }

        #endregion
    }
}