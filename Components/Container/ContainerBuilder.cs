#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ContainerBuilder.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using DMBPageBuilder;
using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Builds and renders the BootstrapBuilder container component or page region.
    /// </summary>
    public sealed class ContainerBuilder : HtmlTagBuilder<ContainerBuilder>,
        ICanUsePadding,
        ICanUseDebugOnly,
        ICanUseMargin,
        ICanUseCustomClasses
    {
        #region Instance fields and properties

        private ContainerStyle _containerStyle = ContainerStyle.Default;
        private SpacingSize _margin = SpacingSize.Auto;
        private SpacingSize _padding = SpacingSize.Three;

        private HtmlRenderContext? _renderContext;

        private SideBarComponent? _sidebar;
        private string _sidebarMaxWidth = "400px";
        private string _sidebarMinWidth = "200px";
        private ResponsiveBreakpoint _sidebarShowFrom = ResponsiveBreakpoint.Xl;
        private string _sidebarWidth = "320px";
        private bool _switchableToFluid;

        private BlockBuilder _containerComponent;
        private BlockBuilder _mainComponent;
        private BlockBuilder _sidebarComponent;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerBuilder"/> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public ContainerBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "div";
            _containerComponent = new BlockBuilder(writer, html);
            _sidebarComponent = new BlockBuilder(writer, html);
            _mainComponent = new BlockBuilder(writer, html);
        }

        #endregion

        #region Instance methods

        /// <inheritdoc />
        protected override ContainerBuilder CreateInstance()
        {
            return new ContainerBuilder(_textWriter, _htmlHelper);
        }

        /// <inheritdoc />
        protected override void InternalClone(ContainerBuilder source)
        {
            base.InternalClone(source);

            _containerStyle = source._containerStyle;
            _margin = source._margin;
            _padding = source._padding;
            _sidebar = source._sidebar;
            _sidebarMaxWidth = source._sidebarMaxWidth;
            _sidebarMinWidth = source._sidebarMinWidth;
            _sidebarShowFrom = source._sidebarShowFrom;
            _sidebarWidth = source._sidebarWidth;
            _switchableToFluid = source._switchableToFluid;

            _containerComponent = source._containerComponent.Clone();
            _mainComponent = source._mainComponent.Clone();
            _sidebarComponent = source._sidebarComponent.Clone();

            _renderContext = null;
        }

        private bool HasSidebar()
        {
            return _sidebar != null && _sidebar.HasContent;
        }

        /// <summary>
        /// Executes the BootstrapBuilder in container component operation.
        /// </summary>
        /// <param name="configure">The configure value.</param>
        /// <returns>The configured <see cref="ContainerBuilder"/> value or BootstrapBuilder result.</returns>
        public ContainerBuilder InContainerComponent(Func<BlockBuilder, BlockBuilder> configure)
        {
            ArgumentNullException.ThrowIfNull(configure);
            _containerComponent = configure(_containerComponent);
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder in main component operation.
        /// </summary>
        /// <param name="configure">The configure value.</param>
        /// <returns>The configured <see cref="ContainerBuilder"/> value or BootstrapBuilder result.</returns>
        public ContainerBuilder InMainComponent(Func<BlockBuilder, BlockBuilder> configure)
        {
            ArgumentNullException.ThrowIfNull(configure);
            _mainComponent = configure(_mainComponent);
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder in side bar component operation.
        /// </summary>
        /// <param name="configure">The configure value.</param>
        /// <returns>The configured <see cref="ContainerBuilder"/> value or BootstrapBuilder result.</returns>
        public ContainerBuilder InSideBarComponent(Func<BlockBuilder, BlockBuilder> configure)
        {
            ArgumentNullException.ThrowIfNull(configure);
            _sidebarComponent = configure(_sidebarComponent);
            return this;
        }

        /// <inheritdoc />
        protected override void OnBeginRendering()
        {
            _renderContext = new HtmlRenderContext
            {
                Kind = HtmlRenderContextKind.Container,
                Owner = this
            };

            HtmlRenderContextManager.Push(HtmlHelper, _renderContext);

            if (HasSidebar())
            {
                WriteSidebarLayoutStart();
                return;
            }

            This().AddClasses("dmb-container", "d-flex", "align-items-stretch", _containerStyle.GetCss());
            SetAttribute("role", "container");

            if (_containerStyle == ContainerStyle.Fluid)
            {
                this.AddClass("p-0");
            }
            else
            {
                this.AddClass("p-3");
            }

            if (_switchableToFluid)
            {
                SetData("switchable-fluid", "true");
                SetData("switchable-reverse", _containerStyle.GetCss());
            }
        }

        /// <inheritdoc />
        protected override void OnEndRendering()
        {
            if (HasSidebar())
            {
                WriteSidebarLayoutEnd();
            }

            HtmlRenderContext? current = HtmlRenderContextManager.Current(HtmlHelper);

            if (ReferenceEquals(current, _renderContext))
            {
                HtmlRenderContextManager.Pop(HtmlHelper);
            }

            _renderContext = null;
        }

        /// <summary>
        /// Configures margin on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <returns>The configured <see cref="ContainerBuilder"/> value or BootstrapBuilder result.</returns>
        public ContainerBuilder SetMargin(SpacingSize size)
        {
            _margin = size;
            return this;
        }

        /// <summary>
        /// Configures padding on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <returns>The configured <see cref="ContainerBuilder"/> value or BootstrapBuilder result.</returns>
        public ContainerBuilder SetPadding(SpacingSize size)
        {
            _padding = size;
            return this;
        }

        /// <summary>
        /// Configures sidebar on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="sidebar">The sidebar value.</param>
        /// <param name="width">The width value.</param>
        /// <param name="unitSize">The unit size value.</param>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="ContainerBuilder"/> value or BootstrapBuilder result.</returns>
        public ContainerBuilder SetSidebar(
            SideBarComponent? sidebar,
            uint width = 320,
            UnitSize unitSize = UnitSize.px,
            ResponsiveBreakpoint breakpoint = ResponsiveBreakpoint.Xl)
        {
            _sidebar = sidebar;
            _sidebarWidth = $"{width}{unitSize}";
            _sidebarShowFrom = breakpoint;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder style operation.
        /// </summary>
        /// <param name="style">The style value.</param>
        /// <returns>The configured <see cref="ContainerBuilder"/> value or BootstrapBuilder result.</returns>
        public ContainerBuilder Style(ContainerStyle style)
        {
            _containerStyle = style;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder switchable to fluid operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="ContainerBuilder"/> value or BootstrapBuilder result.</returns>
        public ContainerBuilder SwitchableToFluid(bool value = true)
        {
            _switchableToFluid = value;
            return this;
        }

        private void WriteSidebarLayoutEnd()
        {
            _textWriter.Write("""
                              </div>
                              </div>
                              """);
        }

        private void WriteSidebarLayoutStart()
        {
            BlockBuilder localSideBarComponent = _sidebarComponent.Clone();
            BlockBuilder localMainComponent = _mainComponent.Clone();
            BlockBuilder localContainerComponent = _containerComponent.Clone();

            localSideBarComponent.AddClasses(
                "dmb-container-sidebar",
                "flex-shrink-0",
                "align-self-stretch",
                "my-3",
                ResponsiveDisplayHelper.BuildVisibleFromCss(_sidebarShowFrom));

            localSideBarComponent.SetStyle("width", _sidebarWidth);
            localSideBarComponent.SetStyle("min-width", _sidebarMinWidth);
            localSideBarComponent.SetStyle("max-width", _sidebarMaxWidth);
            localSideBarComponent.SetAttribute("role", "container-sidebar");

            localMainComponent.AddClasses("dmb-container-main", "flex-grow-1", "min-w-0", "mx-3");
            localMainComponent.SetAttribute("role", "container-main");

            localContainerComponent.AddClasses(
                "dmb-container",
                "p-0",
                "d-flex",
                "align-items-stretch",
                _containerStyle.GetCss());

            localContainerComponent.SetAttribute("role", "container");

            if (_switchableToFluid)
            {
                localContainerComponent.SetData("switchable-fluid", "true");
                localContainerComponent.SetData("switchable-reverse", _containerStyle.GetCss());
            }

            _textWriter.Write($"""
                               <div{localContainerComponent.BuildAttributes()}>
                                   <div{localSideBarComponent.BuildAttributes()}>
                               """);

            _sidebar!.Render(HtmlHelper).WriteTo(_textWriter, System.Text.Encodings.Web.HtmlEncoder.Default);

            _textWriter.Write($"""
                                   </div>
                                   <div{localMainComponent.BuildAttributes()}>
                               """);
        }

        #endregion
    }
}