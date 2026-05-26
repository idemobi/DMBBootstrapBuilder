#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj OrderInternalExtensions.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Provides extension methods for configuring order internal in BootstrapBuilder components.
    /// </summary>
    public static class OrderInternalExtensions
    {
        #region Static methods

        /// <summary>
        /// Gets css for BootstrapBuilder rendering or composition.
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