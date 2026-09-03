export class Kredit {
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
            throw new Error("Greška pri učitavanju kredita.");
        }

        const sviKrediti = await response.json();
        this.data = sviKrediti.filter(kredit => kredit.brojRacuna === this.brojRacuna);

        this.clearBody();
        this.showData();
    }

    clearBody() {
        document.body.innerHTML = "";
    }

    showData() {
        const naslov = document.createElement("h2");
        naslov.innerText = `Krediti računa ${this.brojRacuna}`;
        naslov.classList.add("mb-4");
        this.container.appendChild(naslov);

        const nazad = document.createElement("button");
        nazad.innerText = "Nazad";
        nazad.classList.add("btn", "btn-secondary", "mb-4");
        nazad.onclick = this.onBack;
        this.container.appendChild(nazad);

        if (this.data.length === 0) {
            const poruka = document.createElement("p");
            poruka.innerText = "Za ovaj račun nema kredita.";
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

        const kolone = ["ID", "Status", "Iznos", "Valuta", "Kamatna stopa", "Rok otplate", "Mesečna rata", "Detalji"];

        for (const kolona of kolone) {
            const th = document.createElement("th");
            th.innerText = kolona;
            th.classList.add("text-center");
            headerRow.appendChild(th);
        }

        const tbody = document.createElement("tbody");
        table.appendChild(tbody);

        for (const kredit of this.data) {
            const tr = document.createElement("tr");
            tbody.appendChild(tr);

            this.dodajCeliju(tr, kredit.id);
            this.dodajCeliju(tr, kredit.statusKredita);
            this.dodajCeliju(tr, kredit.iznos);
            this.dodajCeliju(tr, kredit.valuta);
            this.dodajCeliju(tr, kredit.kamatnaStopa);
            this.dodajCeliju(tr, kredit.rokOtplate);
            this.dodajCeliju(tr, kredit.mesecnaRata);

            const tdDetalji = document.createElement("td");
            tdDetalji.classList.add("text-center");
            tr.appendChild(tdDetalji);

            const dugme = document.createElement("button");
            dugme.innerText = "Prikaži";
            dugme.classList.add("btn", "btn-primary", "btn-sm");
            dugme.onclick = () => this.prikaziDetalje(kredit);
            tdDetalji.appendChild(dugme);
        }
    }

    prikaziDetalje(kredit) {
        this.clearBody();

        const naslov = document.createElement("h2");
        naslov.innerText = "Detalji kredita";
        naslov.classList.add("mb-4");
        this.container.appendChild(naslov);

        const nazad = document.createElement("button");
        nazad.innerText = "Nazad na kredite";
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

        this.dodajDetalj(tbody, "ID", kredit.id);
        this.dodajDetalj(tbody, "Status kredita", kredit.statusKredita);
        this.dodajDetalj(tbody, "Namena", kredit.namena);
        this.dodajDetalj(tbody, "Komentar", kredit.komentar);
        this.dodajDetalj(tbody, "Iznos", kredit.iznos);
        this.dodajDetalj(tbody, "Valuta", kredit.valuta);
        this.dodajDetalj(tbody, "Kamatna stopa", kredit.kamatnaStopa);
        this.dodajDetalj(tbody, "Rok otplate", kredit.rokOtplate);
        this.dodajDetalj(tbody, "Mesečna rata", kredit.mesecnaRata);
        this.dodajDetalj(tbody, "Datum dospeća", this.formatirajDatum(kredit.datumDospeca));
        this.dodajDetalj(tbody, "Datum odobrenja", this.formatirajDatum(kredit.datumOdobrenja));
        this.dodajDetalj(tbody, "ID klijenta", kredit.klijentID);
        this.dodajDetalj(tbody, "Broj računa", kredit.brojRacuna);
        this.dodajDetalj(tbody, "ID predmeta obračuna", kredit.predmetObracunaID);
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