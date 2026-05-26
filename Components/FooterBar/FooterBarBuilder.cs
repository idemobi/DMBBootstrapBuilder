#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj FooterBarBuilder.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

using System.Net;
using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Builds and renders the BootstrapBuilder footer bar component or page region.
    /// </summary>
    public class FooterBarBuilder : HtmlTagBuilder<FooterBarBuilder>
    {
        #region Static fields and properties

        /// <summary>
        /// Stores the gap icon value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public static string GapIcon = "gap-1";

        #endregion

        #region Static methods

        private static string ConvertToString(IHtmlContent content)
        {
            using StringWriter writer = new();
            content.WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        }

        private static string GetBreakpointColumnClass(ResponsiveBreakpoint breakpoint)
        {
            return breakpoint switch
            {
                ResponsiveBreakpoint.Xs => "col",
                ResponsiveBreakpoint.Sm => "col-sm",
                ResponsiveBreakpoint.Md => "col-md",
                ResponsiveBreakpoint.Lg => "col-lg",
                ResponsiveBreakpoint.Xl => "col-xl",
                ResponsiveBreakpoint.Xxl => "col-xxl",
                _ => "col-lg"
            };
        }

        private static string GetRelAttribute(UrlActionItem item)
        {
            if (string.IsNullOrWhiteSpace(item.Rel))
            {
                return string.Empty;
            }

            return $""" rel="{WebUtility.HtmlEncode(item.Rel)}" """;
        }

        private static string GetTargetAttribute(UrlActionItem item)
        {
            if (string.IsNullOrWhiteSpace(item.Target))
            {
                return string.Empty;
            }

            return $""" target="{WebUtility.HtmlEncode(item.Target)}" """;
        }

        private static string JoinClasses(params string[] values)
        {
            return string.Join(" ", values.Where(x => !string.IsNullOrWhiteSpace(x)));
        }

        #endregion

        #region Instance fields and properties

        private ContainerStyle _beforeContainerStyle = ContainerStyle.Lg;
        private IHtmlContent? _beforeFooter;
        private string _beforeFooterClasses = string.Empty;
        private ResponsiveBreakpoint _columnBreakpoint = ResponsiveBreakpoint.Lg;
        private readonly List<List<GroupActionItem>> _columns = new();
        private string _footerClasses = string.Empty;
        private string _mainFooterClasses = string.Empty;
        private ContainerStyle _mainContainerStyle = ContainerStyle.Lg;
        private string? _mission;
        private string? _missionTitle;
        private ContainerStyle _noticeContainerStyle = ContainerStyle.Fluid;
        private IHtmlContent? _noticeFooter;
        private string _noticeFooterClasses = string.Empty;
        private SpacingSize _padding = SpacingSize.Three;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FooterBarBuilder"/> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public FooterBarBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
        }

        #endregion

        #region Instance methods

        /// <summary>
        /// Adds column to the current BootstrapBuilder component or page model.
        /// </summary>
        /// <param name="groups">The groups value.</param>
        /// <returns>The configured <see cref="FooterBarBuilder"/> value or BootstrapBuilder result.</returns>
        public FooterBarBuilder AddColumn(params GroupActionItem[] groups)
        {
            List<GroupActionItem> list = new();

            if (groups != null)
            {
                foreach (GroupActionItem group in groups)
                {
                    if (group != null)
                    {
                        list.Add(group);
                    }
                }
            }

            if (list.Count > 0)
            {
                _columns.Add(list);
            }

            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder before container operation.
        /// </summary>
        /// <param name="style">The style value.</param>
        /// <returns>The configured <see cref="FooterBarBuilder"/> value or BootstrapBuilder result.</returns>
        public FooterBarBuilder BeforeContainer(ContainerStyle style)
        {
            _beforeContainerStyle = style;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder before footer operation.
        /// </summary>
        /// <param name="content">The content value.</param>
        /// <returns>The configured <see cref="FooterBarBuilder"/> value or BootstrapBuilder result.</returns>
        public FooterBarBuilder BeforeFooter(IHtmlContent? content)
        {
            _beforeFooter = content;
            return this;
        }

        private string BuildAspRouteUrl(AspRouteActionItem item)
        {
            IUrlHelperFactory factory =
                (IUrlHelperFactory)_htmlHelper.ViewContext.HttpContext.RequestServices.GetService(typeof(IUrlHelperFactory))!;

            IUrlHelper urlHelper = factory.GetUrlHelper(_htmlHelper.ViewContext);

            Dictionary<string, object?> routeValues = new();

            if (!string.IsNullOrWhiteSpace(item.AspArea))
            {
                routeValues["area"] = item.AspArea;
            }

            foreach (KeyValuePair<string, string?> kvp in item.RouteValues)
            {
                routeValues[kvp.Key] = kvp.Value;
            }

            UrlActionContext actionContext = new()
            {
                Action = item.AspAction,
                Controller = item.AspController,
                Values = routeValues
            };

            return urlHelper.Action(actionContext) ?? "#";
        }

        /// <summary>
        /// Executes the BootstrapBuilder column breakpoint operation.
        /// </summary>
        /// <param name="breakpoint">The breakpoint value.</param>
        /// <returns>The configured <see cref="FooterBarBuilder"/> value or BootstrapBuilder result.</returns>
        public FooterBarBuilder ColumnBreakpoint(ResponsiveBreakpoint breakpoint)
        {
            _columnBreakpoint = breakpoint;
            return this;
        }

        protected override FooterBarBuilder CreateInstance()
        {
            return new FooterBarBuilder(_textWriter, _htmlHelper);
        }

        protected override void InternalClone(FooterBarBuilder source)
        {
            base.InternalClone(source);

            _beforeContainerStyle = source._beforeContainerStyle;
            _beforeFooter = source._beforeFooter;
            _beforeFooterClasses = source._beforeFooterClasses;
            _columnBreakpoint = source._columnBreakpoint;
            _footerClasses = source._footerClasses;
            _mainFooterClasses = source._mainFooterClasses;
            _mainContainerStyle = source._mainContainerStyle;
            _mission = source._mission;
            _missionTitle = source._missionTitle;
            _noticeContainerStyle = source._noticeContainerStyle;
            _noticeFooter = source._noticeFooter;
            _noticeFooterClasses = source._noticeFooterClasses;
            _padding = source._padding;

            _columns.Clear();
            foreach (List<GroupActionItem> column in source._columns)
            {
                _columns.Add(new List<GroupActionItem>(column));
            }
        }

        /// <summary>
        /// Executes the BootstrapBuilder main container operation.
        /// </summary>
        /// <param name="style">The style value.</param>
        /// <returns>The configured <see cref="FooterBarBuilder"/> value or BootstrapBuilder result.</returns>
        public FooterBarBuilder MainContainer(ContainerStyle style)
        {
            _mainContainerStyle = style;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder mission operation.
        /// </summary>
        /// <param name="mission">The mission value.</param>
        /// <returns>The configured <see cref="FooterBarBuilder"/> value or BootstrapBuilder result.</returns>
        public FooterBarBuilder Mission(string? mission)
        {
            _mission = mission;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder mission title operation.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <returns>The configured <see cref="FooterBarBuilder"/> value or BootstrapBuilder result.</returns>
        public FooterBarBuilder MissionTitle(string? title)
        {
            _missionTitle = title;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder notice container operation.
        /// </summary>
        /// <param name="style">The style value.</param>
        /// <returns>The configured <see cref="FooterBarBuilder"/> value or BootstrapBuilder result.</returns>
        public FooterBarBuilder NoticeContainer(ContainerStyle style)
        {
            _noticeContainerStyle = style;
            return this;
        }

        /// <summary>
        /// Executes the BootstrapBuilder notice footer operation.
        /// </summary>
        /// <param name="content">The content value.</param>
        /// <returns>The configured <see cref="FooterBarBuilder"/> value or BootstrapBuilder result.</returns>
        public FooterBarBuilder NoticeFooter(IHtmlContent? content)
        {
            _noticeFooter = content;
            return this;
        }

        /// <summary>
        /// Renders column for the BootstrapBuilder output.
        /// </summary>
        /// <param name="groups">The groups value.</param>
        /// <param name="breakpointCol">The breakpoint col value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public virtual string RenderColumn(List<GroupActionItem> groups, string breakpointCol)
        {
            if (groups == null || groups.Count == 0)
            {
                return string.Empty;
            }

            List<string> groupsHtml = new();

            foreach (GroupActionItem group in groups)
            {
                string html = RenderGroup(group);
                if (!string.IsNullOrWhiteSpace(html))
                {
                    groupsHtml.Add(html);
                }
            }

            if (groupsHtml.Count == 0)
            {
                return string.Empty;
            }

            return $"""
                    <div class="col-12 {breakpointCol}">
                        <div class="d-flex flex-column">
                            {string.Join(Environment.NewLine, groupsHtml)}
                        </div>
                    </div>
                    """;
        }

        /// <summary>
        /// Renders group for the BootstrapBuilder output.
        /// </summary>
        /// <param name="group">The group value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public virtual string RenderGroup(GroupActionItem group)
        {
            if (group == null)
            {
                return string.Empty;
            }

            string title = group.Title ?? string.Empty;
            string iconHtml = group.Icon.IsEmpty
                ? string.Empty
                : ConvertToString(HtmlLayoutExtensions.IconBuilder(_htmlHelper, group.Icon));

            string titleHtml = string.IsNullOrWhiteSpace(title)
                ? string.Empty
                : $"""
                   <div class="footer-bar-group-title fw-bold text-uppercase mb-2"><span class="d-inline-flex {GapIcon}">{iconHtml}<span>{WebUtility.HtmlEncode(title)}</span></span></div>
                   """;

            List<string> itemsHtml = new();

            foreach (IActionItem item in group.Items)
            {
                string html = RenderItem(item);
                if (!string.IsNullOrWhiteSpace(html))
                {
                    itemsHtml.Add(html);
                }
            }

            if (string.IsNullOrWhiteSpace(titleHtml) && itemsHtml.Count == 0)
            {
                return string.Empty;
            }

            return $"""
                    <div class="footer-bar-group mb-3">{titleHtml}
                        <nav class="nav flex-column">
                            {string.Join(Environment.NewLine, itemsHtml)}
                        </nav>
                    </div>
                    """;
        }

        /// <summary>
        /// Renders item for the BootstrapBuilder output.
        /// </summary>
        /// <param name="item">The item value.</param>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public virtual string RenderItem(IActionItem item)
        {
            if (item == null)
            {
                return string.Empty;
            }

            if (item is DividerActionItem)
            {
                return """<hr class="nav-divider my-1">""";
            }

            if (item is IGuardedActionItem guarded)
            {
                return RenderItem(guarded.InnerAction);
            }

            if (item is GroupActionItem nestedGroup)
            {
                return RenderGroup(nestedGroup);
            }

            string title = item.Title ?? string.Empty;
            string iconHtml = item.Icon.IsEmpty
                ? string.Empty
                : ConvertToString(HtmlLayoutExtensions.IconBuilder(_htmlHelper, item.Icon));

            string content = $"""
                              <span class="d-inline-flex align-items-start {GapIcon}">{iconHtml}<span>{WebUtility.HtmlEncode(title)}</span></span>
                              """;

            switch (item)
            {
                case UrlActionItem url:
                    return $"""
                            <a class="nav-link m-0 p-0 {GapIcon}" href="{WebUtility.HtmlEncode(url.Url ?? "#")}"{GetTargetAttribute(url)}{GetRelAttribute(url)}>{content}</a>
                            """;

                case AspRouteActionItem route:
                    return $"""
                            <a class="nav-link m-0 p-0 {GapIcon}" href="{WebUtility.HtmlEncode(BuildAspRouteUrl(route))}">{content}</a>
                            """;

                case JavaScriptActionItem js:
                    return $"""
                            <button type="button" class="nav-link m-0 p-0 {GapIcon}" onclick="{HtmlEncoder.Default.Encode(js.JavaScript ?? string.Empty)}">{content}</button>
                            """;

                case ModalActionItem modal:
                    return $"""
                            <button type="button" class="nav-link m-0 p-0 {GapIcon}" data-bs-toggle="modal" data-bs-target="#{WebUtility.HtmlEncode(modal.ModalTargetId ?? string.Empty)}">{content}</button>
                            """;

                default:
                    return $"""
                            <div class="nav-link m-0 p-0 {GapIcon}">{content}</div>
                            """;
            }
        }

        /// <summary>
        /// Renders main content for the BootstrapBuilder output.
        /// </summary>
        /// <returns>The rendered HTML content for the BootstrapBuilder component.</returns>
        public virtual IHtmlContent RenderMainContent()
        {
            bool hasMission = !string.IsNullOrWhiteSpace(_missionTitle) || !string.IsNullOrWhiteSpace(_mission);
            string breakpointCol = GetBreakpointColumnClass(_columnBreakpoint);

            string missionHtml = hasMission
                ? $"""
                   <div class="col-12 {breakpointCol}">
                       <div class="footer-bar-mission">
                           {RenderMission()}
                       </div>
                   </div>
                   """
                : string.Empty;

            List<string> columnsHtml = new();

            foreach (List<GroupActionItem> column in _columns)
            {
                string html = RenderColumn(column, breakpointCol);
                if (!string.IsNullOrWhiteSpace(html))
                {
                    columnsHtml.Add(html);
                }
            }

            return new HtmlString($"""
                                   <div class="row g-3">
                                       {missionHtml}
                                       {string.Join(Environment.NewLine, columnsHtml)}
                                   </div>
                                   """);
        }

        /// <summary>
        /// Renders mission for the BootstrapBuilder output.
        /// </summary>
        /// <returns>The generated CSS class string, HTML attribute string, or rendered text value.</returns>
        public virtual string RenderMission()
        {
            string titleHtml = string.IsNullOrWhiteSpace(_missionTitle)
                ? string.Empty
                : $"""<h2 class="footer-bar-mission-title mb-3">{WebUtility.HtmlEncode(_missionTitle)}</h2>""";

            string textHtml = string.IsNullOrWhiteSpace(_mission)
                ? string.Empty
                : $"""<div class="footer-bar-mission-text">{WebUtility.HtmlEncode(_mission)}</div>""";

            return $"{titleHtml}{textHtml}";
        }

        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            PageInformation page = PageRegistry.GetOrCreatePageInformation(_htmlHelper.ViewContext.HttpContext);
            page.SetStylesheet("/css/FooterBar.css");

            string rootCss = JoinClasses("footer-bar", "mt-auto", _footerClasses);

            FooterBarSectionBuilder beforeSection = new FooterBarSectionBuilder(_htmlHelper, JoinClasses("footer-bar-before", _beforeFooterClasses))
                .Container(_beforeContainerStyle)
                .Content(_beforeFooter);

            FooterBarSectionBuilder mainSection = new FooterBarSectionBuilder(_htmlHelper, JoinClasses("footer-bar-main p-5", _mainFooterClasses))
                .Container(_mainContainerStyle)
                .Content(RenderMainContent());

            FooterBarSectionBuilder noticeSection = new FooterBarSectionBuilder(_htmlHelper, JoinClasses("footer-bar-notice", _noticeFooterClasses))
                .Container(_noticeContainerStyle)
                .Content(_noticeFooter);

            writer.Write($"""
                          <div class="{WebUtility.HtmlEncode(rootCss)}">
                              {ConvertToString(beforeSection.Render())}
                              {ConvertToString(mainSection.Render())}
                              {ConvertToString(noticeSection.Render())}
                          </div>
                          """);
        }

        /// <summary>
        /// Configures before footer classes on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="classes">The classes value.</param>
        /// <returns>The configured <see cref="FooterBarBuilder"/> value or BootstrapBuilder result.</returns>
        public FooterBarBuilder WithBeforeFooterClasses(string classes)
        {
            _beforeFooterClasses = classes ?? string.Empty;
            return this;
        }

        /// <summary>
        /// Configures footer classes on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="classes">The classes value.</param>
        /// <returns>The configured <see cref="FooterBarBuilder"/> value or BootstrapBuilder result.</returns>
        public FooterBarBuilder WithFooterClasses(string classes)
        {
            _footerClasses = classes ?? string.Empty;
            return this;
        }

        /// <summary>
        /// Configures main footer classes on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="classes">The classes value.</param>
        /// <returns>The configured <see cref="FooterBarBuilder"/> value or BootstrapBuilder result.</returns>
        public FooterBarBuilder WithMainFooterClasses(string classes)
        {
            _mainFooterClasses = classes ?? string.Empty;
            return this;
        }

        /// <summary>
        /// Configures notice footer classes on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="classes">The classes value.</param>
        /// <returns>The configured <see cref="FooterBarBuilder"/> value or BootstrapBuilder result.</returns>
        public FooterBarBuilder WithNoticeFooterClasses(string classes)
        {
            _noticeFooterClasses = classes ?? string.Empty;
            return this;
        }

        #endregion
    }
}
