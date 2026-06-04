window.BreadcrumbModeMethod = window.BreadcrumbModeMethod || (function () {
    const storageKey = "layout_breadcrumb";
    const rootAttribute = "data-layout-breadcrumb";

    function normalize(value) {
        return value === true || value === "true";
    }

    function getStoredValue() {
        return localStorage.getItem(storageKey) !== "false";
    }

    function applyToRoot(enabled) {
        document.documentElement.setAttribute(rootAttribute, enabled ? "true" : "false");
    }

    function sync(enabled) {
        document.querySelectorAll('[data-dmb-setting="breadcrumb"]').forEach(function (element) {
            if (element.type === "checkbox") {
                element.checked = enabled;
            }

            element.setAttribute("data-dmb-selected", enabled ? "true" : "false");
        });
    }

    function apply(value, raiseEvent) {
        const enabled = normalize(value);

        localStorage.setItem(storageKey, enabled ? "true" : "false");
        applyToRoot(enabled);
        sync(enabled);

        if (raiseEvent !== false) {
            document.dispatchEvent(new CustomEvent("dmb:breadcrumb-changed", {
                detail: { value: enabled }
            }));
        }
    }

    function init() {
        apply(getStoredValue(), false);
    }

    return {
        init: init,
        set: function (value) {
            apply(value, true);
        },
        get: function () {
            return getStoredValue();
        },
        syncSelection: function () {
            sync(getStoredValue());
        }
    };
})();

document.addEventListener("DOMContentLoaded", function () {
    BreadcrumbModeMethod.init();
});
