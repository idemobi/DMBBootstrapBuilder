(function () {

    function showBrokenImageFallback(container) {
        const inlineTarget = container.querySelector('[data-image-render-inline-svg="true"]');
        const imgTarget = container.querySelector('[data-image-render-img="true"]');

        const fallbackHtml =
            "<div class=\"image-render-broken d-flex align-items-center justify-content-center\">" +
            "<i class=\"bi bi-image-alt\" aria-hidden=\"true\"></i>" +
            "</div>";

        if (inlineTarget) {
            inlineTarget.innerHTML = fallbackHtml;
            return;
        }

        if (imgTarget) {
            imgTarget.outerHTML = fallbackHtml;
        }
    }
    
    function normalizeInlineSvgTarget(target) {
        if (!target) return;

        target.style.display = "block";
        target.style.width = "100%";
        target.style.height = "100%";
        target.style.minWidth = "0";
        target.style.minHeight = "0";
    }

    function normalizeInlineSvgElement(svgElement, mode) {
        if (!svgElement) return;

        svgElement.style.display = "block";
        svgElement.style.maxWidth = "100%";
        svgElement.style.maxHeight = "100%";

        if (mode === "fill") {
            svgElement.style.width = "100%";
            svgElement.style.height = "100%";

            // fallback si SVG mal défini
            if (!svgElement.hasAttribute("viewBox")) {
                svgElement.style.height = "auto";
            }
        } else {
            // contain
            svgElement.style.width = "100%";
            svgElement.style.height = "auto";
        }
    }
    
    function currentTheme() {
        return document.documentElement.getAttribute("data-bs-theme") || "light";
    }

    function ensureModal() {
        let modal = document.getElementById("image-render-modal");
        if (modal) return modal;

        modal = document.createElement("div");
        modal.id = "image-render-modal";
        modal.className = "modal fade";
        modal.tabIndex = -1;
        modal.setAttribute("aria-hidden", "true");

        modal.innerHTML = `
<div class="modal-dialog modal-xl modal-dialog-centered">
    <div class="modal-content">
        <div class="modal-header">
            <h5 class="modal-title" id="image-render-modal-title"></h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body image-render-modal-body">
            <div id="image-render-modal-preview" class="image-render-modal-preview"></div>
        </div>
        <div class="modal-footer">
            <div class="image-render-modal-footer">
                <div class="btn-group image-render-modal-split" id="image-render-theme-download-group" style="display:none;">
                    <button type="button" class="btn btn-outline-secondary" id="image-render-theme-download-main" aria-label="Download themed SVG">
                        <i class="bi-download"></i>
                    </button>
                    <button type="button" class="btn btn-outline-secondary dropdown-toggle dropdown-toggle-split" data-bs-toggle="dropdown" aria-expanded="false">
                        <span class="visually-hidden">Toggle theme download</span>
                    </button>
                    <ul class="dropdown-menu dropdown-menu-end">
                        <li><button type="button" class="dropdown-item" data-download-theme="light"><i class="bi-sun me-2"></i>Light</button></li>
                        <li><button type="button" class="dropdown-item" data-download-theme="dark"><i class="bi-moon me-2"></i>Dark</button></li>
                    </ul>
                </div>
                <button type="button" id="image-render-download-btn" class="btn btn-outline-secondary" style="display:none;" aria-label="Download image">
                    <i class="bi-download"></i>
                </button>
            </div>
        </div>
    </div>
</div>`;

        document.body.appendChild(modal);
        return modal;
    }

    function hideSpinner(container) {
        const spinner = container.querySelector('[data-image-render-spinner="true"]');
        if (spinner) {
            spinner.style.display = "none";
        }
    }

    function detectIsSvg(container) {
        const mode = container.dataset.imageRenderMode || "Auto";
        if (mode === "InlineSvg") return true;
        if (mode === "ImageTag") return false;
        const src = container.dataset.imageRenderSrc || "";
        return src.toLowerCase().endsWith(".svg");
    }

    function applyThemeToSvgText(svgText, theme) {
        let themed = svgText;

        themed = themed.replace(/color-scheme:\s*light dark;?/gi, `color-scheme: ${theme};`);
        themed = themed.replace(/color-scheme:\s*light;?/gi, `color-scheme: ${theme};`);
        themed = themed.replace(/color-scheme:\s*dark;?/gi, `color-scheme: ${theme};`);

        return themed;
    }

    function updateSVGTheme(svgElement) {
        if (!svgElement) return;

        let styleAttr = svgElement.getAttribute("style") || "";
        const theme = currentTheme();

        if (/color-scheme\s*:/i.test(styleAttr)) {
            styleAttr = styleAttr.replace(/color-scheme:\s*(light dark|light|dark);?/gi, `color-scheme: ${theme};`);
        } else {
            styleAttr = `${styleAttr}${styleAttr.trim() ? " " : ""}color-scheme: ${theme};`;
        }

        svgElement.setAttribute("style", styleAttr.trim());
    }

    async function loadInlineSvg(container) {
        const target = container.querySelector('[data-image-render-inline-svg="true"]');
        if (!target) return;

        const src = container.dataset.imageRenderSrc;
        if (!src) {
            showBrokenImageFallback(container);
            hideSpinner(container);
            return;
        }

        normalizeInlineSvgTarget(target);

        try {
            const response = await fetch(src, { cache: "force-cache" });
            if (!response.ok) {
                showBrokenImageFallback(container);
                hideSpinner(container);
                return;
            }

            const svgText = await response.text();
            const themedText = applyThemeToSvgText(svgText, currentTheme());
            const parser = new DOMParser();
            const svgDoc = parser.parseFromString(themedText, "image/svg+xml");
            const svgElement = svgDoc.documentElement;

            svgElement.setAttribute("data-original-src", src);
            svgElement.classList.add("image-render-inline-svg-node");

            normalizeInlineSvgElement(svgElement, "fill");

            target.innerHTML = "";
            target.appendChild(svgElement);

            updateSVGTheme(svgElement);
        } catch {
            showBrokenImageFallback(container);
        } finally {
            hideSpinner(container);
        }
    }

    function attachImgEvents(container) {
        const img = container.querySelector('[data-image-render-img="true"]');
        if (!img) return;

        const done = () => hideSpinner(container);

        if (img.complete) {
            if (img.naturalWidth === 0) {
                showBrokenImageFallback(container);
            }
            done();
        } else {
            img.addEventListener("load", done, { once: true });
            img.addEventListener("error", () => {
                showBrokenImageFallback(container);
                done();
            }, { once: true });
        }
    }

    function fileNameWithoutQuery(src) {
        const clean = (src || "").split("?")[0];
        const parts = clean.split("/");
        return parts[parts.length - 1] || "image";
    }

    async function downloadOriginal(container) {
        const src = container.dataset.imageRenderSrc || "";
        if (!src) return;

        const a = document.createElement("a");
        a.href = src;
        a.download = fileNameWithoutQuery(src);
        document.body.appendChild(a);
        a.click();
        a.remove();
    }

    async function downloadSvgWithTheme(container, theme) {
        const src = container.dataset.imageRenderSrc || "";
        if (!src) return;

        try {
            const response = await fetch(src, { cache: "no-cache" });
            if (!response.ok) return;

            const svgText = await response.text();
            const themed = applyThemeToSvgText(svgText, theme);

            const blob = new Blob([themed], { type: "image/svg+xml;charset=utf-8" });
            const url = URL.createObjectURL(blob);

            const baseName = fileNameWithoutQuery(src).replace(/\.svg$/i, "");
            const suffix = theme === "light" ? "-light" : "-dark";

            const a = document.createElement("a");
            a.href = url;
            a.download = `${baseName}${suffix}.svg`;
            document.body.appendChild(a);
            a.click();
            a.remove();

            URL.revokeObjectURL(url);
        } catch {
        }
    }

    async function openModal(container) {
        const modal = ensureModal();
        const title = modal.querySelector("#image-render-modal-title");
        const preview = modal.querySelector("#image-render-modal-preview");
        const downloadBtn = modal.querySelector("#image-render-download-btn");
        const themeGroup = modal.querySelector("#image-render-theme-download-group");
        const themeMain = modal.querySelector("#image-render-theme-download-main");

        const src = container.dataset.imageRenderSrc || "";
        const textTitle = container.dataset.imageRenderTitle || container.dataset.imageRenderAlt || "";
        const alt = container.dataset.imageRenderAlt || "";
        const allowDownload = container.dataset.imageRenderAllowDownload === "true";
        const allowThemeDownload = container.dataset.imageRenderAllowThemeDownload === "true";
        const isSvg = detectIsSvg(container);
        const isThemeResponsiveSvg = isSvg && allowThemeDownload;
        const useThemeSplit = allowDownload && isThemeResponsiveSvg;

        title.textContent = textTitle;
        preview.innerHTML = "";

        if (isSvg) {
            try {
                const response = await fetch(src, { cache: "force-cache" });
                if (response.ok) {
                    const svgText = await response.text();
                    const themedText = applyThemeToSvgText(svgText, currentTheme());
                    preview.innerHTML = themedText;

                    const svg = preview.querySelector("svg");
                    if (svg) {
                        preview.style.display = "flex";
                        preview.style.alignItems = "center";
                        preview.style.justifyContent = "center";
                        preview.style.width = "100%";
                        preview.style.minHeight = "60vh";

                        normalizeInlineSvgElement(svg, "contain");
                        updateSVGTheme(svg);
                    }
                }
            } catch {
                preview.innerHTML = "<div class=\"text-danger\">Unable to load SVG preview.</div>";
            }
        } else {
            const img = document.createElement("img");
            img.className = "img-fluid";
            img.src = src;
            img.alt = alt;
            preview.appendChild(img);
        }


        if (useThemeSplit) {
            downloadBtn.style.display = "none";
            themeGroup.style.display = "";
        } else if (allowDownload) {
            downloadBtn.style.display = "";
            themeGroup.style.display = "none";
        } else {
            downloadBtn.style.display = "none";
            themeGroup.style.display = "none";
        }

        downloadBtn.onclick = () => downloadOriginal(container);
        themeMain.onclick = () => downloadOriginal(container);

        themeGroup.querySelectorAll("[data-download-theme]").forEach(btn => {
            btn.onclick = () => {
                const theme = btn.getAttribute("data-download-theme") || "light";
                downloadSvgWithTheme(container, theme);
            };
        });

        bootstrap.Modal.getOrCreateInstance(modal).show();
    }

    function makeClickable(container) {
        container.classList.add("image-render-clickable");
        container.addEventListener("click", function (e) {
            const overlayButton = e.target.closest("[data-image-render-download-on-image='true']");
            if (overlayButton) return;
            openModal(container);
        });
    }

    function initContainer(container) {
        if (detectIsSvg(container)) {
            loadInlineSvg(container);
        } else {
            attachImgEvents(container);
        }

        if (container.dataset.imageRenderOpenModal === "true") {
            makeClickable(container);
        }

        const overlayDownloadBtn = container.querySelector("[data-image-render-download-on-image='true']");
        if (overlayDownloadBtn && container.dataset.imageRenderAllowDownload === "true") {
            overlayDownloadBtn.addEventListener("click", function (e) {
                e.preventDefault();
                e.stopPropagation();

                if (container.dataset.imageRenderOpenModal === "true") {
                    openModal(container);
                } else {
                    downloadOriginal(container);
                }
            });
        }
    }

    function initAll() {
        document.querySelectorAll("[data-image-render='true']").forEach(initContainer);
    }

    document.addEventListener("DOMContentLoaded", initAll);

    document.addEventListener("themechange", function () {
        document.querySelectorAll(".image-render-inline-svg-node").forEach(svg => {
            updateSVGTheme(svg);
        });
    });
})();