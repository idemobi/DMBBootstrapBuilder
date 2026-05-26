window.DebugModeMethod = window.DebugModeMethod || (function () {
    const storageKey = "layout_debug";
    function normalize(value) { return value === true || value === "true"; }
    function apply(value, raiseEvent) {
        const enabled = normalize(value);
        localStorage.setItem(storageKey, enabled ? "true" : "false");
        document.body.setAttribute("data-layout-debug", enabled ? "true" : "false");
        sync(enabled);
        if (raiseEvent !== false) {
            document.dispatchEvent(new CustomEvent("dmb:debug-changed", { detail: { value: enabled } }));
        }
    }
    function sync(enabled) {
        document.querySelectorAll('[data-dmb-setting="debug"]').forEach(function (element) {
            element.checked = enabled;
            element.setAttribute("data-dmb-selected", enabled ? "true" : "false");
        });
    }
    function init() { apply(localStorage.getItem(storageKey) === "true", false); }
    return { init: init, set: function (value) { apply(value, true); }, get: function () { return localStorage.getItem(storageKey) === "true"; } };
})();

document.addEventListener("DOMContentLoaded", function () {
    DebugModeMethod.init();

    var CLIP_CLASSES = [
        'eb-section-effect-diagonal-edge',
        'eb-section-effect-curve-edge',
        'eb-section-effect-wave'
    ];

    document.querySelectorAll('.section-debug').forEach(function (debugDiv) {
        var section = debugDiv.parentElement;
        if (!section) return;

        var isClippedByClass = CLIP_CLASSES.some(function (cls) { return section.classList.contains(cls); });
        var clipStyle = window.getComputedStyle(section).clipPath;
        var isClippedByStyle = clipStyle && clipStyle !== 'none' && clipStyle !== '';

        if (!isClippedByClass && !isClippedByStyle) return;

        var r = section.getBoundingClientRect();
        var scrollY = window.pageYOffset || document.documentElement.scrollTop;

        debugDiv.dataset.sectionDebugId = section.id || ('clip-' + Math.random().toString(36).substr(2, 5));
        debugDiv.style.position = 'absolute';
        debugDiv.style.top = (r.top + scrollY + 12) + 'px';
        debugDiv.style.right = (window.innerWidth - r.right + 12) + 'px';
        debugDiv.style.zIndex = '1025';
        document.body.appendChild(debugDiv);
    });
});

function _debugSetAllButtonsZIndex(z) {
    document.querySelectorAll('.section-debug').forEach(function (el) { el.style.zIndex = z; });
}

document.addEventListener('show.bs.collapse', function (e) {
    if (!e.target.classList.contains('section-debug-panel')) return;

    const btn = document.querySelector('[data-bs-target="#' + e.target.id + '"]');
    if (!btn) return;

    _debugSetAllButtonsZIndex('1');
    btn.blur();

    const debugHost = btn.closest('.section-debug');
    if (debugHost) debugHost.style.zIndex = '1020';

    const section = debugHost
        ? (document.getElementById(debugHost.dataset.sectionDebugId) || btn.closest('section') || btn.closest('.position-relative'))
        : (btn.closest('section') || btn.closest('.position-relative'));
    const sectionId = section ? (section.id || 'gen-' + Math.random().toString(36).substr(2, 5)) : (debugHost?.dataset.sectionDebugId || 'global');

    let stack = document.getElementById('debug-stack-' + sectionId);

    if (!stack) {
        stack = document.createElement('div');
        stack.id = 'debug-stack-' + sectionId;
        stack.className = 'section-debug-stack';

        const r = btn.getBoundingClientRect();
        const scrollY = window.pageYOffset || document.documentElement.scrollTop;

        stack.style.position = 'absolute';
        stack.style.top = (r.bottom + scrollY + 10) + 'px';
        stack.style.right = (window.innerWidth - r.right) + 'px';
        stack.style.display = 'flex';

        document.body.appendChild(stack);
    }

    stack.style.zIndex = '2000';

    if (e.target.parentElement !== stack) {
        stack.appendChild(e.target);
    }

    stack.style.visibility = 'visible';
});

document.addEventListener('hidden.bs.collapse', function (e) {
    if (!e.target.classList.contains('section-debug-panel')) return;

    const stack = e.target.parentElement;
    if (stack && stack.classList.contains('section-debug-stack')) {
        const openPanels = stack.querySelectorAll('.section-debug-panel.show');
        if (openPanels.length === 0) {
            stack.style.visibility = 'hidden';
            _debugSetAllButtonsZIndex('1025');
        }
    }
});