import { useState } from "react";
import { FormElement } from "types/types";
import ClientStep from "./ClientStep";
import EquipentStep from "./EquipemntStep";
import InstructorStep from "./InstructorStep";
import PaymentStep from "./PaymentStep";

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
  },
];

const Reservation = () => {
  const [currentClient, setCurrentClient] = useState<number | undefined>();
  const [currentInstructorRes, setCurrentInstructorRes] = useState<
    number | undefined
  >();
  const [currentEquipemntrRes, setCurrentEquipemntrRes] = useState<
    number | undefined
  >();
  const [step, setStep] = useState(0);
  const [price, setPrice] = useState<number>(0);

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

  const setMainPrice = (p: number) => {
    setPrice(price + p);
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
            instructorPrice={setMainPrice}
          />
        );
      case 2:
        return (
          <EquipentStep
            clientId={currentClient}
            setEquipmentResId={setEquipmentRes}
            setStep={setNewStep}
            setEquipmentPrice={setMainPrice}
          />
        );
      case 3:
        return (
          <PaymentStep
            timetableId={currentInstructorRes}
            rentalId={currentEquipemntrRes}
            price={price}
            setStep={setStep}
          />
        );
    }
  };

  return <div>{steps()}</div>;
};

export default Reservation;
