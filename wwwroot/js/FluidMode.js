window.FluidModeMethod = window.FluidModeMethod || (function () {
    const storageKey = "layout_fluid";
    const switchableSelector = '[data-switchable-fluid="true"]';
    const reverseAttribute = 'data-switchable-reverse';
    const infoAttribute = 'data-fluid-info';

    function normalize(value) {
        return value === true || value === "true";
    }

    function getReverseClasses(element) {
        const raw = (element.getAttribute(reverseAttribute) || "").trim();
        if (!raw) {
            return [];
        }

        return raw.split(/\s+/).filter(Boolean);
    }

    function applyToContainers(enabled) {
        const containers = document.querySelectorAll(switchableSelector);

        containers.forEach(function (element) {
            const reverseClasses = getReverseClasses(element);


            element.setAttribute(infoAttribute, enabled ? "true" : "false");
            if (enabled) {
                reverseClasses.forEach(function (cssClass) {
                    element.classList.remove(cssClass);
                });

                element.classList.add("container-fluid");
            } else {
                element.classList.remove("container-fluid");

                reverseClasses.forEach(function (cssClass) {
                    element.classList.add(cssClass);
                });
            }
        });
    }

    function sync(enabled) {
        document.querySelectorAll('[data-dmb-setting="fluid"]').forEach(function (element) {
            if (element.type === "checkbox") {
                element.checked = enabled;
            }

            element.setAttribute("data-dmb-selected", enabled ? "true" : "false");
        });
    }

    function apply(value, raiseEvent) {
        const enabled = normalize(value);

        localStorage.setItem(storageKey, enabled ? "true" : "false");

        function applyNow() {
            if (!document.body) {
                return false;
            }

            //document.body.setAttribute("data-layout-fluid", enabled ? "true" : "false");
            applyToContainers(enabled);
            return true;
        }

        if (!applyNow()) {
            document.addEventListener("DOMContentLoaded", applyNow, { once: true });
        }

        sync(enabled);

        if (raiseEvent !== false) {
            document.dispatchEvent(new CustomEvent("dmb:fluid-changed", {
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
        }
    };
})();

document.addEventListener("DOMContentLoaded", function () {
    FluidModeMethod.init();
});