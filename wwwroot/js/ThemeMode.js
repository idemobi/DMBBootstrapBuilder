window.ThemeMode = window.ThemeMode || (function () {
    const storageKey = "theme";

    function normalize(mode) {
        if (mode === "light" || mode === "dark") {
            return mode;
        }
        return "auto";
    }

    function resolve(mode) {
        mode = normalize(mode);

        if (mode === "auto") {
            return window.matchMedia("(prefers-color-scheme: dark)").matches ? "dark" : "light";
        }

        return mode;
    }

    function apply(mode, raiseEvent) {
        mode = normalize(mode);

        const resolved = resolve(mode);
        document.documentElement.setAttribute("data-bs-theme", resolved);
        localStorage.setItem(storageKey, mode);

        syncSelection(mode);

        if (raiseEvent !== false) {
            document.dispatchEvent(new CustomEvent("dmb:theme-mode-changed", {
                detail: {
                    mode: mode,
                    resolved: resolved
                }
            }));

            document.dispatchEvent(new Event("themechange"));
        }
    }

    function getStoredMode() {
        return normalize(localStorage.getItem(storageKey) || "auto");
    }

    function syncSelection(mode) {
        const items = document.querySelectorAll('[data-dmb-setting="theme-mode"]');

        items.forEach(function (item) {
            const value = item.getAttribute("data-dmb-value");
            const selected = value === mode;

            item.classList.toggle("active", selected);
            item.classList.toggle("disabled", selected);
            item.setAttribute("aria-current", selected ? "true" : "false");
            item.setAttribute("data-dmb-selected", selected ? "true" : "false");
        });
    }

    function init() {
        const mode = getStoredMode();
        apply(mode, false);

        const media = window.matchMedia("(prefers-color-scheme: dark)");
        if (typeof media.addEventListener === "function") {
            media.addEventListener("change", function () {
                if (getStoredMode() === "auto") {
                    apply("auto", true);
                }
            });
        }
    }

    return {
        init: init,
        set: function (mode) {
            apply(mode, true);
        },
        get: function () {
            return getStoredMode();
        },
        syncSelection: function () {
            syncSelection(getStoredMode());
        }
    };
})();

document.addEventListener("DOMContentLoaded", function () {
    ThemeMode.init();
});