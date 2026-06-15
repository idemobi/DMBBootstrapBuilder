(function () {
    "use strict";

    if (window.DMBBootstrapModalPdfPreview) {
        return;
    }

    function getModalFromEvent(event) {
        if (!event || !(event.target instanceof Element)) {
            return null;
        }

        if (event.target.classList.contains("modal")) {
            return event.target;
        }

        return event.target.closest(".modal");
    }

    function forEachPdfPreviewFrame(modal, callback) {
        if (!modal) {
            return;
        }

        modal.querySelectorAll("iframe[data-dmb-pdf-preview-src]").forEach(function (iframe) {
            var url = iframe.getAttribute("data-dmb-pdf-preview-src");

            if (!url) {
                return;
            }

            callback(iframe, url);
        });
    }

    function loadModalPdfPreviews(modal) {
        forEachPdfPreviewFrame(modal, function (iframe, url) {
            if (iframe.getAttribute("src") !== url) {
                iframe.setAttribute("src", url);
            }
        });
    }

    function unloadModalPdfPreviews(modal) {
        forEachPdfPreviewFrame(modal, function (iframe) {
            iframe.removeAttribute("src");
        });
    }

    function onModalShow(event) {
        loadModalPdfPreviews(getModalFromEvent(event));
    }

    function onModalHidden(event) {
        unloadModalPdfPreviews(getModalFromEvent(event));
    }

    document.addEventListener("show.bs.modal", onModalShow, true);
    document.addEventListener("hidden.bs.modal", onModalHidden, true);

    window.DMBBootstrapModalPdfPreview = {
        load: loadModalPdfPreviews,
        unload: unloadModalPdfPreviews
    };
})();
