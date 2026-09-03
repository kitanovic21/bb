import { Kredit } from "./kredit.js";
import { Depozit } from "./depozit.js";

export class Racun {
    constructor(url, container, onBack) {
        this.url = url;
        this.container = container;
        this.onBack = onBack;
        this.data = [];
    }

    async loadData() {
        const response = await fetch(this.url);

        if (!response.ok) {
            throw new Error("Greška pri učitavanju računa.");
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
        naslov.innerText = "Računi klijenta";
        naslov.classList.add("mb-4");
        this.container.appendChild(naslov);

        const nazad = document.createElement("button");
        nazad.innerText = "Nazad na klijente";
        nazad.classList.add("btn", "btn-secondary", "mb-4");
        nazad.onclick = this.onBack;
        this.container.appendChild(nazad);

        if (this.data.length === 0) {
            const poruka = document.createElement("p");
            poruka.innerText = "Klijent nema račune.";
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

        const kolone = ["Broj računa", "Tip računa", "Status", "Stanje", "Valuta", "Detalji", "Povezano"];

        for (const kolona of kolone) {
            const th = document.createElement("th");
            th.innerText = kolona;
            th.classList.add("text-center");
            headerRow.appendChild(th);
        }

        const tbody = document.createElement("tbody");
        table.appendChild(tbody);

        for (const racun of this.data) {
            const tr = document.createElement("tr");
            tbody.appendChild(tr);

            this.dodajCeliju(tr, racun.brojRacuna);
            this.dodajCeliju(tr, racun.tipRacuna);
            this.dodajCeliju(tr, racun.statusRacuna);
            this.dodajCeliju(tr, racun.trenutnoStanje);
            this.dodajCeliju(tr, racun.valuta);

            const tdDetalji = document.createElement("td");
            tdDetalji.classList.add("text-center");
            tr.appendChild(tdDetalji);

            const dugmeDetalji = document.createElement("button");
            dugmeDetalji.innerText = "Prikaži";
            dugmeDetalji.classList.add("btn", "btn-primary", "btn-sm");
            dugmeDetalji.onclick = () => this.prikaziDetalje(racun);
            tdDetalji.appendChild(dugmeDetalji);

            const tdPovezano = document.createElement("td");
            tdPovezano.classList.add("text-center");
            tr.appendChild(tdPovezano);

            const dugmePovezano = document.createElement("button");
            dugmePovezano.innerText = "Prikaži";
            dugmePovezano.classList.add("btn", "btn-primary", "btn-sm");
            dugmePovezano.onclick = () => this.prikaziPovezano(racun);
            tdPovezano.appendChild(dugmePovezano);
        }
    }

    prikaziDetalje(racun) {
        this.clearBody();

        const naslov = document.createElement("h2");
        naslov.innerText = "Detalji računa";
        naslov.classList.add("mb-4");
        this.container.appendChild(naslov);

        this.dodajNazadNaRacune();

        const table = document.createElement("table");
        table.classList.add("table", "table-bordered", "mx-auto");
        table.style.maxWidth = "700px";
        this.container.appendChild(table);

        const tbody = document.createElement("tbody");
        table.appendChild(tbody);

        this.dodajDetalj(tbody, "Broj računa", racun.brojRacuna);
        this.dodajDetalj(tbody, "Tip računa", racun.tipRacuna);
        this.dodajDetalj(tbody, "Status računa", racun.statusRacuna);
        this.dodajDetalj(tbody, "Dozvoljeni minus", racun.dozvoljeniMinus);
        this.dodajDetalj(tbody, "Trenutno stanje", racun.trenutnoStanje);
        this.dodajDetalj(tbody, "Valuta", racun.valuta);
        this.dodajDetalj(tbody, "Komentar", racun.komentar);
        this.dodajDetalj(tbody, "Datum otvaranja", this.formatirajDatum(racun.datumOtvaranja));
        this.dodajDetalj(tbody, "Kamatna stopa", racun.kamatnaStopa);
        this.dodajDetalj(tbody, "ID klijenta", racun.klijentID);
        this.dodajDetalj(tbody, "ID predmeta obračuna", racun.predmetObracunaID);

        if (racun.tipRacuna === "TekuciRacun") {
            this.dodajDetalj(tbody, "Mogućnost platnih kartica", racun.mogucnostPlatnihKartica);
            this.dodajDetalj(tbody, "Mesečni limit transakcija", racun.mesecniLimitTransakcija);
        }

        if (racun.tipRacuna === "StedniRacun") {
            this.dodajDetalj(tbody, "Minimalni iznos za otvaranje", racun.minimalniIznosZaOtvaranje);
            this.dodajDetalj(tbody, "Uslovi podizanja sredstava", racun.usloviPodizanjaSredstava);
            this.dodajDetalj(tbody, "Frekvencija", racun.frekvencija);
            this.dodajDetalj(tbody, "Bonusi za dugoročnu štednju", racun.bonusiZaDugorocnuStednju);
        }

        if (racun.tipRacuna === "DevizniRacun") {
            this.dodajDetalj(tbody, "Namena", racun.namena);
            this.dodajDetalj(tbody, "Ograničenja deviznih propisa", racun.ogranicenjaDeviznihPropisa);
            this.dodajDetalj(tbody, "Kursna razlika konverzije", racun.kursnaRazlikaKonverzije);
        }

        if (racun.tipRacuna === "ZiroRacun") {
            this.dodajDetalj(tbody, "Namena", racun.namena);
            this.dodajDetalj(tbody, "E-bankarstvo za firme", racun.eBankarstvoZaFirme);
            this.dodajDetalj(tbody, "Limit masovnih plaćanja", racun.limitMasovnihPlacanja);
            this.dodajDetalj(tbody, "Integracija", racun.integracija);
        }
    }

    prikaziPovezano(racun) {
        this.clearBody();

        const naslov = document.createElement("h2");
        naslov.innerText = `Podaci povezani sa računom ${racun.brojRacuna}`;
        naslov.classList.add("mb-4");
        this.container.appendChild(naslov);

        this.dodajNazadNaRacune();

        const table = document.createElement("table");
        table.classList.add("table", "table-bordered", "mx-auto");
        table.style.maxWidth = "700px";
        this.container.appendChild(table);

        const tbody = document.createElement("tbody");
        table.appendChild(tbody);

        this.dodajPovezanoDugme(tbody, "Dozvoljene valute", () => this.prikaziListu(racun.dozvoljeneValuteList, "Dozvoljene valute", "Valuta", racun));
        this.dodajPovezanoDugme(tbody, "Povezani paketi usluga", () => this.prikaziListu(racun.povezaniPaketiList, "Povezani paketi usluga", "Paket", racun));

        this.dodajPovezanoDugme(tbody, "Krediti", async () => {
            const kredit = new Kredit(`http://localhost:5219/Kredit/UzmiKrediteKlijenta/${racun.klijentID}`, this.container, racun.brojRacuna, () => {
                this.clearBody();
                this.prikaziPovezano(racun);
            });

            await kredit.loadData();
        });

        this.dodajPovezanoDugme(tbody, "Depoziti", async () => {
            const depozit = new Depozit(`http://localhost:5219/Depozit/UzmiDepoziteKlijenta/${racun.klijentID}`, this.container, racun.brojRacuna, () => {
                this.clearBody();
                this.prikaziPovezano(racun);
            });

            await depozit.loadData();
        });
    }

    prikaziListu(lista, naslovTekst, nazivKolone, racun) {
        this.clearBody();

        const naslov = document.createElement("h2");
        naslov.innerText = naslovTekst;
        naslov.classList.add("mb-4");
        this.container.appendChild(naslov);

        const nazad = document.createElement("button");
        nazad.innerText = "Nazad na povezane podatke";
        nazad.classList.add("btn", "btn-secondary", "mb-4");
        nazad.onclick = () => {
            this.clearBody();
            this.prikaziPovezano(racun);
        };
        this.container.appendChild(nazad);

        if (!lista || lista.length === 0) {
            const poruka = document.createElement("p");
            poruka.innerText = "Nema podataka.";
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
        th.innerText = nazivKolone;
        th.classList.add("text-center");
        headerRow.appendChild(th);

        const tbody = document.createElement("tbody");
        table.appendChild(tbody);

        for (const vrednost of lista) {
            const tr = document.createElement("tr");
            tbody.appendChild(tr);
            this.dodajCeliju(tr, vrednost);
        }
    }

    dodajPovezanoDugme(tbody, naziv, onclick) {
        const tr = document.createElement("tr");
        tbody.appendChild(tr);

        const th = document.createElement("th");
        th.innerText = naziv;
        th.classList.add("text-left");
        tr.appendChild(th);

        const td = document.createElement("td");
        td.classList.add("text-center");
        tr.appendChild(td);

        const dugme = document.createElement("button");
        dugme.innerText = "Prikaži";
        dugme.classList.add("btn", "btn-primary", "btn-sm");
        dugme.onclick = onclick;
        td.appendChild(dugme);
    }

    dodajNazadNaRacune() {
        const nazad = document.createElement("button");
        nazad.innerText = "Nazad na račune";
        nazad.classList.add("btn", "btn-secondary", "mb-4");
        nazad.onclick = () => {
            this.clearBody();
            this.showData();
        };
        this.container.appendChild(nazad);
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