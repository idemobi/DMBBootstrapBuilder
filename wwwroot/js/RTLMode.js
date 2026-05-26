window.RTLModeMethod = window.RTLModeMethod || (function () {
    const storageKey = "layout_rtl";

    function normalize(value) {
        return value === true || value === "true";
    }

    function getMainElement() {
        return document.querySelector("#page-content");
    }

    function applyToMain(enabled) {
        const main = getMainElement();
        if (!main) {
            return false;
        }

        if (enabled) {
            main.setAttribute("dir", "rtl");
        } else {
            main.setAttribute("dir", "ltr");
        }

        return true;
    }

    function sync(enabled) {
        document.querySelectorAll('[data-dmb-setting="rtl"]').forEach(function (element) {
            if (element.type === "checkbox") {
                element.checked = enabled;
            }

            element.setAttribute("data-dmb-selected", enabled ? "true" : "false");
        });
    }

    function apply(value, raiseEvent) {
        const enabled = normalize(value);

        localStorage.setItem(storageKey, enabled ? "true" : "false");

        if (!applyToMain(enabled)) {
            document.addEventListener("DOMContentLoaded", function () {
                applyToMain(enabled);
            }, { once: true });
        }

        sync(enabled);

        if (raiseEvent !== false) {
            document.dispatchEvent(new CustomEvent("dmb:rtl-changed", {
                detail: { value: enabled }
            }));
        }
    }

    function getStoredValue() {
        return normalize(localStorage.getItem(storageKey));
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
    RTLModeMethod.init();
});