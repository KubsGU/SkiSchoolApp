import { Navbar } from "../../types/types";

export const navbarElements: Navbar[] = [
  {
    name: "Instruktor",
    children: [
      {
        name: "Wyświetl",
        link: "instruktor/wyswietl",
      },
      {
        name: "Dodaj",
        link: "instruktor/dodaj",
      },
      {
        name: "Usuń",
        link: "instruktor/usun",
      },
      {
        name: "Edytuj",
        link: "instruktor/edytuj",
      },
      {
        name: "Godziny pracy",
        link: "instruktor/godziny-pracy",
      },
    ],
  },
  {
    name: "Sprzęt",
    children: [
      {
        name: "Wyświetl",
        link: "sprzet/wyswietl",
      },
      {
        name: "Dodaj",
        link: "sprzet/dodaj",
      },
      {
        name: "Usuń",
        link: "sprzet/usun",
      },
      {
        name: "Edytuj",
        link: "sprzet/edytuj",
      },
    ],
  },
  {
    name: "Rezerwacja",
    children: [
      {
        name: "Rezerwuj",
        link: "rezerwacja/rezerwuj",
      },
      {
        name: "Opłać",
        link: "rezerwacja/oplac",
      },
      {
        name: "Anuluj",
        link: "rezerwacja/anuluj",
      },
      {
        name: "Wyszukaj",
        link: "rezerwacja/wyszukaj",
      },
    ],
  },
  {
    name: "Raport",
    link: "raport",
  },
];
