using System.Net;
using System.Text.Encodings.Web;
using DMBPageBuilder;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Builds and renders the BootstrapBuilder tab area component or page region.
    /// </summary>
    public sealed class TabAreaBuilder :
        HtmlBuilderBase<TabAreaBuilder>,
        ICanUseTabArea,
        IDisposable
    {
        #region Constants

        internal const string CurrentContextKey = "__DMB_CURRENT_TABAREA__";

        #endregion

        #region Static methods

        internal static TabAreaBuilder? GetCurrent(IHtmlHelper html)
        {
            if (html?.ViewContext?.HttpContext?.Items == null)
            {
                return null;
            }

            return html.ViewContext.HttpContext.Items.TryGetValue(CurrentContextKey, out object? value)
                ? value as TabAreaBuilder
                : null;
        }

        private static string JoinClasses(params string[] parts)
        {
            return string.Join(" ",
                parts
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .SelectMany(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                    .Distinct(StringComparer.Ordinal));
        }

        private static void SetCurrent(IHtmlHelper html, TabAreaBuilder? builder)
        {
            if (html?.ViewContext?.HttpContext?.Items == null)
            {
                return;
            }

            if (builder == null)
            {
                html.ViewContext.HttpContext.Items.Remove(CurrentContextKey);
            }
            else
            {
                html.ViewContext.HttpContext.Items[CurrentContextKey] = builder;
            }
        }

        #endregion

        #region Instance fields and properties

        private string _contentClasses
        {
            get => GetInternal("_contentClasses", string.Empty);
            set => SetInternal("_contentClasses", value);
        }

        private bool _disposed
        {
            get => GetInternal("_disposed", false);
            set => SetInternal("_disposed", value);
        }

        private bool _enableHashNavigation
        {
            get => GetInternal("_enableHashNavigation", false);
            set => SetInternal("_enableHashNavigation", value);
        }

        private string _navClasses
        {
            get => GetInternal("_navClasses", string.Empty);
            set => SetInternal("_navClasses", value);
        }

        private readonly TextWriter _outputWriter;

        private bool _started
        {
            get => GetInternal("_started", false);
            set => SetInternal("_started", value);
        }

        private readonly List<TabDefinition> _tabs = new();

        private bool _updateHashOnTabChange
        {
            get => GetInternal("_updateHashOnTabChange", false);
            set => SetInternal("_updateHashOnTabChange", value);
        }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TabAreaBuilder"/> class.
        /// </summary>
        /// <param name="writer">The writer that receives the rendered HTML output.</param>
        /// <param name="html">The Razor HTML helper used to access view context and services.</param>
        public TabAreaBuilder(TextWriter writer, IHtmlHelper html)
            : base(writer, html)
        {
            _tag = "div";
            InternalAddClass("dmb-tab-area");
            _outputWriter = html.ViewContext.Writer;
            SetData("tab-area", "true");
        }

        #endregion

        #region Instance methods

        /// <summary>
        /// Executes the BootstrapBuilder begin operation.
        /// </summary>
        /// <returns>The configured <see cref="TabAreaBuilder"/> value or BootstrapBuilder result.</returns>
        public TabAreaBuilder Begin()
        {
            if (_started)
            {
                return this;
            }

            _started = true;

            if (string.IsNullOrWhiteSpace(GetId()))
            {
                SetEnsureId("tabs");
            }

            SetCurrent(_htmlHelper, this);
            return this;
        }

        private string BuildNavCss()
        {
            TabAreaComposer? composer = GetCssComposer<TabAreaComposer>();

            List<string> classes = new();

            if (composer != null)
            {
                classes.AddRange(composer.BuildClasses());
            }

            if (!string.IsNullOrWhiteSpace(_navClasses))
            {
                classes.AddRange(_navClasses.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            }

            return string.Join(" ",
                classes
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Distinct(StringComparer.Ordinal));
        }

        private string BuildRootAttributes()
        {
            string classValue = string.Join(" ",
                GetComponentClasses()
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Distinct(StringComparer.Ordinal));

            string styleValue = BuildStyleValue();

            List<string> attributes = new();

            if (!string.IsNullOrWhiteSpace(classValue))
            {
                attributes.Add($@"class=""{HtmlEncoder.Default.Encode(classValue)}""");
            }

            if (!string.IsNullOrWhiteSpace(styleValue))
            {
                attributes.Add($@"style=""{HtmlEncoder.Default.Encode(styleValue)}""");
            }

            attributes.AddRange(
                _attributes
                    .Where(x => !string.Equals(x.Key, "class", StringComparison.OrdinalIgnoreCase))
                    .Where(x => !string.Equals(x.Key, "style", StringComparison.OrdinalIgnoreCase))
                    .Where(x => !string.IsNullOrWhiteSpace(x.Value))
                    .Select(x =>
                    {
                        if (string.Equals(x.Key, "disabled", StringComparison.OrdinalIgnoreCase) &&
                            string.Equals(x.Value, "disabled", StringComparison.OrdinalIgnoreCase))
                        {
                            return x.Key;
                        }

                        return $@"{x.Key}=""{HtmlEncoder.Default.Encode(x.Value)}""";
                    }));

            return attributes.Count > 0
                ? " " + string.Join(" ", attributes.Distinct(StringComparer.Ordinal))
                : string.Empty;
        }

        /// <summary>
        /// Executes the BootstrapBuilder enable hash navigation operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TabAreaBuilder"/> value or BootstrapBuilder result.</returns>
        public TabAreaBuilder EnableHashNavigation(bool value = true)
        {
            _enableHashNavigation = value;
            return this;
        }

        private void EnsureActiveTab()
        {
            if (_tabs.Any(x => x.Active && !x.Disabled))
            {
                return;
            }

            TabDefinition? firstEnabled = _tabs.FirstOrDefault(x => !x.Disabled);
            if (firstEnabled != null)
            {
                firstEnabled.Active = true;
            }
        }

        /// <summary>
        /// Executes the BootstrapBuilder fill operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TabAreaBuilder"/> value or BootstrapBuilder result.</returns>
        public TabAreaBuilder Fill(bool value = true)
        {
            return this.SetTabAreaFill(value);
        }

        /// <summary>
        /// Executes the BootstrapBuilder justified operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TabAreaBuilder"/> value or BootstrapBuilder result.</returns>
        public TabAreaBuilder Justified(bool value = true)
        {
            return this.SetTabAreaJustified(value);
        }

        /// <summary>
        /// Executes the BootstrapBuilder pills operation.
        /// </summary>
        /// <returns>The configured <see cref="TabAreaBuilder"/> value or BootstrapBuilder result.</returns>
        public TabAreaBuilder Pills()
        {
            return this.SetTabAreaStyle(TabAreaStyle.Pills);
        }

        internal void RegisterTab(TabDefinition tab)
        {
            ArgumentNullException.ThrowIfNull(tab);

            int index = _tabs.Count;

            string tabId = string.IsNullOrWhiteSpace(tab.Id)
                ? $"{GetId()}_tab_{index}"
                : HtmlIdGenerator.CleanId(tab.Id) ?? $"{GetId()}_tab_{index}";

            string paneId = $"{tabId}_pane";

            tab.Id = tabId;
            tab.PaneId = paneId;

            _tabs.Add(tab);
        }

        protected override TabAreaBuilder CreateInstance()
        {
            return new TabAreaBuilder(_textWriter, _htmlHelper);
        }

        protected override void InternalClone(TabAreaBuilder source)
        {
            base.InternalClone(source);

            _contentClasses = source._contentClasses;
            _disposed = false;
            _enableHashNavigation = source._enableHashNavigation;
            _navClasses = source._navClasses;
            _started = false;
            _tabs.Clear();
            _tabs.AddRange(source._tabs.Select(x => x.Clone()));
            _updateHashOnTabChange = source._updateHashOnTabChange;
        }

        protected override void WriteToCore(TextWriter writer, HtmlEncoder encoder)
        {
            if (_tabs.Count == 0)
            {
                return;
            }

            EnsureActiveTab();

            string navCss = BuildNavCss();
            string contentCss = JoinClasses("tab-content", _contentClasses);

            List<string> navItems = new();
            List<string> panes = new();

            foreach (TabDefinition tab in _tabs)
            {
                navItems.Add(RenderNavItem(tab));
                panes.Add(RenderPane(tab));
            }

            string hashScript = (_enableHashNavigation || _updateHashOnTabChange)
                ? RenderHashNavigationScript()
                : string.Empty;

            writer.Write($"""
                         <div{BuildRootAttributes()}>
                             <ul class="{WebUtility.HtmlEncode(navCss)}" role="tablist">
                                 {string.Join(Environment.NewLine, navItems)}
                             </ul>
                             <div class="{WebUtility.HtmlEncode(contentCss)}">
                                 {string.Join(Environment.NewLine, panes)}
                             </div>
                         </div>
                         {hashScript}
                         """);
        }

        /// <summary>
        /// Renders value for the BootstrapBuilder output.
        /// </summary>
        /// <returns>The rendered HTML content for the BootstrapBuilder component.</returns>
        public override IHtmlContent Render()
        {
            throw new NotImplementedException();
        }private string RenderHashNavigationScript()
        {
            string id = WebUtility.HtmlEncode(GetId());

            string updateHashScript = _updateHashOnTabChange
                ? @"
    triggerTabList.forEach(function(triggerEl) {
        triggerEl.addEventListener('shown.bs.tab', function (event) {
            var target = event.target.getAttribute('data-bs-target');
            if (target) {
                history.replaceState(null, '', target);
            }
        });
    });"
                : string.Empty;

            string enableHashScript = _enableHashNavigation
                ? @"
    window.addEventListener('hashchange', activateFromHash);
    activateFromHash();"
                : string.Empty;

            return @$"
<script>
(function() {{
    function initTabAreaHashNavigation() {{
        var root = document.getElementById('{id}');
        if (!root) {{
            return;
        }}

        if (typeof bootstrap === 'undefined' || !bootstrap.Tab) {{
            return;
        }}

        var triggerTabList = [].slice.call(root.querySelectorAll('[data-bs-toggle=""tab""]'));

        function activateFromHash() {{
            var hash = window.location.hash;
            if (!hash) {{
                return;
            }}

            var button = root.querySelector('[data-bs-target=""' + hash + '""]');
            if (!button) {{
                return;
            }}

            var tab = bootstrap.Tab.getOrCreateInstance(button);
            tab.show();
        }}
{updateHashScript}
{enableHashScript}
    }}

    if (document.readyState === 'loading') {{
        document.addEventListener('DOMContentLoaded', initTabAreaHashNavigation);
    }} else {{
        initTabAreaHashNavigation();
    }}
}})();
</script>";
        }

        private string RenderNavItem(TabDefinition tab)
        {
            string activeCss = tab.Active ? " active" : string.Empty;
            string disabledCss = tab.Disabled ? " disabled" : string.Empty;
            string selected = tab.Active ? "true" : "false";
            string tabindex = tab.Disabled ? """ tabindex="-1" aria-disabled="true" """ : string.Empty;

            string content = RenderTabTitle(tab);

            return $"""
                    <li class="nav-item" role="presentation">
                        <button class="nav-link{activeCss}{disabledCss}"
                                id="{WebUtility.HtmlEncode(tab.Id)}"
                                data-bs-toggle="tab"
                                data-bs-target="#{WebUtility.HtmlEncode(tab.PaneId)}"
                                type="button"
                                role="tab"
                                aria-controls="{WebUtility.HtmlEncode(tab.PaneId)}"
                                aria-selected="{selected}"{tabindex}>
                            {content}
                        </button>
                    </li>
                    """;
        }

        private string RenderPane(TabDefinition tab)
        {
            List<string> classes = new() { "tab-pane" };

            if (tab.Fade)
            {
                classes.Add("fade");
            }

            if (tab.Active)
            {
                classes.Add("show");
                classes.Add("active");
            }

            string css = string.Join(" ", classes);

            return $"""
                    <div class="{css}"
                         id="{WebUtility.HtmlEncode(tab.PaneId)}"
                         role="tabpanel"
                         aria-labelledby="{WebUtility.HtmlEncode(tab.Id)}"
                         tabindex="0">
                        {tab.ContentHtml}
                    </div>
                    """;
        }

        private string RenderTabTitle(TabDefinition tab)
        {
            using StringWriter writer = new();

            if (!tab.Icon.IsEmpty)
            {
                HtmlLayoutExtensions.IconBuilder(_htmlHelper, tab.Icon, null, null)
                    .WriteTo(writer, HtmlEncoder.Default);
            }

            if (!string.IsNullOrWhiteSpace(tab.Title))
            {
                if (writer.GetStringBuilder().Length > 0)
                {
                    writer.Write(" ");
                }

                writer.Write($"""<span>{WebUtility.HtmlEncode(tab.Title)}</span>""");
            }

            if (!string.IsNullOrWhiteSpace(tab.Subtitle))
            {
                writer.Write($""" <small class="text-muted">{WebUtility.HtmlEncode(tab.Subtitle)}</small>""");
            }

            string badgesHtml = RenderBadges(tab);
            if (!string.IsNullOrWhiteSpace(badgesHtml))
            {
                writer.Write(" ");
                writer.Write(badgesHtml);
            }

            return writer.ToString();
        }

        private string RenderBadges(TabDefinition tab)
        {
            if (tab.Badges == null || tab.Badges.Count == 0)
            {
                return string.Empty;
            }

            using StringWriter writer = new();
            writer.Write("""<span class="d-inline-flex align-items-center gap-1">""");

            foreach (BadgeBuilder badge in tab.Badges)
            {
                badge.WriteTo(writer, HtmlEncoder.Default);
            }

            writer.Write("</span>");
            return writer.ToString();
        }

        /// <summary>
        /// Executes the BootstrapBuilder style operation.
        /// </summary>
        /// <param name="style">The style value.</param>
        /// <returns>The configured <see cref="TabAreaBuilder"/> value or BootstrapBuilder result.</returns>
        public TabAreaBuilder Style(TabAreaStyle style)
        {
            return this.SetTabAreaStyle(style);
        }

        /// <summary>
        /// Executes the BootstrapBuilder tabs operation.
        /// </summary>
        /// <returns>The configured <see cref="TabAreaBuilder"/> value or BootstrapBuilder result.</returns>
        public TabAreaBuilder Tabs()
        {
            return this.SetTabAreaStyle(TabAreaStyle.Tabs);
        }

        /// <summary>
        /// Executes the BootstrapBuilder underline operation.
        /// </summary>
        /// <returns>The configured <see cref="TabAreaBuilder"/> value or BootstrapBuilder result.</returns>
        public TabAreaBuilder Underline()
        {
            return this.SetTabAreaStyle(TabAreaStyle.Underline);
        }

        /// <summary>
        /// Executes the BootstrapBuilder update hash on tab change operation.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TabAreaBuilder"/> value or BootstrapBuilder result.</returns>
        public TabAreaBuilder UpdateHashOnTabChange(bool value = true)
        {
            _updateHashOnTabChange = value;
            return this;
        }

        /// <summary>
        /// Configures content classes on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="classes">The classes value.</param>
        /// <returns>The configured <see cref="TabAreaBuilder"/> value or BootstrapBuilder result.</returns>
        public TabAreaBuilder WithContentClasses(string classes)
        {
            _contentClasses = classes ?? string.Empty;
            return this;
        }

        /// <summary>
        /// Configures nav classes on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="classes">The classes value.</param>
        /// <returns>The configured <see cref="TabAreaBuilder"/> value or BootstrapBuilder result.</returns>
        public TabAreaBuilder WithNavClasses(string classes)
        {
            _navClasses = classes ?? string.Empty;
            return this;
        }

        #region From interface IDisposable

        /// <summary>
        /// Executes the BootstrapBuilder dispose operation.
        /// </summary>
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;
            SetCurrent(_htmlHelper, null);

            if (!_started)
            {
                return;
            }

            WriteTo(_outputWriter, HtmlEncoder.Default);
        }

        #endregion

        #endregion
    }
}