import React from "react";
import ReactDOM from "react-dom/client";
import "./index.scss";
import App from "./App";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Navbar from "layouts/Navbar/Navbar";
import Reservation from "components/Reservation/Reservation";
import AddInstructor from "components/Instructor/AddInstructor";
import DisplayInstructor from "components/Instructor/DisplayInstructor";
import DeleteInstructor from "components/Instructor/DeleteInstructor";
import AddEquipment from "components/Equipment/AddEquipment";
import DisplayEquipment from "components/Equipment/DisplayEquipment";
import DeleteEquipment from "components/Equipment/DeleteEquipment";
import DeleteReservation from "components/Reservation/DeleteReservation";
import PayReservation from "components/Reservation/PayReservation";
import Raport from "components/Raport/Raport";

const root = ReactDOM.createRoot(
  document.getElementById("root") as HTMLElement
);
root.render(
  <>
    <BrowserRouter>
      <div className="container">
        <div className="navBar">
          <Navbar />
        </div>
        <div className="content">
          <Routes>
            <Route path="/" element={<App />} />
            <Route path="/instruktor/dodaj" element={<AddInstructor />} />
            <Route
              path="/instruktor/wyswietl"
              element={<DisplayInstructor />}
            />
            <Route path="/instruktor/usun" element={<DeleteInstructor />} />
            {/* <Route path="/instruktor/edytuj" element={<EditInstructor />} /> */}
            {/* <Route path="/instruktor/godziny-pracy" element={<WorkHours />} /> */}
            <Route path="/sprzet/dodaj" element={<AddEquipment />} />
            <Route path="/sprzet/wyswietl" element={<DisplayEquipment />} />
            <Route path="/sprzet/usun" element={<DeleteEquipment />} />
            {/* <Route path="/sprzet/edytuj" element={<EditEquipment />} /> */}
            <Route path="/rezerwacja/rezerwuj" element={<Reservation />} />
            <Route path="/rezerwacja/anuluj" element={<DeleteReservation />} />
            <Route path="/rezerwacja/oplac" element={<PayReservation />} />
            <Route path="/raport" element={<Raport />} />
            <Route
              path="*"
              element={
                <main className="my-20">
                  <p>404</p>
                </main>
              }
            />
          </Routes>
        </div>
      </div>
    </BrowserRouter>
  </>
);
