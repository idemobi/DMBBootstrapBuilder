document.addEventListener("DOMContentLoaded", () => {
    document.querySelectorAll('table[data-sortable="true"]').forEach(table => {

        const headers = table.querySelectorAll('th[data-sortable="true"]');
        const tbody = table.querySelector("tbody");

        if (!tbody) {
            return;
        }

        headers.forEach(th => {

            th.addEventListener("click", () => {

                const key = (th.getAttribute("data-sort-key") || "").trim().toLowerCase();
                if (!key) {
                    return;
                }

                const direction = th.getAttribute("data-sort-direction") === "asc" ? "desc" : "asc";

                headers.forEach(h => {
                    h.setAttribute("data-sort-direction", "");
                });

                th.setAttribute("data-sort-direction", direction);

                const rows = Array.from(tbody.querySelectorAll("tr"));
                const attrName = "data-sort-" + key;

                rows.sort((a, b) => {

                    const av = (a.getAttribute(attrName) ?? "").trim();
                    const bv = (b.getAttribute(attrName) ?? "").trim();

                    const an = Number(av);
                    const bn = Number(bv);

                    const aIsNumber = av !== "" && !Number.isNaN(an);
                    const bIsNumber = bv !== "" && !Number.isNaN(bn);

                    if (aIsNumber && bIsNumber) {
                        return direction === "asc" ? an - bn : bn - an;
                    }

                    return direction === "asc"
                        ? av.localeCompare(bv)
                        : bv.localeCompare(av);
                });

                rows.forEach(row => tbody.appendChild(row));
            });

        });

    });
});