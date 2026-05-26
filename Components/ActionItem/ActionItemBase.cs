#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// DMBBootstrapBuilder.csproj ActionItemBase.cs create at 2026/04/07 21:04:27
// ©2024-2026 idéMobi SARL FRANCE

#endregion

#region

#endregion

#region

using DMBPageBuilder;

#endregion

namespace DMBBootstrapBuilder
{
    /// <summary>
    /// Represents the BootstrapBuilder action item base component or support type.
    /// </summary>
    /// <typeparam name="TSelf">The BootstrapBuilder type configured by this member.</typeparam>
    public abstract class ActionItemBase<TSelf> : IActionItem
        where TSelf : ActionItemBase<TSelf>
    {
        #region Instance fields and properties

        private readonly Dictionary<string, string> _htmlAttributes = new(StringComparer.OrdinalIgnoreCase);

        #region From interface IActionItem

        /// <summary>
        /// Gets or sets the active value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// Gets or sets the additional classes value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string AdditionalClasses { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the badge style value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public VariantStyle BadgeStyle { get; set; } = VariantStyle.Danger;

        /// <summary>
        /// Gets or sets the badge text value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? BadgeText { get; set; }

        /// <summary>
        /// Gets or sets the debug only value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool DebugOnly { get; set; }

        /// <summary>
        /// Gets or sets the disabled value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// Gets or sets the html attributes value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public IReadOnlyDictionary<string, string> HtmlAttributes => _htmlAttributes;
        /// <summary>
        /// Gets or sets the icon value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public IconStruct Icon { get; set; }
        /// <summary>
        /// Gets or sets the id value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the outline value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public bool Outline { get; set; }
        /// <summary>
        /// Gets or sets the size value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public BoostrapButtonSize Size { get; set; } = BoostrapButtonSize.Small;
        /// <summary>
        /// Gets or sets the subtitle value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? Subtitle { get; set; }

        /// <summary>
        /// Gets or sets the title value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the variant value used by BootstrapBuilder rendering or composition.
        /// </summary>
        public VariantStyle Variant { get; set; } = VariantStyle.Normal;

        #endregion

        #endregion

        #region Instance methods

        /// <summary>
        /// Removes attribut from the current BootstrapBuilder component or composer.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <returns>The configured <see cref="TSelf"/> value or BootstrapBuilder result.</returns>
        public TSelf RemoveAttribut(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                _htmlAttributes.Remove(name);
            }

            return This();
        }

        /// <summary>
        /// Configures active on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="active">True to enable active; otherwise, false.</param>
        /// <returns>The configured <see cref="TSelf"/> value or BootstrapBuilder result.</returns>
        public TSelf SetActive(bool active = true)
        {
            Active = active;
            return This();
        }

        /// <summary>
        /// Configures additional classes on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="classes">The classes value.</param>
        /// <returns>The configured <see cref="TSelf"/> value or BootstrapBuilder result.</returns>
        public TSelf SetAdditionalClasses(string classes)
        {
            AdditionalClasses = classes ?? string.Empty;
            return This();
        }

        /// <summary>
        /// Configures aria attribut on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TSelf"/> value or BootstrapBuilder result.</returns>
        public TSelf SetAriaAttribut(string name, string value)
        {
            return SetAttribut($"aria-{name}", value);
        }

        /// <summary>
        /// Configures aria attribut on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TSelf"/> value or BootstrapBuilder result.</returns>
        public TSelf SetAriaAttribut(string name, bool value)
        {
            return SetAttribut($"aria-{name}", value);
        }

        /// <summary>
        /// Configures attribut on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TSelf"/> value or BootstrapBuilder result.</returns>
        public TSelf SetAttribut(string name, string value)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name));
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                _htmlAttributes.Remove(name);
            }
            else
            {
                _htmlAttributes[name] = value;
            }

            return (TSelf)this;
        }

        /// <summary>
        /// Configures attribut on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TSelf"/> value or BootstrapBuilder result.</returns>
        public TSelf SetAttribut(string name, bool value)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name));
            }

            _htmlAttributes[name] = value.ToString().ToLower();

            return (TSelf)this;
        }

        /// <summary>
        /// Configures badge on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <param name="style">The style value.</param>
        /// <returns>The configured <see cref="TSelf"/> value or BootstrapBuilder result.</returns>
        public TSelf SetBadge(string text, VariantStyle style = VariantStyle.Danger)
        {
            BadgeText = text;
            BadgeStyle = style;
            return This();
        }

        /// <summary>
        /// Configures data attribut on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TSelf"/> value or BootstrapBuilder result.</returns>
        public TSelf SetDataAttribut(string name, string value)
        {
            return SetAttribut($"data-{name}", value);
        }

        /// <summary>
        /// Configures data attribut on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="name">The name value.</param>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TSelf"/> value or BootstrapBuilder result.</returns>
        public TSelf SetDataAttribut(string name, bool value)
        {
            return SetAttribut($"data-{name}", value);
        }

        /// <summary>
        /// Configures debug only on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TSelf"/> value or BootstrapBuilder result.</returns>
        public TSelf SetDebugOnly(bool value = true)
        {
            DebugOnly = value;
            return This();
        }

        /// <summary>
        /// Configures disabled on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="disabled">True to enable disabled; otherwise, false.</param>
        /// <returns>The configured <see cref="TSelf"/> value or BootstrapBuilder result.</returns>
        public TSelf SetDisabled(bool disabled = true)
        {
            Disabled = disabled;
            return This();
        }

        /// <summary>
        /// Configures icon on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="icon">The icon value.</param>
        /// <returns>The configured <see cref="TSelf"/> value or BootstrapBuilder result.</returns>
        public TSelf SetIcon(IconStruct icon)
        {
            Icon = icon;
            return This();
        }

        /// <summary>
        /// Configures id on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="id">The id value.</param>
        /// <returns>The configured <see cref="TSelf"/> value or BootstrapBuilder result.</returns>
        public TSelf SetId(string id)
        {
            Id = HtmlIdGenerator.CleanId(id) ?? string.Empty;
            return This();
        }

        // TODO move in extension class 
        // public TSelf SetLocalizedBadge(string badgeKey, VariantStyle style = VariantStyle.Danger)
        // {
        //     #if DEBUG
        //     SetDataAttribut("badge-localized", true);
        //     SetDataAttribut("badge-key", badgeKey);
        //     #endif
        //     BadgeText = WebLocalizer.GetInternal(badgeKey);
        //     BadgeStyle = style;
        //     return This();
        // }

        // TODO move in extension class
        // public TSelf SetLocalizedIconBootstrap(string iconBootstrapKey)
        // {
        //     #if DEBUG
        //     SetDataAttribut("icon-bootstrap-localized", true);
        //     SetDataAttribut("icon-bootstrap-key", iconBootstrapKey);
        //     #endif
        //     Icon = IconStruct.BootstrapKey(iconBootstrapKey);
        //     return This();
        // }


        // TODO move in extension class 
        // public TSelf SetLocalizedSubtitle(string subtitleKey)
        // {
        //     #if DEBUG
        //     SetDataAttribut("subtitle-localized", true);
        //     SetDataAttribut("subtitle-key", subtitleKey);
        //     #endif
        //     Subtitle = WebLocalizer.GetInternal(subtitleKey);
        //     return This();
        // }

        // TODO move in extension class 
        // public TSelf SetLocalizedTitle(string titleKey, params object[] args)
        // {
        //     #if DEBUG
        //     SetDataAttribut("title-localized", true);
        //     SetDataAttribut("title-key", titleKey);
        //     #endif
        //     Title = WebLocalizer.GetInternal(titleKey, args);
        //     return This();
        // }

        /// <summary>
        /// Configures outlined on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="value">The value to apply.</param>
        /// <returns>The configured <see cref="TSelf"/> value or BootstrapBuilder result.</returns>
        public TSelf SetOutlined(bool value = true)
        {
            Outline = value;
            return This();
        }

        /// <summary>
        /// Configures size on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="size">The size value.</param>
        /// <returns>The configured <see cref="TSelf"/> value or BootstrapBuilder result.</returns>
        public TSelf SetSize(BoostrapButtonSize size)
        {
            Size = size;
            return This();
        }

        /// <summary>
        /// Configures subtitle on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="subtitle">The subtitle value.</param>
        /// <returns>The configured <see cref="TSelf"/> value or BootstrapBuilder result.</returns>
        public TSelf SetSubtitle(string? subtitle)
        {
            Subtitle = subtitle;
            return This();
        }

        /// <summary>
        /// Configures title on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="title">The title value.</param>
        /// <returns>The configured <see cref="TSelf"/> value or BootstrapBuilder result.</returns>
        public TSelf SetTitle(string? title)
        {
            Title = title;
            return This();
        }

        /// <summary>
        /// Configures variant on the current BootstrapBuilder instance.
        /// </summary>
        /// <param name="variant">The variant value.</param>
        /// <returns>The configured <see cref="TSelf"/> value or BootstrapBuilder result.</returns>
        public TSelf SetVariant(VariantStyle variant)
        {
            Variant = variant;
            return This();
        }

        protected TSelf This()
        {
            return (TSelf)this;
        }

        #region From interface IActionItem

        /// <summary>
        /// Creates a copy of the current BootstrapBuilder composer.
        /// </summary>
        /// <returns>The configured <see cref="IActionItem"/> value or BootstrapBuilder result.</returns>
        public abstract IActionItem Clone();

        #endregion

        #endregion
    }
}