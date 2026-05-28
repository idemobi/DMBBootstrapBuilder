#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj NavbarComponentBase.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using System.Net;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder navbar component base component or support type.
    /// </summary>
    public abstract class NavbarComponentBase : INavbarComponent
    {
        #region Instance fields and properties

        /// <summary>
        /// Gets or sets the additional classes value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string AdditionalClasses { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the visible from value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public ResponsiveBreakpoint VisibleFrom { get; set; } = ResponsiveBreakpoint.Xs;
        /// <summary>
        /// Gets or sets the visible until value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public ResponsiveBreakpoint VisibleUntil { get; set; } = ResponsiveBreakpoint.Xs;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Builds the shared Bootstrap navbar CSS class list.
        /// </summary>
        /// <param name="classes">Additional CSS classes to append to the common navbar classes.</param>
        /// <returns>The CSS class string used by the navbar component.</returns>
        protected string BuildCommonCss(params string[] classes)
        {
            var result = new List<string>();

            foreach (var css in classes)
            {
                if (!string.IsNullOrWhiteSpace(css))
                {
                    result.Add(css);
                }
            }

            string responsiveCss = ResponsiveDisplayHelper.BuildResponsiveCss(VisibleFrom, VisibleUntil);
            if (!string.IsNullOrWhiteSpace(responsiveCss))
            {
                result.Add(responsiveCss);
            }

            if (!string.IsNullOrWhiteSpace(AdditionalClasses))
            {
                result.Add(AdditionalClasses);
            }

            return string.Join(
                " ",
                result
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Distinct(StringComparer.Ordinal));
        }

        /// <summary>
        /// Executes the BootstrapBuilder show from operation.
        /// </summary>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="NavbarComponentBase"/> value or BootstrapBuilder result.</returns>
        public NavbarComponentBase ShowFrom(ResponsiveBreakpoint breakpoint)
        {
            VisibleFrom = breakpoint;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder show until operation.
        /// </summary>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="NavbarComponentBase"/> value or BootstrapBuilder result.</returns>
        public NavbarComponentBase ShowUntil(ResponsiveBreakpoint breakpoint)
        {
            VisibleUntil = breakpoint;
            return this;
        }

        /// <summary>
        /// Configures classes on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="classes">The classes value.</param>
        /// <returns>The configured <see cref="NavbarComponentBase"/> value or BootstrapBuilder result.</returns>
        public NavbarComponentBase WithClasses(string classes)
        {
            AdditionalClasses = classes ?? string.Empty;
            return this;
        }

        #region From interface INavbarComponent

        /// <summary>
        /// Renders value for the BootstrapBuilder output.
        /// </summary>
        /// <param name="htmlHelper">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The rendered HTML content for the BootstrapBuilder component.</returns>
        public abstract IHtmlContent Render(IHtmlHelper htmlHelper);

        #endregion

        #endregion
    }

    /// <summary>
    /// Represents the BootstrapBuilder navbar container component component or support type.
    /// </summary>
    public sealed class NavbarContainerComponent : NavbarComponentBase
    {
        #region Instance fields and properties

        private readonly List<INavbarComponent> _components = new();
        /// <summary>
        /// Gets or sets the align items value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public AlignItems AlignItems { get; set; } = AlignItems.Center;
        /// <summary>
        /// Gets or sets the fill width value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool FillWidth { get; set; }

        /// <summary>
        /// Gets or sets the justify value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public JustifyContent Justify { get; set; } = JustifyContent.Start;
        /// <summary>
        /// Gets or sets the old gap value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public Old_Gap OldGap { get; set; } = Old_Gap.Gap2;

        /// <summary>
        /// Gets or sets the wrap value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool Wrap { get; set; }

        #endregion

        #region Instance methods

        /// <summary>
        /// Adds value to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="component">The component value.</param>
        /// <returns>The configured <see cref="NavbarContainerComponent"/> value or BootstrapBuilder result.</returns>
        public NavbarContainerComponent Add(INavbarComponent component)
        {
            if (component == null)
            {
                throw new ArgumentNullException(nameof(component));
            }

            _components.Add(component);
            return this;
        }

        /// <summary>
        /// Adds value to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="components">The components value.</param>
        /// <returns>The configured <see cref="NavbarContainerComponent"/> value or BootstrapBuilder result.</returns>
        public NavbarContainerComponent Add(params INavbarComponent[] components)
        {
            if (components == null)
            {
                return this;
            }

            foreach (var component in components.Where(x => x != null))
            {
                Add(component);
            }

            return this;
        }

        /// <summary>
        /// Renders value for the BootstrapBuilder output.
        /// </summary>
        /// <param name="htmlHelper">The Razor HTML helper used to access view context and services.</param>
        /// <returns>The rendered HTML content for the BootstrapBuilder component.</returns>
        public override IHtmlContent Render(IHtmlHelper htmlHelper)
        {
            if (htmlHelper == null)
            {
                throw new ArgumentNullException(nameof(htmlHelper));
            }

            string css = BuildCommonCss(
                "d-flex",
                Wrap ? "flex-wrap" : "flex-nowrap",
                FillWidth ? "w-100" : string.Empty,
                Justify.GetJustifyCss(),
                AlignItems.GetAlignItemsCss(),
                OldGap.GetGapCss());

            string contentHtml = string.Join(
                Environment.NewLine,
                _components.Select(x => x.Render(htmlHelper).ToString()));

            return new HtmlString($"""
                                   <div class="{WebUtility.HtmlEncode(css)}">
                                       {contentHtml}
                                   </div>
                                   """);
        }

        /// <summary>
        /// Configures align items on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="alignItems">The align items value.</param>
        /// <returns>The configured <see cref="NavbarContainerComponent"/> value or BootstrapBuilder result.</returns>
        public NavbarContainerComponent WithAlignItems(AlignItems alignItems)
        {
            AlignItems = alignItems;
            return this;
        }

        /// <summary>
        /// Configures fill width on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="NavbarContainerComponent"/> value or BootstrapBuilder result.</returns>
        public NavbarContainerComponent WithFillWidth(bool value = true)
        {
            FillWidth = value;
            return this;
        }

        /// <summary>
        /// Configures gap on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="oldGap">The old gap value.</param>
        /// <returns>The configured <see cref="NavbarContainerComponent"/> value or BootstrapBuilder result.</returns>
        public NavbarContainerComponent WithGap(Old_Gap oldGap)
        {
            OldGap = oldGap;
            return this;
        }

        /// <summary>
        /// Configures justify on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="justify">The justify value.</param>
        /// <returns>The configured <see cref="NavbarContainerComponent"/> value or BootstrapBuilder result.</returns>
        public NavbarContainerComponent WithJustify(JustifyContent justify)
        {
            Justify = justify;
            return this;
        }

        /// <summary>
        /// Configures wrap on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="NavbarContainerComponent"/> value or BootstrapBuilder result.</returns>
        public NavbarContainerComponent WithWrap(bool value = true)
        {
            Wrap = value;
            return this;
        }

        #endregion
    }
}
