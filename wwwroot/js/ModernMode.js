window.ModernModeMethod = window.ModernModeMethod || (function () {
    const storageKey = "layout_modern";

    function normalize(value) {
        return value === true || value === "true";
    }

    function apply(value, raiseEvent) {
        const enabled = normalize(value);

        localStorage.setItem(storageKey, enabled ? "true" : "false");
        document.body.setAttribute("data-layout-modern", enabled ? "true" : "false");

        sync(enabled);

        if (raiseEvent !== false) {
            document.dispatchEvent(new CustomEvent("dmb:modern-changed", {
                detail: { value: enabled }
            }));
        }
    }

    function sync(enabled) {
        document.querySelectorAll('[data-dmb-setting="modern"]').forEach(function (element) {
            element.checked = enabled;
            element.setAttribute("data-dmb-selected", enabled ? "true" : "false");
        });
    }

    function init() {
        apply(localStorage.getItem(storageKey) === "true", false);
    }

    return {
        init: init,
        set: function (value) {
            apply(value, true);
        },
        get: function () {
            return localStorage.getItem(storageKey) === "true";
        }
    };
})();

document.addEventListener("DOMContentLoaded", function () {
    ModernModeMethod.init();
});