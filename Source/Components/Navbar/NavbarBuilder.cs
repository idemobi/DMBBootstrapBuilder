#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    ///     Builds and renders the BootstrapBuilder navbar component or page region.
    /// </summary>
    public sealed class NavbarBuilder : HtmlTagBuilder<NavbarBuilder>, ICanUseCustomClasses
    {
        #region Instance fields and properties

        private AlignItems _alignItems
        {
            get => GetInternal("_alignItems", AlignItems.Center);
            set => SetInternal("_alignItems", value);
        }

        private readonly List<INavbarComponent> _components = new();

        private NavbarExpand _expand
        {
            get => GetInternal("_expand", NavbarExpand.Lg);
            set => SetInternal("_expand", value);
        }

        private bool _fluid
        {
            get => GetInternal("_fluid", true);
            set => SetInternal("_fluid", value);
        }

        private JustifyContent _justify
        {
            get => GetInternal("_justify", JustifyContent.Start);
            set => SetInternal("_justify", value);
        }

        private Old_Gap _oldGap
        {
            get => GetInternal("_oldGap", Old_Gap.Gap2);
            set => SetInternal("_oldGap", value);
        }

        private NavbarPlacement _placement
        {
            get => GetInternal("_placement", NavbarPlacement.Default);
            set => SetInternal("_placement", value);
        }

        private VariantStyle _variant
        {
            get => GetInternal("_variant", VariantStyle.Light);
            set => SetInternal("_variant", value);
        }

        private ResponsiveBreakpoint _visibleFrom
        {
            get => GetInternal("_visibleFrom", ResponsiveBreakpoint.Xs);
            set => SetInternal("_visibleFrom", value);
        }

        private ResponsiveBreakpoint _visibleUntil
        {
            get => GetInternal("_visibleUntil", ResponsiveBreakpoint.Xs);
            set => SetInternal("_visibleUntil", value);
        }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="NavbarBuilder" /> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public NavbarBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "nav";
        }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Adds value to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="component">The component value.</param>
        /// <returns>The configured <see cref="NavbarBuilder" /> value or BootstrapBuilder result.</returns>
        public NavbarBuilder Add(INavbarComponent component)
        {
            ArgumentNullException.ThrowIfNull(component);
            _components.Add(component);
            return this;
        }

        private string BuildInnerCss()
        {
            return string.Join(
                " ",
                new[]
                {
                    "navbar-content",
                    "d-flex",
                    "w-100",
                    _justify.GetJustifyCss(),
                    _alignItems.GetAlignItemsCss(),
                    _oldGap.GetGapCss(),
                    "flex-wrap"
                }.Where(x => !string.IsNullOrWhiteSpace(x)));
        }

        private string BuildNavbarCss()
        {
            List<string> classes = new()
            {
                "navbar",
                GetExpandCss(),
                GetPlacementCss(),
                GetVariantCss()
            };

            string responsiveCss = ResponsiveDisplayHelper.BuildResponsiveCss(_visibleFrom, _visibleUntil);

            if (!string.IsNullOrWhiteSpace(responsiveCss))
            {
                classes.Add(responsiveCss);
            }

            return string.Join(" ", classes.Where(x => !string.IsNullOrWhiteSpace(x)));
        }

        /// <summary>
        ///     Executes the BootstrapBuilder class operation.
        /// </summary>
        /// <param name="cssClass">The css class value.</param>
        /// <returns>The configured <see cref="NavbarBuilder" /> value or BootstrapBuilder result.</returns>
        public NavbarBuilder Class(string cssClass)
        {
            if (!string.IsNullOrWhiteSpace(cssClass))
            {
                this.AddClass(cssClass);
            }

            return this;
        }

        /// <inheritdoc />
        protected override NavbarBuilder CreateInstance()
        {
            return new NavbarBuilder(_textWriter, _htmlHelper);
        }

        /// <summary>
        ///     Executes the BootstrapBuilder expand operation.
        /// </summary>
        /// <param name="expand">The expand value.</param>
        /// <returns>The configured <see cref="NavbarBuilder" /> value or BootstrapBuilder result.</returns>
        public NavbarBuilder Expand(NavbarExpand expand)
        {
            _expand = expand;
            return this;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder fluid operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="NavbarBuilder" /> value or BootstrapBuilder result.</returns>
        public NavbarBuilder Fluid(bool value = true)
        {
            _fluid = value;
            return this;
        }

        private string GetExpandCss()
        {
            return _expand switch
            {
                NavbarExpand.Never => string.Empty,
                NavbarExpand.Always => "navbar-expand",
                NavbarExpand.Sm => "navbar-expand-sm",
                NavbarExpand.Md => "navbar-expand-md",
                NavbarExpand.Lg => "navbar-expand-lg",
                NavbarExpand.Xl => "navbar-expand-xl",
                NavbarExpand.Xxl => "navbar-expand-xxl",
                _ => "navbar-expand-lg"
            };
        }

        private string GetPlacementCss()
        {
            return _placement switch
            {
                NavbarPlacement.FixedTop => "fixed-top",
                NavbarPlacement.FixedBottom => "fixed-bottom",
                NavbarPlacement.StickyTop => "sticky-top",
                NavbarPlacement.StickyBottom => "sticky-bottom",
                _ => string.Empty
            };
        }

        private string GetVariantCss()
        {
            return _variant switch
            {
                VariantStyle.Primary => "navbar-dark bg-primary",
                VariantStyle.Secondary => "navbar-dark bg-secondary",
                VariantStyle.Success => "navbar-dark bg-success",
                VariantStyle.Warning => "navbar-light bg-warning",
                VariantStyle.Danger => "navbar-dark bg-danger",
                VariantStyle.Info => "navbar-dark bg-info",
                VariantStyle.Light => "navbar-light bg-light",
                VariantStyle.Dark => "navbar-dark bg-dark",
                _ => "navbar-light bg-light"
            };
        }

        /// <summary>
        ///     Executes the BootstrapBuilder id operation.
        /// </summary>
        /// <param name="id">The id value.</param>
        /// <returns>The configured <see cref="NavbarBuilder" /> value or BootstrapBuilder result.</returns>
        public NavbarBuilder Id(string id)
        {
            SetId(HtmlIdGenerator.CleanId(id) ?? string.Empty);
            return this;
        }

        /// <inheritdoc />
        protected override void InternalClone(NavbarBuilder source)
        {
            base.InternalClone(source);

            _components.Clear();
            _components.AddRange(source._components);
        }

        /// <summary>
        ///     Executes the BootstrapBuilder justify operation.
        /// </summary>
        /// <param name="justify">The justify value.</param>
        /// <returns>The configured <see cref="NavbarBuilder" /> value or BootstrapBuilder result.</returns>
        public NavbarBuilder Justify(JustifyContent justify)
        {
            _justify = justify;
            return this;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder placement operation.
        /// </summary>
        /// <param name="placement">The placement value.</param>
        /// <returns>The configured <see cref="NavbarBuilder" /> value or BootstrapBuilder result.</returns>
        public NavbarBuilder Placement(NavbarPlacement placement)
        {
            _placement = placement;
            return this;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder show from operation.
        /// </summary>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="NavbarBuilder" /> value or BootstrapBuilder result.</returns>
        public NavbarBuilder ShowFrom(ResponsiveBreakpoint breakpoint)
        {
            _visibleFrom = breakpoint;
            return this;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder show until operation.
        /// </summary>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="NavbarBuilder" /> value or BootstrapBuilder result.</returns>
        public NavbarBuilder ShowUntil(ResponsiveBreakpoint breakpoint)
        {
            _visibleUntil = breakpoint;
            return this;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder style operation.
        /// </summary>
        /// <param name="cssStyle">The css style value.</param>
        /// <returns>The configured <see cref="NavbarBuilder" /> value or BootstrapBuilder result.</returns>
        public NavbarBuilder Style(string cssStyle)
        {
            if (string.IsNullOrWhiteSpace(cssStyle))
            {
                RemoveAttribute("style");
            }
            else
            {
                SetAttribute("style", cssStyle);
            }

            return this;
        }

        /// <summary>
        ///     Executes the BootstrapBuilder variant operation.
        /// </summary>
        /// <param name="variant">The variant value.</param>
        /// <returns>The configured <see cref="NavbarBuilder" /> value or BootstrapBuilder result.</returns>
        public NavbarBuilder Variant(VariantStyle variant)
        {
            _variant = variant;
            return this;
        }

        /// <summary>
        ///     Configures align items on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="alignItems">The align items value.</param>
        /// <returns>The configured <see cref="NavbarBuilder" /> value or BootstrapBuilder result.</returns>
        public NavbarBuilder WithAlignItems(AlignItems alignItems)
        {
            _alignItems = alignItems;
            return this;
        }

        /// <summary>
        ///     Configures gap on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="oldGap">The old gap value.</param>
        /// <returns>The configured <see cref="NavbarBuilder" /> value or BootstrapBuilder result.</returns>
        public NavbarBuilder WithGap(Old_Gap oldGap)
        {
            _oldGap = oldGap;
            return this;
        }

        /// <inheritdoc />
        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            string navbarCss = BuildNavbarCss();
            string innerCss = BuildInnerCss();
            string containerClass = _fluid ? "container-fluid" : "container";

            using (PushInternalClasses(navbarCss))
            {
                writer.Write($"<{GetTag()}{BuildAttributes()}>");
                writer.Write($"""<div class="{encoder.Encode(containerClass)}">""");
                writer.Write($"""<div class="{encoder.Encode(innerCss)}">""");

                foreach (INavbarComponent component in _components)
                {
                    component.Render(_htmlHelper).WriteTo(writer, encoder);
                }

                writer.Write("</div>");
                writer.Write("</div>");
                writer.Write($"</{GetTag()}>");
            }
        }

        #endregion
    }
}