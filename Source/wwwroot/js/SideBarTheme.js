window.DMBSideBarTheme = window.DMBSideBarTheme || (function () {
    const storageKey = "theme_sidebar";
    const bodyAttribute = "sidebar";

    function normalize(theme) {
        switch ((theme || "").toLowerCase()) {
            case "default":
            case "light":
            case "dark":
            case "transparent":
            case "primary":
            case "inversed":
                return theme.toLowerCase();
            case "colored":
                return "default";
            default:
                return "default";
        }
    }

    function apply(theme, raiseEvent) {
        theme = normalize(theme);

        localStorage.setItem(storageKey, theme);
        document.body.setAttribute(bodyAttribute, theme);

        syncSelection(theme);

        if (raiseEvent !== false) {
            document.dispatchEvent(new CustomEvent("dmb:sidebar-theme-changed", {
                detail: { theme: theme }
            }));
        }
    }

    function getStoredTheme() {
        return normalize(localStorage.getItem(storageKey) || "default");
    }

    function syncSelection(theme) {
        document.querySelectorAll('[data-dmb-setting="sidebar-theme"]').forEach(function (item) {
            const value = (item.getAttribute("data-dmb-value") || "").toLowerCase();
            const selected = value === theme;

            item.classList.toggle("active", selected);
            item.classList.toggle("disabled", selected);
            item.setAttribute("data-dmb-selected", selected ? "true" : "false");
            item.setAttribute("aria-current", selected ? "true" : "false");
        });
    }

    function init() {
        apply(getStoredTheme(), false);
    }

    return {
        init: init,
        set: function (theme) {
            apply(theme, true);
        },
        get: function () {
            return getStoredTheme();
        },
        syncSelection: function () {
            syncSelection(getStoredTheme());
        }
    };
})();

document.addEventListener("DOMContentLoaded", function () {
    DMBSideBarTheme.init();
});
