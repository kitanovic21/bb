export class Depozit {
    constructor(url, container, brojRacuna, onBack) {
        this.url = url;
        this.container = container;
        this.brojRacuna = brojRacuna;
        this.onBack = onBack;
        this.data = [];
    }

    async loadData() {
        const response = await fetch(this.url);

        if (!response.ok) {
            throw new Error("Greška pri učitavanju depozita.");
        }

        const sviDepoziti = await response.json();
        this.data = sviDepoziti.filter(depozit => depozit.brojRacuna === this.brojRacuna);

        this.clearBody();
        this.showData();
    }

    clearBody() {
        document.body.innerHTML = "";
    }

    showData() {
        const naslov = document.createElement("h2");
        naslov.innerText = `Depoziti računa ${this.brojRacuna}`;
        naslov.classList.add("mb-4");
        this.container.appendChild(naslov);

        const nazad = document.createElement("button");
        nazad.innerText = "Nazad";
        nazad.classList.add("btn", "btn-secondary", "mb-4");
        nazad.onclick = this.onBack;
        this.container.appendChild(nazad);

        if (this.data.length === 0) {
            const poruka = document.createElement("p");
            poruka.innerText = "Za ovaj račun nema depozita.";
            this.container.appendChild(poruka);
            return;
        }

        const table = document.createElement("table");
        table.classList.add("table", "table-hover", "table-striped");
        this.container.appendChild(table);

        const thead = document.createElement("thead");
        thead.classList.add("bg-primary", "text-white");
        table.appendChild(thead);

        const headerRow = document.createElement("tr");
        thead.appendChild(headerRow);

        const kolone = ["ID", "Iznos", "Valuta", "Status", "Period oročenja", "Kamatna stopa", "Datum isteka", "Detalji"];

        for (const kolona of kolone) {
            const th = document.createElement("th");
            th.innerText = kolona;
            th.classList.add("text-center");
            headerRow.appendChild(th);
        }

        const tbody = document.createElement("tbody");
        table.appendChild(tbody);

        for (const depozit of this.data) {
            const tr = document.createElement("tr");
            tbody.appendChild(tr);

            this.dodajCeliju(tr, depozit.id);
            this.dodajCeliju(tr, depozit.iznos);
            this.dodajCeliju(tr, depozit.valuta);
            this.dodajCeliju(tr, depozit.status);
            this.dodajCeliju(tr, depozit.periodOrocenja);
            this.dodajCeliju(tr, depozit.kamatnaStopa);
            this.dodajCeliju(tr, this.formatirajDatum(depozit.datumIsteka));

            const tdDetalji = document.createElement("td");
            tdDetalji.classList.add("text-center");
            tr.appendChild(tdDetalji);

            const dugme = document.createElement("button");
            dugme.innerText = "Prikaži";
            dugme.classList.add("btn", "btn-primary", "btn-sm");
            dugme.onclick = () => this.prikaziDetalje(depozit);
            tdDetalji.appendChild(dugme);
        }
    }

    prikaziDetalje(depozit) {
        this.clearBody();

        const naslov = document.createElement("h2");
        naslov.innerText = "Detalji depozita";
        naslov.classList.add("mb-4");
        this.container.appendChild(naslov);

        const nazad = document.createElement("button");
        nazad.innerText = "Nazad na depozite";
        nazad.classList.add("btn", "btn-secondary", "mb-4");
        nazad.onclick = () => {
            this.clearBody();
            this.showData();
        };
        this.container.appendChild(nazad);

        const table = document.createElement("table");
        table.classList.add("table", "table-bordered", "mx-auto");
        table.style.maxWidth = "700px";
        this.container.appendChild(table);

        const tbody = document.createElement("tbody");
        table.appendChild(tbody);

        this.dodajDetalj(tbody, "ID", depozit.id);
        this.dodajDetalj(tbody, "Iznos", depozit.iznos);
        this.dodajDetalj(tbody, "Valuta", depozit.valuta);
        this.dodajDetalj(tbody, "Status", depozit.status);
        this.dodajDetalj(tbody, "Period oročenja", depozit.periodOrocenja);
        this.dodajDetalj(tbody, "Datum početka", this.formatirajDatum(depozit.datumPocetka));
        this.dodajDetalj(tbody, "Datum isteka", this.formatirajDatum(depozit.datumIsteka));
        this.dodajDetalj(tbody, "Očekivana kamata", depozit.ocekivanaKamata);
        this.dodajDetalj(tbody, "Kamatna stopa", depozit.kamatnaStopa);
        this.dodajDetalj(tbody, "Komentar", depozit.komentar);
        this.dodajDetalj(tbody, "ID klijenta", depozit.klijentID);
        this.dodajDetalj(tbody, "Broj računa", depozit.brojRacuna);
        this.dodajDetalj(tbody, "ID predmeta obračuna", depozit.predmetObracunaID);
    }

    dodajCeliju(red, vrednost) {
        const td = document.createElement("td");
        td.innerText = vrednost ?? "";
        td.classList.add("text-center");
        red.appendChild(td);
    }

    dodajDetalj(tbody, naziv, vrednost) {
        const tr = document.createElement("tr");
        const th = document.createElement("th");
        const td = document.createElement("td");

        th.innerText = naziv;
        td.innerText = vrednost ?? "";

        th.classList.add("text-left");
        td.classList.add("text-left");

        tr.appendChild(th);
        tr.appendChild(td);
        tbody.appendChild(tr);
    }

    formatirajDatum(datum) {
        if (!datum) return "";
        return new Date(datum).toLocaleDateString("sr-RS");
    }
}