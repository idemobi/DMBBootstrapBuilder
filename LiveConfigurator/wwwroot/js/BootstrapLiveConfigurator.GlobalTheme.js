(function () {
    var legacyStorageKey = "DMB_BOOTSTRAP_LIVE_CONFIG_PRESET";
    var profilesStorageKey = "DMB_BOOTSTRAP_LIVE_CONFIG_PROFILES";
    var activeProfileStorageKey = "DMB_BOOTSTRAP_LIVE_CONFIG_ACTIVE_PROFILE";
    var dynamicStyleId = "dmb-bootstrap-live-dynamic-colors";

    function readStoredConfig() {
        try {
            var activeProfileName = window.localStorage.getItem(activeProfileStorageKey) || "";
            if (activeProfileName) {
                var profilesRaw = window.localStorage.getItem(profilesStorageKey);
                var profiles = profilesRaw ? JSON.parse(profilesRaw) : null;
                if (profiles && typeof profiles === "object" && profiles[activeProfileName]) {
                    return profiles[activeProfileName];
                }
            }

            var legacyValue = window.localStorage.getItem(legacyStorageKey);
            return legacyValue ? JSON.parse(legacyValue) : null;
        } catch (_error) {
            return null;
        }
    }

    function hexToRgbString(hexColor) {
        var value = (hexColor || "").replace("#", "").trim();
        if (value.length !== 6) {
            return null;
        }

        var r = Number.parseInt(value.substring(0, 2), 16);
        var g = Number.parseInt(value.substring(2, 4), 16);
        var b = Number.parseInt(value.substring(4, 6), 16);

        if (Number.isNaN(r) || Number.isNaN(g) || Number.isNaN(b)) {
            return null;
        }

        return r + ", " + g + ", " + b;
    }

    function applyGlobalTheme(config) {
        if (!config || !document || !document.documentElement) {
            return;
        }

        if (config.liveOverrideEnabled === false) {
            clearGlobalTheme();
            return;
        }

        var root = document.documentElement;
        var primary = config.primaryColor || "#0d6efd";
        var secondary = config.secondaryColor || "#6c757d";
        var primaryRgb = hexToRgbString(primary);
        var secondaryRgb = hexToRgbString(secondary);
        var borderRadiusPx = Number.isFinite(config.borderRadiusPx) ? config.borderRadiusPx : 8;
        var borderWidthPx = Number.isFinite(config.borderWidthPx) ? config.borderWidthPx : 1;
        var borderColor = config.borderColor || "#dee2e6";
        var borderColorTranslucent = Number.isFinite(config.borderColorTranslucent) ? config.borderColorTranslucent : 0.175;
        var cardBgMode = config.cardBgMode || "inherit";
        var cardBorderColorMode = config.cardBorderColorMode || "inherit";
        var cardBorderWidthPxMode = config.cardBorderWidthPxMode || "inherit";
        var cardBorderRadiusPxMode = config.cardBorderRadiusPxMode || "inherit";
        var cardBg = cardBgMode === "inherit" ? (config.bodyBgColor || "#ffffff") : (config.cardBg || "#ffffff");
        var cardBorderColor = cardBorderColorMode === "custom" ? (config.cardBorderColor || borderColor) : borderColor;
        var cardBorderWidthPx = cardBorderWidthPxMode === "custom" ? (Number.isFinite(config.cardBorderWidthPx) ? config.cardBorderWidthPx : borderWidthPx) : borderWidthPx;
        var cardBorderRadiusPx;
        if (cardBorderRadiusPxMode === "custom") {
            cardBorderRadiusPx = Number.isFinite(config.cardBorderRadiusPx) ? config.cardBorderRadiusPx : borderRadiusPx;
        } else if (cardBorderRadiusPxMode === "formula") {
            cardBorderRadiusPx = Math.max(0, borderRadiusPx - cardBorderWidthPx);
        } else {
            cardBorderRadiusPx = borderRadiusPx;
        }
        var fontScalePercent = Number.isFinite(config.fontScalePercent) ? config.fontScalePercent : 100;

        root.style.setProperty("--bs-primary", primary);
        root.style.setProperty("--bs-secondary", secondary);

        if (primaryRgb) {
            root.style.setProperty("--bs-primary-rgb", primaryRgb);
        }

        if (secondaryRgb) {
            root.style.setProperty("--bs-secondary-rgb", secondaryRgb);
        }

        root.style.setProperty("--bs-border-radius", (borderRadiusPx / 16) + "rem");
        root.style.setProperty("--bs-border-width", borderWidthPx + "px");
        root.style.setProperty("--bs-border-color", borderColor);
        root.style.setProperty("--bs-border-color-translucent", "rgba(0, 0, 0, " + borderColorTranslucent + ")");
        root.style.setProperty("--bs-card-border-width", borderWidthPx + "px");
        root.style.setProperty("--bs-card-border-color", borderColor);
        root.style.setProperty("--bs-card-border-radius", (borderRadiusPx / 16) + "rem");
        root.style.fontSize = (fontScalePercent / 100).toFixed(3) + "rem";

        applyComponentColorOverrides(primary, secondary, borderColor, borderWidthPx, cardBg, cardBorderColor, cardBorderWidthPx, cardBorderRadiusPx, borderRadiusPx);
    }

    function clearGlobalTheme() {
        if (!document || !document.documentElement) {
            return;
        }

        var root = document.documentElement;
        [
            "--bs-primary", "--bs-secondary", "--bs-border-radius", "--bs-border-width",
            "--bs-border-color", "--bs-border-color-translucent",
            "--bs-card-border-width", "--bs-card-border-color", "--bs-card-border-radius",
            "--bs-primary-rgb", "--bs-secondary-rgb"
        ].forEach(function (name) {
            root.style.removeProperty(name);
        });
        root.style.removeProperty("font-size");

        var styleTag = document.getElementById(dynamicStyleId);
        if (styleTag) {
            styleTag.remove();
        }
    }

    function shadeColor(hexColor, factor) {
        var value = (hexColor || "").replace("#", "").trim();
        if (value.length !== 6) {
            return hexColor;
        }

        var r = Number.parseInt(value.substring(0, 2), 16);
        var g = Number.parseInt(value.substring(2, 4), 16);
        var b = Number.parseInt(value.substring(4, 6), 16);

        if (Number.isNaN(r) || Number.isNaN(g) || Number.isNaN(b)) {
            return hexColor;
        }

        r = Math.max(0, Math.min(255, Math.round(r * factor)));
        g = Math.max(0, Math.min(255, Math.round(g * factor)));
        b = Math.max(0, Math.min(255, Math.round(b * factor)));

        var toHex = function (component) {
            return component.toString(16).padStart(2, "0");
        };

        return "#" + toHex(r) + toHex(g) + toHex(b);
    }

    function applyComponentColorOverrides(primary, secondary, borderColor, borderWidthPx, cardBg, cardBorderColor, cardBorderWidthPx, cardBorderRadiusPx, borderRadiusPx) {
        if (!document) {
            return;
        }

        var styleTag = document.getElementById(dynamicStyleId);
        if (!styleTag) {
            styleTag = document.createElement("style");
            styleTag.id = dynamicStyleId;
            document.head.appendChild(styleTag);
        }

        var primaryHover = shadeColor(primary, 0.9);
        var primaryActive = shadeColor(primary, 0.8);
        var secondaryHover = shadeColor(secondary, 0.9);
        var secondaryActive = shadeColor(secondary, 0.8);

        styleTag.textContent = [
            ".card{background:" + cardBg + " !important;border-color:" + cardBorderColor + " !important;border-width:" + cardBorderWidthPx + "px !important;border-radius:" + (cardBorderRadiusPx / 16) + "rem !important;}",
            ".btn-primary{--bs-btn-bg:" + primary + ";--bs-btn-border-color:" + primary + ";--bs-btn-hover-bg:" + primaryHover + ";--bs-btn-hover-border-color:" + primaryHover + ";--bs-btn-active-bg:" + primaryActive + ";--bs-btn-active-border-color:" + primaryActive + ";}",
            ".btn-outline-primary{--bs-btn-color:" + primary + ";--bs-btn-border-color:" + primary + ";--bs-btn-hover-bg:" + primary + ";--bs-btn-hover-border-color:" + primary + ";--bs-btn-active-bg:" + primaryHover + ";--bs-btn-active-border-color:" + primaryHover + ";}",
            ".btn-secondary{--bs-btn-bg:" + secondary + ";--bs-btn-border-color:" + secondary + ";--bs-btn-hover-bg:" + secondaryHover + ";--bs-btn-hover-border-color:" + secondaryHover + ";--bs-btn-active-bg:" + secondaryActive + ";--bs-btn-active-border-color:" + secondaryActive + ";}",
            ".btn-outline-secondary{--bs-btn-color:" + secondary + ";--bs-btn-border-color:" + secondary + ";--bs-btn-hover-bg:" + secondary + ";--bs-btn-hover-border-color:" + secondary + ";--bs-btn-active-bg:" + secondaryHover + ";--bs-btn-active-border-color:" + secondaryHover + ";}",
            ".text-bg-primary,.badge.text-bg-primary{background-color:" + primary + " !important;}",
            ".text-bg-secondary,.badge.text-bg-secondary{background-color:" + secondary + " !important;}",
            ".alert-primary{--bs-alert-color:" + primaryActive + ";--bs-alert-bg:" + primary + "22;--bs-alert-border-color:" + primary + "55;}",
            ".alert-secondary{--bs-alert-color:" + secondaryActive + ";--bs-alert-bg:" + secondary + "22;--bs-alert-border-color:" + secondary + "55;}",
            "a{color:" + primary + ";}"
        ].join("");
    }

    applyGlobalTheme(readStoredConfig());
})();
