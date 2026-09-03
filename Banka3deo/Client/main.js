import { Klijent } from "./klijent.js";

const klijent = new Klijent("http://localhost:5219/Klijent/UzmiSveKlijente", document.body);
await klijent.loadData();