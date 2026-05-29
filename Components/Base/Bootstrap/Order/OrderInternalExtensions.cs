#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Provides extension methods for configuring order internal in BootstrapBuilder components.
    /// </summary>
    public static class OrderInternalExtensions
    {
        #region Static methods

        /// <summary>
        ///     Gets css for BootstrapBuilder rendering or composition.
        /// </summary>
        /// <param name="order">The order value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public static string GetCss(this Order order)
        {
            return order switch
            {
                Order.None => string.Empty,
                Order.Zero => "0",
                Order.One => "1",
                Order.Two => "2",
                Order.Three => "3",
                Order.Four => "4",
                Order.Five => "5",
                Order.First => "first",
                Order.Last => "last",
                _ => string.Empty
            };
        }

        #endregion
    }
}