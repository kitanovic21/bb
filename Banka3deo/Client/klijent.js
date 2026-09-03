import { Racun } from "./racun.js";

export class Klijent {
    constructor(url, container) {
        this.url = url;
        this.container = container;
        this.data = [];
    }

    async loadData() {
        const response = await fetch(this.url);

        if (!response.ok) {
            throw new Error("Greška pri učitavanju klijenata.");
        }

        this.data = await response.json();
        this.clearBody();
        this.showData();
    }

    clearBody() {
        document.body.innerHTML = "";
    }

    showData() {
        const naslov = document.createElement("h2");
        naslov.innerText = "Klijenti";
        naslov.classList.add("mb-4");
        this.container.appendChild(naslov);

        if (this.data.length === 0) {
            const poruka = document.createElement("p");
            poruka.innerText = "Nema klijenata.";
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

        const kolone = ["ID", "Tip klijenta", "Status", "Klijent", "Grad", "Email", "Detalji", "Telefoni", "Računi"];

        for (const kolona of kolone) {
            const th = document.createElement("th");
            th.innerText = kolona;
            th.classList.add("text-center");
            headerRow.appendChild(th);
        }

        const tbody = document.createElement("tbody");
        table.appendChild(tbody);

        for (const klijent of this.data) {
            const tr = document.createElement("tr");
            tbody.appendChild(tr);

            this.dodajCeliju(tr, klijent.id);
            this.dodajCeliju(tr, klijent.tipKlijenta);
            this.dodajCeliju(tr, klijent.status);

            let nazivKlijenta = "";

            if (klijent.tipKlijenta === "FizickoLice") {
                nazivKlijenta = `${klijent.ime ?? ""} ${klijent.prezime ?? ""}`.trim();
            } else if (klijent.tipKlijenta === "PravnoLice") {
                nazivKlijenta = klijent.nazivFirme ?? "";
            }

            this.dodajCeliju(tr, nazivKlijenta);
            this.dodajCeliju(tr, klijent.grad);
            this.dodajCeliju(tr, klijent.email);

            const tdDetalji = document.createElement("td");
            tdDetalji.classList.add("text-center");
            tr.appendChild(tdDetalji);

            const dugmeDetalji = document.createElement("button");
            dugmeDetalji.innerText = "Prikaži";
            dugmeDetalji.classList.add("btn", "btn-primary", "btn-sm");
            dugmeDetalji.onclick = () => this.prikaziDetalje(klijent);
            tdDetalji.appendChild(dugmeDetalji);

            const tdTelefoni = document.createElement("td");
            tdTelefoni.classList.add("text-center");
            tr.appendChild(tdTelefoni);

            const dugmeTelefoni = document.createElement("button");
            dugmeTelefoni.innerText = "Prikaži";
            dugmeTelefoni.classList.add("btn", "btn-primary", "btn-sm");
            dugmeTelefoni.onclick = () => this.prikaziTelefone(klijent);
            tdTelefoni.appendChild(dugmeTelefoni);

            const tdRacuni = document.createElement("td");
            tdRacuni.classList.add("text-center");
            tr.appendChild(tdRacuni);

            const dugmeRacuni = document.createElement("button");
            dugmeRacuni.innerText = "Prikaži";
            dugmeRacuni.classList.add("btn", "btn-primary", "btn-sm");
            tdRacuni.appendChild(dugmeRacuni);

            dugmeRacuni.onclick = async () => {
                const racun = new Racun(`http://localhost:5219/Racun/UzmiRacuneKlijenta/${klijent.id}`, this.container, () => {
                    this.clearBody();
                    this.showData();
                });

                await racun.loadData();
            };
        }
    }

    prikaziDetalje(klijent) {
        this.clearBody();

        const naslov = document.createElement("h2");
        naslov.innerText = "Detalji klijenta";
        naslov.classList.add("mb-4");
        this.container.appendChild(naslov);

        const nazad = document.createElement("button");
        nazad.innerText = "Nazad na klijente";
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

        this.dodajDetalj(tbody, "ID", klijent.id);
        this.dodajDetalj(tbody, "Tip klijenta", klijent.tipKlijenta);
        this.dodajDetalj(tbody, "Status", klijent.status);
        this.dodajDetalj(tbody, "Adresa", klijent.adresa);
        this.dodajDetalj(tbody, "Grad", klijent.grad);
        this.dodajDetalj(tbody, "Email", klijent.email);
        this.dodajDetalj(tbody, "Komentar", klijent.komentar);

        if (klijent.tipKlijenta === "FizickoLice") {
            this.dodajDetalj(tbody, "Ime", klijent.ime);
            this.dodajDetalj(tbody, "Prezime", klijent.prezime);
            this.dodajDetalj(tbody, "Broj lične karte", klijent.brojLicneKarte);
            this.dodajDetalj(tbody, "JMBG", klijent.jmbg);
            this.dodajDetalj(tbody, "Datum rođenja", this.formatirajDatum(klijent.datumRodjenja));
        }

        if (klijent.tipKlijenta === "PravnoLice") {
            this.dodajDetalj(tbody, "Naziv firme", klijent.nazivFirme);
            this.dodajDetalj(tbody, "PIB", klijent.pib);
        }
    }

    prikaziTelefone(klijent) {
        this.clearBody();

        const naslov = document.createElement("h2");
        naslov.innerText = "Telefoni klijenta";
        naslov.classList.add("mb-4");
        this.container.appendChild(naslov);

        const nazad = document.createElement("button");
        nazad.innerText = "Nazad na klijente";
        nazad.classList.add("btn", "btn-secondary", "mb-4");
        nazad.onclick = () => {
            this.clearBody();
            this.showData();
        };
        this.container.appendChild(nazad);

        if (!klijent.telefoni || klijent.telefoni.length === 0) {
            const poruka = document.createElement("p");
            poruka.innerText = "Klijent nema evidentirane telefone.";
            this.container.appendChild(poruka);
            return;
        }

        const table = document.createElement("table");
        table.classList.add("table", "table-hover", "table-striped", "mx-auto");
        table.style.maxWidth = "500px";
        this.container.appendChild(table);

        const thead = document.createElement("thead");
        thead.classList.add("bg-primary", "text-white");
        table.appendChild(thead);

        const headerRow = document.createElement("tr");
        thead.appendChild(headerRow);

        const th = document.createElement("th");
        th.innerText = "Broj telefona";
        th.classList.add("text-center");
        headerRow.appendChild(th);

        const tbody = document.createElement("tbody");
        table.appendChild(tbody);

        for (const telefon of klijent.telefoni) {
            const tr = document.createElement("tr");
            tbody.appendChild(tr);
            this.dodajCeliju(tr, telefon);
        }
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