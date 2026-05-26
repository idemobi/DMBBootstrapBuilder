(function () {
    function fallbackCopy(text) {
        var textarea = document.createElement("textarea");
        textarea.value = text;
        textarea.setAttribute("readonly", "readonly");
        textarea.style.position = "fixed";
        textarea.style.opacity = "0";
        textarea.style.pointerEvents = "none";
        document.body.appendChild(textarea);
        textarea.focus();
        textarea.select();

        try {
            document.execCommand("copy");
        } finally {
            document.body.removeChild(textarea);
        }
    }

    function setClipboardState(element, copied) {
        if (!element) {
            return;
        }

        var iconContainer = element.querySelector(".action-item-clipboard-icon");
        var textContainer = element.querySelector(".action-item-clipboard-text");

        var iconHtml = copied
            ? (element.getAttribute("data-copy-icon-end-html") || "")
            : (element.getAttribute("data-copy-icon-start-html") || "");

        var textValue = copied
            ? (element.getAttribute("data-copy-text-end") || "")
            : (element.getAttribute("data-copy-text-start") || "");

        if (iconContainer) {
            iconContainer.innerHTML = iconHtml;
        }

        if (textContainer) {
            textContainer.textContent = textValue;
        }

        if (copied) {
            element.classList.add("clipboard-copied");
        } else {
            element.classList.remove("clipboard-copied");
        }
    }

    function resetClipboardStateLater(element, delayMs) {
        if (!element) {
            return;
        }

        if (element._dmbClipboardResetTimer) {
            clearTimeout(element._dmbClipboardResetTimer);
        }

        element._dmbClipboardResetTimer = window.setTimeout(function () {
            setClipboardState(element, false);
            element._dmbClipboardResetTimer = null;
        }, delayMs);
    }

    window.DMBActionItemClipboard = function (element) {
        if (!element) {
            return;
        }

        var value = element.getAttribute("data-copy") || "";
        if (!value) {
            return;
        }

        var delayMs = parseInt(element.getAttribute("data-copy-reset-ms") || "5000", 10);
        if (isNaN(delayMs) || delayMs < 0) {
            delayMs = 5000;
        }

        function onCopied() {
            setClipboardState(element, true);
            resetClipboardStateLater(element, delayMs);
        }

        if (navigator.clipboard && navigator.clipboard.writeText) {
            navigator.clipboard.writeText(value).then(onCopied).catch(function () {
                fallbackCopy(value);
                onCopied();
            });
            return;
        }

        fallbackCopy(value);
        onCopied();
    };
})();