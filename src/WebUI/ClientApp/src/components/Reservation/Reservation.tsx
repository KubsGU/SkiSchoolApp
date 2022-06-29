import { EquipmentList } from "components/Equipment/DisplayEquipment";
import { InstructorsList } from "components/Instructor/DisplayInstructor";
import { Fragment, useEffect, useState } from "react";
import { Client, FormElement, SelectOptions } from "types/types";
import s from "./../../App.module.scss";
import ClientStep from "./ClientStep";
import EquipentStep from "./EquipemntStep";
import InstructorStep from "./InstructorStep";

//
// TO DO
// ogarnac dodawanie sprzetu wiecej niz jednego
//

export const instructorsOptions: SelectOptions[] = InstructorsList.map(
  (inst) => {
    return {
      id: inst.id,
      label: inst.name + " " + inst.surname + ", " + inst.price + "zł",
    };
  }
);

export const equipmentOptions: SelectOptions[] = EquipmentList.map((inst) => {
  return {
    id: inst.id,
    label: inst.name + " " + inst.type + ", " + inst.price + "zł",
  };
});

export const CLientnForm: FormElement[] = [
  { name: "Imie", type: "text", id: "name" },
  { name: "Nazwisko", type: "text", id: "surname" },
  { name: "Nr dowodu", type: "number", id: "idNo" },
  { name: "Pesel", type: "number", id: "pesel" },
  { name: "E-Mail", type: "email", id: "email" },
  { name: "Telefon", type: "tel", id: "phoneNumber" },
];

export const ReservationForm: FormElement[] = [
  { name: "Data startu", type: "datetime-local", id: "startDate" },
  { name: "Data końca", type: "datetime-local", id: "endtDate" },
  { name: "Oplacone", type: "checkbox", id: "paid" },
  {
    name: "Instruktor (opcjonalne)",
    type: "number",
    id: "idIns",
    selectOptions: instructorsOptions,
  },
];

const Reservation = () => {
  const [reservationForm, setReservationForm] = useState<FormElement[]>(
    ReservationForm
  );
  const [existingClient, setExistingClient] = useState<boolean>();
  const [currentClient, setCurrentClient] = useState<number | undefined>();
  const [currentInstructorRes, setCurrentInstructorRes] = useState<
    number | undefined
  >();
  const [currentEquipemntrRes, setCurrentEquipemntrRes] = useState<
    number | undefined
  >();
  const [equipmentsTypes, setEquipmentsTypes] = useState<string[]>();
  const [equipmentsType, setEquipmentsType] = useState<string>();
  const [step, setStep] = useState(0);

  const setClient = (clientId: number | undefined) => {
    setCurrentClient(clientId);
  };

  const setNewStep = (step: number) => {
    setStep(step);
  };

  const setInstructorRes = (res: number | undefined) => {
    setCurrentInstructorRes(res);
  };

  const setEquipmentRes = (res: number | undefined) => {
    setCurrentEquipemntrRes(res);
  };

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await fetch(
          `${process.env.REACT_APP_IP}/Equipments/types`
        );
        const res = await data.json();
        setEquipmentsTypes(res.items);
        setEquipmentsType(res.items[0]);
      } catch (e) {
        console.log(e);
      }
    };
    fetchData();
  }, []);

  const handleData = (e: any) => {
    e.preventDefault();
    const body = {};
    console.log(body);
  };

  const handleAddEqu = (e: any) => {
    e.preventDefault();

    setReservationForm(
      reservationForm.concat([
        {
          name: "Sprzet typu " + equipmentsType,
          type: "number",
          id: "idEqu" + reservationForm.length,
          selectOptions: equipmentOptions,
        },
      ])
    );
  };

  const steps = () => {
    switch (step) {
      case 0:
        return (
          <ClientStep
            setClientId={setClient}
            setStep={setNewStep}
            currentClient={currentClient}
          />
        );
      case 1:
        return (
          <InstructorStep
            clientId={currentClient}
            setInstructorResId={setInstructorRes}
            setStep={setNewStep}
          />
        );
      case 2:
        return (
          <EquipentStep
            clientId={currentClient}
            setEquipmentResId={setEquipmentRes}
            setStep={setNewStep}
          />
        );
    }
  };

  return (
    <div>
      {steps()}

      {/* <form className={s.form} id="form" onSubmit={handleData}>      
      <label>Nowy klient</label>
      <input type="checkbox" name="existingClient"  onChange={(e) => setExistingClient(e.target.checked)}/>
        {reservationForm &&
          reservationForm.map((el, i) => {
            return (
              <Fragment key={el.id}>
                <label htmlFor={el.name}>{el.name}</label>
                {el.selectOptions?.length ? (
                  <select id={el.id} name={el.name} multiple={el.multiselect}>
                    {el.selectOptions.map((op, i) => {
                      return (
                        <option key={op.id} value={op.id}>
                          {op.label}
                        </option>
                      );
                    })}
                  </select>
                ) : (
                  <input type={el.type} id={el.id} name={el.name}></input>
                )}
              </Fragment>
            );
          })}
        <label>Dodaj sprzęt danego typu</label>
        <div className={s.addContainer}>
          <select onChange={(e) => setEquipmentsType(e.target.value)}>
            {equipmentsTypes &&
              equipmentsTypes.map((e, i) => {
                return (
                  <option key={i} value={e}>
                    {e}
                  </option>
                );
              })}
          </select>
          <i
            className={
              (equipmentsType ? s.plus : s.plusDisable) + " material-icons"
            }
            onClick={handleAddEqu}
          >
            add
          </i>
        </div>
      </form>
      <div className={s.add}>
        <button type="submit" form="form">
          Dodaj
        </button>
      </div> */}
    </div>
  );
};

export default Reservation;
