#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

using System;

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Represents the BootstrapBuilder html style helper component or support type.
    /// </summary>
    public static class HtmlStyleHelper
    {
        #region Static methods

        /// <summary>
        ///     Executes the BootstrapBuilder merge style operation.
        /// </summary>
        /// <param name="currentStyle">The current style value.</param>
        /// <param name="appendedStyle">The appended style value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string MergeStyle(string? currentStyle, string appendedStyle)
        {
            if (string.IsNullOrWhiteSpace(currentStyle))
            {
                return appendedStyle;
            }

            if (string.IsNullOrWhiteSpace(appendedStyle))
            {
                return currentStyle;
            }

            string left = currentStyle.Trim();
            string right = appendedStyle.Trim();

            if (!left.EndsWith(";", StringComparison.Ordinal))
            {
                left += ";";
            }

            return left + " " + right;
        }

        #endregion
    }
}